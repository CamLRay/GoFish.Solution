using System.Collections.Generic;

namespace GoFish.Models
{
  public class Card
  {
    public string Suit { get; set; }
    public string Rank { get; set; }
    private static List<Card> _instances = new List<Card> {};
    
    private static string[] suits = { "hearts", "clubs", "spades", "diamonds" };
    private static string[] ranks = { "ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king" };

    public Card(string suit, string rank)
    {
      Suit = suit;
      Rank = rank;
      _instances.Add(this);
    }

    public static List<Card> DeckBuilder()
    {
      foreach(string suit in suits)
      {
        foreach(string rank in ranks)
        {
          Card thisDeck = new Card(suit, rank);
        }
      }
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Card GetCard(int index)
    {
      return _instances[index];
    }

    public static void RemoveCard(int index)
    {
      _instances.RemoveAt(index);
    }

  }
}