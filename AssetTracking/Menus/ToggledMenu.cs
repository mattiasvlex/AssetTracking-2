using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Menus
{
    internal abstract class ToggledMenu
    {
        protected ProgramController Controller { get; set; }
        protected string Prompt { get; set; } = string.Empty;
        protected string[] Options { get; set; }
        protected int CurrentSelection { get; set; } = 0;
        protected int TopRowPos { get; set; } = 0;

        public ToggledMenu(ProgramController controller)
        { 
            Controller = controller;
        }

        public void Run()
        {
            Console.WriteLine(Prompt);
            DrawMenuOptions();
            bool run = true;
            while (run)
            {
                ConsoleKey keyPressed = Console.ReadKey().Key;
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        MoveCursorUp();
                        DrawMenuOptions();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveCursorDown();
                        DrawMenuOptions();
                        break;
                    case ConsoleKey.Enter:
                        SendRequest();
                        run = false;
                        break;
                }
            }
        }

        public abstract void SendRequest();

        protected void DrawMenuOptions()
        {
            for (int i = 0; i < Options.Length; i++)
            {
                Console.CursorTop = TopRowPos + i;
                Console.CursorLeft = 40;
                if (i == CurrentSelection)
                {
                    SetColors(ConsoleColor.Black, ConsoleColor.White);
                    Console.WriteLine("      " + Options[i] + "      ");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("      " + Options[i] + "      ");
                }
            }
        }

        protected void MoveCursorUp()
        {
            if (CurrentSelection <= 0)
            {
                CurrentSelection = Options.Length - 1;
            }
            else
            {
                CurrentSelection--;            
            }
        }

        protected void MoveCursorDown()
        {
            if (CurrentSelection >= Options.Length - 1)
            {
                CurrentSelection = 0;
            }
            else
            {
                CurrentSelection++;
            }
        }

        protected void SetColors(ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

    }
}
