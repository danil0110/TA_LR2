using System.Collections.Generic;

namespace TA_LR2
{
    public class Item
    {
        public int Key { get; set; }
        public List<string> Nodes { get; set; }

        public Item(int key)
        {
            Key = key;
            Nodes = new List<string>();
        }
    }
}