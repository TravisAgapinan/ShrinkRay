using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URLShortener.Services
{
    public class UtilityService
    {
        public static string MakeSlug(int size)
        {
            Random random = new Random();
            //Using random() to  pull the characters out of the input string
            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, size)
                //looping thru the above string generating a random number
                //and pulling out character based on the position of the random number as if in an array
                                   .Select(x => input[random.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }
    }
}

