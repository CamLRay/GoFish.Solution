using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GoFish.Models;
using System;

namespace GoFish.Tests
{
  [TestClass]
  public class CardTests : IDisposable
  {
    public void Dispose()
    {
      Card.ClearAll();
    }

    [TestMethod]
    public void CardConstructor_CreateInstanceOfCard_Card()
    {
      Card newCard = new Card("ace", "hearts");
      Assert.AreEqual(typeof(Card), newCard.GetType());
    }

    [TestMethod]
    public void DeckBuilder_CreateADeckFromCards_List()
    {
      List<Card> newDeck = Card.DeckBuilder();
      // List<Card> newDeck = 
      // 
      Assert.AreEqual(52, newDeck.Count);
    }

    [TestMethod]
    public void GetCard_GetTheFirstCard_String()
    {
      List<Card> newDeck = Card.DeckBuilder();
      Card firstCard = Card.GetCard(0);
      Assert.AreEqual("ace", firstCard.Rank);
    }

    [TestMethod]
    public void RemoveCard_RemoveACardFromDeck_List()
    {
      List<Card> newDeck = Card.DeckBuilder();
      Card.RemoveCard(0);
      Assert.AreEqual(51, newDeck.Count);
    }

    
  }
}