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
      // Random rnd = new Random();
      if(player == "player1")
      {
        for (int i = 0; i < num; i++ )
        {
          // int randI = rnd.Next(_deck.Count);
          _hand.Add(_deck[0]);
          _deck.RemoveAt(0);
        }
      }
      else if (player == "player2")
      {
        for (int i = 0; i < num; i++ )
        {
          // int randI = rnd.Next(_deck.Count);
          _handTwo.Add(_deck[0]);
          _deck.RemoveAt(0);
        }
      }
      
    }

    public bool Match(int index, string player)
    {

      if(player == "player1")
      {
      for(int i = 0; i< _handTwo.Count; i++)
        {
          if(_handTwo[i].Rank == _hand[index].Rank)
          {
            _hand.RemoveAt(index);
            _handTwo.RemoveAt(i);
            PlayerOneScore += 1;
            return true;
          }
        } 
        return false; 
      } 
      else
      {
        for(int i = 0; i< _handTwo.Count; i++)
        {
          if(_hand[i].Rank == _handTwo[index].Rank)
          {
            _hand.RemoveAt(i);
            _handTwo.RemoveAt(index);
            PlayerTwoScore += 1;
            return true;
          }
        }  
        return false;
      }
    }

    public List<Card> getDeck()
    {
      return _deck;
    }

    public List<Card> getHand()
    {
      return _hand;
    }

    public List<Card> getHandTwo()
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