using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class element
    {
        public int num;
        public string name;
        public element Next;
        public element()
        {
        }

        public element(int n, string s)
        {
            num = n;
            name = s;
        }
        
    }
}
