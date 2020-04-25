using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{
    public class Node
    {
        public Movie Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node()
        {

        }
        public Node(Movie data)
        {
            this.Data = data;

        }
    }
    class MovieCollection
    {
        private int count = 0;
        private Node _root;
        public MovieCollection()
        {
            _root = null;
        }

        // This method mainly calls deleteRec()  
        public void deleteKey(string key)
        {
            _root = deleteRec(_root, key);
        }

        /* A recursive function to insert a new key in BST */
        Node deleteRec(Node root, string Data)
        {
            if (root == null) { Console.WriteLine("No records found for " + "`" + Data + "'"); return root; }
            if (string.Compare(Data, root.Data.Title) == -1)
            {
                root.Left = deleteRec(root.Left, Data);
            }
            else if (string.Compare(Data, root.Data.Title) == 1)
            {
                root.Right = deleteRec(root.Right, Data);
            }
            else if (string.Compare(Data, root.Data.Title) == 0)
            {
                Console.WriteLine("Deleted '" + Data + "' from Movie Collection");
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;
                root.Data.Title = minValue(root.Right);
                root.Right = deleteRec(root.Right, root.Data.Title);
            }
            return root;
        }

        string minValue(Node root)
        {
            string minv = root.Data.Title;
            while (root.Left != null)
            {
                minv = root.Left.Data.Title;
                root = root.Left;
            }
            return minv;
        }
        public void Insert(Movie data)
        {
            // 1. If the tree is empty, return a new, single node 
            if (_root == null)
            {
                _root = new Node(data);
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertRec(_root, new Node(data));
        }
        private void InsertRec(Node root, Node newNode)
        {
            if (root == null)
                root = newNode;

            if (string.Compare(newNode.Data.Title, root.Data.Title) == -1)
            {
                if (root.Left == null)
                    root.Left = newNode;
                else
                    InsertRec(root.Left, newNode);

            }
            else
            {
                if (root.Right == null)
                    root.Right = newNode;
                else
                    InsertRec(root.Right, newNode);
            }
        }
        private void DisplayTree(Node root)
        {
            if (root == null) { return; };
            count++;
            DisplayTree(root.Left);
            Console.WriteLine("");
            Console.WriteLine(count.ToString() + ".");
            Console.WriteLine("Title: " + root.Data.Title);
            Console.WriteLine("Starring: " + root.Data.Starring);
            Console.WriteLine("Directed by: " + root.Data.Director);
            Console.WriteLine("Length: " + root.Data.Duration.ToString() + " hours");
            Console.WriteLine("Genre: " + root.Data.Genre);
            Console.WriteLine("Classification: " + root.Data.Classification);
            Console.WriteLine("Release Date: " + root.Data.ReleaseDate);
            DisplayTree(root.Right);
        }
        public void DisplayTree()
        {
            Console.WriteLine("========Movie Collection========");
            DisplayTree(_root);
            Console.WriteLine("");
            Console.WriteLine("================================");
            Console.WriteLine("");
            count = 0;
        }

    }
}
