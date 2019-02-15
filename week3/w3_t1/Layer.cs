using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3_t1
{
    class Layer
    {
        public FileSystemInfo[] Content
        {
            //used for storing the info of the folders
            get;
            set;
        }

        private int selectedItem;
        public int SelectedItem
        {
            get
            {
                //returns the index of the selcted item
                return selectedItem;
            }
            set
            {
                //this used when you scroll through items
                if (value >= Content.Length)
                {
                    //if the index is more than the amount of total number of items
                    //it makes the very first item selected
                    selectedItem = 0;
                }
                else if (value < 0)
                {
                    //if the index is less than the amount of total number of items
                    //it makes the last item selected
                    selectedItem = Content.Length - 1;
                }
                else
                {
                    //in other cases the selected item is not changed
                    selectedItem = value;
                }
            }
        }



        public void Draw()
        {
            //function that stands for outputing files and folders
            Console.BackgroundColor = ConsoleColor.Black;//makes the background of cmd black
            Console.Clear();//erase everthing from cmd

            for (int i = 0; i < Content.Length; i++)
            {
                if (i == SelectedItem)
                {
                    //highlights the selected item in blue
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    //other items are highlighted in black
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (Content[i].GetType() == typeof(DirectoryInfo))
                {
                    //if the item is folder then the name of it is in white
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    //files are written in DarkCyan
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                //outputing the name of the item and its index
                Console.WriteLine(i + 1 + ". " + Content[i].Name);
            }
        }
    }
}

