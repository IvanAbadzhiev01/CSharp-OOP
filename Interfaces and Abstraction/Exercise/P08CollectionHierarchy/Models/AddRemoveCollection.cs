using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> data;
        private const int AddIndex = 0;

        public AddRemoveCollection()
        {
            data = new List<string>();
        }
        public int Add(string item)
        {
            data.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            int lastIndex = data.Count - 1;
            string removeElement = null;
            if (data.Count > 0)
            {
                removeElement = data[lastIndex];
                data.RemoveAt(lastIndex);

            }
            return removeElement;
        }
    }
}
