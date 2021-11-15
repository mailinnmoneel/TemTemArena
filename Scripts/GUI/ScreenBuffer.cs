using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Singletons;
using static TemTemArena.Scripts.Data.ScreenData;

namespace TemTemArena.Scripts.GUI
{
        class ScreenBuffer
        {
            private readonly string[] _screenBuffer;
            private readonly string[] _previousDrawcall;
            private string[] _consoleBuffer; //--The actual data drawn to screen
            public IEnumerable<string> Buffer => _consoleBuffer;

            public ScreenBuffer()
            {
                _screenBuffer = new string[ScreenWidth * ScreenHeight];
                _previousDrawcall = new string[ScreenWidth * ScreenHeight];
                _consoleBuffer = new string[ScreenWidth * ScreenHeight];
            }

            public void PushBuffer()
            {
                _consoleBuffer = new string[ScreenWidth * ScreenHeight];
                var length = _screenBuffer.Length;

                for (var i = 0; i < length; i++)
                {
                    var current = _screenBuffer[i];
                    var previous = _previousDrawcall[i];

                    if (current == previous) continue;

                    _consoleBuffer[i] = current;
                    _previousDrawcall[i] = current;
                }
            }

            public void ReloadBuffer()
            {
                LoadCombatBackground();
                LoadCommandBackground();
                LoadInputField();
                LoadCommands();
                LoadCombat();
                LoadHeader();
                LoadEmptyCells();
            }

            public void LoadInputField()
            {
                var left = (int) InputAreaStart.X;
                var right = (int) InputAreaEnd.X;
                var top = (int) InputAreaStart.Y;
                var bottom = (int) InputAreaEnd.Y;

                LoadArea(left, right, top, bottom, InputBackground, InputBorder);
            }

            //-- Load Background Colors to Buffer
            private void LoadCombatBackground()
            {
                var left = (int) GameAreaStart.X;
                var right = (int) GameAreaEnd.X;
                var top = (int) GameAreaStart.Y;
                var bottom = (int) GameAreaEnd.Y;

                LoadArea(left, right, top, bottom, GameAreaBackground, GameAreaBorder);
            }

            private void LoadCommandBackground()
            {
                var left = (int) InfoAreaStart.X;
                var right = (int) InfoAreaEnd.X;
                var top = (int) InfoAreaStart.Y;
                var bottom = (int) InfoAreaEnd.Y;

                LoadArea(left, right, top, bottom, InfoBackground, InfoBorder);
            }

            [Obsolete("Replaced by mew LoadArea Method")]
            private void LoadAreaOLD(int left, int right, int top, int bottom, Color background, Color border)
            {
                for (var y = top; y < bottom; y++)
                for (var x = left; x < right; x++)
                {
                    if (x == left || x == left + 1 || x == right - 2 || x == right - 1 || y == top || y == bottom - 1)
                        UpdateBufferCell(border, x, y, true);
                    else UpdateBufferCell(background, x, y, false);
                }

                void UpdateBufferCell(Color cellColor, int x, int y, bool border)
                {
                    var symbol = border ? HeartSymbol : ' ';
                    var color = Colors.GetColor(cellColor);
                    _screenBuffer[y * (ScreenWidth + 1) + x] = "\x1b[48;5;" + color + $"m{symbol}";
                }
            }

            private void LoadArea(int left, int right, int top, int bottom, Color background, Color border)
            {
                for (var y = top; y < bottom; y++)
                for (var x = left; x < right; x++)
                {
                    if (x == left && y == top) UpdateBufferCell(border, x, y, Border.TopLeft);
                    else if (x == right - 1 && y == top) UpdateBufferCell(border, x, y, Border.TopRight);
                    else if (x == left && y == bottom - 1) UpdateBufferCell(border, x, y, Border.BottomLeft);
                    else if (x == right - 1 && y == bottom - 1) UpdateBufferCell(border, x, y, Border.BottomRight);
                    else if ((x == left || x == right - 1) && (y != top && y != bottom - 1))
                        UpdateBufferCell(border, x, y, Border.Vertical);
                    else if ((x != left && x != right - 1) && (y == top || y == bottom - 1))
                        UpdateBufferCell(border, x, y, Border.Horizontal);
                    else UpdateBufferCell(background, x, y, Border.None);
                }

                void UpdateBufferCell(Color cellColor, int x, int y, Border type)
                {
                    var symbol = BorderTypes[type];
                    var color = Colors.GetColor(cellColor);
                    _screenBuffer[y * (ScreenWidth + 1) + x] = "\x1b[48;5;" + color + $"m{symbol}";
                }
            }

            //-- Load Text to Buffer
            private void LoadCombat()
            {
                var commands = Game.Manager.EventLog.Combat;

                var left = (int) GameAreaStart.X + (int) BorderWidth.X + (int) TextPadding.X;
                var right = (int) GameAreaEnd.X - (int) BorderWidth.X - (int) TextPadding.X;
                var top = (int) GameAreaStart.Y + (int) BorderWidth.Y + (int) TextPadding.Y;
                var bottom = (int) GameAreaEnd.Y - (int) BorderWidth.Y - (int) TextPadding.Y;

                LoadText(left, right, top, bottom, commands);
            }

            private void LoadCommands()
            {
                var commands = Game.Manager.EventLog.Commands;

                var left = (int) InfoAreaStart.X + (int) BorderWidth.X + (int) TextPadding.X;
                var right = (int) InfoAreaEnd.X - (int) BorderWidth.X - (int) TextPadding.X;
                var top = (int) InfoAreaStart.Y + (int) BorderWidth.Y + (int) TextPadding.Y;
                var bottom = (int) InfoAreaEnd.Y - (int) BorderWidth.Y - (int) TextPadding.Y;

                LoadText(left, right, top, bottom, commands);
            }

            void LoadText(int left, int right, int top, int bottom, IEnumerable<string[]> commands)
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
                            _screenBuffer[yBuffer * (ScreenWidth + 1) + xBuffer] =
                                "\x1b[48;5;" + color + $"m{message[i]}";

                            x = xBuffer >= right ? 0 : x + 1;
                            y = xBuffer >= right ? y + 1 : y;
                        }

                        x = 0;
                        y++;
                    }
                }
            }

            void LoadText(int left, int right, int top, int bottom, IEnumerable<string[]> commands, bool useColor,
                Align alignment)
            {
                var len = commands.Select(message => message.Length).Prepend(0).Max();
                if (alignment == Align.Center)
                {
                    left += 16; //--Using magic numbers. Terrible things may happen
                    //--Below code should work? Why does it break everything badly?
                    /*
                    left = ScreenWidth / 2;
                    left -= len / 2;
                    */
                }

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

                            var col = useColor
                                ? Colors.GetColor(DefaultTextBackgroundColor)
                                : Colors.GetColor(DefaultBackgroundColor);
                            _screenBuffer[yBuffer * (ScreenWidth + 1) + xBuffer] =
                                "\x1b[48;5;" + col + $"m{message[i]}";

                            x = xBuffer >= right ? 0 : x + 1;
                            y = xBuffer >= right ? y + 1 : y;
                        }

                        x = 0;
                        y++;
                    }
                }
            }

            //--Not implemented yet
            private void LoadHeader()
            {
                var commands = Game.Manager.EventLog.Header;
                var left = (int) HeaderStart.X;
                var right = (int) HeaderEnd.X;
                var top = (int) HeaderStart.Y;
                var bottom = (int) HeaderEnd.Y;

                LoadText(left, right, top, bottom, commands, false, Align.Center);
            }

            //-- Fill empty cells in Buffer
            private void LoadEmptyCells()
            {
                for (var y = 0; y < ScreenHeight; y++)
                for (var x = 0; x < ScreenWidth; x++)
                {
                    if (_screenBuffer[y * ScreenWidth + x] != null) continue;

                    var color = Colors.GetColor(DefaultBackgroundColor);
                    _screenBuffer[y * ScreenWidth + x] = "\x1b[48;5;" + color + "m ";
                }
            }
        }
    }

