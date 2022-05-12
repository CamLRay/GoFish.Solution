using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GoFish.Models;

namespace GoFish.Controllers
{
  public class GameController : Controller
  {
    Game newGame = new Game();

    [HttpGet("/game")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost("/playerOne")]
    public ActionResult Draw(int num, string playerOne)
    {
      newGame.Draw(5, "player1");
      return RedirectToAction("PlayerOne");
    }

    [HttpPost("/playerTwo")]
    public ActionResult Draw(string playerTwo, int num)
    {
      newGame.Draw(5, "player2");
      return RedirectToAction("PlayerTwo");
    }

    [HttpGet("/playerOne")]
    public ActionResult PlayerOne()
    {
      List<Card> hand = newGame.GetHand();
      return View(hand);
    }

    [HttpGet("/playerTwo")]
    public ActionResult PlayerTwo()
    {    
      List<Card> handTwo = newGame.GetHandTwo();
      return View(handTwo);
    }

    [HttpPost("/PlayerOne/match")]
    public ActionResult Match(int ind)
    {
      if(!newGame.Match(ind, "player1"))
      {
        newGame.Draw(1, "player1");
      }
      return RedirectToAction("PlayerOne");
    }

    [HttpPost("/PlayerTwo/match")]
    public ActionResult MatchTwo(int ind)
    {
      if(!newGame.Match(ind, "player2"))
      {
        newGame.Draw(1, "player2");
      }
      return RedirectToAction("PlayerTwo");
    }
  }
}