using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TemTemArena.Scripts.GUI
{
  
        public enum EntryType
        {
            Command,
            Combat,
            Header,
        }

        public class EventLog
        {
            private readonly List<List<string[]>> _lists;
            private readonly List<string[]> _commands;
            private readonly List<string[]> _combat;
            private readonly List<string[]> _header;

            public IEnumerable<string[]> Commands => _commands;
            public IEnumerable<string[]> Combat => _combat;
            public IEnumerable<string[]> Header => _header;

            public EventLog()
            {
                _lists = new List<List<string[]>>();

                _commands = new List<string[]>();
                _combat = new List<string[]>();
                _header = new List<string[]>();

                _lists.Add(_commands);
                _lists.Add(_combat);
                _lists.Add(_header);
            }

            void ClearAll()
            {
                foreach (var list in _lists) list.Clear();
            }

            public void AddEntry(EntryType type, string message)
            {
                var messages = new string[] {message};
                AddEntry(type, messages);
            }

            public void AddEntry(EntryType type, string[] messages)
            {
                switch (type)
                {
                    case EntryType.Command:
                        if (_commands.Count > 0) _commands[0] = messages;
                        else _commands.Add(messages);
                        break;
                    case EntryType.Combat:
                        _combat.Add(messages);
                        break;
                    case EntryType.Header:
                        _header.Add(messages);
                        break;
                    default: break;
                }
            }

            public string ReadLine(Vector2 position)
            {
                Console.SetCursorPosition((int) position.X, (int) position.Y);
                var input = Console.ReadLine();

                ClearInput(position, input);

                Console.SetCursorPosition((int) position.X, (int) position.Y);
                GUI.ReloadInputArea();
                return input;

                static void ClearInput(Vector2 position, string input)
                {
                    var length = input.Length;
                    if (length <= 0) return;

                    var x = (int) position.X;
                    var y = (int) position.Y;

                    for (var i = 0; i <= length; i++)
                    {
                        Console.SetCursorPosition(x + i, y);
                        Console.Write(' ');
                    }
                }
            }
        }
    }

