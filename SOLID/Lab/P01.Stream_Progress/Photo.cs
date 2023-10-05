using System.Security.AccessControl;

namespace P01.Stream_Progress
{
    public class Photo : IFile
    {
        private string author;
        public Photo(string author, int length, int bytesSent)
        {
            this.author = author;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}
