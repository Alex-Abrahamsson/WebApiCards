
    // Create a deck of cards class
    class Deck
    {
        // Create a list of cards
        List<Card> cards = new List<Card>();
        // Create a constructor that populates the list of cards
        public Deck()
        {
            string[] types = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            for (int i = 0; i < types.Length; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    cards.Add(new Card(types[i], j));
                }
            }
        }
        // Create a method that shuffles the deck
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int j = rand.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        // Create a method that deals a card
        public Card Deal()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        // Create a method that returns the remaining cards in the deck
        public int RemainingCards()
        {
            return cards.Count;
        }
    }