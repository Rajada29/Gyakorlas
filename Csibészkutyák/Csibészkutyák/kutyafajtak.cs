using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csibészkutyák
{
    internal class kutyafajtak
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string originalname { get; private set; }

        public kutyafajtak(string sor)
        {
            string[] tomb = sor.Split(';');
            id = int.Parse(tomb[0]);
            name = tomb[1];
            originalname = tomb[1];

        }
    }
}
