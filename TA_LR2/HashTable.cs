using System;
using System.Collections.Generic;
using System.Text;

namespace TA_LR2
{
    public class HashTable<T>
    {
        private Item[] items;

        public HashTable(int size)
        {
            items = new Item[size];
            for (int i = 0; i < items.Length; i++)
                items[i] = new Item(i);
        }

        public void Add(string item)
        {
            byte key = PearsonHashing(item);
            if (!items[key].Nodes.Contains(item))
                items[key].Nodes.Add(item);
        }

        public void Search(string item)
        {
            var key = PearsonHashing(item);
            for (int i = 0; i < items[key].Nodes.Count; i++)
            {
                if (item == items[key].Nodes[i])
                {
                    Console.WriteLine("Элемент найден.");
                    return;
                }
            }
            Console.WriteLine("Элемент не найден.");
        }

        public byte ShowHash(string item)
        {
            var key = PearsonHashing(item);
            return key;
        }
        
        private byte PearsonHashing(string item)
        {
            byte hash = 0;
            byte[] bytes = Encoding.UTF8.GetBytes(item);

            foreach (var b in bytes)
            {
                hash = (byte)(hash ^ b);
            }

            return hash;
        }
    }
}