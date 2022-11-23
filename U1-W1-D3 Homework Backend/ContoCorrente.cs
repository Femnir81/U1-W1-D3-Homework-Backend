using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D3_Homework_Backend
{
    internal class ContoCorrente
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public bool ContoAperto = false;

        public void Menu(ContoCorrente conto)
        {
            if (ContoAperto == false)
            {
                Console.WriteLine("1) Apri un nuovo conto");
                string scelta = Console.ReadLine();
                if (scelta == "1")
                {                 
                    AprireIlConto(conto);
                }                
            } else
            {
                Console.WriteLine("1) Esegui versamento");
                Console.WriteLine("2) Esegui prelievo");
                string scelta = Console.ReadLine();
                if (scelta == "1")
                {
                    Versamento(conto);
                } else if (scelta == "2")
                {
                    Prelievo(conto);
                }
            }
        }

        public void AprireIlConto(ContoCorrente conto)
        {
            if (ContoAperto == false)
            {
            Console.WriteLine("Scrivi il tuo cognome:");
            conto.Cognome = Console.ReadLine();
            Console.WriteLine("Scrivi il tuo nome:");
            conto.Nome = Console.ReadLine();
            conto.Saldo = 0;
            conto.ContoAperto = true;
            Console.WriteLine($"Conto corrente n° 00001234 intestato a: {conto.Cognome} {conto.Nome}");
            VersamentoStart(conto);
            Console.ReadLine();    
            Menu(conto);
            }
        }

        public void Versamento(ContoCorrente conto)
        {
            Console.WriteLine("Digita la cifra che vuoi versare:");
            conto.Saldo += int.Parse(Console.ReadLine());
            Console.WriteLine($"Il tuo saldo attuale è di {conto.Saldo} euro.");
            Menu(conto);
        }

        public void Prelievo(ContoCorrente conto1)
        {
            Console.WriteLine("Digita la cifra che vuoi versare:");
            double conto = int.Parse(Console.ReadLine());
            if (conto1.Saldo - conto <= 0)
            {
                Console.WriteLine($"Il tuo saldo attuale è di {conto1.Saldo} euro, non puoi effettuare il prelievo");
                Menu(conto1);
            }
            else
            {
                conto1.Saldo -= conto;
                Console.WriteLine($"Il tuo saldo attuale è di {conto1.Saldo} euro.");
                Menu(conto1);
            }
        }

        public void VersamentoStart(ContoCorrente conto1)
        {
            Console.WriteLine("Digita la cifra che vuoi versare:");
            double conto = int.Parse(Console.ReadLine());
            if (conto <= 999)
            {
                Console.WriteLine("Non puoi effettuare il prelievo");
                VersamentoStart(conto1);
            }
            else
            {
                conto1.Saldo += conto;
                Console.WriteLine($"Il tuo saldo attuale è di {conto1.Saldo} euro.");
                Menu(conto1);
            }
        }
    }
}
