using System;
using System.Collections.Generic;
using System.Text;

namespace Procesi_popis
{
    class Sortiranje : IComparable
    {
        public System.Diagnostics.Process P { get; }
        public Sortiranje(System.Diagnostics.Process p)
        {
            P = p;
        }
        public int CompareTo(object obj)
        {
            Sortiranje dps = (Sortiranje) obj;
            System.Diagnostics.Process drugiProces = dps.P;
            if (P.WorkingSet64 > drugiProces.WorkingSet64)
            {
                return -1;
            } else if (P.WorkingSet64 < drugiProces.WorkingSet64)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
    }
}
