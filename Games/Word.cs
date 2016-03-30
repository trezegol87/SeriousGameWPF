using SeriousGameWPF.Games.Base;
using SeriousGameWPF.Helper;
using SeriousGameWPF.Static;
using System.Windows.Media;

namespace SeriousGameWPF.Games
{
  public class Word : GameContent
  {
    public Word(int pairId, double posX, double posY, string textContent, string imagePath,
                string name, double textLeft, double textTop, double viewBoxHeight, double viewBoxWidth, Brush background)
    {
      DefaultPosX = 400;
      DefaultPosY = 400;
      ZIndex = 1;
      ImageUri = MainMenuHandler.ConvertStringToImageSource(imagePath);
      Name = name;
      PairId = pairId;
      PosX = posX;
      PosY = posY;
      TextContent = textContent;
      TextFontSize = 20;
      TextLeft = textLeft;
      TextTop = textTop;
      ViewboxHeight = viewBoxHeight;
      ViewboxWidth = viewBoxWidth;
      Draggable = true;
      State = State.Default;
      SetActive = SetActiveforGame;
      Background = ColorHeper.LightBlueBrush;
    }

    public void SetActiveforGame(bool t)
    {
      Background = t ? ColorHeper.PinkBrush : ColorHeper.LightBlueBrush;
    }
  }
}