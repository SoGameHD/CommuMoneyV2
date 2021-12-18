using System;
using System.Collections.Generic;
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
            Console.WriteLine("2. Se connecter");
            Console.WriteLine("\n(q pour quitter)");
            Console.WriteLine("===================================");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewAccount();
                    break;
                case "2":
                    ConnectAccount();
                    break;

                case "q":
                    Environment.Exit(0);
                    break;

                default:
                    Menu();
                    break;
            }
        }

        private static void ConnectAccount()
        {
            string s_idToFetch;
            int idToFetch;
            Console.WriteLine("===================================");
            Console.WriteLine("Pour pouvoir consulter votre compte, veuillez entrer votre N° d'identification :");
            Console.WriteLine("\"Au secours ! Je ne connais plus mon N° d'identification !\" Pas de soucis, tapez \"help\"");
            s_idToFetch = Console.ReadLine();

            if (s_idToFetch == "help")
                RecoverAccount();

            bool ParsedID = int.TryParse(s_idToFetch, out idToFetch);
            while (!ParsedID)
            {
                Console.WriteLine("Veuillez entrer un numéro d'identification valide (pas de virgules, ni plusieurs chiffres espacés");
                s_idToFetch = Console.ReadLine();
                ParsedID = int.TryParse(s_idToFetch, out idToFetch);
            }
            Console.WriteLine("Vous êtes connecté(e) !");
            Console.WriteLine("Que voulez-vous faire à présent ?");
            NextStepConnectedAccount();
        }

        private static void NextStepConnectedAccount()
        {
            throw new NotImplementedException();
        }

        private static void ConsultAccount()
        {
            
            
            var SearchPerson = new Personnnes_SERVICES();
            Personnes_METIER p = SearchPerson.GetByID(idToFetch);
            
            var DepenseOfPerson = new Depenses_SERVICE();
            Depenses_METIER dep = DepenseOfPerson.GetByIDPerson(idToFetch);


            var ProjectOfPerson = new Personnnes_SERVICES();
            List<Projet_METIER> ListProjOfPerson = ProjectOfPerson.GetProjectByPersonID(idToFetch);

            var RemboursmeentOfPerson = new Remboursement_SERVICE();
            Remboursement_METIER rem = RemboursmeentOfPerson.GetByIDPerson(idToFetch);

            foreach (var Project in ListProjOfPerson)
            {
                Console.WriteLine("===================================");

                double Debt = rem.Dette;
                Console.WriteLine("Voici votre avancement :");
                Console.WriteLine($"Vous avez dépensé {dep.Montant} sur le projet {}, qui se finit le {datefinprojet}");
                //Check si on doit de l'argent OU si on doit se faire rembourser
                if (Debt < 0.0)
                    Console.WriteLine($"On vous doit {Math.Abs(Debt)}€ ");//Savoir QUI nous doit de l'argent

                if (Debt > 0.0)
                    Console.WriteLine($"Vous devez {Debt}€");//Savoir à QUI on doit de l'argent

                if (Debt == 0.0)
                    Console.WriteLine("Personne ne vous doit rien, soit car vous êtes seul dans le projet, soit tous les remboursements on été effectués.");

                Console.WriteLine("===================================");

            }



        }

        private static void RecoverAccount()
        {
            throw new NotImplementedException();
        }

        #region Créer tout de zéro (compte + projet) A CORRIGER


        private static void CreateNewAccount()
        {
            string choice = "0";
            Console.WriteLine("===================================");
            Console.WriteLine("Vous avez choisi de créer un compte ! Commencez par votre prénom :\n");
            var prenom = Console.ReadLine();
            Console.WriteLine("\n Très bien ! Ensuite votre nom :\n");
            var nom = Console.ReadLine();
            int id;
            var p = new Personnes_METIER(nom, prenom);
            var personneService = new Personnnes_SERVICES();
            personneService.Insert(p);
            var IdPersonne = personneService.GetAll();//TODO: ALEDDD
            Console.WriteLine("===================================\n");
            Console.WriteLine($"Très bien ! Vous êtes inscrit ! Voici vos identifiants, retenez-les bien :\nNom : {p.Nom}\nPrénom : {p.Prenom}\nNuméro d'identification unique (attention TRÈS important) : {p.ID} Ca marche pas ptdr\n\nMaintenant que voulez-vous faire ?\n");
            Console.WriteLine("1. Créer un nouveau projet\n2.Quitter\n3.Retourner au menu principal");


            NextStepCreateAccount(choice, p.ID);

        }

        private static void NextStepCreateAccount(string choice, int IDPersonne)
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
                case "3":
                    Menu();
                    break;
                default:
                    NextStepCreateAccount(choice, IDPersonne);
                    break;
            }
        }

        private static void CreateNewProject(int IDPersonne)
        {
            Console.WriteLine("Comment va s'appeler votre joli projet ?");
            var nomProjet = Console.ReadLine();
            Console.WriteLine("Et combien voulez-vous dépenser pour ce projet ?");
            var s_cout = Console.ReadLine();
            double cout;

            bool parsedCout = double.TryParse(s_cout, out cout);

            while (!parsedCout)
            {
                Console.WriteLine("Veuillez entrer une valeur valable");
                s_cout = Console.ReadLine();
                parsedCout = double.TryParse(s_cout, out cout);
            }
            Console.WriteLine("Quand sera le jour de votre projet ? Format AAAA-MM-JJ");
            var s_deadline = Console.ReadLine();
            DateTime deadline;

            bool parsedDeadline = DateTime.TryParse(s_deadline, out deadline);
            while (!parsedDeadline)
            {
                Console.WriteLine("Veuillez entrer le format correct (AAAA-MM-JJ)");
                s_deadline = Console.ReadLine();
                parsedDeadline = DateTime.TryParse(s_deadline, out deadline);
            }


            var projet = new Projet_METIER(nomProjet, IDPersonne, cout, cout,deadline);

            var depense = new Depenses_METIER(IDPersonne, projet.ID, cout);

            var remboursement = new Remboursement_METIER(IDPersonne, projet.ID, 0.0);

            var DepenseService = new Depenses_SERVICE();
            DepenseService.Insert(depense);


            var ProjetService = new Projet_SERVICE();
            ProjetService.Insert(projet);

            var RemboursementService = new Remboursement_SERVICE();
            RemboursementService.Insert(remboursement);

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