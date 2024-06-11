using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Menus
{
    internal abstract class ToggledMenu(ProgramController controller)
    {
        protected ProgramController Controller { get; set; } = controller;
        protected string Prompt { get; set; } = string.Empty;
        protected string[] Options { get; set; } = [];
        protected int CurrentSelection { get; set; } = 0;
        protected int TopRowPos { get; set; } = 0;
        protected int LeftColumnPos { get; set; } = 0;
        protected int MenuWidth { get; set; } = 0;

        protected void SetMenuWidth()
        {
            //Calculate longest string in options to make the menu symmetric
            int index = 0;
            for (int i = 0; i < Options.Length; i++)
            {
                if (Options[index].Length < Options[i].Length)
                {
                    index = i;
                }
            }
            MenuWidth = Options[index].Length;
        }

        public virtual void Run()
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
                        NavigateOptions();
                        run = false;
                        break;
                }
            }
        }

        protected abstract void NavigateOptions();

        protected void DrawMenuOptions()
        {
            for (int i = 0; i < Options.Length; i++)
            {
                Console.CursorTop = TopRowPos + i;
                Console.CursorLeft = LeftColumnPos;
                if (i == CurrentSelection)
                {
                    SetColors(ConsoleColor.Black, ConsoleColor.White);
                    Console.WriteLine("      " + Options[i] + " ".PadRight(6 + MenuWidth - Options[i].Length));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("      " + Options[i] + " ".PadRight(6 + MenuWidth - Options[i].Length));
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
