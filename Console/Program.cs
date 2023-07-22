using Bibliotheque.DAL;
using Bibliotheque.entity;
using System;
using System.Linq;

namespace Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContextDA context = new ContextDA();
                foreach (Statut item in context.Statuts.ToArray())
                {
                    System.Console.WriteLine(item.ToString());
                }
                foreach (Employe item in context.Employes.ToArray())
                {
                    System.Console.WriteLine(item.ToString());
                }
                foreach (Experience item in context.Experiences.ToArray())
                {
                    System.Console.WriteLine(item.ToString());
                }
                foreach (Formation item in context.Formations.ToArray())
                {
                    System.Console.WriteLine(item.ToString());
                }
                foreach (Offre item in context.Offres.ToArray())
                {
                    System.Console.WriteLine(item.ToString());
                }
                foreach (Postulation item in context.Postulations.ToArray())
                {
                    System.Console.WriteLine(item.ToString());
                }
            } catch(Exception ex)
            {
                System.Console.WriteLine(ex.ToString()); 
            }
        }
    }
}
