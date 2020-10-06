using System;

namespace Open_Lab_03._08
{
    public class Checker
    {
        public bool IsPlural(string word)
        {
            if (word.EndsWith("s"))
                return true;
            else
                return false;
        }
    }
}
