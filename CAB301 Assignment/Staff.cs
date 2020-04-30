using System;

namespace CAB301_Assignment
{
    //This is the Staff class and this is where movies are added or removed, and where staff members can add new members or view contact details.
    class Staff
    {
        /*
        paramters: 
        Movies = This is the movie collection to be passed down and accessed within the Staff class
        Members = This is to be passed down to be be accessed within the Staff class

        Authentication for logging into the Staff menu.

        returns: nothing
             
        */
        public static void LOGIN(MovieCollection Movies, MemberCollection Members)
        {
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("============Staff Login===========");
            Console.WriteLine("Please Enter Credentials");

            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();
            try
            {
                LOGINCHECK(user, pass, Movies, Members);
            }
            catch { Console.WriteLine("ERROR: Incorrect Credentials"); Console.ReadLine(); }
            Console.Clear();
        }


        /*
        paramters:
        user = The username field.
        pass = The password field.
        Movies = This is the movie collection to be passed down and accessed within the Staff class
        Members = This is to be passed down to be be accessed within the Staff class

        This is to validate if the provided inputs are correct.     
            
        returns: nothing
        */

        public static void LOGINCHECK(string user, string pass, MovieCollection Movies, MemberCollection Members)
        {
            if (user == "staff" && pass == "today123")
            {
                STAFF(Movies, Members);
            }
            else
            {
                throw new Exception();
            }
        }

        /*
        parameters:
        Movies = This is the movie collection to be passed down and accessed within the Staff class
        Members = This is to be passed down to be be accessed within the Staff class

        This displays the Staff Menu options, and this also reads the input of the staff member.

        returns: nothing

         */

        static void STAFF(MovieCollection Movies, MemberCollection Members)
        {
            Console.Clear();
            bool truth = true;
            while (truth)
            {
                Console.WriteLine("============Staff Menu===========");
                Console.WriteLine("1. Add a new movie DVD");
                Console.WriteLine("2. Remove a movie DVD");
                Console.WriteLine("3. Register a new Member");
                Console.WriteLine("4. Find a registered member's phone number");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("================================");
                Console.Write("Please make a selection (1-4, 0 to exit): ");
                string value = Console.ReadLine();

                try
                {
                    int result = Convert.ToInt32(value);
                    truth = SWITCHSTAFF(result, Movies, Members);
                }
                catch { Console.WriteLine("ERROR: Please try again"); Console.WriteLine("Please press 'Enter' to continue..."); Console.ReadLine();}
                Console.Clear();
            }
        }

        /*
         parameters: 
         result = an integer value to determine the switchcase
         Movies = The Binary Search Tree to be passed down and accessed.
         Members = The array of members to be passed and accessed.
             
         This allows staff to traverse throughout the staff menu, depending on the choosen number value they have inputted.

         returns: int = To determine readline status on the 'MENU' method.
        */

        public static bool SWITCHSTAFF(int result, MovieCollection Movies, MemberCollection Members)
        {
            switch (result)
            {
                case 1:
                    AddMovie(Movies);
                    break;
                case 2:
                    RemoveMovie(Movies);
                    break;
                case 3:
                    RegisterMember(Members);
                    break;
                case 4:
                    MemberSearch(Members);
                    break;
                case 0:
                    return false;
                default:
                    throw new Exception();
            }
            return true;
        }

        /*
         parameters: 
         Members = The array of members to be passed and accessed.
             
         This displays the MemberSearch function where it takes an input and searches through the 
         MemberCollection array for contact details depending on the name given.

         returns: nothing
        */

        public static void MemberSearch(MemberCollection Members)
        {
            Console.Clear();
            Members.DisplayMembers();
            bool SearchCatch = true;
            while (SearchCatch)
            {
                SearchCatch = false;
                Console.Write("Enter Member's Fullname to 'search' for Contact Information or press 'ENTER' to exit: ");
                string name = Console.ReadLine();
                try
                {
                    if (name != "")
                    {
                        Console.Clear();
                        Members.DisplayNumber(name);
                        Console.WriteLine("");
                        Console.WriteLine("press 'ENTER' to continue");
                        Console.ReadLine();
                    }
                }
                catch { Console.WriteLine("ERROR: Please enter valid input"); SearchCatch = true; }
            }
        }

        /*
         parameters: 
         Members = The array of members to be passed and accessed.
             
         This displays the RegisterMember function where several inputs are taken to create a new Member

         returns: nothing
        */
        public static void RegisterMember(MemberCollection Members)
        {
            bool truth = true;
            while (truth)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("============Add Member==========");
                string GivenName = LoopCheck("Enter Given Name: ");
                string Surname = LoopCheck("Enter Surname: ");
                string ResidentialAddress = LoopCheck("Enter Residential Address: ");
                string PhoneNumber = "";

                bool NumberCatch = true;
                while (NumberCatch)
                {
                    NumberCatch = false;
                    Console.Write("Enter valid Phone Number: ");
                    string number = Console.ReadLine();

                    try { Int32.Parse(number); PhoneNumber = number; } catch { Console.WriteLine("ERROR: Please enter valid input"); NumberCatch = true; }
                }

                bool RestartCatch = true;
                while (RestartCatch)
                {
                    RestartCatch = false;
                    Console.Write("Restart (0), Add (1): ");
                    string restart = Console.ReadLine();
                    try
                    {
                        int value = Int32.Parse(restart);
                        if (value == 0)
                            truth = true;
                        else if (value == 1)
                        {
                            if (Members.Insert(new Member(GivenName, Surname, ResidentialAddress, PhoneNumber)))
                            {
                                Console.WriteLine();
                                Console.WriteLine(String.Format("Member '{0} {1}' has been added press 'ENTER' to continue", GivenName, Surname));
                                
                            }
                            Console.ReadLine();
                            truth = false;
                        }
                        else { throw new Exception(); }
                    }
                    catch { Console.WriteLine("ERROR: Please enter valid input"); RestartCatch = true; }
                }
            }
        }

        /*
         parameters: 
         Movies = Contains a binary search tree of Movie objects that are to be passed and accessed.
             
         This displays the RemoveMovie function where an input is taken and is searched through the BST of Movies, and promptly deletes that Movie.

         returns: nothing
        */

        public static void RemoveMovie(MovieCollection Movies)
        {
            Console.Clear();
            Movies.DisplayTree();
            bool RemoveCatch = true;
            while (RemoveCatch)
            {
                RemoveCatch = false;
                Console.Write("Enter Movie Title to remove from Collection or press 'ENTER' to exit: ");
                string title = Console.ReadLine();
                try { if (title != "") { Movies.deleteKey(title, "Removed ");
                        Console.WriteLine("");
                        Console.WriteLine("press 'ENTER' to continue");
                        Console.ReadLine(); 
                    } 
                } catch { Console.WriteLine("ERROR: Please enter valid input"); RemoveCatch = true; }
            }
        }

        /*
         parameters: 
         Movies = Contains a binary search tree of Movie objects that are to be passed and accessed.
             
         This displays the AddMovie function where several inputs are taken and a new Movie Object is added into the BST.

         returns: nothing
        */
        public static void AddMovie(MovieCollection Movies)
        {
            bool truth = true;
            while (truth)
            {
                Console.Clear();
                truth = false;
                string Title;
                string Starring;
                string Director;
                string ReleaseDate = "";
                string Genre = "";
                string Classification = "";
                float Duration = 0;
                int Copies = 0;

                Console.WriteLine("============Add Movie===========");
                Title = LoopCheck("Enter Title: ");
                Starring = LoopCheck("Enter Starring Role: ");
                Director = LoopCheck("Enter Director: ");

                bool DurationCatch = true;
                while (DurationCatch)
                {
                    DurationCatch = false;
                    Console.Write("Enter Duration in hours (e.g 1h30m is 1.5): ");
                    string duration = Console.ReadLine();

                    try { Duration = float.Parse(duration); } catch { Console.WriteLine("ERROR: Please enter valid input"); DurationCatch = true; }
                }

                bool GenreCatch = true;
                while (GenreCatch)
                {
                    GenreCatch = false;
                    Console.Write("Enter Genre (Drama, Adventure, Family, Action, Sci-Fi, Comedy, Animated, Thriller, or Other): ");
                    string genre = Console.ReadLine();
                    try
                    {
                        if (genre == "Drama" || genre == "Adventure" || genre == "Family" ||
                            genre == "Action" || genre == "Sci-Fi" || genre == "Comedy" ||
                            genre == "Animated" || genre == "Thriller" || genre == "Other")
                            Genre = genre;
                        else { throw new Exception(); }
                    }
                    catch { Console.WriteLine("ERROR: Please enter valid input"); GenreCatch = true; }

                }

                bool ClassificationCatch = true;
                while (ClassificationCatch)
                {
                    ClassificationCatch = false;
                    Console.Write("Enter Classification (General (G), Parental Guidance (PG)), Mature (M15+), Mature Accompanied (MA15+): ");
                    string clas = Console.ReadLine();
                    try
                    {
                        if (clas == "G" || clas == "PG" || clas == "M15+" ||
                            clas == "MA15+")
                            Classification = clas;
                        else { throw new Exception(); }
                    }
                    catch { Console.WriteLine("ERROR: Please enter valid input"); ClassificationCatch = true; }

                }

                bool ReleaseCatch = true;
                while (ReleaseCatch)
                {
                    ReleaseCatch = false;
                    Console.Write("Enter Release Year: ");
                    string year = Console.ReadLine();

                    try { Int32.Parse(year); ReleaseDate = year; } catch { Console.WriteLine("ERROR: Please enter valid input"); ReleaseCatch = true; }
                }

                bool CopiesCatch = true;
                while (CopiesCatch)
                {
                    CopiesCatch = false;
                    Console.Write("Enter number of copies: ");
                    string copies = Console.ReadLine();

                    try { Copies = Int32.Parse(copies); if (Copies <= 0) { throw new Exception(); } } catch { Console.WriteLine("ERROR: Please enter valid input"); CopiesCatch = true; }
                }

                Console.WriteLine("");
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Starring: " + Starring);
                Console.WriteLine("Directed by: " + Director);
                Console.WriteLine("Length: " + Duration.ToString() +" hours");
                Console.WriteLine("Genre: " + Genre);
                Console.WriteLine("Classification: " + Classification);
                Console.WriteLine("Release Date: " + ReleaseDate);
                Console.WriteLine("Copies: " + Copies);
                Console.WriteLine("");

                bool RestartCatch = true;
                while (RestartCatch)
                {
                    RestartCatch = false;
                    Console.Write("Restart (0), Add (1): ");
                    string restart = Console.ReadLine();
                    try
                    {
                        int value = Int32.Parse(restart);
                        if (value == 0)
                            truth = true;
                        else if (value == 1)
                        {
                            Movies.Insert(new Movie(Title, Starring, Director, Duration, Genre, Classification, ReleaseDate),false,Copies);
                            Console.WriteLine("");
                            Console.WriteLine(String.Format("Movie '{0}' has been Added to collection press 'ENTER' to continue", Title));
                            Console.ReadLine();
                            truth = false;
                        }
                        else{throw new Exception();}
                    }
                    catch { Console.WriteLine("ERROR: Please enter valid input"); RestartCatch = true; }
                }
            }
            
        }
        /*
        parameters: 
        message = The string message to be displyed on screen

        A reusabe function to essentially throw an exeception whenever nothing is inputted for a readline. 

        returns: string = the Readline() value
       */
        public static string LoopCheck(string message)
        {
            string value = "";
            bool link = true;
            while (link)
            {
                link = false;
                Console.Write(message);
                value = Console.ReadLine();

                try { if (value == "") { throw new Exception(); } } catch { Console.WriteLine("ERROR: Please enter valid input"); link = true; }
            }
            return value;
        }

        /*
        parameters: 
        message = The string message to be displyed on screen

        A reusabe function to progress through the function normally without handling any errors. 

        returns: string = the Readline() value
       */
        public static string LoopEnterCheck(string message)
        {
            Console.Write(message);
            string value = Console.ReadLine();
            return value;
        }
    }
}
