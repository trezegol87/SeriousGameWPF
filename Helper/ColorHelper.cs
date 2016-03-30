using System.Windows.Media;
namespace SeriousGameWPF.Helper
{
  public static class ColorHeper
  {
    private static string LightBlue = "#00ccff";
    private const string LightGreen = "#00ff00";
    private static string Red = "#ff0000";
    private static string Yellow = "#00ccff";
    private static string Pink = "#ff00ff";

    public static SolidColorBrush LightBlueBrush = GetBrush(LightBlue);
    public static SolidColorBrush LightGreenBrush = GetBrush(LightGreen);
    public static SolidColorBrush RedBrush = GetBrush(Red);
    public static SolidColorBrush YellowBrush = GetBrush(Yellow);
    public static SolidColorBrush PinkBrush = GetBrush(Pink);

    public static SolidColorBrush GetBrush(string color)
    {
      return (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
    }
  }
}
