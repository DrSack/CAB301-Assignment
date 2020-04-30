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
        public int count = 0;
        private int track = 0;
        public Node _root;

        public MovieCollection()
        {
            _root = null;
        }

        /*
         
             
        */
        public Movie borrowKey(string key, MovieCollection Movies)
        {
            if(borrowRec(Movies._root, key) == null)
            {
                if(Movies.count > 9)
                {
                    Console.WriteLine("");
                    Console.WriteLine("MAXIMUM OF 10 MOVIES ALLOWED");
                    return null;
                }
                else if (borrowRec(_root, key) == null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("No records found for " + "`" + key + "'");
                    return null;
                }
                else
                {
                    borrowRec(_root, key).Data.View++;
                    Node stuffs = new Node(borrowRec(_root, key).Data);
                    Movie Borrowing = new Movie(stuffs.Data.Title, stuffs.Data.Starring, stuffs.Data.Director, stuffs.Data.Duration, stuffs.Data.Genre, stuffs.Data.Classification, stuffs.Data.ReleaseDate);
                    Borrowing.View++;
                    Console.WriteLine("");
                    Console.WriteLine("Borrowed '" + Borrowing.Title + "' from library collection");
                    return Borrowing;
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("'"+key + "' already exists in your collection");
                return null;
            }
        }

        /* A recursive function to insert a new key in BST */
        public Node borrowRec(Node root, string Data)
        {
            Node Boi = null;
            if (root == null) { return null; }
            if (string.Compare(Data, root.Data.Title) == -1)
            {
                Boi = borrowRec(root.Left, Data);
            }
            else if (string.Compare(Data, root.Data.Title) == 1)
            {
                Boi = borrowRec(root.Right, Data);
            }
            else if (string.Compare(Data, root.Data.Title) == 0)
            {
                return root;
            }
            return Boi;
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
                    Console.WriteLine("");
                    Console.WriteLine(mes+"'"+ root.Data.Title + "' from Movie Collection");
                    count--;
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
        public void Insert(Movie data, bool truth)
        {
            // 1. If the tree is empty, return a new, single node 
            if(borrowRec(_root, data.Title) == null)
            {
                if (_root == null)
                {
                    _root = new Node(data);
                    count++;
                    return;
                }
                else if (count > 9 && truth)
                {
                    Console.WriteLine("");
                    Console.WriteLine("MAXIMUM OF 10 MOVIES ALLOWED");
                }
                else
                {
                    // 2. Otherwise, recur down the tree 
                    InsertRec(_root, new Node(data));
                    Console.WriteLine("");
                    Console.WriteLine(String.Format("Movie '{0}' has been Added to collection press 'ENTER' to continue", data.Title));
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("'" + data.Title + "' already exists in the collection");
            }
            
        }
        private void InsertRec(Node root, Node newNode)
        {
            if (root == null) { count++; root = newNode; }
                

            if (string.Compare(newNode.Data.Title, root.Data.Title) == -1)
            {
                if (root.Left == null) { count++; root.Left = newNode; }
                    
                else
                    InsertRec(root.Left, newNode);

            }
            else
            {
                if (root.Right == null) { count++; root.Right = newNode; }
                    
                else
                    InsertRec(root.Right, newNode);
            }
        }
        private void DisplayTree(Node root)
        {
            if (root == null) { return; };
            DisplayTree(root.Left);
            track++;
            Console.WriteLine("");
            Console.WriteLine(track.ToString() + ".");
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
            track = 0;
        }

        public void DisplayMostPopular()
        {
            Movie temp;
            track = 0;
            Movie[] Display = new Movie[count];
            ObtainRecurssive(_root, Display);
            for(int i = 0; i < Display.Length-1; i++)
            {
                for (int j = i + 1; j < Display.Length; j++)// iterate n^2
                {
                    if (Display[i].View < Display[j].View)// if the count of views is less then the next elements views
                    {
                        temp = Display[i];
                        Display[i] = Display[j];
                        Display[j] = temp;
                    }// Change spots.
                }
            }
            Console.WriteLine("Displays movies with 1 or more views!");
            Console.WriteLine("");
            Console.WriteLine("========Top 10 Most Popular Movies========");
            for (int i = 0; i < 10; i++)
            {
                
                if (Display[i].View > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Title: " + Display[i].Title + " Views: " + Display[i].View);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("==========================================");
            Console.WriteLine("");
            track = 0;
        }

        public void ObtainRecurssive(Node root, Movie[] Display)
        {
            if (root == null) { return; };
            ObtainRecurssive(root.Left, Display);
            Display[track] = root.Data;  track++;
            ObtainRecurssive(root.Right, Display);
        }
    }
}
