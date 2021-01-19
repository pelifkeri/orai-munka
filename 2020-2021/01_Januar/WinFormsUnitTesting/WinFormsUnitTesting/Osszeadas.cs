using System;

namespace WinFormsUnitTesting
{
    public static class Matematika
    {
        public static int Osszeadas(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                throw new UresTextboxException();
            }

            return Convert.ToInt32(s1) + Convert.ToInt32(s2);
        }
    }
}
