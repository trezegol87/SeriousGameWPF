using System.Windows;
namespace SeriousGameWPF.Games.Base
{
  public enum State
  {
    Default,
    Undefined,
    Solved,
    Active
  }

  public delegate void SetActive(bool t);

  public class GameContent : Displayable
  {
    private int _pairId;
    private double _defaultPosX;
    private double _defaultPosY;
    private State _state;
    private string _textContent;
    private double _textLeft;
    private double _textTop;
    private double _viewboxHeight;
    private double _viewboxWidth;
    private int _textFontSize;
    private bool _focus;
    private bool _draggable;
    public SetActive SetActive;

    public int TextFontSize
    {
      get { return _textFontSize; }
      set
      {
        _textFontSize = value;
        OnPropertyChanged("TextFontSize");
      }
    }

    public double ViewboxHeight
    {
      get { return _viewboxHeight; }
      set
      {
        _viewboxHeight = value;
        OnPropertyChanged("ViewboxHeight");
      }
    }

    public bool Draggable
    {
      get { return _draggable; }
      set
      {
        _draggable = value;
        OnPropertyChanged("Draggable");
      }
    }

    public double ViewboxWidth
    {
      get { return _viewboxWidth; }
      set
      {
        _viewboxWidth = value;
        OnPropertyChanged("ViewboxWidth");
      }
    }

    public double TextTop
    {
      get { return _textTop; }
      set
      {
        _textTop = value;
        OnPropertyChanged("TextLeft");
      }
    }

    public double TextLeft
    {
      get { return _textLeft; }
      set
      {
        _textLeft = value;
        OnPropertyChanged("TextLeft");
      }
    }


    public string TextContent
    {
      get { return _textContent; }
      set
      {
        _textContent = value;
        OnPropertyChanged("TextContent");
      }
    }

    public int PairId
    {
      get { return _pairId; }
      set
      {
        _pairId = value;
        OnPropertyChanged("PairId");
      }
    }

    public double DefaultPosX
    {
      get { return _defaultPosX; }
      set
      {
        _defaultPosX = value;
        OnPropertyChanged("DefaultPosX");
      }
    }

    public double DefaultPosY
    {
      get { return _defaultPosY; }
      set
      {
        _defaultPosY = value;
        OnPropertyChanged("DefaultPosY");
      }
    }

    public State State
    {
      get { return _state; }
      set
      {
        _state = value;
        OnPropertyChanged("State");
      }
    }

    //TODO lehet jó lenne az alapértelmezetten kívül több konstruktor, ezt így nehéz használni

    //A Focus mechanika jó, de nem a méretet kellene növelni hanem valami normálisabb ötlet kellene
    public bool Focus
    {
      get { return _focus; }
      set
      {
        if (_focus)
        {
          if (value == false)
          {
            ViewboxHeight /= 1.10;
            ViewboxWidth /= 1.10;
          }
          _focus = value;
        }
        else
        {
          if (value)
          {
            ViewboxHeight *= 1.10;
            ViewboxWidth *= 1.10;
          }

          _focus = value;
        }
        OnPropertyChanged("Focus");
      }
    }

    public virtual bool CollusionCalc(GameContent toTest)
    {
      //const int div = 1;
      //const int div2 = 1;
      //if (PosX >= toTest.PosX && PosX <= toTest.PosX + toTest.ViewboxWidth/div && PosY >= toTest.PosY &&
      //    PosY <= toTest.PosY + toTest.ViewboxHeight/div2)
      //  return true;
      //if (PosX + ViewboxWidth/div >= toTest.PosX && PosX + ViewboxWidth/div <= toTest.PosX + toTest.ViewboxWidth/div &&
      //    PosY >= toTest.PosY && PosY <= toTest.PosY + toTest.ViewboxHeight/div2)
      //  return true;
      //if (PosX >= toTest.PosX && PosX <= toTest.PosX + toTest.ViewboxWidth/div &&
      //    PosY + ViewboxHeight/div2 >= toTest.PosY &&
      //    PosY + ViewboxHeight/div2 <= toTest.PosY + toTest.ViewboxHeight/div2)
      //  return true;
      //if (PosX + ViewboxWidth/div >= toTest.PosX && PosX + ViewboxWidth/div <= toTest.PosX + toTest.ViewboxWidth/div &&
      //    PosY + ViewboxHeight/div2 >= toTest.PosY &&
      //    PosY + ViewboxHeight/div2 <= toTest.PosY + toTest.ViewboxHeight/div2)
      //  return true;

      //return false;

      var centerPoint = new Point
      {
        X = PosX + ViewboxWidth / 2,
        Y = PosY + ViewboxHeight / 2
      };

      if (centerPoint.X >= toTest.PosX && centerPoint.X <= toTest.PosX + toTest.ViewboxWidth
        && centerPoint.Y >= toTest.PosY && centerPoint.Y <= toTest.PosY + toTest.ViewboxHeight)
      {
        return true;
      }


      return false;
    }
    public bool Collusion(GameContent toTest)
    {
      /*
            this.ViewboxHeight;
            this.ViewboxWidth;
            this.PosX;
            this.PosY; * */

      return CollusionCalc(toTest) | toTest.CollusionCalc(this);

    }
  }
}
