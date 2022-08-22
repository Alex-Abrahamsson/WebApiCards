
public class PlayerCardHand
{
    public List<Card> cards { get; set; }
    public int sum { get; set; }
    public PlayerCardHand()
    {
        cards = new List<Card>();
    }
    public void AddCard(Card card)
    {
        cards.Add(card);
        sum += card.value;
    }
    public void RemoveCard(Card card)
    {
        cards.Remove(card);
        sum -= card.value;
    }
}