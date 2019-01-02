﻿namespace Blazor_Traffic.Client.Helpers
{
    using System.Collections.Generic;

    public class CustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int xVal, yVal;
            var xIsVal = int.TryParse(x, out xVal);
            var yIsVal = int.TryParse(y, out yVal);

            if (xIsVal && yIsVal)   // both are numbers...
                return xVal.CompareTo(yVal);
            if (!xIsVal && !yIsVal) // both are strings...
                return x.CompareTo(y);
            if (xIsVal)             // x is a number, sort first
                return -1;
            return 1;               // x is a string, sort last
        }
    }
}
