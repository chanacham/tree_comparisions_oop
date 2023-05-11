// See https://urldefense.com/v3/__https://aka.ms/new-console-template__;!!HoV-yHU!u1ruH-LcdOk-sLi2OFAQJgea99r549ltocpp5ouiCAMKu18z7EEHX58Fce3JUK-gjMDf1ym6VjqGMaApG5SLYnZX1gVd-E-9$  for more information
using System.Diagnostics;
using System.Xml.Serialization;
using TreeComparison;
using System.Collections.Generic;
using System.Text;



class Program
{
    readonly static int TOPVAL = 150000;
    readonly static int BOTVAL = 1; 
    readonly static int TOPGAP = 41;
    public static void Main(string[] args)
    {
        
        Console.WriteLine("test:       insert | contains | remove |");
        Console.WriteLine("----------------------------------------");
        bstTimes();
        splayTimes();
        avlTimes();
        Console.WriteLine("----------------------------------------"); 

    }

    static void bstTimes()
    {
        BinaryTree<int> bst = new BinaryTree<int>();


        StringBuilder results = new StringBuilder();
        results.Append("BST:        | ");

        var insert = Stopwatch.StartNew();
        int gap = BOTVAL;
        
        for (int i = 0; i < TOPVAL; i++)
        {
           
            bst.Insert(gap);
            gap += TOPGAP;
            if (gap >= TOPVAL)
            {
                gap %= TOPVAL;
                //Console.WriteLine(gap.ToString() + " ");
            }

        }
        insert.Stop();
        results.Append('\n' + insert.ElapsedMilliseconds + "   | ");
        //Console.WriteLine("completed insertion ");

        var contains = Stopwatch.StartNew();
        for (int i = 1; i < TOPVAL; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                if (!bst.Contains(i))
                {
                    Console.WriteLine("Bloody murder " + i.ToString()); 
                }
                //Console.WriteLine(i.ToString() + " "); 
            }
        }
        contains.Stop();
        results.Append('\n' + contains.ElapsedMilliseconds + "     | ");
       // Console.WriteLine("completed contains ");


        var remove = Stopwatch.StartNew();
        for (int i = 1; i < TOPVAL; i++)
        {
            bst.Remove(i);
        }
        remove.Stop();
        results.Append('\n' + remove.ElapsedMilliseconds + "     | ");
       // Console.WriteLine("completed removal ");


        Console.WriteLine(results.ToString());

    }
    static void avlTimes()
    {
        AvlTree<int> avl = new AvlTree<int>();
        StringBuilder results = new StringBuilder();
        results.Append("AVL:        |");

        var insert = Stopwatch.StartNew();
        int gap = BOTVAL;

        for (int i = 0; i < TOPVAL; i++)
        {

            avl.Insert(gap);
            gap += TOPGAP;
            if (gap >= TOPVAL)
            {
                gap %= TOPVAL;
                //Console.WriteLine(gap.ToString() + " ");
            }

        }
        insert.Stop();
        results.Append('\n' + insert.ElapsedMilliseconds + "   | ");

        var contains = Stopwatch.StartNew();
        for (int i = 0; i < TOPVAL; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (!avl.Contains(i))
                {
                    Console.WriteLine("Bloody murder " + i.ToString());
                }
            }
        }
        contains.Stop();
        results.Append('\n' + contains.ElapsedMilliseconds + "       | ");

        var remove = Stopwatch.StartNew();
        for (int i = 0; i < TOPVAL; i++)
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
        int gap = BOTVAL;

        for (int i = 0; i < TOPVAL; i++)
        {

            splay.Insert(gap);
            gap += TOPGAP;
            if (gap >= TOPVAL)
            {
                gap %= TOPVAL;
                //Console.WriteLine(gap.ToString() + " ");
            }

        }
        insert.Stop();
        results.Append('\n' + insert.ElapsedMilliseconds + "   | ");

        var contains = Stopwatch.StartNew();
        for (int i = 0; i < TOPVAL; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (!splay.Contains(i))
                {
                    Console.WriteLine("Bloody murder " + i.ToString());
                }
            }
        }
        contains.Stop();
        results.Append('\n' + contains.ElapsedMilliseconds + "       | ");

        var remove = Stopwatch.StartNew();
        for (int i = 0; i < TOPVAL; i++)
        {
            splay.Remove(i);
        }
        remove.Stop();
        results.Append('\n' + remove.ElapsedMilliseconds + "     | ");

        Console.WriteLine(results.ToString());

    }

}



