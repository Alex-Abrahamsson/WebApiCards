
    //Create a playing card class
    class Card
    {
        //Create a constructor that takes a suit and a value
        public Card(string type, int value)
        {
            this.type = type;
            this.value = value;
        }
        //Create a property for the suit
        public string type { get; set; }
        //Create a property for the value
        public int value { get; set; }
        //Create a ToString method that returns the card's value and suit
        public override string ToString()
        {
            return $"{value} of {type}";
        }
    }