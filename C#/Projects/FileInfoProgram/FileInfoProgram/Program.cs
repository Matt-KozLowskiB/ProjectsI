﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileInfoProgram
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Source Folder/Directory: ");
            string sourcepath = @Console.ReadLine();
            Console.WriteLine("Enter Destination Folder/Directory: ");
            string destinypath = @Console.ReadLine();
            ProcessFolder(sourcepath, destinypath);
        }
        public static void ProcessFolder(string sourcepath, string destinypath)
        {
            foreach (string file in Directory.GetFiles(sourcepath))
            {
                
                FileInfo fi = new FileInfo(file);
                StreamWriter sw = File.AppendText("Moron.txt");
                sw.WriteLine("{0}, {1}", fi.Name, fi.FullName);
                sw.Close();
                if (DateTime.Now.AddHours(-24) <= fi.LastWriteTime)
                {
                    MoveModedFiles(fi, destinypath);
                }
            }
        }
        public static void MoveModedFiles(FileInfo fi, string destinypath)
        {
            StreamWriter sw = File.AppendText("Moron.txt");
            File.Move(fi.FullName, (Path.Combine(destinypath, fi.Name)));
            Console.WriteLine("The file {0} has been copied to {1}", fi.Name, destinypath );
            sw.WriteLine("The file {0} has been copied to {1}", fi.Name, destinypath);
            sw.Close();
            Console.ReadKey();
        }
    }
}
   
                
              
                