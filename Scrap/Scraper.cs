using HtmlAgilityPack;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;
using System;


namespace Scrap
{
    public class Scraper
    {
        private ObservableCollection<Property> properties = new ObservableCollection<Property>();

        public ObservableCollection<Property> Properties
        {
            get { return properties; }
            set { properties = value; }
        }


        public void ScrapeData(string page)
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


            //Dictionary<string, string> property = new Dictionary<string, string>();



            Property.prop.Add("tytuł", header);
            Property.prop.Add("opis", text);
            Property.prop.Add("adres", loc);

            //for (int i = 0; i < tab.Count - 1; i++)
            //{
            //    switch (tab[i])
            //    {
            //        case "Cena za m²":
            //            property.Add("Cena za m²", tab2[i]);
            //            break;
            //        case "Umeblowane":
            //            property.Add("Umeblowane", tab2[i]);
            //            break;
            //        case "Oferta od":
            //            property.Add("Oferta od", tab2[i]);
            //            break;
            //        case "Poziom":
            //            property.Add("Poziom", tab2[i]);
            //            break;
            //        case "Rynek":
            //            property.Add("Rynek", tab2[i]);
            //            break;
            //        case "Rodzaj zabudowy":
            //            property.Add("Rodzaj zabudowy", tab2[i]);
            //            break;
            //        case "Powierzchnia":
            //            property.Add("Powierzchnia", tab2[i]);
            //            break;
            //        case "Liczba pokoi":
            //            property.Add("Liczba pokoi", tab2[i]);
            //            break;

            //        default:
            //            break;
            //    }



            for (int i = 0; i < tab.Count - 1; i++)
            {
                switch (tab[i])
                {
                    case "Cena za m²":
                        Property.prop.Add("Cena za m²", tab2[i]);
                        break;
                    case "Umeblowane":
                        Property.prop.Add("Umeblowane", tab2[i]);
                        break;
                    case "Oferta od":
                        Property.prop.Add("Oferta od", tab2[i]);
                        break;
                    case "Poziom":
                        Property.prop.Add("Poziom", tab2[i]);
                        break;
                    case "Rynek":
                        Property.prop.Add("Rynek", tab2[i]);
                        break;
                    case "Rodzaj zabudowy":
                        Property.prop.Add("Rodzaj zabudowy", tab2[i]);
                        break;
                    case "Powierzchnia":
                        Property.prop.Add("Powierzchnia", tab2[i]);
                        break;
                    case "Liczba pokoi":
                        Property.prop.Add("Liczba pokoi", tab2[i]);
                        break;

                    default:
                        break;
                }




            }
        }
    }
}









