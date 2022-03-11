using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entities
{
    internal class Task
    {

        public string Descrizione { get; set; } 
        public DateTime Scadenza { get; set; } 
        public Int32 Priorità { get; set; } 


        public override string ToString()
        {
           
            return $" Descrizione: {Descrizione} - Scadenza: {Scadenza.ToShortDateString()}" +
                $" - Priorità: {Priorità} (1 = Alta, 2 = Media, 3 = Bassa)";
        }

    }

    
}
