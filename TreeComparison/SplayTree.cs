using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic; 

namespace TreeComparison
{
    internal class SplayTree<T> where T : IComparable<T>, IEquatable<T>
    {
            /**
             * Construct the tree.
             */
            public SplayTree()
            {
                nullNode = new BinaryNode<T>(null);
                nullNode.Left = nullNode.Right = nullNode;
                root = nullNode;
            }

    private BinaryNode<T> newNode = null;  // Used between different inserts

        /**
         * Insert into the tree.
         *
         * @param x the item to insert.
         */
        public void Insert(T x)
        {
            if (newNode == null)
                newNode = new BinaryNode<T>(null);
            newNode.element = x;

            if (root == nullNode)
            {
                newNode.Left = newNode.Right = nullNode;
                root = newNode;
            }
            else
            {
                root = Splay(x, root);

                int compareResult = x.CompareTo(root.element);

                if (compareResult < 0)
                {
                    newNode.Left = root.Left;
                    newNode.Right = root;
                    root.Left = nullNode;
                    root = newNode;
                }
                else if (compareResult > 0)
                {
                    newNode.Right = root.Right;
                    newNode.Left = root;
                    root.Right = nullNode;
                    root = newNode;
                }
                else
                    return;   // No duplicates
            }
            newNode = null;   // So next insert will call new
        }

        /**
         * Remove from the tree.
         *
         * @param x the item to remove.
         */
        public void Remove(T x)
        {
            if (!Contains(x))
                return;

            BinaryNode<T> NewTree;

            // If x is found, it will be splayed to the root by contains
            if (root.Left == nullNode)
                NewTree = root.Right;
            else
            {
                // Find the maximum in the left subtree
                // Splay it to the root; and then attach right child
                NewTree = root.Left;
                NewTree = Splay(x, NewTree);
                NewTree.Right = root.Right;
            }
            root = NewTree;
        }

        /**
         * Find the smallest item in the tree.
         * Not the most efficient implementation (uses two passes), but has correct
         * amortized behavior.
         * A good alternative is to first call find with parameter
         * smaller than any item in the tree, then call findMin.
         *
         * @return the smallest item or null if empty.
         */
        public T FindMin()
        {
           // T min = null;
            T? min = default;

            if (!IsEmpty())
            {
                BinaryNode<T> ptr = root;

                while (ptr.Left != nullNode)
                    ptr = ptr.Left;

                root = Splay(ptr.element, root);
                return ptr.element;
            }
            return min;
        }

        /**
         * Find the largest item in the tree.
         * Not the most efficient implementation (uses two passes), but has correct
         * amortized behavior.
         * A good alternative is to first call find with parameter
         * larger than any item in the tree, then call findMax.
         *
         * @return the largest item or throw null if empty.
         */
        public T FindMax()
        {
           // T max = null;
            T? max = default; 
            if (!IsEmpty())
            {
                BinaryNode<T> ptr = root;

                while (ptr.Right != nullNode)
                    ptr = ptr.Right;

                root = Splay(ptr.element, root);
                return ptr.element;
            }
            return max;
        }

        /**
         * Find an item in the tree.
         *
         * @param x the item to search for.
         * @return true if x is found; otherwise false.
         */
        public Boolean Contains(T x)
        {
            if (IsEmpty())
                return false;

            root = Splay(x, root);

            return root.element.CompareTo(x) == 0;
        }

        /**
         * Make the tree logically empty.
         */
        public void MakeEmpty()
        {
            root = nullNode;
        }

        /**
         * Test if the tree is logically empty.
         *
         * @return true if empty, false otherwise.
         */
        public Boolean IsEmpty()
        {
            return root == nullNode;
        }

        private readonly BinaryNode<T> header = new BinaryNode<T>(null); // For splay

        /**
         * Internal method to perform a top-down splay.
         * The last accessed node becomes the new root.
         *
         * @param x the target item to splay around.
         * @param t the root of the subtree to splay.
         * @return the subtree after the splay.
         */
        private BinaryNode<T> Splay(T x, BinaryNode<T> t)
        {
            BinaryNode<T> leftTreeMax, rightTreeMin;

            header.Left = header.Right = nullNode;
            leftTreeMax = rightTreeMin = header;

            nullNode.element = x;   // Guarantee a match

            for (; ; )
            {
                int compareResult = x.CompareTo(t.element);

                if (compareResult < 0)
                {
                    if (x.CompareTo(t.Left.element) < 0)
                        t = RotateWithLeftChild(t);
                    if (t.Left == nullNode)
                        break;
                    // Link Right
                    rightTreeMin.Left = t;
                    rightTreeMin = t;
                    t = t.Left;
                }
                else if (compareResult > 0)
                {
                    if (x.CompareTo(t.Right.element) > 0)
                        t = RotateWithRightChild(t);
                    if (t.Right == nullNode)
                        break;
                    // Link Left
                    leftTreeMax.Right = t;
                    leftTreeMax = t;
                    t = t.Right;
                }
                else
                    break;
            }

            leftTreeMax.Right = t.Left;
            rightTreeMin.Left = t.Right;
            t.Left = header.Right;
            t.Right = header.Left;
            return t;
        }

        /**
         * Rotate binary tree node with left child.
         * For AVL trees, this is a single rotation for case 1.
         */
        private BinaryNode<T> RotateWithLeftChild(BinaryNode<T> k2)
        {
            BinaryNode<T> k1 = k2.Left;
            k2.Left = k1.Right;
            k1.Right = k2;
            return k1;
        }

        /**
         * Rotate binary tree node with right child.
         * For AVL trees, this is a single rotation for case 4.
         */
        private BinaryNode<T> RotateWithRightChild(BinaryNode<T> k1)
        {
            BinaryNode<T> k2 = k1.Right;
            k1.Right = k2.Left;
            k2.Left = k1;
            return k2;
        }

        // Basic node stored in unbalanced binary search trees
        private class BinaryNode<AnyType>
        {
            // Constructors
            BinaryNode(T theElement)
            {
                element = theElement;
                Left = null;
                Right = null; 
            }

            BinaryNode(T theElement, BinaryNode<T> lt, BinaryNode<T> rt)
            {
                element = theElement;
                Left = lt;
                Right = rt;
            }

            public T? element;            // The data in the node
            public BinaryNode<T>? Left;   // Left child
            public BinaryNode<T>? Right;  // Right child
        }

        private BinaryNode<T> root;
        private BinaryNode<T> nullNode;


    }
}
