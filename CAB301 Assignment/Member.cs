using System;

namespace CAB301_Assignment
{
    //This is the Member object class which borrows and returns movies, and is able to access the member menu.
    class Member
    {
        //Declare all variables
        public string FullName { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string ResidentialAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public bool PasswordSet { get; set; }

        private MovieCollection Movies;

        //Decalre constructor and set all arguments to the object variables.
        public Member(string givenname, string surname, string residentialaddress, string phonenumber)
        {
            this.GivenName = givenname;
            this.Surname = surname;
            this.ResidentialAddress = residentialaddress;
            this.PhoneNumber = phonenumber;
            this.PasswordSet = false;
            Username = surname + givenname;
            FullName = givenname +" "+ surname;
            Movies = new MovieCollection();
        }

        /*
         paramater: pass = the password that was given from the user input.

         Check whenever the password is the equivalent to what the Member has set the password as.
         OR if there no password set, then set new password as the user input.
             
         return: bool = true or false to determine if the password check has failed or not.
         */

        public bool PasswordCheck(string pass)
        {
            if (!PasswordSet)
            {
                this.Password = pass;
                Console.WriteLine("New Password Set");
                Console.WriteLine("");
                PasswordSet = true;
                return true;
            }
            else if (PasswordSet)
            {
                if(this.Password == pass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /*
         paramater: nothing

         Checks if the member already has a password.
             
         return: bool = true or false to determine if the password has already been set.
         */
        public bool PassRego()
        {
            if (!PasswordSet)
            {
                return true;
            }
            return false;
        }

        /*
         paramater:
         Movies = This is the movie collection to be passed down and accessed for the particular member
         Members = This is to be passed down to be be accessed for a particular member

         Checks if the member already has a password.
             
         return: bool = true or false to determine if the password has already been set.
         */

        public static void Login(MemberCollection Members, MovieCollection Movies)
        {
            bool flag = false;
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("============Member Login===========");
            Console.WriteLine("Please Enter Credentials");
            Console.WriteLine("");
            Member logged;

            string user = Staff.LoopCheck("Username (LastnameFirstname): ");
            string pass = "";
            logged = Members.UserSearch(user);

            try { 
                if (logged.PassRego()) {
                    string value = "";
                    bool link = true;
                    while (link)
                    {
                        link = false;
                        Console.Write("Set New Password (Must be 4 digits): ");
                        value = Console.ReadLine();
                        try
                        {
                            if (value == "")
                            {
                                throw new Exception();
                            }
                            else
                            {
                                if (value.Length != 4)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    Int32.Parse(value);
                                    pass = value;
                                }

                            }
                        }
                        catch { Console.WriteLine("ERROR: Please enter 4 digits"); link = true; }
                    }
                } else { pass = Staff.LoopCheck("Enter Password: ");}
            }
            catch { Console.WriteLine(String.Format("User '{0}' not found", user)); flag = true; }

            if (!flag)
            {
                if (logged.PasswordCheck(pass))
                {
                    Console.WriteLine(String.Format("Succesfully Logged in, Welcome {0}, press 'ENTER' to continue", logged.FullName));
                    Console.ReadLine();
                    logged.MEMBER(Movies);
                }
                else
                {
                    Console.WriteLine("Password Incorrect press 'ENTER' to exit");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.ReadLine();
            }
            Console.Clear();
        }

        /*
        parameters:
        Movies = This is the movie collection to be passed down and accessed within the Member object.

        This displays the Member Menu options, and this also reads the input of the logged member.

        returns: nothing
         */
        private void MEMBER(MovieCollection Movies)
        {
            Console.Clear();
            bool truth = true;
            while (truth)
            {
                Console.WriteLine(string.Format("Welcome '{0}'", FullName));
                Console.WriteLine("============Member Menu===========");
                Console.WriteLine("1. Display all movies");
                Console.WriteLine("2. Borrow a movie DVD");
                Console.WriteLine("3. Return a movie DVD");
                Console.WriteLine("4. List current borrowed movie DVD's");
                Console.WriteLine("5. Display top 10 most popular movies");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("================================");
                Console.Write("Please make a selection (1-5, 0 to exit): ");
                string value = Console.ReadLine();
                try
                {
                    int result = Convert.ToInt32(value);
                    truth = SWITCHMEMBER(result, Movies);
                }
                catch{Console.WriteLine("ERROR: Please try again: "); Console.WriteLine("Please press 'Enter' to continue..."); Console.ReadLine(); }
                Console.Clear();
            }
        }

        /*
         parameters: 
         result = an integer value to determine the switchcase
         Movies = This is the movie collection to be passed down and accessed within the Member object.
             
         This allows staff to traverse throughout the member menu, depending on the choosen number value they have inputted.

         returns: bool = To determine whenever to break out of the MEMBER menu.
        */

        private bool SWITCHMEMBER(int result, MovieCollection Movies)
        {
            switch (result)
            {
                case 1:
                    DisplayMovies(Movies);
                    break;
                case 2:
                    BorrowMovies(Movies);
                    break;
                case 3:
                    ReturnMovies(Movies);
                    break;
                case 4:
                    DisplayMovies(this.Movies);
                    break;
                case 5:
                    DisplayPopularMovies(Movies);
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
         Movies = This is the movie collection to be passed down and accessed within the Member object.
             
         This displays the most Popular Movies withint the community library depending on view count.

         returns: nothing.
        */
        private void DisplayPopularMovies(MovieCollection Movies)
        {
            Console.Clear();
            Movies.DisplayMostPopular();
            Console.WriteLine("Please press 'Enter' to continue...");
            Console.ReadLine();
        }

        /*
         parameters: 
         Movies = This is the movie collection to be passed down and accessed within the Member object.
             
         This displays all of the Movies within the community library.

         returns: nothing.
        */
        private void DisplayMovies(MovieCollection Movies)
        {
            Console.Clear();
            Movies.DisplayTree();
            Console.WriteLine("");
            Console.WriteLine("Please press 'Enter' to continue...");
            Console.ReadLine();
        }

        /*
         parameters: 
         Movies = This is the movie collection to be passed down and accessed within the Member object.
             
         This displays the Borrow Movie screen, and this takes in an input and searches for that movie within the community library, and if found 
         the movie within the community libraries collection, it will add that movie.

         returns: nothing.
        */

        private void BorrowMovies(MovieCollection Movies)
        {
            Console.Clear();
            Console.WriteLine("");
            string value = Staff.LoopEnterCheck("Enter Movie to Borrow or press 'ENTER' to exit: ");
            if(value != "")
            {
               Movie MovVal = Movies.borrowKey(value, this.Movies);
               if (MovVal != null)
               {
                    this.Movies.Insert(MovVal, true,1);
               }
                
                Console.WriteLine("");
                Console.WriteLine("Please press 'Enter' to continue...");
                Console.ReadLine();
            }
        }
        /*
         parameters: 
         Movies = This is the movie collection to be passed down and accessed within the Member object.
             
         This displays the Return Movie screen, and this takes in an input and searches for that movie within this member objects collection, and if found 
         the movie within the members collection will delete that movie found.

         returns: nothing.
        */
        private void ReturnMovies(MovieCollection Movies)
        {
            Console.Clear();
            Console.WriteLine("");
            string value = Staff.LoopEnterCheck("Enter Movie to Return or press 'ENTER' to exit: ");
            if(value != "")
            {
                this.Movies.deleteKey(value, "Returned ");
                try { Movies.borrowRec(Movies._root, value).copies++; } catch { }// try parse and catch, as Movie might of been deleted from staff;
                Console.WriteLine("");
                Console.WriteLine("Please press 'Enter' to continue...");
                Console.ReadLine();
            }
        }
    }
}
