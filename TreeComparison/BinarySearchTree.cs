using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TreeComparison {

    class BinarySearchTree<T> where T : IComparable<T>, IEquatable<T> { 
    
        // Basic node stored in unbalanced binary search trees
        internal class BinaryNode<T>
        {
            // Constructors
            public BinaryNode(T theElement)
            {
                element = theElement;
                left = null;
                right = null; 
            }

            public BinaryNode(T theElement, BinaryNode<T> lt, BinaryNode<T> rt)
            {
                element = theElement;
                left = lt;
                right = rt;
            }

            public T element;            // The data in the node
            public  BinaryNode<T> left;   // Left child
            public BinaryNode<T> right;  // Right child
        }


        /** The tree root. */
        BinaryNode<T> root;



    /**
     * Construct the tree.
     */
        public BinarySearchTree()
        {
            root = null;
        }

        /**
         * Insert into the tree; duplicates are ignored.
         * @param x the item to insert.
         */
        void Insert(T x)
        {
            root = Insert(x, root);
        }

        /**
         * Remove from the tree. Nothing is done if x is not found.
         * @param x the item to remove.
         */
        void Remove(T x)
        {
            root = Remove(x, root);
        }

        /**
         * Find the smallest item in the tree.
         * @return smallest item or null if empty.
         */
        T FindMin()
        {
            //T? found = null;
            T? found = default; 
            if (!IsEmpty())
            {
                found = FindMin(root).element;
            }
            return found;
        }

        /**
         * Find the largest item in the tree.
         *
         * @return the largest item or null if empty.
         */
        T FindMax()
        {
            //T found = null;
            T? found = default;

            if (!IsEmpty())
        { 
                found = FindMax(root).element;
            }
            return found;
        }

        /**
         * Find an item in the tree.
         * @param x the item to search for.
         * @return true if not found.
         */
        Boolean Contains(T x)
        {
            return Contains(x, root);
        }

        /**
         * Make the tree logically empty.
         */
        void MakeEmpty()
        {
            root = null;
        }

        /**
         * Test if the tree is logically empty.
         * @return true if empty, false otherwise.
         */
        Boolean IsEmpty()
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

        /**
         * return a string with a visual representation of BST
         * @return String representation of the tree
         */
     
        String ToString()
        {
            StringBuilder buffer = new StringBuilder(50);
            ToStr(root, buffer, "", "");
            return buffer.ToString();
        }

        /*----------------------------------------------------------
         *
         *                  Private Methods
         *
         ----------------------------------------------------------*/

        /**
         * Internal method to insert into a subtree.
         * @param x the item to insert.
         * @param t the node that roots the subtree.
         * @return the new root of the subtree.
         */
        BinaryNode<T> Insert(T x, BinaryNode<T> t)
        {
            if (t == null)
                return new BinaryNode<T>(x, null, null);

            int compareResult = x.CompareTo(t.element);

            if (compareResult < 0)
            t.left = Insert(x, t.left);
            else if (compareResult > 0)
                t.right = Insert(x, t.right);
            else
                ;  // Duplicate; do nothing.  Explicitly emphasized
            return t;
        }

        /**
         * Internal method to remove from a subtree.
         * @param x the item to remove.
         * @param t the node that roots the subtree.
         * @return the new root of the subtree.
         */
        BinaryNode<T> Remove(T x, BinaryNode<T> t)
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
            return t;
        }

        /**
         * Internal method to find the smallest item in a subtree.
         * @param t the node that roots the subtree.
         * @return node containing the smallest item.
         */
        BinaryNode<T> FindMin(BinaryNode<T> t)
        {
            if (t == null)
                return null;
            else if (t.left == null)
                return t;
            return FindMin(t.left);
        }

        /**
         * Internal method to find the largest item in a subtree.
         * @param t the node that roots the subtree.
         * @return node containing the largest item.
         */
        BinaryNode<T> FindMax(BinaryNode<T> t)
        {
            if (t != null)
                while (t.right != null)
                    t = t.right;

            return t;
        }

        /**
         * Internal method to find an item in a subtree.
         * @param x is item to search for.
         * @param t the node that roots the subtree.
         * @return node containing the matched item.
         */
        Boolean Contains(T x, BinaryNode<T> t)
        {
            if (t == null)
                return false;

            int compareResult = x.CompareTo(t.element);

            if (compareResult < 0)
                return Contains(x, t.left);
            else if (compareResult > 0)
                return Contains(x, t.right);
            else
                return true;    // Match
        }

        /**
         * Internal method to print a subtree in sorted order.
         * @param t the node that roots the subtree.
         */
        void PrintTree(BinaryNode<T> t)
        {
            if (t != null)
            {
                PrintTree(t.left);
                Console.WriteLine(t.element);
                PrintTree(t.right);
            }
        }

        /** Internal method to prepare a string display
        * of a BST in a manner of DOS-file structure
        * @param node starting node
        * @param buffer - dynamically generated connections
        * @param prefix - connection prefix for the node
        * @param childrenPrefix - connection prefix for the children
        */
        void ToStr(BinaryNode<T> node,
                           StringBuilder buffer,
                           String prefix,
                           String childrenPrefix)
        {
            buffer.Append(prefix);
            buffer.Append(node.element.ToString());
            buffer.Append('\n');
            if (node.right != null)
            {
                ToStr(node.right, buffer, childrenPrefix + ">── ",
                        node.left != null
                                ? childrenPrefix + "│   "
                                : childrenPrefix + "    ");
            }
            if (node.left != null)
            {
                ToStr(node.left, buffer, childrenPrefix + "<── ", childrenPrefix + "    ");
            }
        }
    }
}
