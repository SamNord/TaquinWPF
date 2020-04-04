using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logique d'interaction pour GifLoose.xaml
    /// </summary>
    public partial class GifLoose : Window
    {
        
        public GifLoose()
        {
            InitializeComponent();
            AfficherLesGifs();          
        }

        private void AfficherGif1()
        {
            string nameFile = "loose1.gif";
            //méthode pour obtenir le chemin du fichier stocké dans dossier bin/debug
            string fullPath = System.IO.Path.GetFullPath(nameFile);

            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(fullPath);
            imageSource.EndInit();

            ///*Pour utiliser ImageBehavior il faut installer 
            // * le package nuget WpfAnimatedGif */
            ImageBehavior.SetAnimatedSource(monImage, imageSource);
        }

        private void AfficherLesGifs()
        {
            AfficherGif1(); 
        }
    }
}
