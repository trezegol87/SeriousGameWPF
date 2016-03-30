using SeriousGameWPF.Games.Base;
using SeriousGameWPF.Static;

namespace SeriousGameWPF.Games
{
  public class BackgroundContent : GameContent
  {

    public BackgroundContent(string imageUri, double posX, double posY, string textContent, int textFontSize, string name, double height, double width)
    {
      DefaultPosX = 400;
      DefaultPosY = 400;
      this.ZIndex = 0;
      this.ImageUri = MainMenuHandler.ConvertStringToImageSource(imageUri);
      this.Name = name;
      this.PairId = -1;
      this.PosX = posX;
      this.PosY = posY;
      this.TextContent = textContent;
      TextLeft = 0;
      TextTop = 0;
      this.ViewboxHeight = height;
      this.ViewboxWidth = width;
      State = State.Undefined;
      Draggable = false;
    }
  }
}