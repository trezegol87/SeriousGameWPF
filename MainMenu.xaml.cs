using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SeriousGameWPF.Games.Base;
using SeriousGameWPF.Static;

namespace SeriousGameWPF
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            this.DataContext = MainMenuHandler.DataContext;
        }
        private void Viewbox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          //MessageBox.Show("most");
            var vb = sender as Viewbox;
            var gametoview = vb.DataContext as Game;
            MainMenuHandler.SelectedGame = gametoview;
            MainMenuHandler.ChangeScreenTo("GameStartPage.xaml");

        }
        private void myimg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var img = sender as Image;
            var gametostart = img.DataContext as Game;
            /*
            if (gametostart.Start != null)
            {
                gametostart.Start();
            }
            else
            {
                MessageBox.Show("A játék nem indítható.");
            }
             * */
        }
    }
}
