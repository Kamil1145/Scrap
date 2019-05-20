using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrap
{
    public class Property
    {

        public static Dictionary<string, string> prop = new Dictionary<string, string>();

        public string tytul;
        public string opis;
        public string cena;
        public string adres;
        public string powierzchnia;
        public string pokoje;
        public string poziom;
        public string umeblowanie;
        public string rodzaj_zabudowy;
        public string cenaZaM;
        public string ofertaOd;
        public string rynek;
        public string czynsz;
        public string telefon;

        public Property()
        {
        }

        public Property(string tytul, string opis, string cena, string adres, string powierzchnia, string pokoje, string poziom, 
                        string umeblowanie, string rodzaj_zabudowy, string cenaZaM, string ofertaOd, string rynek, string czynsz, string telefon)
        {
            this.tytul = tytul;
            this.opis = opis;
            this.cena = cena;
            this.adres = adres;
            this.powierzchnia = powierzchnia;
            this.pokoje = pokoje;
            this.poziom = poziom;
            this.umeblowanie = umeblowanie;
            this.rodzaj_zabudowy = rodzaj_zabudowy;
            this.cenaZaM = cenaZaM;
            this.ofertaOd = ofertaOd;
            this.rynek = rynek;
            this.czynsz = czynsz;
            this.telefon = telefon;
        }

        public string Tytul
        {
            set { tytul = value; }
            get { return tytul; }
        }
        public string Opis
        {
            set { opis = value; }
            get { return opis; }
        }
        public string Cena
        {
            set { cena = value; }
            get { return cena; }
        }
        public string Adres
        {
            set { adres = value; }
            get { return adres; }
        }
        public string Powierzchnia
        {
            set { powierzchnia = value; }
            get { return powierzchnia; }
        }
        public string Pokoje
        {
            set { pokoje = value; }
            get { return pokoje; }
        }
        public string Poziom
        {
            set { poziom = value; }
            get { return poziom; }
        }
        public string Umeblowanie
        {
            set { umeblowanie = value; }
            get { return umeblowanie; }
        }
        public string Rodzaj_zabudowy
        {
            set { rodzaj_zabudowy = value; }
            get { return rodzaj_zabudowy; }
        }
        public string CenaZaM
        {
            set { cenaZaM = value; }
            get { return cenaZaM; }
        }
        public string OfertaOd
        {
            set { ofertaOd = value; }
            get { return ofertaOd; }
        }
        public string Rynek
        {
            set { rynek = value; }
            get { return rynek; }
        }
        public string Czynsz
        {
            set { czynsz = value; }
            get { return czynsz; }
        }
        public string Telefon
        {
            set { telefon = value; }
            get { return telefon; }
        }
    }
}

