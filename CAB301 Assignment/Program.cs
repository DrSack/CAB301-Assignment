using System;

namespace CAB301_Assignment
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MovieCollection Movies = new MovieCollection();
            Movies.Insert(new Movie("Cool", "So", "What", 1.5f, "Drama", "G", "13/02/1998"));
            MemberCollection Members = new MemberCollection();
            MENU(Movies, Members);
        }

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

        //ROUTE TO OTHER MENUS
        public static int SWITCHMENU(int result, MovieCollection Movies, MemberCollection Members)
        {
            int release = 1;
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
