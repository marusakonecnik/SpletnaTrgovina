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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Path = System.IO.Path;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace SpletnaTrgovina
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
       // private static ObservableCollection<ListViewItem> vsiArtikli = new ObservableCollection<ListViewItem>();
        private static ObservableCollection<Artikel> vsiArtikli = new ObservableCollection<Artikel>();
        private List<Artikel> seznam = new List<Artikel>();
        public static List<ListBox> listBoxi = new List<ListBox>();
        public MainWindow()
        {
            InitializeComponent();
            Artikel artikel1 = new Artikel("Samsung a3", "telefonija", "OPIS TELEFONA", "slike/4.png", 350, "priporocamo");
            Artikel artikel2 = new Artikel("Lenovo ThinkPad", "racunalnistvo", "OPIS RAČUNALNIKA", "slike/3.png", 1322, "priporocamo");
            Artikel artikel3 = new Artikel("Gorenje Pralni stroj", "Bela tehnika", "OPIS PRALNEGA STROJA", "slike/2.png", 271, "rabljeno");
            Artikel artikel4 = new Artikel("Gorenje Susilni stoj", "Bela tehnika", "OPIS SUSILNEGA STROJA", "slike/1.png", 53, "testno");
            Artikel artikel5 = new Artikel("Gorenje Blender", "Mali gospodinjski aparati", "OPIS BLENDERJA", "slike/blender.png", 37.59, "Novo");
            Artikel artikel6 = new Artikel("Gorenje pečica", "Bela tehnika", "OPIS PEČICE", "slike/oven.png", 150, "rabljeno");

            /* ListViewItem item = new ListViewItem();
             item.Content = artikel1.Ime; */
            artikel1.IsSupposedToShow = Visibility.Hidden;

            vsiArtikli.Add(artikel1);
            vsiArtikli.Add(artikel2);
            vsiArtikli.Add(artikel3);
            vsiArtikli.Add(artikel4);
            vsiArtikli.Add(artikel5);
            vsiArtikli.Add(artikel6);


            seznam.Add(artikel1);
            seznam.Add(artikel2);
            seznam.Add(artikel3);
            seznam.Add(artikel4);
            seznam.Add(artikel5);
            seznam.Add(artikel6);

            artikli.ItemsSource = vsiArtikli;


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Zadnjenovosti_Click(object sender, RoutedEventArgs e)
        {
               
            vsiArtikli.Clear();
            int stevec = 0;

         
            for (int i = 0; i < seznam.Count; i++)
            {
                if (seznam[i].Nalepka.Equals("Novo"))
                {
                    
                    vsiArtikli.Add(seznam[i]);
                    Artikel item = (Artikel)artikli.Items[stevec];
                   
                    //item.MouseDoubleClick += ListItem_MouseDoubleClick;
                    stevec++;
                }
            } 

        }

        private void ListItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            ListViewItem selectedItem = e.Source as ListViewItem;
            Artikel a = (Artikel)selectedItem.Content;
            a.IsSupposedToShow = Visibility.Visible;
                             
        }


        private void Isk_Leto_DropDownClosed(object sender, EventArgs e)
        {
            vsiArtikli.Clear();
            string selected = comboBox_cena.Text;
            string zgornjaMeja = "";
            string spodnjaMeja = "";
            Debug.Write("dsgasha");
            int j = 0;
            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    j += 2;
                }
                while (Char.IsDigit(selected[j]))
                {
                    if (i == 0)
                    {
                        spodnjaMeja += selected[j];
                    }

                    else if (i == 1)
                    {
                        zgornjaMeja += selected[j];
                    }

                    j++;
                }
            }

            for (int i = 0; i < seznam.Count; i++)
            {
                if (seznam[i].Cena > Int32.Parse(spodnjaMeja) && seznam[i].Cena < Int32.Parse(zgornjaMeja))
                {
                    vsiArtikli.Add(seznam[i]);
                            
                }
            } 
        }


        private void Kosara_Click(object sender, RoutedEventArgs e)
        {

            DoubleAnimation da = new DoubleAnimation();
            da.From = 22;
            da.To = 47;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da.AutoReverse = true;
            kosara.BeginAnimation(Button.HeightProperty, da);
        }

        private int inc = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            inc++;
            timer.Content = inc.ToString();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckboxRabljeno.IsChecked == false && CheckBoxRabljeno.IsChecked == false && CheckboxTestno.IsChecked == false)
            {
                vsiArtikli.Clear();
            }
    
            foreach (Artikel artikel in seznam)
            {
                if (artikel.Nalepka.Equals("Novo"))
                    vsiArtikli.Add(artikel);
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (checkboxNovo.IsChecked==false && CheckBoxRabljeno.IsChecked==false && CheckboxTestno.IsChecked==false)
            {
                vsiArtikli.Clear();
            }
            
            foreach (Artikel artikel in seznam)
            {
                if (artikel.Nalepka.Equals("rabljeno"))
                    vsiArtikli.Add(artikel);
            }
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            if (checkboxNovo.IsChecked == false && CheckBoxRabljeno.IsChecked == false && CheckboxRabljeno.IsChecked == false)
            {
                vsiArtikli.Clear();
            }
            foreach (Artikel artikel in seznam)
            {
                if (artikel.Nalepka.Equals("testno"))
                    vsiArtikli.Add(artikel);
            }
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            if (checkboxNovo.IsChecked == false && CheckBoxRabljeno.IsChecked == false && CheckboxTestno.IsChecked == false)
            {
                vsiArtikli.Clear();
            }
            foreach (Artikel artikel in seznam)
            {
                if (artikel.Nalepka.Equals("priporocamo"))
                    vsiArtikli.Add(artikel);
            }
        }

        private void CheckboxRabljeno_Unchecked(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<vsiArtikli.Count; i++)
            {
                if (vsiArtikli[i].Nalepka.Equals("rabljeno"))
                    vsiArtikli.Remove(vsiArtikli[i]);

            }
        }
    }
}
