using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommuMoney.METIER.Metier;
using CommuMoney.METIER.Services;


namespace CommuMoney.CONSOLE
{
    class CommuMoney
    {

        //ALGO
        //Demander le nom du projet, l'insérer dans la db, 
        /*Demander le nom des personnes, en les insérant dans la db, et les assigner au projet
         * Dire qui dépense combien
         * 
         * Faire le total, pour chaque personne qui a dépensé dans ce projet, ajouter
         * 
         *Puis diviser ce total par le nombre de gens présent dans le projet
         *
         *Si une personne est en négatif, ça veut dire qu'on lui doit tant d'argent.
         *
         *à l'inverse, si une personnes est en positif dans les dettes, ça veut qu'il doit tant à celui qui est le plus en négatif.
         *
         *Rembourser la personne, en lui donnant le montant max défini par la dette
         */

        public static void Menu()
        {
            string choice = "NaN";
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Bonjour et bienvenue sur CommuMoney !");
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("1. Créer un nouveau compte");
            Console.WriteLine("2. Consulter mon compte");
            Console.WriteLine("\n(q pour quitter)");
            Console.WriteLine("===================================");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewAccount();
                    break;
                case "2":
                    ConsultAccount();
                    break;

                case "q":
                    Environment.Exit(0);
                    break;

                default:
                    Menu();
                    break;
            }
        }

        private static void ConsultAccount()
        {
            string s_idToFetch;
            Console.WriteLine("===================================");
            Console.WriteLine("Pour pouvoir consulter votre compte, veuillez entrer votre N° d'identification :");
            Console.ReadLine();

        }

        #region Créer tout de zéro (compte + projet)


        private static void CreateNewAccount()
        {
            string choice = "0";
            Console.WriteLine("===================================");
            Console.WriteLine("Vous avez choisi de créer un compte ! Commencez par votre prénom :\n");
            var prenom = Console.ReadLine();
            Console.WriteLine("\n Très bien ! Ensuite votre nom :\n");
            var nom = Console.ReadLine();

            var p = new Personnes_METIER(nom, prenom);
            var personneService = new Personnnes_SERVICES();
            personneService.Insert(p);

            Console.WriteLine("===================================\n");
            Console.WriteLine($"Très bien ! Vous êtes inscrit ! Voici vos identifiants, retenez-les bien :\nNom : {p.Nom}\nPrénom : {p.Prenom}\nNuméro d'identification unique (attention TRÈS important) : {p.ID} \n\nMaintenant que voulez-vous faire ?\n");
            Console.WriteLine("1. Créer un nouveau projet\n2.Quitter");


            NextStepAccount(choice, p.ID);

        }

        private static void NextStepAccount(string choice, int IDPersonne)
        {
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateNewProject(IDPersonne);
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    NextStepAccount(choice, IDPersonne);
                    break;
            }
        }

        private static void CreateNewProject(int IDPersonne)
        {
            Console.WriteLine("Comment va s'appeler votre joli projet ?");
            var nomProjet = Console.ReadLine();
            Console.WriteLine("Et combien voulez-vous dépenser pour ce projet ?");
            var s_cout = Console.ReadLine();
            float cout;

            bool parsedCout = float.TryParse(s_cout, out cout);

            while (!parsedCout)
            {
                Console.WriteLine("Veuillez entrer une valeur valable");
                s_cout = Console.ReadLine();
                parsedCout = float.TryParse(s_cout, out cout);
            }



            var projet = new Projet_METIER(nomProjet, IDPersonne, cout, cout, DateTime.Now);

            var depense = new Depenses_METIER(IDPersonne, projet.ID, cout);



            var DepenseService = new Depenses_SERVICE();
            DepenseService.Insert(depense);


            var ProjetService = new Projet_SERVICE();
            ProjetService.Insert(projet);



            Console.WriteLine("===================================");
            Console.WriteLine($"Fort bien, vous avez créé votre projet !\nParlez-en à vos amis pour qu'ils s'y ajoutent !");
            for (int a = 2; a >= 0; a--)
            {
                Console.CursorLeft = 3;
                Console.WriteLine($"\nRetour au menu principal dans {a + 1}");
                System.Threading.Thread.Sleep(1000);
            }
            Menu();

        }
        #endregion



        public static void Main(string[] args)
        {
            Menu();
        }
    }
}