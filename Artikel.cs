using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpletnaTrgovina
{
    internal class Artikel : INotifyPropertyChanged
    {
        private string ime;
        private string oddelek;
        private string slika;
        private double cena;
        private string nalepka;
        private String opisArtikla;
        private string opis;
        private Visibility jeViden;
       

        public Artikel(string ime, string oddelek, string opisArtikla, string slika, double cena, string nalepka)
        {
            this.ime = ime;
            this.oddelek = oddelek;
            this.OpisArtikla = opisArtikla;
            this.slika = slika;
            this.cena = cena;
            this.nalepka = nalepka;
            jeViden = Visibility.Hidden;

            opis = "   "+ime +"\n"+ "   "+ cena+"€";
                   
        }

        public string Ime { get => ime; set => ime = value; }
        public string Oddelek { get => oddelek; set => oddelek = value; }

        public string Opis { get => opis; set => opis = value; }
        public string Slika { get => slika; set => slika = value; }
        public double Cena { get => cena; set => cena = value; }
        public string Nalepka { get => nalepka; set => nalepka = value; } 

        public event PropertyChangedEventHandler PropertyChanged;

        public Visibility IsSupposedToShow
        {
            get { return jeViden; }
            set
            {
                if (jeViden == value)
                    return;
                jeViden = value;
                if (PropertyChanged != null)
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("IsSupposedToShow"));
            }
        }

        public string OpisArtikla { get => opisArtikla; set => opisArtikla = value; }
    }
}
