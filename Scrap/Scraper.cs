using HtmlAgilityPack;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System;
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
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;





namespace Scrap
{
    public class Scraper
    {
        private ObservableCollection<Property> _entries = new ObservableCollection<Property>();
        public ObservableCollection<Property> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }


        public string[,] ScrapeData(string page)
        {
            List<string> headerl = new List<string>();
            List<string> contentl = new List<string>();
            List<string> addressl = new List<string>();
            List<string> pricel = new List<string>();
            List<string> tab = new List<string>();
            List<string> tab2 = new List<string>();
            string[,] tab3;

            var web = new HtmlWeb();
            var doc = web.Load(page);

            int ind, s;
            string header, text, loc, price;

            var Title = doc.DocumentNode.SelectNodes("//*[@class = 'offer-titlebox']");

            foreach (var title in Title)
            {
                header = HttpUtility.HtmlDecode(title.SelectSingleNode(".//h1").InnerText);
                headerl.Add(header);
            }

            var Content = doc.DocumentNode.SelectNodes("//*[@class='clr descriptioncontent marginbott20']");

            foreach (var content in Content)
            {
                text = HttpUtility.HtmlDecode(content.SelectSingleNode(".//div[@id= 'textContent']").InnerText);
                contentl.Add(text);
            }

            var Address = doc.DocumentNode.SelectNodes("//*[@class='offer-user__address']");

            foreach (var address in Address)
            {
                loc = HttpUtility.HtmlDecode(address.SelectSingleNode(".//p").InnerText);
                addressl.Add(loc);
            }

            var Tab = doc.DocumentNode.SelectNodes("//table[@class='details fixed marginbott20 margintop5 full']/tr/td");

            foreach (var cell in Tab)
            {
                tab.Add(cell.InnerText);
            }

            var Price = doc.DocumentNode.SelectNodes("//*[@class='offer-sidebar__inner offeractions']");


            foreach (var prize in Price)
            {
                price = HttpUtility.HtmlDecode(prize.SelectSingleNode("//*[@id='offeractions']/div[1]/strong").InnerText);
                pricel.Add(price);
            }

            headerl.RemoveAll(string.IsNullOrEmpty);
            contentl.RemoveAll(string.IsNullOrEmpty);
            addressl.RemoveAll(string.IsNullOrEmpty);

            header = headerl[0];
            header = header.Replace("\n", "");
            header = header.Trim();

            text = contentl[0];
            text = text.Replace("\n", "");
            text = text.Replace("\r", "");
            text = text.Trim();

            loc = addressl[0];
            loc = loc.Trim();



            for (int i = 0; i < tab.Count; i++)
            {
                tab[i] = tab[i].Replace("\t", "");
                tab[i] = tab[i].Replace("&nbsp;", "");
                tab[i] = tab[i].Replace("\n", " ");
                tab[i] = tab[i].Trim();
                tab[i] = tab[i].Replace("\t", "");
                tab[i] = tab[i].Replace("\n", "");



                ind = tab[i].IndexOf("   ");
                if (ind == -1)
                {
                    continue;
                }
                tab2.Add(tab[i].Substring(ind));
                tab2[i] = tab2[i].Trim();
                tab[i] = tab[i].Remove(ind);
            }


            tab.RemoveAll(string.IsNullOrEmpty);
            tab2.RemoveAll(string.IsNullOrEmpty);


            if (tab.Count > tab2.Count)
            {
                s = tab.Count;
            }
            else
            {
                s = tab2.Count;
            }

            tab3 = new string[10, 2];

            tab3[0, 0] = "Tytuł";
            tab3[0, 1] = header;
            tab3[1, 0] = "Opis";
            tab3[1, 1] = text;
            tab3[2, 0] = "Adres";
            tab3[2, 1] = loc;

            for (int i = 3; i < s; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        tab3[i, j] = tab[i];
                    }
                    if (j == 1)
                    {
                        tab3[i, j] = tab2[i];
                    }
                }
            }

            return tab3;
  
            //_entries.Add(new Property { Tytuł = header, Opis = text, Adres = loc, Cena = pricel[0], Powierzchnia = tab2[6], OfertaOd = tab2[0], Zabudowa = tab2[5], Pokoje = tab2[7] });




        }




    }
}
