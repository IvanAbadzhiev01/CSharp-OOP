using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private readonly List<string> data;
        private const int AddIndex = 0;


        public MyList()
        {
            data = new List<string>();
        }
        public int Used => data.Count;

        public int Add(string item)
        {
            data.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            string item = null;
            if (data.Count > 0)
            {
                item = data[0];
                data.RemoveAt(0);
            }
            return item;
        }
    }
}
