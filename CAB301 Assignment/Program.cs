using System;

namespace CAB301_Assignment
{
    //This is the main program class, this is where the entire program is executed.
    class Program
    {
        /*
        paramters: None
             
        Runs main and executes the program.

        returns: Nothing
        */
        static void Main()
        {
            MovieCollection Movies = new MovieCollection();
            Movies.Insert(new Movie("B", "0", "0", 1.5f, "Drama", "G", "1998"), false, 2);
            Movies.Insert(new Movie("F", "1", "1", 1.5f, "Drama", "G", "1998"), false,2);
            Movies.Insert(new Movie("C", "2", "2", 1.5f, "Drama", "G", "1999"), false,1);
            Movies.Insert(new Movie("G", "2", "2", 1.5f, "Drama", "G", "1999"), false, 1);
            Console.Clear();
            MemberCollection Members = new MemberCollection();
            MENU(Movies, Members);
        }

        /*
        paramters: 
        Movies = This is the movie collection to be passed down and accessed throughout the program
        Members = This is to be passed down to be be accessed throughout the program
             
        displays the Main Menu and allows staff or members to traverse through the system.

        returns: Nothing
        */

        static void MENU(MovieCollection Movies, MemberCollection Members)
        {
            int truth = 1;
            while (truth >= 1)
            {
                truth = 1;
                Console.WriteLine("Welcome to the Community Library");
                Console.WriteLine("============Main Menu===========");
                Console.WriteLine("1. Staff Login");
                Console.WriteLine("2. Member Login");
                Console.WriteLine("0. Exit");
                Console.WriteLine("================================");
                Console.Write("Please make a selection (1-2, 0 to exit): ");
                string value = Console.ReadLine();

                try
                {
                    int result = Convert.ToInt32(value);
                    truth = SWITCHMENU(result, Movies, Members);
                }
                catch { Console.WriteLine("ERROR: Please try again"); }
                Console.WriteLine("Please press any key to continue...");

                if (truth == 1)
                {
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }

        /*
         parameters: 
         result = an integer value to determine the switchcase
         Movies = The Binary Search Tree to be passed down and accessed.
         Members = The array of members to be passed and accessed.
             
         This allows staff and members to traverse throughout the program, depending on the choosen number value they have inputted.

         returns: int = To determine readline status on the 'MENU' method.
             
        */
        public static int SWITCHMENU(int result, MovieCollection Movies, MemberCollection Members)
        {
            int release;
            switch (result)
            {
                case 1:
                    Console.Clear();
                    Staff.LOGIN(Movies, Members);
                    release = 2;
                    break;
                case 2:
                    Console.Clear();
                    Member.Login(Members, Movies);
                    release = 2;
                    break;
                case 0:
                    release = 0;
                    break;
                default:
                    throw new Exception();
            }
            return release;
        }

    }


    
}
