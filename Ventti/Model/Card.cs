namespace Ventti.Model
{
    //enum not used yet, but propably in other game
    public enum Suits { spades, clubs, hearts, diamons}
    public class Card
    {
        string[] suitSymbols = new string[] { "♠", "♣", "♥", "♦" };
        public int Value { get; }
        public int Suit { get;}

        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }
        public override string ToString()
        {
            switch (Value)
            {
                case 1: return $"Ace of {suitSymbols[Suit]}";
                case 13: return $"King of {suitSymbols[Suit]}";
                case 12: return $"Queen of {suitSymbols[Suit]}";
                case 11: return $"Jack of {suitSymbols[Suit]}";
                default: return $"{Value} of {suitSymbols[Suit]}";
            }       
        }
    }
}






