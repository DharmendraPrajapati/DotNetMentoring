using System;

namespace DelegateAndEvents
{
    
    internal class FileSystemEventsHandler
    {
        internal delegate void FileSystemEvents(string msg);
        internal delegate void FileSystemSearchEvents(string msg);
        internal delegate void FileSystemAbortAndExcludeEvent();
        internal delegate void FileSystemExcludeEvent();

        internal event FileSystemEvents FileSysEvent;
        internal event FileSystemEvents FileSysSearchEvent;
        internal event FileSystemAbortAndExcludeEvent AbortAndExcludeEvent;
        internal FileSystemEventsHandler()
        {
            FileSysEvent = PrintSearchMessage;
            FileSysSearchEvent = PrintFindMessage;
        }
        public void SearchBroadcastMessage(string message)
        {
            FileSysEvent?.Invoke(message);
        }
        private static void PrintSearchMessage(string message)
        {
            Console.WriteLine("Search has been " + message);
        }
        public void OnBroadcastSearch(string type)
        {
            FileSysSearchEvent?.Invoke(type);
        }
        private static void PrintFindMessage(string type)
        {
            Console.WriteLine(type+" Finded");
        }
        protected virtual void OnFileSysEvent(string msg)
        {
            FileSysEvent?.Invoke("**"+msg);
        }

        internal void TriggerInteruptEvent()
        {
            AbortAndExcludeEvent = delegate()
            {
                Console.WriteLine("System Aborted.");
            };
            AbortAndExcludeEvent?.Invoke();
        }

        internal void OnExcludeFileEvent()
        {
            AbortAndExcludeEvent = delegate ()
            {
                Console.WriteLine("File Has been excluded.");
            };
            AbortAndExcludeEvent?.Invoke();
        }
    }
}
