using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.IO.Directory;

namespace DelegateAndEvents
{
    internal class FileSystemVisitor
    {
        private readonly string _location;
        private readonly FileSystemEventsHandler _eventHandler;
        private delegate void FileSystemDelegate(string searchKey, ref List<string> result);
        private readonly string _interupText;
        private readonly string _excludeFileKey;
        internal FileSystemVisitor(string location, string interuptKey, string excludeFileKey)
        {
            _location = location;
            _eventHandler = new FileSystemEventsHandler();
            _interupText = interuptKey;
            _excludeFileKey = excludeFileKey;
        }
        internal FileSystemVisitor(Action<string> action, string location)
        {
            var result = GetDirectories(location).ToList();
            result.ForEach(action.Invoke);
        }
        internal FileSystemVisitor(Func<string, bool> exp, string location)
        {
            var result = GetDirectories(location).ToList();
            result.ForEach(a => exp(a));
        }
        internal void PrintFileForldersByName(string searchKey)
        {
            SearchEventHandler("Started");
            var result = new List<string>();
            FileSystemDelegate folderDelegate = PrintFolder;
            FileSystemDelegate fileDelegate = PrintFile;
            var fileSysDel = folderDelegate + fileDelegate;
            fileSysDel(searchKey, ref result);
            PrintFoundResult(result);
            SearchEventHandler("Ended");
        }

        private void SearchEventHandler(string msg)
        {
            _eventHandler?.SearchBroadcastMessage(msg);
        }

        private void FindFileOrFolderEventHandler(string type)
        {
            _eventHandler?.OnBroadcastSearch(type);
        }
        private static string GetName(string entry)
        {
            return Path.GetFileName(entry);
        }
        private void PrintFolder(string searchKey, ref List<string> result)
        {
            var folders = GetDirectories(_location).Select(GetName).Where(a => a.Contains(searchKey)).ToList();
            folders.ToList().AddRange(result);
            result.AddRange(folders);
            if (result.Any())
            {
                FindFileOrFolderEventHandler("Folder");
            }
        }

        private void TriggerInteruptEvent()
        {
            _eventHandler?.TriggerInteruptEvent();
        }

        private void PrintFile(string searchKey, ref List<string> result)
        {
            result.ToList().AddRange(GetFiles(_location).ToList().Select(GetName).ToList());
            if (result.Any())
            {
                FindFileOrFolderEventHandler("File");
            }
        }

        private void PrintFoundResult(ICollection<string> result)
        {
            if (result.Any(a => a == _excludeFileKey))
            {
                result.Remove(_excludeFileKey);
                OnExcludeFileEvent();
            }
            result.ToList().ForEach((a) =>
            {
                if (a == _interupText)
                {
                    TriggerInteruptEvent();
                    return;
                }
                Console.WriteLine("\t" + a);
            });
        }

        private void OnExcludeFileEvent()
        {
            _eventHandler?.OnExcludeFileEvent();
        }
    }
}
