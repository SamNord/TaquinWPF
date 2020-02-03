﻿using System;
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
            string fileName = @"c:\Users\PC_DellPro\source\repos\TaquinWPF\TaquinWPF\gifs\loose1.gif";
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(fileName);
            imageSource.EndInit();

            /*Pour utiliser ImageBehavior il faut installer 
             * le package nuget WpfAnimatedGif */
            ImageBehavior.SetAnimatedSource(monImage, imageSource);
        }

        //private void AfficherGif2()
        //{
        //    string fileName = @"c:\Users\PC_DellPro\source\repos\TaquinWPF\TaquinWPF\gifs\loose.gif";
        //    BitmapImage imageSource = new BitmapImage();
        //    imageSource.BeginInit();
        //    imageSource.UriSource = new Uri(fileName);
        //    imageSource.EndInit();

        //    /*Pour utiliser ImageBehavior il faut installer 
        //     * le package nuget WpfAnimatedGif */
        //    ImageBehavior.SetAnimatedSource(monImage, imageSource);
        //}

        private void AfficherLesGifs()
        {
            AfficherGif1(); 
        }
    }
}
