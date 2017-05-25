using System;

namespace DelegatesAndEventsTask
{
    public class DeletePerformedEventArgs : EventArgs
    {
        public DeletePerformedEventArgs(string path)
        {
            Path = path;
        }

        public DeletePerformedEventArgs(string path, string fileNameToDelete)
        {
            Path = path;
            FileNameToDelete = fileNameToDelete;
        }

        public string Path { get; set; }
        public string FileNameToDelete { get; set; }
    }
}