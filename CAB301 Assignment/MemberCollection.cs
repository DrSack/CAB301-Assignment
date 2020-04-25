﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{
    class MemberCollection
    {
        Member[] collection;
        public MemberCollection()
        {
            collection = new Member[20];
        }

        public void Insert(Member member)
        {
            for(int i = 0; i < collection.Length; i++)
            {
                if (collection[i] == null)
                {
                    collection[i] = member;
                    break;
                }
            }
        }

        public void DisplayMembers()
        {
            Console.WriteLine("=======Registered Members=======");
            Console.WriteLine("");
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] != null)
                {
                    Console.WriteLine((i+1).ToString()+".");
                    Console.WriteLine(collection[i].FullName);
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("================================");
        }

        public void DisplayNumber(string name)
        {
            bool hit = false;
            Console.WriteLine(String.Format("======User '{0}' Information=====", name));
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] != null)
                {
                    if(collection[i].FullName == name)
                    {
                        hit = true;
                        Console.WriteLine("");
                        Console.WriteLine(String.Format("Residential Address: {0}", collection[i].ResidentialAddress));
                        Console.WriteLine("Phone Number: {0}", collection[i].PhoneNumber.ToString());
                    }
                }
            }
            if (!hit)
            {
                Console.WriteLine();
                Console.WriteLine(String.Format("Member '{0}' does not exist", name));
            }
            Console.WriteLine("");
            Console.WriteLine("=================================");
        }

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
