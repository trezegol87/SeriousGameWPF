namespace SeriousGameWPF.Games.Base
{
  public class GameMode : Displayable
  {
    private string _gameDesc;
    private string _startParameters; //?

    public const double XSize = 100;
      //ViewBox méretét állítja, azért konstans mert futásidő előtt beállítja a viewbox méretét, de futásidőben kalkulálja a pozicíóját

    public const double YSize = 100;
      //ViewBox méretét állítja, azért konstans mert futásidő előtt beállítja a viewbox méretét, de futásidőben kalkulálja a pozicíóját

    public string GameDesc
    {
      get { return _gameDesc; }
      set
      {
        _gameDesc = value;
        OnPropertyChanged("GameDesc");
      }
    }

    public string StartParameters
    {
      get { return _startParameters; }
      set
      {
        _startParameters = value;
        OnPropertyChanged("StartParameters");
      }
    }
  }
}
