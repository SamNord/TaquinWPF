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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TaquinWPF.Models;

namespace TaquinWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour JeuTaquin.xaml
    /// </summary>
    public partial class JeuTaquin : Window
    {/*Explication du UIElement : la grille crée possède des éléments créés (button, label etc..
        ces éléments sont appelés des UIElement donc la grille est une liste de UIElement
        la grille en liste = maGrille.Children*/
        private TaquinLettre taquin;
        private Label labelCpt;
        private Button bStart;
        private Button boutonLetter;
        private UIElement elementTest;
        private UIElement elementBouton;
        private DispatcherTimer timer;
        private TimeSpan time;
        private TextBlock tbTime;
        public JeuTaquin()
        {
            InitializeComponent();
            CreateRowsAndCols();
            taquin = new TaquinLettre();
            CreateStart();
            Create_Quitter();
            AddStyle();
            CreateZoneTimer();
        }

        private void CreateRowsAndCols()
        {
            for (int i = 0; i < 7; i++)
            {
                if (i < 7)
                    maGrille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                maGrille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
        }

        private void CreateStart()
        {
            bStart = new Button() { Content = "Start", Height = 31, FontSize = 15 };
            maGrille.Children.Add(bStart);
            Grid.SetColumn(bStart, 3);
            Grid.SetRow(bStart, 1);
            labelCpt = new Label() { Content = "0", FontSize = 15, FontWeight = FontWeights.Bold, Foreground = Brushes.DarkMagenta };
            maGrille.Children.Add(labelCpt);
            Grid.SetRow(labelCpt, 1);
            Grid.SetColumn(labelCpt, 1);
            bStart.Background = Brushes.Blue;
            bStart.Foreground = Brushes.Yellow;
            bStart.FontWeight = FontWeights.Bold;
            bStart.Click += CreateElements;
            bStart.Click += CreateTimer;

        }

        private void CreateElements(object sender, RoutedEventArgs e)
        {
            /***Le clic sur un bouton lettre crée son même bouton(un clone -->voir méthode ClickElement()) et l'ancien se déplace
             donc il faut supprimer le bouton dans sa case initiale
             Pour cela on crée une liste dans laquelle on met tous les boutons clonés puis on les supprime*/
            maGrille.Children.Cast<UIElement>().Where(x => Grid.GetRow(x) > 1 && Grid.GetRow(x) < 5).ToList().ForEach(x => maGrille.Children.Remove(x));
            /******équivalent à :
            List<UIElement> listeASupprimer = new List<UIElement>();
            foreach(UIElement element in maGrille.Children)
            {
                if(Grid.GetRow(element) > 1 && Grid.GetRow(x) <5)
                {
                    listeASupprimer.Add(element);
                }
            }
            listeASupprimer.ForEach(el =>
            {
                maGrille.Children.Remove(el);
            });*/
            taquin.Lettres = taquin.Shuffle();
            labelCpt.Content = Convert.ToInt32("0");
            int index = 0;
            for (int i = 2; i < 6; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (index < taquin.Lettres.Count)
                    {
                        boutonLetter = new Button() { Content = taquin.Lettres[index], FontSize = 21 };
                        boutonLetter.Click += ClickElement;
                        maGrille.Children.Add(boutonLetter);
                        Grid.SetColumn(boutonLetter, j);
                        Grid.SetRow(boutonLetter, i);
                        boutonLetter.Background = Brushes.Brown;
                        boutonLetter.Foreground = Brushes.Black;
                        boutonLetter.FontWeight = FontWeights.Bold;
                        index++;
                    }
                }
            }
        }

        private void ClickElement(object sender, RoutedEventArgs e)
        {

            if (sender is Button)
            {
                Button b = (sender as Button);
                /*récupère la position de l'élément 
                niveau de la ligne avec GetRow
                au niveau de la colonne avec GetColumn*/
                int x = Grid.GetRow(b);
                int y = Grid.GetColumn(b);
                if (TestDeplacement(x + 1, y) && x < 4)
                {
                    Grid.SetRow(b, x + 1);
                }
                else if (TestDeplacement(x - 1, y) && x > 2)
                {
                    Grid.SetRow(b, x - 1);
                }
                else if (TestDeplacement(x, y + 1) && y < 3)
                {
                    Grid.SetColumn(b, y + 1);
                }
                else if (TestDeplacement(x, y - 1) && y > 1)
                {
                    Grid.SetColumn(b, y - 1);
                }
                labelCpt.Content = Convert.ToInt32(labelCpt.Content.ToString()) + 1;
                taquin.Lettres.ToString();
                if (Win())
                {
                    timer.Stop();
                    MessageBox.Show("Bravo !");
                    GifWin winWindow = new GifWin();
                    winWindow.Show();
                }
                else if (Convert.ToInt32(labelCpt.Content.ToString()) > 500)
                {
                    timer.Stop();
                    MessageBox.Show("Perdu !");
                    GifLoose looseWindow = new GifLoose();
                    looseWindow.Show();
                }
            }
        }

        //si TestDeplacement() == true --> la case est vide
        private bool TestDeplacement(int x, int y)
        {
            //Return true si elementTrouve est null
            /*La grille est composée d'éléments sous forme de UIElement qui renvoit une liste d'UIElement*/
            //si UIEelement est null ça veut dire que la case est vide
            UIElement elementTrouve = null;
            //maGrille.Children = liste d'UIElement
            foreach (UIElement element in maGrille.Children)
            {
                //si la case est en position ligne x et colonne y
                if (Grid.GetRow(element) == x && Grid.GetColumn(element) == y)
                {
                    elementTrouve = element;
                    break;
                }
            }
            //return case vide --> UIElement elementTrouve ==null 
            return elementTrouve == null;
        }

        private void Click_Quitter(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Create_Quitter()
        {
            Button bClose = new Button() { Content = "Close", FontSize = 10, Height = 30, FontWeight = FontWeights.Bold };
            bClose.Background = Brushes.Black;
            bClose.Foreground = Brushes.Red;
            maGrille.Children.Add(bClose);
            Grid.SetRow(bClose, 6);
            Grid.SetColumn(bClose, 6);
            Grid.SetColumnSpan(bClose, 2);
            bClose.Click += Click_Quitter;
        }

        private void AddStyle()
        {
            maGrille.Background = Brushes.Aqua;
        }

        private bool Win()
        {
            //string chaineWin = "ABCDEFGH#";
            string chaineWin = "ABCDEFGH";
            string chaine = "";

            elementTest = maGrille.Children.Cast<UIElement>().FirstOrDefault(e => (Grid.GetColumn(e) == 3 && Grid.GetRow(e) == 4));

            for (int i = 2; i < 5; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    while (elementTest == null)
                    {
                        elementBouton = maGrille.Children.Cast<UIElement>().FirstOrDefault(e => (Grid.GetColumn(e) == j && Grid.GetRow(e) == i));
                        if (elementBouton != null)
                            chaine += (elementBouton as Button).Content.ToString();
                        break;
                    }
                }
            }
            return chaine == chaineWin;
        }

        //ajout d'un TextBlock pour le décompte
        private void CreateZoneTimer()
        {
            tbTime = new TextBlock() { FontSize = 21, FontWeight = FontWeights.Bold, Foreground = Brushes.Red };
            maGrille.Children.Add(tbTime);
            Grid.SetRow(tbTime, 1);
            Grid.SetColumn(tbTime, 4);
        }

        //Ajout du décompte
        private void CreateTimer(object sender, RoutedEventArgs e)
        {
            time = TimeSpan.FromSeconds(0);
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = time.ToString("c");
                //if (Win())
                //    timer.Stop();

                time = time.Add(TimeSpan.FromSeconds(1));
            }, Application.Current.Dispatcher);
            timer.Start();
        }

    }
}
