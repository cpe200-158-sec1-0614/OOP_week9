using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame2
{
    class Game
    {
        private Player p1, p2;
        private Deck nDeck;

        public Game()
        {
            nDeck = new Deck();  
            Setup();
            PlayLoop();
        }

        public void Setup()

        {
            string nameP1, nameP2;

            Console.Write("Player1 Name: ");
            nameP1 = Console.ReadLine();
            Console.Write("Player2 Name: ");
            nameP2 = Console.ReadLine();

            p1 = new Player(nameP1, 0, nDeck);
            Console.WriteLine("\n");
            p2 = new Player(nameP2, 26, nDeck);

        }

        public void PlayLoop() //LoopGame
        {
            //Check Remaining Card
            while (p1.Pile.Count > 0 && p2.Pile.Count > 0)
            {
                p1.Dealing();
                p2.Dealing();

                Console.WriteLine(Check());
                Console.ReadKey();
            }
            if (p1.Count > p2.Count) { Console.WriteLine("\n" + p1.Name + "  You Win ! "); }
            else if (p1.Count < p2.Count) { Console.WriteLine("\n" + p2.Name + "  You Win ! "); }
            else { Console.WriteLine("\n Tie"); }
        }

        public string Check()
        {
            string result = "";

            if (p1.OnHand.Value > p2.OnHand.Value)
            {
                p2.Take();
                p2.Remove();
                p1.Remove();

                result = p2.Name + " win!" + "(" + p1.Name + "= " + p1.Count + " " + p2.Name + "= " + p2.Count + " )";
            }
            else if (p1.OnHand.Value < p2.OnHand.Value)
            {
                p1.Take();
                p1.Remove();
                p2.Remove();

                result = p1.Name + " win!" + "(" + p1.Name + "= " + p1.Count + " " + p2.Name + "= " + p2.Count + " )";
            }
            else if (p1.OnHand.Value == p2.OnHand.Value)
            {
                Console.WriteLine(" Draw! ");
                int j = p1.OnHand.Value;

                if (j < p1.Pile.Count && j < p2.Pile.Count)
                {
                    p1.Dealing(p1.OnHand.Value + 1);
                    p2.Dealing(p2.OnHand.Value + 1);

                    Console.Write(CheckAgain(j));
                }
                else if (p1.Pile.Count != 1 || p2.Pile.Count != 1)
                {
                    p1.Shuffle();
                    p2.Shuffle();

                    Console.WriteLine("Card is not enough to play, ....Shuffling....\n\n Press any key to continue");
                }
                else if (p1.Pile.Count == 1 || p2.Pile.Count == 1)
                {
                    p1.Remove();
                    p2.Remove();

                    Console.WriteLine("This is the Last Card, Game will END");
                }
            }
            return result;
        }

        public string CheckAgain(int k)
        {
            string result = "";


            if (p1.OnHand.Value > p2.OnHand.Value)
            {
                p2.Take(k + 1);
                p2.Remove(k + 1);
                p1.Remove(k + 1);

                result = p2.Name + " win! " + "(" + p1.Name + "= " + p1.Count + " " + p2.Name + "= " + p2.Count + " )";
            }
            else if (p1.OnHand.Value < p2.OnHand.Value)
            {
                p1.Take(k + 1);
                p1.Remove(k + 1);
                p2.Remove(k + 1);

                result = p1.Name + " win! " + "(" + p1.Name + "= " + p1.Count + " " + p2.Name + "= " + p2.Count + " )";
            }
            else if (p1.OnHand.Value == p2.OnHand.Value)
            {
                Console.WriteLine(" Draw! ");

                p1.Shuffle();
                p2.Shuffle();

                Console.WriteLine(" Press any key to Continue ");
            }
            return result;
        }
    }
}
