using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using SeriousGameWPF.Games.Base;
using SeriousGameWPF.Helper;
using SeriousGameWPF.Static;

namespace SeriousGameWPF.Games
{
  public class Helyes : Game
  {
    private readonly List<Point> _wordPositionList;
    private readonly List<Point> _answerPositionList;

    private void FillPositionLists()
    {
      const int stepX = 45;
      for (int i = 1; i < 11; i++)
      {
        _wordPositionList.Add(new Point(i % 2 == 0 ? 15 : 50, i * stepX + 90));
      }
      _answerPositionList.Add(new Point(200, 60));
      _answerPositionList.Add(new Point(470, 60));
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
    }

    public Helyes(Start StartGame)
    {
      _wordPositionList = new List<Point>();
      _answerPositionList = new List<Point>();

      ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.Clown);
      Name = "Helyes vagy hejes";
      Start = StartGame;
      this.GenerateActiveContent = GenerateActiveContentforHelyes;
      this.ResultCheck = ResultCheckforHelyes;

      GameModes = new ObservableCollection<GameMode>();
      Background = new SolidColorBrush(Color.FromArgb(0xff, 0xcc, 0xff, 0xff));
      //for (int i = 0; i < 10; i++)
      //{
        this.GameModes.Add(new GameMode() { GameDesc = "Start", StartParameters = "Start" });
      //}

    }

    public void ResultCheckforHelyes()
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
      var solvedAnswers = ActiveContent.Count(ac => ac.Name == "Word" && ac.State == State.Solved);
      foreach (GameContent gameContent in this.ActiveContent)
      {
        if (gameContent.Name == "Word")
        {
          switch (gameContent.State)
          {
            case State.Solved:
              {
                gameContent.Background = ColorHeper.LightGreenBrush;
                break;
              }
            case State.Default:
              {
                gameContent.Background = ColorHeper.RedBrush;
                break;
              }
          }
        }

        if (gameContent.Name == "Owl")
        {
          if (solvedAnswers >= 0 && solvedAnswers <= 3)
          {
            gameContent.ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.BadResult);
          }
          if (solvedAnswers >= 4 && solvedAnswers <= 6)
          {
            gameContent.ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.BadResult);
          }
          if (solvedAnswers >= 7 && solvedAnswers <= 8)
          {
            gameContent.ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.GoodResult);
          }
          if (solvedAnswers >= 9 && solvedAnswers <= 10)
          {
            gameContent.ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.GoodResult);
          }
        }
        if (gameContent.Name == "ResultText")
        {
          if (solvedAnswers >= 0 && solvedAnswers <= 3)
          {
            gameContent.TextContent = PathHelper.Result1.Replace("{0}", solvedAnswers.ToString());
          }
          if (solvedAnswers >= 4 && solvedAnswers <= 6)
          {
            gameContent.TextContent = PathHelper.Result2.Replace("{0}", solvedAnswers.ToString());
          }
          if (solvedAnswers >= 7 && solvedAnswers <= 8)
          {
            gameContent.TextContent = PathHelper.Result3.Replace("{0}", solvedAnswers.ToString());
          }
          if (solvedAnswers >= 9 && solvedAnswers <= 10)
          {
            gameContent.TextContent = PathHelper.Result4.Replace("{0}", solvedAnswers.ToString());
          }
        }
      }
    }

    public void GenerateActiveContentforHelyes(GameMode gm)
    {
      if (gm.StartParameters != null)
      {
        GenerateRandomLists();
        MainMenuHandler.SelectedGame.ActiveContent = new ObservableCollection<GameContent>();
        MainMenuHandler.SelectedGame.ActiveContent.Add(new BackgroundContent(PathHelper.Bagoly, 50, 20, "", 0, "Owl", 100, 100));
        MainMenuHandler.SelectedGame.ActiveContent.Add(new BackgroundContent("", 200, 30, "", 0, "ResultText", 30, 500));
        GenerateSpecificVariables(gm.StartParameters, MainMenuHandler.SelectedGame.ActiveContent);
      }

    }

    private void GenerateSpecificVariables(string param, ObservableCollection<GameContent> activeContent)
    {
      var words_j = FileReaderHelper.Instance.GetWordsFromTextFile("../../Datas/Helyes/solutions_j.txt");
      var words_ly = FileReaderHelper.Instance.GetWordsFromTextFile("../../Datas/Helyes/solutions_ly.txt");
      words_j.AddRange(words_ly);
      Shuffle(words_j);

      Random random = new Random();
      for (var i = 0; i < 10; i++)
      {
        int wordRandomizer = random.Next(0, _wordPositionList.Count);
        activeContent.Add(new Word(words_j[i].Contains("j") ? 1 : 0, 
                              _wordPositionList[wordRandomizer].X,
                              _wordPositionList[wordRandomizer].Y,
                              words_j[i].Replace('j', '_').Replace("lly", "_").Replace("ly", "_"),
                              "",
                              "Word",
                              words_j[i].Length > 10 ? 10 : 25,
                              5,
                              40,
                              120,
                              ColorHeper.LightBlueBrush));
        _wordPositionList.RemoveAt(wordRandomizer);
      }

      activeContent.Add(new Answer(0,
                             _answerPositionList[0].X,
                             _answerPositionList[0].Y,
                             "",
                             PathHelper.HelyesKonyvLy,
                             "WordAnswer",
                             0,
                             0,
                             450, 
                             260));
      activeContent.Add(new Answer(1,
                             _answerPositionList[1].X,
                             _answerPositionList[1].Y,
                             "",
                             PathHelper.HelyesKonyvJ,
                             "WordAnswer",
                             0,
                             0,
                             450,
                             260));
    }
  }
}
