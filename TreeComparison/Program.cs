// See https://urldefense.com/v3/__https://aka.ms/new-console-template__;!!HoV-yHU!u1ruH-LcdOk-sLi2OFAQJgea99r549ltocpp5ouiCAMKu18z7EEHX58Fce3JUK-gjMDf1ym6VjqGMaApG5SLYnZX1gVd-E-9$  for more information
using System.Diagnostics;
using System.Xml.Serialization;
using TreeComparison;
using System.Collections.Generic;
using System.Text;



class Program
{
    BinaryTree<int> bst = new BinaryTree<int>();

    public static void Main(string[] args)
    {
        
        Console.WriteLine("test:       insert | contains | remove |");

        bstTimes();
        splayTimes();
        avlTimes();

    }

    static void bstTimes()
    {
        BinaryTree<int> bst = new BinaryTree<int>();


        StringBuilder results = new StringBuilder();
        results.Append("BST:        | ");

        var insert = Stopwatch.StartNew();
        for (int i = 0; i < 999; i++)
        {
            bst.Insert(i);
        }
        insert.Stop();
        results.Append('\n' + insert.ElapsedMilliseconds + "   | ");

        var contains = Stopwatch.StartNew();
        for (int i = 0; i < 999999; i++)
        {
            bst.Contains(i);
        }
        contains.Stop();
        results.Append('\n' + contains.ElapsedMilliseconds + "     | ");

        var remove = Stopwatch.StartNew();
        for (int i = 0; i < 999999; i++)
        {
            bst.Remove(i);
        }
        remove.Stop();
        results.Append('\n' + remove.ElapsedMilliseconds + "     | ");

        Console.WriteLine(results.ToString());

    }
    static void avlTimes()
    {
        AvlTree<int> avl = new AvlTree<int>();
        StringBuilder results = new StringBuilder();
        results.Append("AVL:        |");

        var insert = Stopwatch.StartNew();
        for (int i = 0; i < 999999; i++)
        {
            avl.Insert(i);
        }
        insert.Stop();
        results.Append('\n' + insert.ElapsedMilliseconds + "   | ");

        var contains = Stopwatch.StartNew();
        for (int i = 0; i < 999999; i++)
        {
            avl.Contains(i);
        }
        contains.Stop();
        results.Append('\n' + contains.ElapsedMilliseconds + "       | ");

        var remove = Stopwatch.StartNew();
        for (int i = 0; i < 999999; i++)
        {
            avl.Remove(i);
        }
        remove.Stop();
        results.Append('\n' + remove.ElapsedMilliseconds + "    | ");

        Console.WriteLine(results.ToString());
    }


    static void splayTimes()
    {
        SplayTree<int> splay = new SplayTree<int>();

        StringBuilder results = new StringBuilder();
        results.Append("Splay:      | ");

        var insert = Stopwatch.StartNew();
        for (int i = 0; i < 999999; i++)
        {
            splay.Insert(i);
        }
        insert.Stop();
        results.Append('\n' + insert.ElapsedMilliseconds + "   | ");

        var contains = Stopwatch.StartNew();
        for (int i = 0; i < 999999; i++)
        {
            splay.Contains(i);
        }
        contains.Stop();
        results.Append('\n' + contains.ElapsedMilliseconds + "       | ");

        var remove = Stopwatch.StartNew();
        for (int i = 0; i < 999999; i++)
        {
            splay.Remove(i);
        }
        remove.Stop();
        results.Append('\n' + remove.ElapsedMilliseconds + "     | ");

        Console.WriteLine(results.ToString());

    }

}



