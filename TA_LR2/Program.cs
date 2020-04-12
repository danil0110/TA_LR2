using System;

namespace TA_LR2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> hashTable = new HashTable<string>(256);
            
            hashTable.Add("tabletop");
            hashTable.Add("Robin100");
            hashTable.Add("123");
            
            hashTable.Search("321");
            
            Console.WriteLine(hashTable.ShowHash("tabletop"));
            Console.WriteLine(hashTable.ShowHash("Robin100"));
            Console.WriteLine(hashTable.ShowHash("123"));
        }
    }
}