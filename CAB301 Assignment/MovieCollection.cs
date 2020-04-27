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
        public MovieArchive Archive;
        public MovieCollection()
        {
            _root = null;
            Archive = new MovieArchive();
        }

        // This method mainly calls deleteRec()  
        public Movie borrowKey(string key, string mes)
        {
            Node stuffs = new Node(borrowRec(_root, key).Data);
            Movie Borrowing = new Movie(stuffs.Data.Title, stuffs.Data.Starring, stuffs.Data.Director, stuffs.Data.Duration, stuffs.Data.Genre, stuffs.Data.Classification, stuffs.Data.ReleaseDate);
            if(Borrowing == null)
            {
                return null;
            }
            else
            {
                deleteKey(key, mes);
                return Borrowing;
            }
            
        }

        /* A recursive function to insert a new key in BST */
        Node borrowRec(Node root, string Data)
        {
            Node Boi;
            if (root == null) { Console.WriteLine("No records found for " + "`" + Data + "'"); return null; }
            if (string.Compare(Data, root.Data.Title) == -1)
            {
                Boi = borrowRec(root.Left, Data);
                return Boi;
            }
            else if (string.Compare(Data, root.Data.Title) == 1)
            {
                Boi = borrowRec(root.Right, Data);
                return Boi;
            }
            else if (string.Compare(Data, root.Data.Title) == 0)
            {
                return root;
            }
            return null;
        }

        // This method mainly calls deleteRec()  
        public void deleteKey(string key, string mes)
        {
            _root = deleteRec(_root, key, true, mes);
        }

        Node deleteRec(Node root, string Data, bool trust, string mes)
        {
            if (root == null) { Console.WriteLine("No records found for " + "`" + Data + "'"); return root; }
            if (string.Compare(Data, root.Data.Title) == -1)
            {
                root.Left = deleteRec(root.Left, Data, trust, mes);
            }
            else if (string.Compare(Data, root.Data.Title) == 1)
            {
                root.Right = deleteRec(root.Right, Data, trust, mes);
            }
            else if (string.Compare(Data, root.Data.Title) == 0)
            {
                if (trust)
                {
                    Console.WriteLine(mes+" '"+ root.Data.Title + "' from Movie Collection");
                }
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;
                root.Data.Title = minValue(root.Right);
                root.Right = deleteRec(root.Right, root.Data.Title, false, mes);
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
            Archive.AddMovie(data);
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
            DisplayTree(root.Left);
            count++;
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
