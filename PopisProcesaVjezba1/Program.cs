using Procesi_popis;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace PopisProcesaVjezba1
{
    class Program
    {
        static void Main(string[] args)
        {

            Process[] popisProcesa = Process.GetProcesses();
            for(int i=0; i<popisProcesa.Length; i++)
            {
                for(int j=0; j<popisProcesa.Length; j++)
                {
                    if (popisProcesa[i].WorkingSet64 > popisProcesa[j].WorkingSet64)
                    {
                        var pridrzi = popisProcesa[i];
                        popisProcesa[i] = popisProcesa[j];
                        popisProcesa[j] = pridrzi;
                    }
                } 
            } 
            Console.WriteLine("Popis procesa koji troše najviše memorije: ");
            Console.WriteLine();
            for(int i=0; i<10; i++)
            {
                var p = popisProcesa[i];
                Console.WriteLine("{0, 15:0.000} MB - {1} [{2}]", p.WorkingSet64 / (double)(1024 * 1024), p.ProcessName, p.MainWindowTitle);
            }
            Console.WriteLine();
            Console.WriteLine("Rješenje s listom: \n");
            List<Sortiranje> lista = new List<Sortiranje>();
            foreach(Process p in popisProcesa)
            {
                Sortiranje ps = new Sortiranje(p);
                lista.Add(ps);
            }
            lista.Sort();
            for (int i = 0; i < 10; i++)
            {
                var p = lista[i].P;
                Console.WriteLine("{0, 15:0.000} MB - {1} [{2}]", p.WorkingSet64 / (double)(1024 * 1024), p.ProcessName, p.MainWindowTitle);
            }
        }
    }
}
