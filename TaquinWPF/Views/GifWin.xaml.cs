using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace TaquinWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour GifWin.xaml
    /// </summary>
    public partial class GifWin : Window
    {
        public GifWin()
        {
            InitializeComponent();
            AfficherGif();
        }

        private void AfficherGif()
        {
            /*le chemin de fichier est différent selon le pc*/
            //string fileName = @"c:\Users\PC_DellPro\source\repos\TaquinWPF\TaquinWPF\gifs\win.gif";
            string fileName = @"c:\Users\Administrateur\Desktop\CSharp\TaquinWPF\TaquinWPF\gifs\win.gif";
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(fileName);
            imageSource.EndInit();

            /*Pour utiliser ImageBehavior il faut installer 
             * le package nuget WpfAnimatedGif */
            ImageBehavior.SetAnimatedSource(monImage, imageSource);
        }
    }
}
