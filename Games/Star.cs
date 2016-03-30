using SeriousGameWPF.Games.Base;
using SeriousGameWPF.Helper;
using SeriousGameWPF.Static;

namespace SeriousGameWPF.Games
{
  public class Star : GameContent
  {
    public Star(int pairId, double posX, double posY, string textContent, string imagePath,
                string name, double textLeft, double textTop, double viewBoxHeight, double viewBoxWidth)
    {
      DefaultPosX = 400;
      DefaultPosY = 400;
      ZIndex = 1;
      ImageUri = MainMenuHandler.ConvertStringToImageSource(imagePath);
      Name = "Balloon";
      PairId = pairId;
      PosX = posX;
      PosY = posY;
      TextContent = textContent;
      TextFontSize = MainMenuHandler.FontSize;
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
      ImageUri = MainMenuHandler.ConvertStringToImageSource(t ? PathHelper.PinkStar : PathHelper.BlueStar);
    }
  }
}