using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    public class FileHandling
    {
        public void CreateFile(string path)
        {
            Console.WriteLine("Enter the file name to Create");
            string fname = Console.ReadLine();
            string fpath = path + fname;
            File.Create(fpath);
            Console.WriteLine($"File Created with filename:{fname} and path:{fpath} \n Successfully");
            Console.WriteLine("You want to write the content into the file press y otherwise press any key");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                StreamWriter sw = File.AppendText(fpath);
                sw.WriteLine("Welcome to .net training");
                sw.Dispose();
                sw.Close();
            }
            else
            {
                Console.WriteLine("Successfully created the file");
            }

        }
        public void DeleteFile(string fname, string fpath)
        {
            if (File.Exists(fpath))
            {
                Console.WriteLine("Are you sure u wanna delete the file");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    File.Delete(fpath);
                    Console.WriteLine($"from {fpath} location {fname} is deleted permenantly !!!");
                }
                else
                {
                    Console.WriteLine("I think u pressed delete button accidently");
                }
            }
            else
            {
                Console.WriteLine($"{fname} in {fpath} is not exist");
            }

        }
        public void ReadFile(string fpath)
        {
            if (File.Exists(fpath))
            {
                string[] lines = File.ReadAllLines(fpath);
                Console.WriteLine("The content in the file is as follows:");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File doesn't Exist");
            }
       
        }
        public void AppenToFile(string fpath)
        {
            if(File.Exists(fpath))
            {
                StreamWriter sw = File.AppendText(fpath);
                sw.WriteLine("Welcome to .net training");
                sw.Dispose();
                sw.Close();
                Console.WriteLine("Successfully written the text into file");
            }
            else
            {
                Console.WriteLine("File is not Exists");
                Console.WriteLine("Do you wanna create a file press yes otherwise press any key to exit");
                string press=Console.ReadLine().ToLower();
                if( press == "y" )
                {
                    File.Create(fpath);
                    Console.WriteLine("Write content into the file");
                    string content = Console.ReadLine();
                    StreamWriter sw = File.AppendText(fpath);
                    sw.WriteLine(content);
                    sw.Dispose();
                    sw.Close();
                    Console.WriteLine("Successfully written the text into file");
                }
                else
                {
                    Console.WriteLine("End of AppendText Method");
                }
            }
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FileHandling fl = new FileHandling();
            Console.WriteLine("Enter the operation name which operation you want to perform ");
            string choice = Console.ReadLine().ToUpper();

            switch (choice)
            {
                case "CREATE":
                    fl.CreateFile("E:\\C#\\Exercises\\");
                    break;
                case "READ":
                    Console.WriteLine("Enter the file path to read the content");
                    string fname = Console.ReadLine();
                    fl.ReadFile(fname);
                    break;

                case "DELETE":
                    Console.WriteLine("Enter file name to delete");
                    string del = Console.ReadLine();
                    Console.WriteLine("Enter the file path to delete");
                    string fpath = Console.ReadLine();
                    fl.DeleteFile(del, fpath);
                    break;
                case "APPEND":
                    Console.WriteLine("Enter file path to insert content into the file");
                    string fpath1= Console.ReadLine();
                    fl.AppenToFile(fpath1);
                    break;
                default:
                    Console.WriteLine("You are selected invalid operation");
                    break;
            }


        }
    }
}

