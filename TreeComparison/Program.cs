// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Xml.Serialization;
using TreeComparison;
using System.Collections.Generic;
using System.Text;

class Program <T> where T : IComparable<T>, IEquatable<T>
    {
        public static SplayTree<T> splay = new SplayTree<T>();
        public static BinarySearchTree<T> binary = new BinarySearchTree<T>();
        public static AvlTree<T> avl = new AvlTree<T>();
        public static void Main(string[] args)
        {
            
            Console.WriteLine("test:       insert | contains | remove |");

            bstTimes(); 
            splayTimes();
            avlTimes();
        
        }

        static void bstTimes()
        {
            StringBuilder results = new StringBuilder();
            results.Append("BST:    | "); 
           
            var insert = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                binary.Insert(i);
            }
            insert.Stop();
            results.Append('\n' + insert.ElapsedMilliseconds + " | ");

            var contains = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                binary.Contains(i);
            }
            contains.Stop();
            results.Append('\n' + contains.ElapsedMilliseconds + " | ");

            var remove = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                binary.Remove(i);
            }
            remove.Stop();
            results.Append('\n' + remove.ElapsedMilliseconds + " | ");

            Console.WriteLine(results.ToString());

        }

        static void splayTimes()
        {
            StringBuilder results = new StringBuilder();
            results.Append("Splay:    | ");

            var insert = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                splay.Insert(i);
            }
            insert.Stop();
            results.Append('\n' + insert.ElapsedMilliseconds + " | ");

            var contains = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                splay.Contains(i);
            }
            contains.Stop();
            results.Append('\n' + contains.ElapsedMilliseconds + " | ");

            var remove = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                splay.Remove(i);
            }
            remove.Stop();
            results.Append('\n' + remove.ElapsedMilliseconds + " | ");

            Console.WriteLine(results.ToString());

        }

        static void avlTimes()
        {
            StringBuilder results = new StringBuilder();
            results.Append("AVL:    | ");

            var insert = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                avl.Insert(i);
            }
            insert.Stop();
            results.Append('\n' + insert.ElapsedMilliseconds + " | ");

            var contains = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                avl.Contains(i);
            }
            contains.Stop();
            results.Append('\n' + contains.ElapsedMilliseconds + " | ");

            var remove = Stopwatch.StartNew();
            for (int i = 0; i < 999999; i++)
            {
                avl.Remove(i);
            }
            remove.Stop();
            results.Append('\n' + remove.ElapsedMilliseconds + " | ");

            Console.WriteLine(results.ToString());

        }



}