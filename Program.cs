using System;
using System.Threading;

namespace BlackJack
{
    class Program
    {
        
        public static string P1;
        public static string cpu = "House";
        public  static int p1Score=0;
        public static int cpuScore = 0;
        public static int p1Wins = 0;
        public static int cpuWins = 0;
        public static int round = 1;
        public static bool won = false;
        public static string dealMessage = "............  ";
        static void TypeMessage(string msg)
        {
            for (int i = 0; i < msg.Length; i++)                         
            {
                Console.Write(msg[i]);                                                             
                Console.Beep(1500, 2);
                Thread.Sleep(10);

            }

            Thread.Sleep(1000);
        } 

        static void Main(string[] args)
        {
            Console.WindowHeight = 25;
            Console.WindowWidth = 65;
            Console.Title = "            Fon21 ";
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            string title = "\nWELCOME TO THE GAME 21\n";
            TypeMessage(title);
            StartGame();

        }
       
        public static void StartGame()
        {
            string nameMessage = "What is your name?";
            TypeMessage(nameMessage);
          
            P1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nWelcome {P1} lets play!");
            Console.WriteLine($"Objective: Stand with the highest count without going over 21\n");
            Thread.Sleep(1000);


            while (true)
            {
                Random random = new Random();

                if (round == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    int p1Card = random.Next(1, 11);
                    int cpuCard = random.Next(1, 11);

                    p1Score += p1Card;
                    cpuScore += cpuCard;
                    TypeMessage(dealMessage);
                    Console.WriteLine($"{P1} you are dealt a {p1Card}\n");
                    Thread.Sleep(3000);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    TypeMessage(dealMessage);
                    Console.WriteLine($"{cpu} is dealt a {cpuCard}\n");
                    round++;
                }
                if (round > 1 && !won)
                {
                    if (cpuScore>p1Score)
                    {
                        Console.Write($"{P1} please select another card. (Y)");
                    }
                    else
                    Console.Write("Would you like another card? (Y/N)");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "y" && !won)
                    {
                        
                        int p1Card = random.Next(1, 11);
                        p1Score += p1Card;
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypeMessage(dealMessage);
                        Console.WriteLine($"{P1} you are dealt a {p1Card} total value: {p1Score}\n");
                         CheckBust(p1Score, cpuScore);
                        if (won) return;

                    }
                    else if (round > 1 && message.ToLower() == "n" && !won)
                    {
                        while (cpuScore <= p1Score && p1Score>0)
                        {
                            int cpuCard = random.Next(1, 11);
                            cpuScore += cpuCard;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            TypeMessage("The House is thinking...");
                            
                            Thread.Sleep(1000);
                            Console.WriteLine($"{cpu} is dealt a {cpuCard} total value {cpuScore}\n");
                            CheckBust(p1Score, cpuScore);
                            if (cpuScore > p1Score)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{cpu} wins! you suck!  :(");
                                Console.Beep(1000, 500);
                                cpuWins++;
                                
                                ContinuePlaying();
                            }

                        }


                    }

                }


            }
            
        }
        static void ContinuePlaying()
        {

                Console.Write("Continue playing? (Y/N)");
                string response = Console.ReadLine();

            if (response.ToLower() == "y")
            {
                ResetGame();
            }
            else
            {
                ExitGame();

            }

        }

        private static void ExitGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Goodbye {P1} and thanks for playing friend!");
            Console.WriteLine($"Created by Johnny Fonseca");
            Console.WriteLine($"Send coffee to creator: $jfonseca79");
            Console.WriteLine($"\nThis window will self terminate in 7 seconds..");

            Thread.Sleep(7000);

            Environment.Exit(0);
        }

        private static void ResetGame()
        {
            p1Score = 0;
            cpuScore = 0;
            round = 1;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            string rnd = "Round ";
            int rndNum = cpuWins + p1Wins + 1; 
            TypeMessage(rnd+rndNum.ToString());
            //Console.WriteLine($"\nRound {cpuWins+p1Wins+1}\n");
            Console.WriteLine($"\n{P1} : {p1Wins}  | {cpu} : {cpuWins}\n");
            Thread.Sleep(1000);
        }

        static void  CheckBust(int score, int cpuscore)
        {
            if (score > 21)
            {
                Console.Beep(500, 500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{P1} you Bust, dealer wins");
                cpuWins++;
                ContinuePlaying();
               

            }
            if (cpuscore > 21)
            {
                Console.Beep(2000, 200);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{cpu} Bust, {P1} wins");
                p1Wins++;
                
                ContinuePlaying();
                
            }
            

        }
    }

}



