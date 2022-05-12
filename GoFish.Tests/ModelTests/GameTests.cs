using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GoFish.Models;
using System;

namespace GoFish.Tests
{
  [TestClass]
  public class GameTests : IDisposable
  {
    public void Dispose()
    {
      Game.ClearAll();
    }
    [TestMethod]
    public void GameConstructor_CreateInstanceOfDeck_List()
    {
      Game newGame = new Game();
      Assert.AreEqual(52, newGame.GetDeck().Count);
    }

    [TestMethod]
    public void Draw_CreateListOfNCards_List()
    {
      Game newGame = new Game();
      newGame.Draw(5, "player1");

      Assert.AreEqual(5, newGame.GetHand().Count);
    }

    [TestMethod]
    public void Match_DrawIfNoMatch_List()
    {
      Game newGame = new Game();
      newGame.Draw(5, "player1");
      newGame.Draw(5, "player2");
      if(!newGame.Match(0, "player1"))
        {
          newGame.Draw(1, "player1");
        }

      Assert.AreEqual(6, newGame.GetHand().Count);
    }

    [TestMethod]
    public void Match_RemoveMatchingPairScoreUp_List()
    {
      Game newGame = new Game();
      newGame.Draw(13, "player1");
      newGame.Draw(13, "player2");
      if(!newGame.Match(0, "player1"))
        {
          newGame.Draw(1, "player1");
        }

      Assert.AreEqual(1, newGame.PlayerOneScore);
      Assert.AreEqual(12, newGame.GetHandTwo().Count);
      Assert.AreEqual(12, newGame.GetHand().Count);
    }
  }
}