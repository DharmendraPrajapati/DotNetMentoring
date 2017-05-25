using System;

namespace DelegatesAndEventsTaskIII
{
    public class SearchPerformedEventArgs : EventArgs
    {
        public SearchPerformedEventArgs(string path, string searchExtension)
        {
            Path = path;
            SearchExtension = searchExtension;
        }

        public string Path { get; set; }
        public string SearchExtension { get; set; }
    }
}