using System;
using System.Text;

namespace TA_LR2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> hashTable = new HashTable<string>();
            
            GenerationForHashTable(hashTable, 1000);
            Console.Write("Введите ключ для поиска элемента в хеш-таблице: ");
            hashTable.Search(Console.ReadLine());
        }

        public static void GenerationForHashTable(HashTable<string> hashTable, int count)
        {
            string item;
            for (int i = 0; i < count; i++)
            {
                item = RandomString();
                hashTable.Add(item);
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static string RandomString()
        {
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rnd = new Random();
            int Length = rnd.Next(1, 20);
            StringBuilder sb = new StringBuilder(Length);
            int Position;
            
            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length-1);
                sb.Append(Alphabet[Position]);
            }

            return sb.ToString();
        }
        
    }

}