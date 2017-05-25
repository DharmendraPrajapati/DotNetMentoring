using System;
using System.IO;

namespace DelegateAndEvents
{
    public class Program
    {
        internal static void Main(string[] args)
        {
            // This is location where to search in file System
            const string fileSystemLocation = "D:\\TestProject";

            // This is the key which use to interupt the search if file/ Directory name contain it.
            const string interupKey = "Copy";

            // This variable hold the name of exclude file name
            const string excludeFileName = "Copy (3)";
            SearchInFileSystem(fileSystemLocation, interupKey, excludeFileName);
            DeleteInFileSystemDelegate(fileSystemLocation);
            DeleteInFileSystem(fileSystemLocation);
        }

        private static void SearchInFileSystem(string fileSystemLocation, string interupKey, string excludeFileName)
        {
            Console.WriteLine("This Execution with delegate");
            var obj = new FileSystemVisitor(fileSystemLocation, interupKey, excludeFileName);
            obj.PrintFileForldersByName("Delegate");
        }

        private static void DeleteInFileSystemDelegate(string fileSystemLocation)
        {
            Console.WriteLine("This Execution with delegate");
            new FileSystemVisitor(DeleteFunction, fileSystemLocation);
        }

        private static bool DeleteFunction(string filePath)
        {
            File.Delete(filePath);
            return true;
        }

        private static void DeleteInFileSystem(string fileSystemLocation)
        {
            Console.Write("This Execution with Expression");
            new FileSystemVisitor(s =>
            {
                File.Delete(s);
            },
            fileSystemLocation);
        }
    }
}
