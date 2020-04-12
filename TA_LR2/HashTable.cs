using System;
using System.Collections.Generic;
using System.Text;

namespace TA_LR2
{
    public class HashTable<T>
    {
        private Item[] items;
        private int[] table;
        private int size;

        public HashTable(int size)
        {
            this.size = size;
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

        public void OutputTable()
        {
            foreach (var el in table)
            {
                Console.Write($"{el}    ");
            }
        }

        public void Add(string item)
        {
            int key = PearsonHashing(item);
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

        public int ShowHash(string item)
        {
            var key = PearsonHashing(item);
            return key;
        }

        public void ShowShow(string item)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(item);
            foreach (var el in bytes)
            {
                Console.WriteLine(el);
            }
        }
        
        private int PearsonHashing(string item)
        {
            int h;
            int[] hh = new int[8];
            int result = 0;
            string tempResult = "";

            for (int j = 0; j < 8; j++)
            {
                h = table[(item[0] + j) % 256];
                for (int i = 0; i < item.Length; i++)
                    h = table[h ^ item[i]];

                hh[j] = h;
                tempResult += Convert.ToString(hh[j]);
            }

            result = Convert.ToInt32(Convert.ToDouble(tempResult) % size);

            return result;
        }
    }
}