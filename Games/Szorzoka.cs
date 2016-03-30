﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using SeriousGameWPF.Games.Base;
using SeriousGameWPF.Helper;
using SeriousGameWPF.Static;

namespace SeriousGameWPF.Games
{
  public class Szorzoka : Game
  {
    private readonly List<Point> _balloonPositionList;
    private readonly List<Point> _answerPositionList;

    private void FillPositionLists()
    {
      const int minX = 100;
      const int stepX = 60;
      for (int i = minX; i <= 640; i += stepX)
      {
        _balloonPositionList.Add(new Point(i, i%((minX + stepX)/20) == 0 ? 200 : 100));
        _answerPositionList.Add(new Point(i, i%((minX + stepX)/20) == 0 ? 350 : 400));
      }
    }

    public static void Shuffle<T>(IList<T> list)
    {
      var random = new Random();
      var n = list.Count;
      while (n > 1)
      {
        n--;
        var k = random.Next(n + 1);
        var value = list[k];
        list[k] = list[n];
        list[n] = value;
      }
    }

    public void GenerateRandomLists()
    {
      FillPositionLists();
      //Randomize
      Shuffle(_balloonPositionList);
      Shuffle(_answerPositionList);
    }

    public Szorzoka(Start StartGame)
    {
      _balloonPositionList = new List<Point>();
      _answerPositionList = new List<Point>();

      // GenerateRandomLists();
      ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.Clown);
      Name = "Szorzóka";
      Start = StartGame;
      this.GenerateActiveContent = GenerateActiveContentforSzorzoka;
      this.ResultCheck = ResultCheckforSzorzoka;

      GameModes = new ObservableCollection<GameMode>();
      Background = new SolidColorBrush(Color.FromArgb(0xff, 0xcc, 0xff, 0xff));
      for (int i = 0; i < 10; i++)
      {
        this.GameModes.Add(new GameMode() {GameDesc = (i + 1).ToString(), StartParameters = (i + 1).ToString()});
      }

    }

    public void ResultCheckforSzorzoka()
    {

      foreach (GameContent result in this.ActiveContent)
      {
        result.Draggable = false;
        if (result is IResult)
        {
          if ((result as GameContent).State == State.Solved)
          {
            GameContent temp;
            if (this.CollusionTest(result as GameContent, out temp))
            {
              if (temp.PairId == (result as GameContent).PairId)
              {
                temp.State = State.Solved;
                (result as GameContent).State = State.Solved;
              }
              else temp.State = State.Default;
            }
            else (result as GameContent).State = State.Default;
          }
        }
      }
      //TODO implement this
      foreach (GameContent gameContent in this.ActiveContent)
      {
        switch (gameContent.State)
        {
          case State.Solved:
          {
            gameContent.ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.GreenStar);
            break;
          }
          case State.Default:
          {
            gameContent.ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.RedStar);
            break;
          }
        }
      }
    }

    public void GenerateActiveContentforSzorzoka(GameMode gm)
    {
      if (gm.StartParameters != null)
      {
        GenerateRandomLists();
        MainMenuHandler.SelectedGame.ActiveContent = new ObservableCollection<GameContent>();
        MainMenuHandler.SelectedGame.ActiveContent.Add(new BackgroundContent(PathHelper.SzorzokaLogo, -20, 550, "", 0, "", 100, 120));
        MainMenuHandler.SelectedGame.ActiveContent.Add(new BackgroundContent(PathHelper.Clown, 0, 415, "", 0, "", 100, 100));
        MainMenuHandler.SelectedGame.ActiveContent.Add(new BackgroundContent(PathHelper.Cloud, 650, 150, "", 0, "", 100, 100));
        MainMenuHandler.SelectedGame.ActiveContent.Add(new BackgroundContent(PathHelper.CloudMirrored, -15, 100, "", 0, "", 100, 100));
        GenerateSpecificVariables(gm.StartParameters, MainMenuHandler.SelectedGame.ActiveContent);
      }

    }

    private void GenerateSpecificVariables(string param, ObservableCollection<GameContent> activeContent)
    {
      Random random = new Random();
      for (var i = 1; i < 11; i++)
      {
        int ballonRandomizer = random.Next(0, _balloonPositionList.Count);
        int answerRandomizer = random.Next(0, _answerPositionList.Count);

        activeContent.Add(new Star(i, _balloonPositionList[ballonRandomizer].X, 
                                         _balloonPositionList[ballonRandomizer].Y, 
                                         (i * int.Parse(param)).ToString(),
                                          PathHelper.BlueStar,
                                          "Star", 
                                          90, 
                                          85, 
                                          60, 
                                          60));
        _balloonPositionList.RemoveAt(ballonRandomizer);
        activeContent.Add(new Answer(i, _answerPositionList[answerRandomizer].X, 
                                        _answerPositionList[answerRandomizer].Y,
                                        i + "x" + param,
                                        PathHelper.YellowStar,
                                        "StarAnswer",
                                        GetLeftPosition(String.Concat(i.ToString(), param).Length),
                                        90,
                                        70,
                                        70));
        _answerPositionList.RemoveAt(answerRandomizer);
      }
    }

    private double GetLeftPosition(int textLength)
    {
      double leftPos = 65;
      switch (textLength)
      {
        case 3:
          leftPos = 70;
          break;
        case 4:
          leftPos = 65;
          break;
        case 5:
          leftPos = 60;
          break;
        case 6:
          leftPos = 55;
          break;
      }
      return leftPos;
    }
  }
}
