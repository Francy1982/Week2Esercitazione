using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConsoleApp1.Entities;


namespace ConsoleApp1
{
    internal class GestioneAgenda
    {
        /// <summary>
        /// Aggiunge un nuovo evento all'agenda
        /// </summary>
        /// <returns>restituisce l'evento aggiunto </returns>
        public static Task CreaNuovoTask()
        {
            Task nuovoTask = new Task();


            Console.WriteLine("Inserisci la descrizione dell'evento da inserire:");
            string descrizione = Console.ReadLine();
            nuovoTask.Descrizione = descrizione;

            Console.WriteLine("Inserisci data di scadenza dd/mm/aaaa");
            bool bene = DateTime.TryParse(Console.ReadLine(), out DateTime scadenza);
            while (!bene)
            {
                Console.WriteLine("Inserisci data di scadenza dd/mm/aaaa:");
                bene = DateTime.TryParse(Console.ReadLine(), out scadenza);
            }
            nuovoTask.Scadenza = scadenza;

            Console.WriteLine("Inserisci livello di priorità: 1 = alta, 2 = media, 3 = bassa");
            bool priority = Int32.TryParse(Console.ReadLine(), out Int32 priorità);
            while (!priority)
            {
                Console.WriteLine("Priorità errata");
                Console.WriteLine("Inserisci livello di priorità: 1 = alta, 2 = media, 3 = bassa");
                priority = Int32.TryParse(Console.ReadLine(), out priorità);
            }

            nuovoTask.Priorità = priorità;

            return nuovoTask;

        }
        /// <summary>
        /// Elimina un evento dall'agenda, se lo trova
        /// </summary>
        /// <param name="Agenda"> Agenda da cui eliminare l'evento </param>
        /// <param name="descrizione"> descrizione dell'evento da cercare e eliminare</param>
        public static void EliminaEvento(ArrayList Agenda, string descrizione)
        {

            foreach (Task eventoDaEliminare in Agenda)
                if (eventoDaEliminare.Descrizione == descrizione)
                {
                    Agenda.Remove(eventoDaEliminare);
                    Console.WriteLine("Evento eliminato");
                    return;
                }
                    
            Console.WriteLine("Evento non trovato");

        }
        /// <summary>
        /// Stampa a video tutti gli eventi dell'agenda
        /// </summary>
        /// <param name="Agenda"> Agenda da cui stampare gli eventi </param>
        public static void PrintAgenda(ArrayList Agenda)
        {
            if (Agenda.Count == 0)
                Console.WriteLine("Non ci sono eventi in programma");
            else
                foreach (Task evento in Agenda)
                    StampaEvento(evento);


        }
        /// <summary>
        /// Stampa a video l'evento 
        /// </summary>
        /// <param name="evento"> evento da stampare </param>
        public static void StampaEvento(Task evento)
        {
            Console.WriteLine(evento);
        }

        /// <summary>
        /// Riordina gli eventi dell'agenda in base alla priorità: alta, media e bassa
        /// </summary>
        /// <param name="Agenda"></param>
        public static void Riordina(ArrayList Agenda)
        {
            Console.WriteLine("Da fare");
        }

        public static void StampaEventiSuFile(ArrayList Agenda)
        {
            //Mi faccio restituire il percorso desktop con il file agenda.txt
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "agenda.txt");
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Task eventoDaStampareSuFile in Agenda)
                {
                    //sw.WriteLine($"Nome: {personaDaStampareSuFile.Nome} - ");
                    sw.WriteLine(eventoDaStampareSuFile);
                }
            }
        }

        public static ArrayList LeggiEventiDaFile()
        {
            ArrayList eventiCaricatiDaFile = new ArrayList();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "agenda.txt");
            string line;
            using (StreamReader sr = File.OpenText(path))
            {
                line = sr.ReadLine();
                while (line != null) //finchè c'è qualcosa da leggere nel file vado avanti
                {
                    string[] Evento = line.Split('-');
                    string descrizione = Evento[0];
                    string scadenza = Evento[1];
                    DateTime.TryParse(Evento[1], out DateTime dataScadenza);
                    string priority = Evento[2];
                    Int32.TryParse(Evento[2], out Int32 priorità);

                    Task e = new Task()
                    {
                        Descrizione = descrizione,
                        Scadenza = dataScadenza,
                        Priorità = priorità
                    };
                    eventiCaricatiDaFile.Add(e);
                    line = sr.ReadLine();
                }
            }

            return eventiCaricatiDaFile;
        }




    }


}

