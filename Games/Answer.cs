using SeriousGameWPF.Helper;
using SeriousGameWPF.Static;

namespace SeriousGameWPF.Games.Base
{
  public class Answer : GameContent, IResult
  {
    public Answer(int pairId, double posX, double posY, string textContent, string imagePath, 
      string name, double textLeft, double textTop, double viewBoxHeight, double viewBoxWidth, int textFontSize = 20)
    {
      DefaultPosX = 400;
      DefaultPosY = 400;
      this.ZIndex = 0;
      ImageUri = MainMenuHandler.ConvertStringToImageSource(imagePath);
      Name = name;
      this.PairId = pairId;
      this.PosX = posX;
      this.PosY = posY;
      this.TextContent = textContent;
      this.TextFontSize = textFontSize;
      TextLeft = textLeft;
      TextTop = textTop;
      ViewboxHeight = viewBoxHeight;
      ViewboxWidth = viewBoxWidth;
      State = State.Default;
      Draggable = false;
    }
  }
}