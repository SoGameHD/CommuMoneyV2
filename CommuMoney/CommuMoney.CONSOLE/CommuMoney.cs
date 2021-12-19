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
        private const string Trait = "===========================";
        private const string PetitTrait = "--------------------";

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

        public static double EnsureDouble(string ConsoleReadResult)
        {
            string strToEnsure = ConsoleReadResult;
            double finalDouble;

            bool parsedDouble= double.TryParse(strToEnsure, out finalDouble);

            while (!parsedDouble)
            {
                Console.WriteLine("Veuillez entrer une valeur valable");
                strToEnsure = Console.ReadLine();
                parsedDouble = double.TryParse(strToEnsure, out finalDouble);
            }
            return finalDouble;
        }
        public static int EnsureInt(string ConsoleReadResult)
        {
            string strToEnsure = ConsoleReadResult;
            int finalInt;

            bool parsedInt = int.TryParse(strToEnsure, out finalInt);

            while (!parsedInt)
            {
                Console.WriteLine("Veuillez entrer une valeur valable");
                strToEnsure = Console.ReadLine();
                parsedInt = int.TryParse(strToEnsure, out finalInt);
            }
            return finalInt;
        }


        #region Fonctions de transitions
        private static void NextStepConnectedAccount(int id)
        {
            int saveID = id;
            Console.WriteLine(Trait);

            Console.WriteLine("Que voulez-vous faire à présent ?");
            Console.WriteLine("1. Consulter mes projets en cours");
            Console.WriteLine("2. Ajouter une personne à un de mes projets");
            Console.WriteLine("3. Revenir au menu principal");
            Console.WriteLine(Trait);
            Console.WriteLine("\nq : Quitter");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ConsultAccount(saveID);
                    break;
                case "2":
                    AddPersonToProject(saveID);
                    break;
                case "3":
                    Menu();
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    NextStepConnectedAccount(saveID);
                    break;
            }


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

        #endregion

        public static void Menu()
        {
            string choice = "NaN";
            Console.Clear();
            Console.WriteLine(Trait);
            Console.WriteLine("Bonjour et bienvenue sur CommuMoney !");
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("1. Créer un nouveau compte");
            Console.WriteLine("2. Se connecter");
            Console.WriteLine("\n(q pour quitter)");
            Console.WriteLine(Trait);

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
            Console.WriteLine(Trait);
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
            Console.WriteLine("Vous êtes connecté(e) !\n");
            
            NextStepConnectedAccount(idToFetch);
        }


        private static void AddPersonToProject(int connectedPerson)
        {
            Console.WriteLine($"Vous voulez ajouter une personne à un porjet. Sur quel projet voulez-vous l'ajouter ? Entrez le numéro pour les ajouter");

            var ProjetService = new Projet_SERVICE();
            List<Projet_METIER> AllCurrentProjectsFormPerson = ProjetService.GetProjetByID_Personne(connectedPerson);
            foreach (var item in AllCurrentProjectsFormPerson)
            {
                Console.WriteLine($"{item.ID}. {item.Nom} date :{item.Date_Soiree}");
            }
            var s_PickedProjet = Console.ReadLine();
            int PickedProjet = EnsureInt(s_PickedProjet);

            Projet_METIER MonProjetSpecifique = ProjetService.GetByID(PickedProjet);

            Console.WriteLine(Trait);
            Console.WriteLine("Quelle personne voulez-vous ajouter ? Entrez leur numéro pour les ajouter");
            var p = new Personnnes_SERVICES();
            List<Personnes_METIER> ToutesMesPersonnes = p.GetAll();
            
            foreach (var item in ToutesMesPersonnes)
            {
                Console.WriteLine($"{item.ID}. {item.Nom} {item.Prenom}");
                
            }
            var s_PickedID = Console.ReadLine();
          int  PickedID=EnsureInt(s_PickedID);
            Personnes_METIER MaPersonneChoisie = p.GetByID(PickedID);

            var DepenseDeBase = new Depenses_METIER(MaPersonneChoisie.ID, MonProjetSpecifique.ID, 0.0);
            var depp = new Depenses_SERVICE();

            depp.Insert(DepenseDeBase);

            Console.WriteLine($"{MaPersonneChoisie.Prenom} a bien été ajouté au projet {MonProjetSpecifique.Nom} !");
            //Perso 1 connecté
            //Ajouter qq
            //Je Choisis le projet sur qui je veux ajouter qq
            //J'ai choisi mon projet
            //Je choisis QUI doit aller dans mon projet
            //Et je créer mon association de ce projet va s'associer 
            NextStepConnectedAccount(connectedPerson);
        }

        private static void ConsultAccount(int idFromPerson)//TODO
        {
            

            var p = new Projet_SERVICE();
            List<Projet_METIER> AllCurrentProjectsFormPerson = p.GetProjetByID_Personne(idFromPerson);

            var rem = new Remboursement_SERVICE();

            //var rem = new Remboursement_SERVICE();
            //List<Remboursement_METIER> AllRemboursementsFromPerson=rem.GetRemboursementByID_Personne

            foreach (var Project in AllCurrentProjectsFormPerson)
            {
                Remboursement_METIER monRemboursement = rem.GetRemboursementByID_Projet(Project.ID);
                double maDette = monRemboursement.Dette;
                Console.WriteLine(PetitTrait);
                //Pour chaque projet, sors moi la dépense correspondante et le remboursement qui va avec

                Console.WriteLine($"Projet {Project.Nom} :  \n\t- Total des dépenses : {Project.Total_Montant}\n\t- Dépense moyenne par personne : {Project.Moyenne}\n\t- Date prévu : {Project.Date_Soiree}");
               
                //Faire le système de prio
                /*Si tu dois rembourser qq, prends celle qui est le plus en dette
                 * Si tu dois te faire rembourser(en négatif dans les dettes donc)
                 * Vise celui qui a dépensé le moins
                 * faire le calcul du DepensePersonne - Moyenne = mes dettes
                 */
                

                Console.WriteLine("Mes remboursements à effectuer :");
                if (maDette<0.0)
                    Console.WriteLine($"On vous doit {Math.Abs(maDette)}€, et ");
                
                if (maDette>0.0)
                    Console.WriteLine($"Vous devez {maDette}");
                
                if (maDette==0.0)
                    Console.WriteLine($"Votre dette est à {maDette}, vous n'avez donc aucun compte à rendre");

                Console.WriteLine($"");
                Console.WriteLine(PetitTrait);

            }



        }

        private static void RecoverAccount()//TODO
        {
            Console.WriteLine("Pas de soucis, quel est votre prénom ?");
            var prenom = Console.ReadLine();
            Console.WriteLine("Et votre nom ?");
            var nom = Console.ReadLine();

        }

        #region Créer tout de zéro (compte + projet) A CORRIGER


        private static void CreateNewAccount()//TODO
        {
            string choice = "0";
            Console.WriteLine(Trait);
            Console.WriteLine("Vous avez choisi de créer un compte ! Commencez par votre prénom :\n");
            var prenom = Console.ReadLine();
            Console.WriteLine("\n Très bien ! Ensuite votre nom :\n");
            var nom = Console.ReadLine();
            var p = new Personnes_METIER(nom, prenom);
            var personneService = new Personnnes_SERVICES();
            personneService.Insert(p);
           //TODO: ALEDDD
            Console.WriteLine("===================================\n");
            Console.WriteLine($"Très bien ! Vous êtes inscrit ! Voici vos identifiants, retenez-les bien :\nNom : {p.Nom}\nPrénom : {p.Prenom}\nNuméro d'identification unique (attention TRÈS important) : {p.ID} Ca marche pas ptdr\n\nMaintenant que voulez-vous faire ?\n");
            Console.WriteLine("1. Créer un nouveau projet\n2.Quitter\n3.Retourner au menu principal");


            NextStepCreateAccount(choice, p.ID);

        }


        private static void CreateNewProject(int IDPersonne)
        {
            Console.WriteLine("Comment va s'appeler votre joli projet ?");
            var nomProjet = Console.ReadLine();
            
            Console.WriteLine("Et combien voulez-vous dépenser pour ce projet ?");
            var s_cout = Console.ReadLine();
            double cout= EnsureDouble(s_cout);

            Console.WriteLine("Quand sera le jour de votre projet ? Format AAAA-MM-JJ");
            var s_deadline = Console.ReadLine();
            DateTime deadline;
            
            #region Mini EnsureDateTime, mais vu qu'on s'en sert 1 fois je fais pas de fonction
            bool parsedDeadline = DateTime.TryParse(s_deadline, out deadline);
            while (!parsedDeadline)
            {
                Console.WriteLine("Veuillez entrer le format correct (AAAA-MM-JJ)");
                s_deadline = Console.ReadLine();
                parsedDeadline = DateTime.TryParse(s_deadline, out deadline);
            }
            #endregion



            var projet = new Projet_METIER(nomProjet, IDPersonne, cout, cout,deadline);

            var depense = new Depenses_METIER(IDPersonne, projet.ID, cout);

            var remboursement = new Remboursement_METIER(IDPersonne, projet.ID, 0.0);

            var DepenseService = new Depenses_SERVICE();
            DepenseService.Insert(depense);


            var ProjetService = new Projet_SERVICE();
            ProjetService.Insert(projet);

            var RemboursementService = new Remboursement_SERVICE();
            RemboursementService.Insert(remboursement);

            Console.WriteLine(Trait);
            Console.WriteLine($"Fort bien, vous avez créé votre projet !\nParlez-en à vos amis pour qu'ils s'y ajoutent !");
            
            BackToMainMenuIn3secs();

        }

        private static void BackToMainMenuIn3secs()
        {
            for (int a = 2; a >= 0; a--)
            {
                Console.Clear();
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