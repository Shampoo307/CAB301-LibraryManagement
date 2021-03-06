﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_LibraryManagement
{
    // ARRAY TO STORE
    class MemberCollection
    {

        public Member[] members = new Member[15];
        public bool membersRegistered = false;

        public int AddMember(Member member)
        {
            if (!membersRegistered)
            {
                members[0] = member;
                membersRegistered = true;
                return 0;
            } 
            else
            {
                // Check each user spot before adding
                for (int i = 0; i < members.Length; i++)
                {
                    if (members[i] == null)
                    {
                        member.Index = i;
                        members[i] = member;
                        return i;
                    }
                }
            }
            // Unable to add user
            return -1;
        }

        public bool MemberAlreadyExists(Member member)
        {
            for (int i = 0; i < members.Length; i++)    // Sequential search
            {
                if (members[i]?.FullName == member.FullName)
                {
                    return true;
                }
            }
            return false;
        }

        public int SearchMembers(string fullName)
        {
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i] != null)
                {
                    if (members[i].FullName == fullName)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public int ValidateLogin(string memberUser, string memberPass)
        {

            for (int i = 0; i < members.Length; i++)    // Sequential Search
            {
                if (members[i] != null)
                {
                    if (memberUser == members[i].UserName
                    && memberPass == members[i].Password)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

    }
}
