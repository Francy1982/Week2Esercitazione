using System;
using ConsoleApp1.Entities;
using System.Collections;

namespace ConsoleApp1
{
    internal class Program
    {

        //Domanda 1 
                    //a) inizializzazione
                    //b) dichiarazione
                    //c) assegnazione
        
        //Domanda 2
                    // b) 
        
        //Domanda 3
                    //c)

        //Domanda 4
                    //c)



        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto in Agenda");

            bool continua = true;
            Task taskDaAggiungere = new Task();
            Task taskDaEliminare = new Task();
            ArrayList Agenda = new ArrayList();

            while (continua)

            {
                string scelta = Menu();
                switch (scelta)
                {
                    case "1":
                        //Visualizza gli eventi in agenda
                        
                        Console.WriteLine("Ecco gli eventi nella tua Agenda:\n");
                        GestioneAgenda.PrintAgenda(Agenda);
                        
                            break;
                        
                    case "2":
                        // Inserisci un nuovo evento
                        
                        taskDaAggiungere = GestioneAgenda.CreaNuovoTask();
                        Agenda.Add(taskDaAggiungere);
                        Console.WriteLine("Evento aggiunto con successo");
                        break;
                    case "3":
                        //Salva gli eventi su file agenda.txt

                        GestioneAgenda.StampaEventiSuFile(Agenda);
                        Console.WriteLine("Eventi salvati correttamente");
                        break;
                    case "4":
                        //Elimina evento
                        
                        Console.WriteLine("Inserire descrizione evento che si vuole eliminare");
                        string descrizione = Console.ReadLine();
                        GestioneAgenda.EliminaEvento(Agenda, descrizione);  
                        break;
                    case "5":
                        //Ordina gli eventi per priorità
         
                        Console.WriteLine("I tuoi eventi in ordine di priorità:");
                        GestioneAgenda.Riordina(Agenda);
                        break;
                    case "6":
                        //Leggi eventi da File
                        Console.WriteLine("Ecco i tuoi eventi:");
                        Agenda = GestioneAgenda.LeggiEventiDaFile();
                        GestioneAgenda.PrintAgenda(Agenda);
                        break;
                    case "0":
                        //Esci

                        continua = false;
                        Console.WriteLine("Arrivederci");
                        break;
                        
                }
            }


        }

        public static string Menu()
        {
            
            Console.WriteLine("\nScegli un'opzione dal Menu");
            Console.WriteLine("");
            Console.WriteLine("1. Visualizza gli eventi in agenda");
            Console.WriteLine("2. Inserisci un nuovo evento");
            Console.WriteLine("3. Salva eventi");
            Console.WriteLine("4. Elimina evento");
            Console.WriteLine("5. Ordina gli eventi per livello di priorità ");
            Console.WriteLine("6. Leggi gli eventi dall'agenda");
            Console.WriteLine("0. Esci");
            string scelta = Console.ReadLine();
                
            return scelta;
        }
    }
}
