using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace TreeComparison
{
    class AvlTree <T> where T : IComparable<T>, IEquatable<T>
    {
        internal class AvlNode<T>
        {
            // Constructors
            public AvlNode(T theElement)
            {
                element = theElement;
                left = null;
                right = null;
            }

            public AvlNode(T theElement, AvlNode<T> lt, AvlNode<T> rt)
            {
                element = theElement;
                left = lt;
                right = rt;
                height = 0;
            }


            public T element;      // The data in the node
            public AvlNode<T> left;         // Left child
            public AvlNode<T> right;        // Right child
            public int height;       // Height
        }

        /** The tree root. */
        public AvlNode<T> root;

        /**
         * Construct the tree.
         */
        public AvlTree()
        {
            root = null;
        }

        /**
         * Insert into the tree; duplicates are ignored.
         * @param x the item to insert.
         */
            public void Insert(T x)
            {
                root = Insert(x, root);
            }

            /**
             * Remove from the tree. Nothing is done if x is not found.
             * @param x the item to remove.
             */
            public void Remove(T x)
            {
                root = Remove(x, root);
            }


            /**
             * Internal method to remove from a subtree.
             * @param x the item to remove.
             * @param t the node that roots the subtree.
             * @return the new root of the subtree.
             */
            AvlNode<T> Remove(T x, AvlNode<T> t)
            {
                if (t == null)
                    return t;   // Item not found; do nothing

            int compareResult = x.CompareTo(t.element);

                if (compareResult < 0)
                    t.left = Remove(x, t.left);
                else if (compareResult > 0)
                    t.right = Remove(x, t.right);
                else if (t.left != null && t.right != null) // Two children
                {
                    t.element = FindMin(t.right).element;
                    t.right = Remove(t.element, t.right);
                }
                else
                    t = (t.left != null) ? t.left : t.right;
                return Balance(t);
            }

            /**
             * Find the smallest item in the tree.
             * @return smallest item or null if empty.
             */
            T FindMin()
            {
               // T? min = null;
            T? min = default;

            if (!IsEmpty())
                    min = FindMin(root).element;
                return min;
            }

            /**
             * Find the largest item in the tree.
             * @return the largest item of null if empty.
             */
            T FindMax()
            {
                 //T max = null;
                 T? max = default;
                if (!IsEmpty())
                {
                    max = FindMax(root).element;
                }
                return max;
            }

            /**
             * Find an item in the tree.
             * @param x the item to search for.
             * @return true if x is found.
             */
            public Boolean Contains(T x)
            {
                return Contains(x, root);
            }

            /**
             * Make the tree logically empty.
             */
            public void MakeEmpty()
            {
                root = null;
            }

            /**
             * Test if the tree is logically empty.
             * @return true if empty, false otherwise.
             */
            public Boolean IsEmpty()
            {
                return root == null;
            }

            /**
             * Print the tree contents in sorted order.
             */
            void PrintTree()
            {
                if (IsEmpty())
                   Console.WriteLine("Empty tree");
                 else
                    PrintTree(root);
            }

        private static int ALLOWED_IMBALANCE = 1; // what is int32???

        // Assume t is either balanced or within one of being balanced
        AvlNode<T> Balance(AvlNode<T> t)
        {
            if (t == null)
                return t;

            if (Height(t.left) - Height(t.right) > ALLOWED_IMBALANCE)
                if (Height(t.left.left) >= Height(t.left.right))
                    t = RotateWithLeftChild(t);
                else
                    t = DoubleWithLeftChild(t);
            else
            if (Height(t.right) - Height(t.left) > ALLOWED_IMBALANCE)
                if (Height(t.right.right) >= Height(t.right.left))
                    t = RotateWithRightChild(t);
                else
                    t = DoubleWithRightChild(t);

            t.height = Math.Max(Height(t.left), Height(t.right)) + 1;
            return t;
        }

         void CheckBalance()
        {
            CheckBalance(root);
        }

        int CheckBalance(AvlNode<T> t)
        {
            if (t == null)
                return -1;

            if (t != null)
            {
                int hl = CheckBalance(t.left);
                int hr = CheckBalance(t.right);
                if (Math.Abs(Height(t.left) - Height(t.right)) > 1 ||
                        Height(t.left) != hl || Height(t.right) != hr)
                    Console.WriteLine("OOPS!!");
            }

            return Height(t);
        }


        /**
         * Internal method to insert into a subtree.
         * @param x the item to insert.
         * @param t the node that roots the subtree.
         * @return the new root of the subtree.
         */
        AvlNode<T> Insert(T x, AvlNode<T> t)
        {
            if (t == null)
                return new AvlNode<T>(x, null, null);

            int compareResult = x.CompareTo(t.element);

            if (compareResult < 0)
                t.left = Insert(x, t.left);
            else if (compareResult > 0)
                t.right = Insert(x, t.right);
            else
                ;  // Duplicate; do nothing
            return Balance(t);
        }

        /**
         * Internal method to find the smallest item in a subtree.
         * @param t the node that roots the tree.
         * @return node containing the smallest item.
         */
        AvlNode<T> FindMin(AvlNode<T> t)
        {
            if (t == null)
                return t;

            while (t.left != null)
                t = t.left;
            return t;
        }

        /**
         * Internal method to find the largest item in a subtree.
         * @param t the node that roots the tree.
         * @return node containing the largest item.
         */
        AvlNode<T> FindMax(AvlNode<T> t)
        {
            if (t == null)
                return t;

            while (t.right != null)
                t = t.right;
            return t;
        }

        /**
         * Internal method to find an item in a subtree.
         * @param x is item to search for.
         * @param t the node that roots the tree.
         * @return true if x is found in subtree.
         */
        Boolean Contains(T x, AvlNode<T> t)
        {
            while (t != null)
            {
                int compareResult = x.CompareTo(t.element);

                if (compareResult < 0)
                    t = t.left;
                else if (compareResult > 0)
                    t = t.right;
                else
                    return true;    // Match
            }

            return false;   // No match
        }

        /**
         * Internal method to print a subtree in sorted order.
         * @param t the node that roots the tree.
         */
        void PrintTree(AvlNode<T> t)
        {
            if (t != null)
            {
                PrintTree(t.left);
                Console.WriteLine(t.element);
                PrintTree(t.right);
            }
        }

        /**
         * Return the height of node t, or -1, if null.
         */
        int Height(AvlNode<T> t)
        {
            return t == null ? -1 : t.height;
        }

        /**
         * Rotate binary tree node with left child.
         * For AVL trees, this is a single rotation for case 1.
         * Update heights, then return new root.
         */
        AvlNode<T> RotateWithLeftChild(AvlNode<T> k2)
        {
            AvlNode<T> k1 = k2.left;
            k2.left = k1.right;
            k1.right = k2;
            k2.height = Math.Max(Height(k2.left), Height(k2.right)) + 1;
            k1.height = Math.Max(Height(k1.left), k2.height) + 1;
            return k1;
        }

        /**
         * Rotate binary tree node with right child.
         * For AVL trees, this is a single rotation for case 4.
         * Update heights, then return new root.
         */
        AvlNode<T> RotateWithRightChild(AvlNode<T> k1)
        {
            AvlNode<T> k2 = k1.right;
            k1.right = k2.left;
            k2.left = k1;
            k1.height = Math.Max(Height(k1.left), Height(k1.right)) + 1;
            k2.height = Math.Max(Height(k2.right), k1.height) + 1;
            return k2;
        }

        /**
         * Double rotate binary tree node: first left child
         * with its right child; then node k3 with new left child.
         * For AVL trees, this is a double rotation for case 2.
         * Update heights, then return new root.
         */
        AvlNode<T> DoubleWithLeftChild(AvlNode<T> k3)
        {
            k3.left = RotateWithRightChild(k3.left);
            return RotateWithLeftChild(k3);
        }

        /**
         * Double rotate binary tree node: first right child
         * with its left child; then node k1 with new right child.
         * For AVL trees, this is a double rotation for case 3.
         * Update heights, then return new root.
         */
        AvlNode<T> DoubleWithRightChild(AvlNode<T> k1)
        {
            k1.right = RotateWithLeftChild(k1.right);
            return RotateWithRightChild(k1);
        }

      
    }

}

