
public class PlayerCardHand
{
    public string playerName { get; set; }
    public int sum { get; set; }
    public bool isWinner { get; set; }
    public List<Card> cards { get; set; }
    public PlayerCardHand(string playerName)
    {
        this.playerName = playerName;
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
    public void SortCards()
    {
        cards.Sort((x, y) => x.value.CompareTo(y.value));
    }
    public Card GetHighestCard()
    {
        SortCards();
        return cards[cards.Count - 1];
    }
}