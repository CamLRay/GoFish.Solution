using System.Collections.Generic;
using System;

namespace GoFish.Models
{
  public class Game 
  {
    private static List<Card> _deck = new List<Card> {};
    private static List<Card> _hand = new List<Card> {};
    private static List<Card> _handTwo = new List<Card> {};
    public int PlayerOneScore { get; set; }
    public int PlayerTwoScore { get; set; }

    public Game() 
    {
      _deck = Card.DeckBuilder();
      PlayerOneScore = 0;
      PlayerTwoScore = 0;
    }

    public void Draw(int num, string player)
    {
      Random rnd = new Random();
      if(player == "player1")
      {
        for (int i = 0; i < num; i++ )
        {
          int randI = rnd.Next(_deck.Count);
          _hand.Add(_deck[randI]);
          _deck.RemoveAt(randI);
        }
      }
      else if (player == "player2")
      {
        for (int i = 0; i < num; i++ )
        {
          int randI = rnd.Next(_deck.Count);
          _handTwo.Add(_deck[randI]);
          _deck.RemoveAt(randI);
        }
      }
      
    }

    public bool Match(int ind, string player)
    {

      if(player == "player1")
      {
      for(int i = 0; i< _handTwo.Count; i++)
        {
          if(_handTwo[i].Rank == _hand[ind].Rank)
          {
            _hand.RemoveAt(ind);
            _handTwo.RemoveAt(i);
            PlayerOneScore += 1;
            return true;
          }
        } 
        return false; 
      } 
      else
      {
        for(int i = 0; i< _hand.Count; i++)
        {
          if(_hand[i].Rank == _handTwo[ind].Rank)
          {
            _hand.RemoveAt(i);
            _handTwo.RemoveAt(ind);
            PlayerTwoScore += 1;
            return true;
          }
        }  
        return false;
      }
    }

    public List<Card> GetDeck()
    {
      return _deck;
    }

    public List<Card> GetHand()
    {
      return _hand;
    }

    public List<Card> GetHandTwo()
    {
      return _handTwo;
    }

    public static void ClearAll()
    {
      _deck.Clear();
      _hand.Clear();
      _handTwo.Clear();
    }

  }
}