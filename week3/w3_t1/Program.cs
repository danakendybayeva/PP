using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3_t1
{
    enum ViewMode
    {
        //creating the set of constants so they can be easily accessed everywhere
        ShowDirContent,
        ShowFileContent
    }

    class Program
    {
        static void Main(string[] args)
        {
            //assigning the location of folder to show info about it
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Swist\Desktop\Aegisub");
            //creating stack where we will put the layers
            //everytime we open the folder it opens in new layer
            Stack<Layer> history = new Stack<Layer>();
            history.Push(//here we put the info of the folder to new layer
                new Layer
                {
                    Content = dir.GetFileSystemInfos()//assigning all info about the folder
                }
            );

            ViewMode viewMode = ViewMode.ShowDirContent;//when we start the program it shows the folder
            bool esc = false;//creating bool variable which stands for stoping the program
            while (!esc)//while it is false all next things are held
            {
                if (viewMode == ViewMode.ShowDirContent)
                {
                    //if the folder is opened 
                    //it is represented through function Draw
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();//variable for working with hotkeys
                switch (consoleKeyInfo.Key)
                    //creating a number of statements to go through, 
                    //for each hotkey there is a special case
                {
                    case ConsoleKey.F2://hotkey for renaming the file/folder
                        //clears the cmd
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string name = Console.ReadLine();//input of new name 
                        int x3 = history.Peek().SelectedItem;//assigning the index of last selected item to variable
                        FileSystemInfo fileSystemInfo3 = history.Peek().Content[x3];//assigning the element with index x3
                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo))
                        {
                            //renaming the folder with files
                            DirectoryInfo directoryInfo = fileSystemInfo3 as DirectoryInfo;//assigning the path of the folder
                            //moving folder from one location to new one
                            //as the folder can have some folders in it, we call the original location of the folder and then change the name
                            Directory.Move(fileSystemInfo3.FullName, Directory.GetParent(directoryInfo.FullName) + "/" + name);
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos();//opens the original folder where the folder was located
                        }
                        else
                        {
                            //renaming file
                            FileInfo fileInfo = fileSystemInfo3 as FileInfo;//assigning the path of the file
                            //moving file from one location to new one
                            File.Move(fileSystemInfo3.FullName, fileInfo.Directory.FullName + "/" + name);
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos();//opens the folder where the file was located
                        }

                        break;
                    case ConsoleKey.Delete:
                        int x2 = history.Peek().SelectedItem;//assigning the index of last selected item to variable
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];//assigning the element with index x3
                        history.Peek().SelectedItem--;//the index of selected item is decreased
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                        {
                            //deleting the folder
                            DirectoryInfo directoryInfo = fileSystemInfo2 as DirectoryInfo;//assigning the selected folder
                            Directory.Delete(fileSystemInfo2.FullName, true);//deleting the original path of the folder from computer
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos();//opens the original folder where the folder was located
                        }
                        else
                        {
                            //deleting the file
                            FileInfo fileInfo = fileSystemInfo2 as FileInfo;//assigning the selected file
                            File.Delete(fileSystemInfo2.FullName);//deleting the original path of the file
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos();//opens the folder where the file was located
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;//goes for one item higher
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;//goes for one item down
                        break;
                    case ConsoleKey.Enter://for opening file/folder
                        int x = history.Peek().SelectedItem;//assigning the index of last selected item to variable
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];//assigning the element with index x3

                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            //opens folder
                            viewMode = ViewMode.ShowDirContent;
                            DirectoryInfo selectedDir = fileSystemInfo as DirectoryInfo;//assigning the location of the selected folder
                            history.Push(new Layer { Content = selectedDir.GetFileSystemInfos() });
                            //creating new layer with the info about selected folder in it
                        }
                        else
                        {
                            //opens file
                            viewMode = ViewMode.ShowFileContent;
                            //FileStream allows to move data to and from the stream as arrays of bytes
                            //FileMode allows to operate the file, here we just open existed file
                            //FileAccess gives permission on read and write in file, here we give permission to read file
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                //StreamReader allows to take all or some part of data from the file
                                {
                                    Console.BackgroundColor = ConsoleColor.White;//background of cmd is white
                                    Console.Clear();//clears the previous layer
                                    Console.ForegroundColor = ConsoleColor.Black;//color of text is white
                                    Console.WriteLine(sr.ReadToEnd());//outputs everything from file
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace://go back hotkey
                        if (viewMode == ViewMode.ShowDirContent)
                        {
                            //if the folder was opened
                            history.Pop();//removes the last layer and opens the previous one
                        }
                        else
                        {
                            //if the file was opened
                            Console.BackgroundColor = ConsoleColor.Black;//cmd is in black color
                            Console.Clear();//clears cmd from last session
                            Console.ForegroundColor = ConsoleColor.White;//color of text is white
                            viewMode = ViewMode.ShowDirContent;
                        }
                        break;
                    case ConsoleKey.Escape:
                        esc = true;//stops the program
                        break;
                }
            }
        }
    }
}
