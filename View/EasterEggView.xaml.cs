using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quizyy_wpf.View
{
    /// <summary>
    /// Logika interakcji dla klasy EasterEggView.xaml
    /// </summary>
    public partial class EasterEggView : UserControl
    {
        private MainWindow mainWindow;
        public EasterEggView(MainWindow mainView)
        {
            InitializeComponent();
            mainWindow = mainView;
            OpenMode();
        }
        private void OpenMode()
        {
            mainWindow.backButton.Visibility = Visibility.Visible;
            string text1 = "Pierwszy \"easter egg\" w grach komputerowych pojawił się w grze \"Adventure\" na konsolę Atari " +
                         "2600 w 1980 roku. Twórcą tego easter egga był Warren Robinett, programista pracujący dla Atari " +
                         "w tamtym okresie. W grze \"Adventure\" ukrył on swoje nazwisko w formie ukrytej komnaty, której " +
                         "dostęp był trudny do znalezienia. To było swoiste protestowanie przeciwko braku uznania dla " +
                         "twórców gier w tamtych czasach - producenci gier rzadko wymieniali programistów w napisach końcowych. " +
                         "Od tego momentu easter eggi stały się powszechne w grach komputerowych, stając się integralną " +
                         "częścią rozrywki dla graczy poszukujących ukrytych tajemnic w grach.";


			eggText.Text = text1;
		}
    }
}
