using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csibészkutyák
{
    internal class kutyak
    {
        public int id { get; private set; }
        public int fajta_id { get; private set; }
        public int nev_id { get; private set; }
        public int age { get; private set; }
        public string ellenorzes { get; private set; }

        public kutyak(string sor)
        {
            string[] tomb = sor.Split(';');
            id = int.Parse(tomb[0]);
            fajta_id = int.Parse(tomb[1]);
            nev_id = int.Parse(tomb[2]);
            age = int.Parse(tomb[3]);
            ellenorzes = tomb[4];



        }
    }
}
