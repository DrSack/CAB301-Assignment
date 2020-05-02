using System;

namespace CAB301_Assignment
{
    //This is the MemberCollection class, which stores Member objects into an array.
    class MemberCollection
    {
        Member[] collection;//Declare all variables
        
        //Declare constructor and allow for up to 10 members to be added.
        public MemberCollection()
        {
            collection = new Member[10];
        }

        /*
         parameter:
         member = pass a member object.

         Insert a new member object into the array. 
         If a member already exists return with error. If there is no more space, return with error.

         return: bool = either true or false depending on the outcome.
        */

        public bool Insert(Member member)
        {
            for(int i = 0; i<collection.Length; i++)//For loop to search through collection
            {
                if(collection[i] != null)//if an element is not null
                {
                    if(collection[i].FullName == member.FullName)// check if that elements Fullname equals the new member object
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ERROR: User already exists");
                        return false;// if so return false and display an error message.
                    }
                }
            }
            if (collection[collection.Length - 1] != null)
            {// If all elements are full, display error and return false.
                Console.WriteLine("");
                Console.WriteLine("ERROR: Maximum of 10 users only");
                return false;
            }
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] == null)
                {// if element is empty, then fill that empty element with the new member object. Then return true.
                    collection[i] = member;
                    return true;
                }
            }
            return false;
        }

        /*
         parameter: nothing

         Displays all of the members, and the assosiated Fullnames.

         return: nothing.
        */
        public void DisplayMembers()
        {
            Console.WriteLine("=======Registered Members=======");
            Console.WriteLine("");
            for (int i = 0; i < collection.Length; i++)// search through entire array.
            {
                if (collection[i] != null)// if an element exists display information
                {
                    Console.WriteLine((i+1).ToString()+".");
                    Console.WriteLine(collection[i].FullName);
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("================================");
        }

        /*
        parameter: name = the input

        Displays the phonenumber/contact details assosiated with the Fullname for that contact number.

        return: nothing.
       */
        public void DisplayNumber(string name)
        {
            bool hit = false;
            Console.WriteLine(String.Format("======User '{0}' Information=====", name));//Display user information
            for (int i = 0; i < collection.Length; i++)//go through array
            {
                if (collection[i] != null)// If the element contains an object
                {
                    if(collection[i].FullName == name)// if that objects equals the name provided as the input.
                    {
                        hit = true;
                        Console.WriteLine("");//Display the contact information
                        Console.WriteLine(String.Format("Residential Address: {0}", collection[i].ResidentialAddress));
                        Console.WriteLine("Phone Number: {0}", collection[i].PhoneNumber.ToString());
                    }
                }
            }
            if (!hit)
            {
                //If none is found display Error message.
                Console.WriteLine();
                Console.WriteLine(String.Format("Member '{0}' does not exist", name));
            }
            Console.WriteLine("");
            Console.WriteLine("=================================");
        }

        /*
        parameter: username = the username that was inputted

        Returns back the member object depending on the username input.

        return: Member = the member object the was found by the username.
       */
        public Member UserSearch(string username)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] != null)
                {
                    if(collection[i].Username == username)
                    {
                       return collection[i];
                    }
                }
            }
            return null;
            
        }
    }
}
