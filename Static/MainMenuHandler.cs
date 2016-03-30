using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SeriousGameWPF.Games.Base;

namespace SeriousGameWPF.Static
{
    public delegate void ChangeScreen(string page);
    public static class MainMenuHandler
    {
        
       
        public static object DataContext;
        public static ChangeScreen ChangeScreenTo;
        public static Game SelectedGame;
        public static int FontSize = 50;
        public static int DebugMode = 0;// lehet 0 vagy 1
        public static bool ResultCheckFinished = false;
        private static ObservableCollection<Game> _gamesList { get; set; }
        public static ObservableCollection<Game> GamesList
        {
            get
            {
                return _gamesList;
            }
        }
       
        static MainMenuHandler()
        {
        
            _gamesList = new ObservableCollection<Game>();
        }
        
        public static void AddGame(Game game)
        {
            _gamesList.Add(game);

        }
        public static ObservableCollection<Game> GetGamesList()
        {
            return _gamesList;

        }
        
        public static double[] CalculatePositionFor<T>(ObservableCollection<T> stuff,MainWindow mainWindow, bool isHorizontal) where T:Displayable
        {
            double[] data;
            double _ySize = -1;
            double _xSize= -1;
            if (typeof(T)==typeof(Game))
            {
                _ySize = Game.YSize+20;
                _xSize = Game.XSize+20;

            }
            else if(typeof(T) == typeof(GameMode))
            {
                _ySize = GameMode.YSize+20;
                _xSize = GameMode.XSize+20;

            }
            if (isHorizontal)
            {
                double currentPosY = 0;
                double currentPosX = 20;
                double windowHeight = mainWindow.ActualHeight-40;
                if (windowHeight<0)
                {
                    windowHeight = 1;
                    
                }

                int db = (int)(windowHeight / _ySize);
                if (db > stuff.Count)
                {
                    db = stuff.Count;
                }
                double extraspace = ((((windowHeight) - (_ySize * db)) / db) / 2);
                currentPosY += extraspace;
                double thisySize = _ySize + (windowHeight - (_ySize * db)) / db;
                double canvash = 0;
                double canvasw = 0;
                foreach (Displayable game in stuff)
                {
                    game.PosX = currentPosX;
                    game.PosY = currentPosY;
                    currentPosY += thisySize;
                    //currentPosX += _xSize;
                    if ((windowHeight < currentPosY + _ySize) )
                    {
                        currentPosY = 0 + extraspace;
                        currentPosX += _xSize;
                        canvasw = currentPosX;
                    }
                }
                if (db != 0)
                {
                    if (stuff.Count % db > 0)
                    {
                        canvasw += _xSize;
                    }
                }

                data = new double[2] { canvash, canvasw };

            }
            else
            {
                double currentPosY = 20;
                double currentPosX = 0;
                int db = (int)(mainWindow.ActualWidth / _xSize);
                if (db>stuff.Count)
                {
                    db = stuff.Count;
                }
                double extraspace = (((mainWindow.ActualWidth - (_xSize * db)) / db) / 2);
                currentPosX += extraspace;
                double thisxSize = _xSize + (mainWindow.ActualWidth - (_xSize * db)) / db;
                double canvash = 0;
                double canvasw = 0;
                foreach (Displayable game in stuff)
                {
                    game.PosX = currentPosX;
                    game.PosY = currentPosY;
                    currentPosX += thisxSize;
                    if ((mainWindow.ActualWidth < currentPosX + _xSize))
                    {
                        currentPosX = 0 + extraspace;
                        currentPosY += _ySize;
                        canvash = currentPosY;
                    }
                }
                if (db != 0)
                {
                    if (stuff.Count % db > 0)
                    {
                        canvash += _ySize;
                    }
                    
                }
                data = new double[2] { canvash, canvasw };


            }
            if (data[0]<0)
            {
                data[0] = 0;
            }
            if (data[1] < 0)
            {
                data[1] = 0;
            }
            return data;

        }
        #region Staticpropertymembers
        public static event EventHandler CanvasHeightPropertyChanged;
        public static void RaiseCanvasHeightPropertyChanged()
        {
            EventHandler handler = CanvasHeightPropertyChanged;
            if (handler != null)
                handler(null, EventArgs.Empty);
        }
        public static event EventHandler CanvasWidthPropertyChanged;
        public static double _canvasHeight;
        public static double _canvasWidth;
        public static GameMode SelectedGameMode;
        public static void RaiseCanvasWidthPropertyChanged()
        {
            EventHandler handler = CanvasWidthPropertyChanged;
            if (handler != null)
                handler(null, EventArgs.Empty);
        }

        #endregion
        public static ImageSource ConvertStringToImageSource(string uri)
        {
            var bimage = new BitmapImage();
            bimage.BeginInit();
            bimage.UriSource = new Uri(uri, UriKind.Relative);
            bimage.EndInit();

            return bimage;
        }
        //private double _gameWindowHeight;
        public static double GameWindowHeight { get{return 700;} set{} }//   TEMP!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        public static double GameWindowWidth { get { return 900; } set { } }//   TEMP!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static int GameMenuFontSize { get { return 30; } set { } }

       
        public static void RunResultCheck()
        {
            //TODO implement/verify this
            if (SelectedGame.ResultCheck!=null)
            {
                SelectedGame.ResultCheck();
            }
            //ChangeScreenTo("EndScreen.xaml");
        }
    }
}
