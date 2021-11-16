using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TemTemArena.Scripts.Data;
using TemTemArena.Scripts.Singletons;

/*
 *  HOW TO USE
 *
 *  To use the GUI-Interface, instantiate a GUI using
 *  GUI.UseGUI();
 *  
 *  To draw to and get input from the GUI
 *  use the follow two methods:
 *  
 *  -- GUI.WriteLine(EntryType, string);
 *  where EntryType specifies where on the GUI the message will appear.
 *  the message can be passed in as either a string or if multiple lines are needed, a string array.
 *
 *  -- GUI.ReadLine();
 *
 *  If not GUI has been instantiated, these two methods will behave like
 *  Console.WriteLine(); and Console.ReadLine();
 *
 *  Further customization is done by adjusting properties in ScreenData.cs
 *
 */
namespace TemTemArena.Scripts.GUI
{
    public static class GUI
    {
        public static bool Initialized => GUIController.Instance.Initialized;
        public static IEnumerable<string> Buffer => GUIController.Instance.ScreenBuffer.Buffer;
        public static IEnumerable<string> Text => GUIController.Instance.ScreenBuffer.Text;

        public static void UseGUI()
        {
            if (GUIController.Instance.Initialized) return;
            GUIController.Instance.Initialized  = true;

            GUIController.Instance.EventLog     = new EventLog();
            GUIController.Instance.ScreenBuffer = new ScreenBuffer();
            GUIController.Instance.Renderer     = new GUIRenderer();
        }
        public static void PushAndDrawText()
        {
            GUIController.Instance.Renderer.PushAndDrawText();
        }
        public static void WriteLine(EntryType type, string message)
        {
            if (!GUI.Initialized)
            {
                WriteWithoutGUI(new string[] { message }, false);
                return;
            }

            GUIController.Instance.EventLog.AddEntry(type, message);
        }
        public static void WriteLine(EntryType type, string message, bool update)
        {
            if (!GUI.Initialized)
            {
                WriteWithoutGUI(new string[] { message }, false);
                return;
            }

            GUIController.Instance.EventLog.AddEntry(type, message);
            if (!update) return;
            Update();
            Draw();
        }
        public static void WriteLine(EntryType type, string[] messages, bool update)
        {
            if (!GUI.Initialized)
            {
                WriteWithoutGUI(messages, true);
                return;
            }

            GUIController.Instance.EventLog.AddEntry(type, messages);
            if (!update) return;
            Update();
            Draw();
        }
        public static void WriteLine(EntryType type, string[] messages)
        {
            if (!GUI.Initialized)
            {
                WriteWithoutGUI(messages, true);
                return;
            }

            GUIController.Instance.EventLog.AddEntry(type, messages);
            Refresh();
        }

        static void WriteWithoutGUI(string[] messages, bool usingStringArray)
        {
            if (usingStringArray)
            {
                foreach (var message in messages)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.Write(messages[0]);
            }
        }
        public static string ReadLine()
        {
            return !GUI.Initialized ? Console.ReadLine() : GUIController.Instance.EventLog.ReadLine();
        }
        public static void Refresh()
        {
            Update();
            Draw();
        }
        public static void Update()
        {
            GUIController.Instance.ScreenBuffer.ReloadBuffer();
        }
        public static void Draw()
        {
            GUIController.Instance.Renderer.DrawScreenBuffer();
        }

        public static void MergeBuffer()
        {
            GUIController.Instance.ScreenBuffer.PushBuffer();
        }

        public static void ReloadInputArea()
        {
            GUIController.Instance.ScreenBuffer.LoadInputField();
            Refresh();
        }

        public static string[] CreateMessage(string[] availableAbilities)
        {
            var message = new string[availableAbilities.Length + 2];
            message[0] = "Available attacks actions are:";
            for (var j = 0; j < availableAbilities.Length; j++)
                message[j + 1] = availableAbilities[j];
            message[^1] = "Choose ability 1, 2 or 3";
            return message;
        }

        public static void AddInputData(int x, int y, int length)
        {
            if (length <= 0) return;
            GUIController.Instance.ScreenBuffer.AddInputData(x, y, length);
        }

        public static void ClearTextBuffer()
        {
            GUIController.Instance.ScreenBuffer.ClearTextBuffer();
        }

        public static void PushText()
        {
            GUIController.Instance.ScreenBuffer.PushText();
        }
    }
}
