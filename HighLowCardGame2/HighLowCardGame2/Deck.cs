using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame2
{
    class Deck
    {
        private List<Card> _deck;

        public List<Card> ADeck
        {
            get { return _deck; }
        }

        public Deck()
        {
            _deck = new List<Card>(52);

            for (int s = 1; s < 5; s++)
            {
                for (int v = 1; v < 14; v++)
                {
                    _deck.Add(new Card(v, s));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            int size = _deck.Count;
            for (int i = 0; i < size; i++)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int a = r.Next(0, 52);
                Card c = _deck[a];
                _deck[a] = _deck[i];
                _deck[i] = c;
            }
        }

        public void PrintDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                _deck[i].PrintCard();
            }
        }
    }
}
