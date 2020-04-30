using System;

namespace CAB301_Assignment
{
    //This is the Node class which stores the Movie object, and has additional nodes to travese to via left and right nodes.
    public class Node
    {
        public Movie Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int copies { get; set; }
        public Node(Movie data, int copies)
        {
            this.Data = data;
            this.copies = copies;
        }
    }
    class MovieCollection
    {
        public int count = 0;
        private int track = 0;
        public Node _root;

        /*
            parameter: null

            This constructor instantiates the root node, and decalres it as null

            return: nothing
        */
        public MovieCollection()
        {
            _root = null;
        }

        /*
            parameter: key = the input value from Readline(), Movies = the movie collection of a Member Object
             
            This method allows Members to borrow movies from the MovieCollection BST.

            returns: Movie = The movie object from the specific key input from Readline();
        */
        public Movie borrowKey(string key, MovieCollection Movies)
        {
            if(borrowRec(Movies._root, key) == null)
            {
                if(Movies.count > 9)//If the Member collection has 10 Movies already. 
                {
                    Console.WriteLine("");
                    Console.WriteLine("MAXIMUM OF 10 MOVIES ALLOWED");
                    return null;
                }
                else if (borrowRec(_root, key) == null)//If the Movie does not exist.
                {
                    Console.WriteLine("");
                    Console.WriteLine("No records found for " + "`" + key + "'");
                    return null;
                }
                else
                {// If the movie exists, increase the view count of that movie, and return that Movie Object.
                    Node contain = borrowRec(_root, key);
                    if (contain.copies > 0)
                    {//If copies exist for this movie.
                        contain.Data.View++; contain.copies--;
                        Node stuffs = new Node(contain.Data, 1);
                        Movie Borrowing = new Movie(stuffs.Data.Title, stuffs.Data.Starring, stuffs.Data.Director, stuffs.Data.Duration, stuffs.Data.Genre, stuffs.Data.Classification, stuffs.Data.ReleaseDate);
                        Borrowing.View = contain.Data.View;
                        Console.WriteLine("");
                        Console.WriteLine("Borrowed '" + Borrowing.Title + "' from library collection");
                        return Borrowing;
                    }
                    else
                    {//If there are no more copies for this movie.
                        Console.WriteLine("");
                        Console.WriteLine("No more copies for '" + key + "'");
                        return null;
                    }
                }
            }
            else
            {// If the Movie object is already found within the Member collection.
                Console.WriteLine("");
                Console.WriteLine("'"+key + "' already exists in your collection");
                return null;
            }
        }


        /*
        parameter: key = the input value from Readline(), Movies = the movie collection of a Member Object
             
        This method is a recursive function to return a specific Node from the BST

        returns: Movie = The movie object from the specific key input from Readline();
        */

        /*  */
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

        /*
         parameters: key = the search key of the particular Movie object, mes = the message to be sent following a success.

         This method is set the root node to the new root node that does not contain the deleted node.

         returns: nothing.
         */
        
        public void deleteKey(string key, string mes)
        {
            _root = deleteRec(_root, key, true, mes);// Set the root after deleting that specific object
        }

        /*
         parameters: Node = the root node, Data = the search key, trust a boolean value to ensure only 1 message, mes the message to be following success.

         This method is called to recursively travel through each node to find a certain key, if so, it will delete that node.

         returns: Node = new root node.
         */

        Node deleteRec(Node root, string Data, bool trust, string mes)
        {
            if (root == null) { Console.WriteLine("No records found for " + "`" + Data + "'"); return root; }
            if (string.Compare(Data, root.Data.Title) == -1)// go down left
            {
                root.Left = deleteRec(root.Left, Data, trust, mes);
            }
            else if (string.Compare(Data, root.Data.Title) == 1)// go to right
            {
                root.Right = deleteRec(root.Right, Data, trust, mes);
            }
            else if (string.Compare(Data, root.Data.Title) == 0)// if found
            {
                if (trust)
                {
                    Console.WriteLine("");
                    Console.WriteLine(mes+"'"+ root.Data.Title + "' from Movie Collection");
                    count--;
                }
                if (root.Left == null) { return root.Right; }
                else if (root.Right == null) { return root.Left; }
                root.Data = MinimumValue(root.Right);
                root.Right = deleteRec(root.Right, root.Data.Title, false, mes);
            }
            return root;
        }

        /*
         parameters: Node = the node that is to be replaced.

         This method sets the new next nodes Data values.

         returns: Movie object.
         */
        Movie MinimumValue(Node root)
        {
            Movie min = root.Data;
            while (root.Left != null)
            {
                min = root.Left.Data;
                root = root.Left;
            }
            return min;
        }

        /*
         parameters: data = the recently created movie object, truth = determine if Member or Staff, copies = the number of copies to insert.

         This method sets the new next nodes Data values.

         returns: Movie object.
         */
        public void Insert(Movie data, bool truth, int copies)
        {
            // 1. If the tree is empty, return a new, single node 
            if(borrowRec(_root, data.Title) == null)//if the movie does not exist
            {
                if (_root == null)// if the root is null
                {
                    _root = new Node(data, copies);
                    count++;
                    return;
                }
                else if (count > 9 && truth)// If over maximum amount of movies
                {
                    Console.WriteLine("");
                    Console.WriteLine("MAXIMUM OF 10 MOVIES ALLOWED");
                }
                else
                {
                    //Otherwise use the reccursive method down the tree 
                    InsertRec(_root, new Node(data,copies));
                }
            }
            else
            {//if the movie exists
                Console.WriteLine("");
                Console.WriteLine("'" + data.Title + "' already exists in the collection");
            }
            
        }

        /*
         parameters: root = the root node, newNode = the new node to be inserted.

         This method recurs down the tree and insets the new Node with all its properties into that free node spot.

         returns: Nothing.
         */
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

        /*
         parameters: root = the root node.

         This method recurs down the tree and displays the movie information.

         returns: Nothing.
         */

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
            Console.WriteLine("Copies: " + root.copies);
            Console.WriteLine("Times Viewed: " + root.Data.View);
            DisplayTree(root.Right);
        }

        /*
         parameters: root = the root node.

         This displays the title of the collection and mainly uses the DisplayTree(_root) method to display the rest of the information.

         returns: Nothing.
         */
        public void DisplayTree()
        {
            Console.WriteLine("========Movie Collection========");
            DisplayTree(_root);
            Console.WriteLine("");
            Console.WriteLine("================================");
            Console.WriteLine("");
            track = 0;
        }

        /*
         parameters: nothing

         This displays the top ten most popular movies

         returns: Nothing.
         */
        public void DisplayMostPopular()
        {
            Movie temp;// temporariliy create movie object without anything
            track = 0;// set track to 0
            Movie[] Display = new Movie[count];
            ObtainRecurssive(_root, Display);// Recur down tree and fill array.
            for(int i = 0; i < Display.Length-1; i++)// Bubble Sort array from highest to lowest amount of views
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
            Console.WriteLine("displays movies with 1 or more views!");// Display information
            Console.WriteLine("");
            Console.WriteLine("========Top 10 Most Popular Movies========");
            int aLength;
            if(count > 9) { aLength = 10;  } else { aLength = count;  }// set the iteration length to the count of the current collection of total movie titles, or to 10 if it exceeds the maximum.
            for (int i = 0; i < aLength; i++)
            {
                if (Display[i].View > 0)// If the Movie has more than 0 views, then display the information
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

        /*
         parameters: root = the root node, Display = the array that will be used to dispaly all the the most popular movies

         This method recurs down the tree and adds every node to an array. To then be sorted and displayed, showing the top ten most viewed movies.

         returns: Nothing.
         */

        public void ObtainRecurssive(Node root, Movie[] Display)
        {
            if (root == null) { return; };
            ObtainRecurssive(root.Left, Display);
            Display[track] = root.Data;  track++;
            ObtainRecurssive(root.Right, Display);
        }
    }
}
