using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using SeriousGameWPF.Games.Base;
using SeriousGameWPF.Static;

namespace SeriousGameWPF
{
    /// <summary>
    /// Interaction logic for GameStartPage.xaml
    /// </summary>
    public partial class GameStartPage : Page , INotifyPropertyChanged
    {
        public ObservableCollection<GameMode> SelectedGameModes { get; set; }

        
         #region INotifyPropertyChanged members

         public event PropertyChangedEventHandler PropertyChanged;
         protected void OnPropertyChanged(string propertyName)
         {
             if (PropertyChanged != null)
                 this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }

         #endregion
        public GameStartPage()
        {
            InitializeComponent();
            this.DataContext = MainMenuHandler.DataContext;
            this.SelectedGameModes = MainMenuHandler.SelectedGame.GameModes;

         }

        private void Viewbox_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Viewbox vb = sender as Viewbox;
            GameMode gm = vb.DataContext as GameMode;

            if (MainMenuHandler.SelectedGame.Start != null)
            {
                MainMenuHandler.SelectedGameMode = gm;
                MainMenuHandler.SelectedGame.Start(gm);
            }
            else
            {
                
            }
        }

        
    }
}
