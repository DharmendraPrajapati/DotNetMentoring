using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DelegatesAndEventsTask
{
    public delegate void DeletePerformedHandler(object sender, DeletePerformedEventArgs eventArgs);

    public class FileSystemTraverse
    {
        public FileSystemTraverse(Action<object,DeletePerformedEventArgs> toDelete, DeletePerformedEventArgs eventArgs)
        {
            toDelete(this, eventArgs);
        }

        public static event DeletePerformedHandler DeletePerformed;

        public static event EventHandler DeleteCompleted;

        public static void DeleteFileFolder(object sender, DeletePerformedEventArgs eventArgs)
        {
            OnDeletePerformed(null,eventArgs);
            
            var directories = Directory.GetDirectories(eventArgs.Path);
            foreach(var path in directories)
            {
                if(eventArgs.FileNameToDelete != string.Empty)
                {
                    var files = Directory.GetFiles(path).TakeWhile(_ => _.Contains(eventArgs.FileNameToDelete));
                    foreach (var file in files)
                    {
                        File.Delete(file);
                    }
                }
                
                Console.WriteLine(path);
                WriteInfo(path);
            }
            OnDeleteCompleted();
        }

        protected static void OnDeletePerformed(object sender,DeletePerformedEventArgs eventArgs)
        {
            var del = DeletePerformed;
            del?.Invoke(null, eventArgs);
        }

        protected static void OnDeleteCompleted()
        {
            var del = DeleteCompleted;
            del?.Invoke(null, EventArgs.Empty);
        }

        public static void WriteInfo(string filePath)
        {
            foreach(var path in GetDirectories(filePath))
            {
                Console.WriteLine(path);
                if(path != null)
                {
                    WriteInfo(path);
                }
            }
        }

        private static IEnumerable<string> GetDirectories(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var dirInfo = directoryInfo.GetDirectories();
            foreach(var info in dirInfo)
            {
                yield return info.FullName;
            }
        }
    }
}