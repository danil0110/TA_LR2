using System;
using System.Collections.Generic;
using System.Text;

namespace TA_LR2
{
    public class HashTable<T>
    {
        private Item[] items;
        private int[] table;
        private int size = 256;
        private int counter;
        private int collisions;

        public HashTable()
        {
            items = new Item[size];
            for (int i = 0; i < items.Length; i++)
                items[i] = new Item(i);

            table = CreateByteTable();
            Shuffle(table);
        }

        private int[] CreateByteTable()
        {
            int[] array = new int[256];
            for (int i = 0; i < array.Length; i++)
                array[i] = i;

            return array;
        }
        
        private void Shuffle(int[] table)
        {
            Random rng = new Random();
            int n = table.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int temp = table[k];
                table[k] = table[n];
                table[n] = temp;
            }
        }

        public void Add(string item)
        {
            int key = PearsonHashing(item);
            if (!items[key].Nodes.Contains(item))
                if (items[key].Nodes.Count != 0)
                {
                    collisions++;
                    items[key].Nodes.Add(item);
                }
                else
                {
                    items[key].Nodes.Add(item);
                }
                
        }

        public void Search(string item)
        {
            var key = PearsonHashing(item);
            for (int i = 0; i < items[key].Nodes.Count; i++)
            {
                if (item == items[key].Nodes[i])
                {
                    Console.WriteLine($"Элемент найден.\n{key}: {items[key].Nodes[i]}\n");
                    counter++;
                    
                    Console.WriteLine($"Количество сравнений: {counter}");
                    Console.WriteLine($"Количество коллизий: {collisions}");
                    return;
                }

                counter++;
            }
            Console.WriteLine("Элемент не найден.");
        }
        
        private int PearsonHashing(string item)
        {
            int h = 0;
            byte[] bytes = Encoding.UTF8.GetBytes(item);
            for (int i = 0; i < bytes.Length; i++)
                h = table[h ^ bytes[i]];

            return h;
        }
    }
}