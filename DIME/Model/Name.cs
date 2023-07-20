using System;
using System.Collections.Generic;
using System.Text;

namespace DIME.Model
{
    public class Name
    {
        public string first { get; set; }
        public string last { get; set; }

        public override string ToString()
        {
            return first + " " + last;
        }
    }
}
