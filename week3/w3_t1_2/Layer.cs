using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager3
{
    class Layer
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }

        private int selectedItem;
        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value >= Content.Length)
                {
                    selectedItem = 0;
                }
                else if (value < 0)
                {
                    selectedItem = Content.Length - 1;
                }
                else
                {
                    selectedItem = value;
                }
            }
        }

        

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (Content[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                Console.WriteLine(i + 1 + ". " + Content[i].Name);
            }
        }
    }
}

