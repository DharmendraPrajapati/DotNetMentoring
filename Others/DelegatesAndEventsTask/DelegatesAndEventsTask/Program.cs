using System;
using System.Runtime.Remoting.Channels;
using DelegatesAndEventsTask.Properties;

namespace DelegatesAndEventsTask
{
    internal class Program
    {

        private static readonly string Path = Resources.Path;
        private const string NameToDelete = "log";
        private static void Main()
        {

            FileSystemTraverse.DeletePerformed += (s, e) =>
            {
                Console.WriteLine(@"Delete Operation Started" + "\n");
            };
            FileSystemTraverse.DeleteCompleted += (s, e) =>
            {
                Console.WriteLine("\n" + @"Delete Operation Completed" + "\n");
            };

            var fileSystemTraverse = new FileSystemTraverse(FileSystemTraverse.DeleteFileFolder, new DeletePerformedEventArgs(Path, NameToDelete));

            Console.Read();
        }
        
    }
}

