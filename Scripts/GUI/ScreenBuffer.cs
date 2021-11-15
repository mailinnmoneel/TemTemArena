using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Singletons;
using static TemTemArena.Scripts.Data.ScreenData;

namespace TemTemArena.Scripts.GUI
{
    class ScreenBuffer
    {
        private readonly string[] _screenBuffer;
        private readonly string[] _previousDrawcall;
        private string[] _inputData;
        private string[] _garbage;
        private string[] _consoleBuffer; //--The actual data drawn to screen
        private string[] _textBuffer;
        private string[] _previousTextBuffer;
        private string[] _consoleText;
        public IEnumerable<string> Buffer => _consoleBuffer;
        public IEnumerable<string> Text => _textBuffer;

        private readonly int BufferSize;
        public ScreenBuffer()
        {
            BufferSize = ScreenWidth * ScreenHeight;
            _consoleText        = new string[BufferSize];
            _previousTextBuffer = new string[BufferSize];
            _garbage            = new string[BufferSize];
            _textBuffer         = new string[BufferSize];
            _inputData          = new string[BufferSize];
            _screenBuffer       = new string[BufferSize];
            _previousDrawcall   = new string[BufferSize];
            _consoleBuffer      = new string[BufferSize];
        }

        public void ClearTextBuffer()
        {
            _textBuffer = new string[BufferSize];
        }

        private void RemoveBufferData()
        {
            for (var i = 0; i < _screenBuffer.Length; i++)
            {
                var deletion = _inputData[i];

                if (deletion == null) continue;
                _garbage[i] = deletion;
            }
            _inputData = new string[BufferSize];
        }
        public void AddInputData(int xGlobal, int yGlobal, int length)
        {
            var left = xGlobal;
            var top = yGlobal;

            int x = 0, y = 0;
            for (var i = 0; i <= length; i++)
            {
                var xBuffer = left + x;
                var yBuffer = top + y;

                _inputData[yBuffer * ScreenWidth + xBuffer] = ScreenData.CellOccupiedSymbol;

                x = xBuffer >= ScreenWidth ? 0 : x + 1;
                y = xBuffer >= ScreenWidth ? y + 1 : y;
            }
        }

        public void PushBuffer()
        {
            _consoleBuffer = new string[BufferSize];

            PushElements();
            void PushElements()
            {
                var length = _screenBuffer.Length;

                for (var i = 0; i < length; i++)
                {
                    var current = _screenBuffer[i];
                    var previous = _previousDrawcall[i];
                    var garbage = _garbage[i] != null;

                    if ((current == previous) && garbage) continue;

                    _consoleBuffer[i] = current;
                    _previousDrawcall[i] = current;
                    _garbage = new string[BufferSize];
                }
            }
        }

        public void PushText()
        {
            LoadHeaderText();
        }
        public void ReloadBuffer()
        {
            //--Garbage Collection
            RemoveBufferData();
            //--Draw Elements
            LoadCombatBackground();
            LoadCommandBackground();
            LoadCombatLogBackground();
            //--Draw Text
            LoadInputField();
            LoadInventory();
            LoadCommands();
            LoadCombat();
            //--Draw Header
            LoadHeaderArea();
            //--Fill Empty Cells
            LoadEmptyCells();
        }

        private void LoadCombatLogBackground()
        {
            LoadCLog(true);
            LoadCLog(false);

            void LoadCLog(bool leftRight)
            {
                var left   = leftRight ? (int)CLogLeftStart.X : (int)CLogRightStart.X;
                var right  = leftRight ? (int)CLogLeftEnd.X   : (int)CLogRightEnd.X;
                var top    = leftRight ? (int)CLogLeftStart.Y : (int)CLogRightStart.Y;
                var bottom = leftRight ? (int)CLogLeftEnd.Y   : (int)CLogRightEnd.Y;

                var backgroundColor = leftRight ? CombatLogLeft       : CombatLogRight;
                var borderColor = leftRight     ? GameAreaBorder      : GameAreaBorder;

                LoadArea(left, right, top, bottom, backgroundColor, borderColor);
            }
        }
        public void LoadInventory()
        {
            var left   = (int)InventoryStart.X;
            var right  = (int)InventoryEnd.X;
            var top    = (int)InventoryStart.Y;
            var bottom = (int)InventoryEnd.Y;

            LoadArea(left, right, top, bottom, InventoryBackground, InventoryBorder);
        }
        public void LoadInputField()
        {
            var left   = (int)InputAreaStart.X;
            var right  = (int)InputAreaEnd.X;
            var top    = (int)InputAreaStart.Y;
            var bottom = (int)InputAreaEnd.Y;

            LoadArea(left, right, top, bottom, InputBackground, InputBorder);
        }

        //-- Load Background Colors to Buffer
        private void LoadCombatBackground()
        {
            var left   = (int)GameAreaStart.X;
            var right  = (int)GameAreaEnd.X;
            var top    = (int)GameAreaStart.Y;
            var bottom = (int)GameAreaEnd.Y;

            LoadCombatArea(left, right, top, bottom, GameAreaBackground, GameAreaBorder);
        }

        private void LoadCommandBackground()
        {
            var left   = (int)InfoAreaStart.X;
            var right  = (int)InfoAreaEnd.X;
            var top    = (int)InfoAreaStart.Y;
            var bottom = (int)InfoAreaEnd.Y;

            LoadArea(left, right, top, bottom, InfoBackground, InfoBorder);
        }
        
        private void LoadArea(int left, int right, int top, int bottom, Color background, Color border)
        {
            for (var y = top; y < bottom; y++)
            for (var x = left; x < right; x++)
            {
                if      ( x == left     && y == top)                                        UpdateBufferCell(border,     x, y, Border.TopLeft);
                else if ( x == right -1 && y == top)                                        UpdateBufferCell(border,     x, y, Border.TopRight);
                else if ( x == left     && y == bottom -1)                                  UpdateBufferCell(border,     x, y, Border.BottomLeft);
                else if ( x == right -1 && y == bottom -1)                                  UpdateBufferCell(border,     x, y, Border.BottomRight);
                else if ((x == left     || x == right  -1) && (y != top && y != bottom -1)) UpdateBufferCell(border,     x, y, Border.Vertical);
                else if ((x != left     && x != right  -1) && (y == top || y == bottom -1)) UpdateBufferCell(border,     x, y, Border.Horizontal);
                else                                                                        UpdateBufferCell(background, x, y, Border.None);
            }

            void UpdateBufferCell(Color cellColor, int x, int y, Border type)
            {
                var symbol = BorderTypes[type];
                var color = Colors.GetColor(cellColor);
                _screenBuffer[y * ScreenWidth + x] = "\x1b[48;5;" + color + $"m{symbol}";
            }
        }
        private void LoadCombatArea(int left, int right, int top, int bottom, Color background, Color border)
        {
            for (var y = top; y < bottom; y++)
            for (var x = left; x < right; x++)
            {
                if (x == left && y == top) UpdateBufferCell(border, x, y, Border.TopLeft);
                else if (x == right - 1 && y == top) UpdateBufferCell(border, x, y, Border.TopRight);
                else if (x == left && y == bottom - 1) UpdateBufferCell(border, x, y, Border.BottomLeft);
                else if (x == right - 1 && y == bottom - 1) UpdateBufferCell(border, x, y, Border.BottomRight);
                else if ((x == left || x == right - 1) && (y != top && y != bottom - 1)) UpdateBufferCell(border, x, y, Border.Vertical);
                else if ((x != left && x != right - 1) && (y == top || y == bottom - 1)) UpdateBufferCell(border, x, y, Border.Horizontal);
                else UpdateBufferCell(background, x, y, Border.Dithering2);
            }

            void UpdateBufferCell(Color cellColor, int x, int y, Border type)
            {
                var symbol = BorderTypes[type];
                var color = Colors.GetColor(cellColor);
                _screenBuffer[y * ScreenWidth + x] = "\x1b[48;5;" + color + $"m{symbol}";
            }
        }

        //-- Load Text to Buffer
        private void LoadCombat()
        {
            var commands = Game.Manager.EventLog.Combat;

            var left   = (int)GameAreaStart.X + (int)BorderWidth.X + (int)TextPadding.X;
            var right  = (int)GameAreaEnd.X   - (int)BorderWidth.X - (int)TextPadding.X;
            var top    = (int)GameAreaStart.Y + (int)BorderWidth.Y + (int)TextPadding.Y;
            var bottom = (int)GameAreaEnd.Y   - (int)BorderWidth.Y - (int)TextPadding.Y;

            LoadArea(left, right, top, bottom, commands);
        }

        private void LoadCommands()
        {
            var commands = Game.Manager.EventLog.Commands;

            var left   = (int)InfoAreaStart.X  + (int) BorderWidth.X + (int)TextPadding.X;
            var right  = (int)InfoAreaEnd.X    - (int)BorderWidth.X  - (int)TextPadding.X;
            var top    = (int)InfoAreaStart.Y  + (int)BorderWidth.Y  + (int)TextPadding.Y;
            var bottom = (int)InfoAreaEnd.Y    - (int)BorderWidth.Y  - (int)TextPadding.Y;

            LoadArea(left, right, top, bottom, commands);
        }

        void LoadArea(int left, int right, int top, int bottom, IEnumerable<string[]> commands)
        {
            int x = 0, y = 0;

            foreach (var messages in commands)
            {
                foreach (var message in messages)
                {
                    var length = message.Length;

                    for (var i = 0; i < length; i++)
                    {
                        if (y >= bottom) break;

                        var xBuffer = left + x;
                        var yBuffer = top + y;

                        var color = Colors.GetColor(DefaultTextBackgroundColor);
                        _screenBuffer[yBuffer * ScreenWidth + xBuffer] = "\x1b[48;5;" + color + $"m{message[i]}";

                        x = xBuffer >= right ? 0 : x + 1;
                        y = xBuffer >= right ? y + 1 : y;
                    }

                    x = 0;
                    y++;
                }
            }
        }
        //--Header

        public void LoadHeaderText()
        {
            var commands = Game.Manager.EventLog.Header;
            LoadHeaderText(commands, Align.Center);
        }
        private void LoadHeaderArea()
        {
            var left   = (int) HeaderStart.X;
            var right  = (int) HeaderEnd.X;
            var top    = (int) HeaderStart.Y;
            var bottom = (int) HeaderEnd.Y;

            LoadArea(left, right, top, bottom, HeaderBackground, HeaderBorder);
        }
        public void LoadHeaderText(IEnumerable<string[]> messageList, Align alignment)
        {
            var length = 0;
            foreach (var messages in messageList)
            {
                foreach(var message in messages)
                    if (message.Length > length)
                        length = message.Length;
            }

            var anchor = 0;
            if (alignment == Align.Center)
            {
                anchor = ScreenWidth / 2;
                anchor -= length / 2;
            }
             
            int x = 0, y = 0;
            foreach (var messages in messageList)
            {
                foreach (var message in messages)
                {
                    var numberOfChars = message.Length;

                    for (var i = 0; i < numberOfChars; i++)
                    {
                        if (y >= ScreenHeight) break;

                        var xBuffer = anchor + x;
                        var yBuffer = (int) TextPadding.Y + y;

                        var col = Colors.GetColor(HeaderBackground);
                        _textBuffer[yBuffer * ScreenWidth + xBuffer] = "\x1b[48;5;" + col + $"m{message[i]}";

                        x = xBuffer >= ScreenWidth ? 0 : x + 1;
                        y = xBuffer >= ScreenWidth ? y + 1 : y;
                    }

                    x = 0;
                    y++;
                }
            }
        }

        //-- Fill empty cells in Buffer
        private void LoadEmptyCells()
        {
            for (var y = 0; y < ScreenHeight; y++)
            for (var x = 0; x < ScreenWidth; x++)
            {
                if (_screenBuffer[y * ScreenWidth + x] != null) continue;

                var color = Colors.GetColor(DefaultBackgroundColor);
                _screenBuffer[y * ScreenWidth + x] = "\x1b[48;5;" + color + $"m{Dithering3}";
            }
        }
    }
}
