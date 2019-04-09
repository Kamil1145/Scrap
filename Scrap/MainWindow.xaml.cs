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


namespace Scrap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Scraper scraper;
        public MainWindow()
        {

            InitializeComponent();
            scraper = new Scraper();
            DataContext = scraper;

            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            scraper.ScrapeData(TbPage.Text);

            if (Property.prop.ContainsKey("Tytul"))
                title.Text = Property.prop["Tytul"];
            
            if (Property.prop.ContainsKey("Opis"))
                opis.Text = Property.prop["Opis"];

            if (Property.prop.ContainsKey("Cena"))
                prize.Text = Property.prop["Cena"];
            else
                prize.Text = null;
            
            if (Property.prop.ContainsKey("Adres"))
                address.Text =Property.prop["Adres"];
            else
                address.Text = null;

            if (Property.prop.ContainsKey("Powierzchnia"))
                area.Text = Property.prop["Powierzchnia"];
            else
                area.Text = null;

            if (Property.prop.ContainsKey("Liczba pokoi"))
                rooms.Text = Property.prop["Liczba pokoi"];
            else
                rooms.Text = null;

            if (Property.prop.ContainsKey("Poziom"))
                floor.Text = Property.prop["Poziom"];
            else
                floor.Text = null;

            if (Property.prop.ContainsKey("Rodzaj zabudowy"))
                develop.Text =  Property.prop["Rodzaj zabudowy"];
            else
                develop.Text = null;

            if (Property.prop.ContainsKey("Czynsz(dodatkowo)"))
                rent.Text = Property.prop["Czynsz(dodatkowo)"];
            else
                rent.Text = "puste";

            if (Property.prop.ContainsKey("Umeblowane"))
                furnitured.Text = Property.prop["Umeblowane"];
            else
                furnitured.Text = null;

            if (Property.prop.ContainsKey("Rynek"))
                rynek.Text = Property.prop["Rynek"];
            else
                rynek.Text = null;
            
        


        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }








    }
}
