using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{
    class Member
    {
        public string FullName { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string ResidentialAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public bool PasswordSet { get; set; }

        private MovieCollection Movies;
        public Member(string givenname, string surname, string residentialaddress, string phonenumber)
        {
            this.GivenName = givenname;
            this.Surname = surname;
            this.ResidentialAddress = residentialaddress;
            this.PhoneNumber = phonenumber;
            this.PasswordSet = false;
            Username = givenname + surname;
            FullName = givenname +" "+ surname;
            Movies = new MovieCollection();
        }

        public void BorrowMovie(Movie movie)
        {
            Movies.Insert(movie);
        }

        public void ReturnMovie(string movie)
        {
            Movies.deleteKey(movie);
        }

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
        
        public bool PassRego()
        {
            if (!PasswordSet)
            {
                return true;
            }
            return false;
        }

        public static void Login(MemberCollection Members, MovieCollection Movies)
        {
            bool flag = false;
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("============Member Login===========");
            Console.WriteLine("Please Enter Credentials");
            Console.WriteLine("");
            Member logged;

            string user = Staff.LoopCheck("Username: ");
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
                    logged.MEMBER(Members, Movies);
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

        private void MEMBER(MemberCollection Members, MovieCollection Movies)
        {
            Console.Clear();
            bool truth = true;
            while (truth)
            {
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
                    truth = SWITCHMEMBER(result, Movies, Members);
                }
                catch { Console.WriteLine("ERROR: Please try again"); Console.WriteLine("Please press 'Enter' to continue..."); Console.ReadLine(); }
                Console.Clear();
            }
        }
        private static bool SWITCHMEMBER(int result, MovieCollection Movies, MemberCollection Members)
        {
            switch (result)
            {
                case 1:
                    Console.Clear();
                    Movies.DisplayTree();
                    Console.WriteLine("");
                    Console.WriteLine("Please press 'Enter' to continue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Borrow a movie DVD");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Return a movie DVD");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("List current borrowed movie DVD's");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Display top 10 most popular movies");
                    Console.ReadLine();
                    break;
                case 0:
                    return false;
                default:
                    throw new Exception();
            }
            return true;
        }
    }
}
