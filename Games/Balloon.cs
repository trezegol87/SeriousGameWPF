using SeriousGameWPF.Games.Base;
using SeriousGameWPF.Helper;
using SeriousGameWPF.Static;

namespace SeriousGameWPF.Games
{
  public class Balloon : GameContent
  {
    public Balloon(int pairId, double posX, double posY, string textContent, string imagePath,
                string name, double textLeft, double textTop, double viewBoxHeight, double viewBoxWidth, int textFontSize = 20)
    {
      DefaultPosX = 400;
      DefaultPosY = 400;
      ZIndex = 1;
      ImageUri = MainMenuHandler.ConvertStringToImageSource(PathHelper.BlueBalloon);
      Name = name;
      PairId = pairId;
      PosX = posX;
      PosY = posY;
      TextContent = textContent;
      TextFontSize = textFontSize;
      TextLeft = textLeft;
      TextTop = textTop;
      ViewboxHeight = viewBoxHeight;
      ViewboxWidth = viewBoxWidth;
      Draggable = true;
      State = State.Default;
      SetActive = SetActiveforGame;
    }

    public void SetActiveforGame(bool t)
    {
      ImageUri = MainMenuHandler.ConvertStringToImageSource(t ? PathHelper.PinkBalloon : PathHelper.BlueBalloon);
    }
  }
}