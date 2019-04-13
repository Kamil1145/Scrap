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
using Microsoft.Win32;
using System.IO;



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
            if (!Directory.Exists(@"c:\\temporary\\"))
            {
                Directory.CreateDirectory(@"c:\\temporary\\");
            }
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


            if (File.Exists(@"c:\\temporary\\0.jpg"))
                img0.Source = new BitmapImage(new Uri(@"c:\\temporary\\0.jpg"));
            
            if (File.Exists(@"c:\\temporary\\1.jpg"))
                img1.Source = new BitmapImage(new Uri(@"c:\\temporary\\1.jpg"));

            if (File.Exists(@"c:\\temporary\\2.jpg"))
                img2.Source = new BitmapImage(new Uri(@"c:\\temporary\\2.jpg"));

            if (File.Exists(@"c:\\temporary\\3.jpg"))
                img3.Source = new BitmapImage(new Uri(@"c:\\temporary\\3.jpg"));

            if (File.Exists(@"c:\\temporary\\4.jpg"))
                img4.Source = new BitmapImage(new Uri(@"c:\\temporary\\4.jpg"));
            else
                img4.Source = null;

            if (File.Exists(@"c:\\temporary\\5.jpg"))
                img5.Source = new BitmapImage(new Uri(@"c:\\temporary\\5.jpg"));
            else
                img5.Source = null;

            if (File.Exists(@"c:\\temporary\\6.jpg"))
                img6.Source = new BitmapImage(new Uri(@"c:\\temporary\\6.jpg"));
            else
                img6.Source = null;

            if (File.Exists(@"c:\\temporary\\7.jpg"))
                img7.Source = new BitmapImage(new Uri(@"c:\\temporary\\7.jpg"));
            else
                img7.Source = null;

        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            

            string path = (@"c:\\temporary\\" + Property.prop["Adres"]+".txt");
            StreamWriter sw = new StreamWriter(path);

            if (Property.prop.ContainsKey("Tytul"))
                sw.WriteLine("Tytuł: " + Property.prop["Tytul"]);
            else
                sw.WriteLine();

            if (Property.prop.ContainsKey("Adres"))
                sw.WriteLine("Adres: " + Property.prop["Adres"]);
            else
                sw.WriteLine();

            if (Property.prop.ContainsKey("Cena"))
                sw.WriteLine("Cena: " + Property.prop["Cena"]);
            else
                sw.WriteLine();

            sw.WriteLine("Telefon: " + phone.Text);

            if (Property.prop.ContainsKey("Czynsz(dodatkowo)"))
                sw.WriteLine("Czynsz: " + Property.prop["Czynsz"]);
            else
                sw.WriteLine();

            if (Property.prop.ContainsKey("Powierzchnia"))
                sw.WriteLine("Powierzchnia: " + Property.prop["Powierzchnia"]);
            else
                sw.WriteLine();

            if (Property.prop.ContainsKey("Rynek"))
                sw.WriteLine("Rynek: " + Property.prop["Rynek"]);
            else
                sw.WriteLine();

            if (Property.prop.ContainsKey("Liczba pokoi"))
                sw.WriteLine("Pokoje: " + Property.prop["Liczba pokoi"]);
            else
                sw.WriteLine();

            if (Property.prop.ContainsKey("Poziom"))
                sw.WriteLine("Poziom: " + Property.prop["Poziom"]);
            else
                sw.WriteLine();

            if (Property.prop.ContainsKey("Rodzaj zabudowy"))
                sw.WriteLine("Rodzaj zabudowy: " + Property.prop["Rodzaj zabudowy"]);
            else
                sw.WriteLine();

            sw.WriteLine();

            if (Property.prop.ContainsKey("Opis"))
                sw.WriteLine("Opis: " + Property.prop["Opis"]);
            else
                sw.WriteLine();




            System.Threading.Thread.Sleep(8000);
            MessageBox.Show("Dane zapisano w lokalizacji: " + path);


        }

       private void Close_Program(object sender, RoutedEventArgs e)
        {
          
            Application.Current.Shutdown();
            
        }


        //private void Delete_all(object sender, RoutedEventArgs e)
        //{

        //    File.Delete(@"c:\\temporary\\" + Property.prop["Adres"] + ".txt");
        //    File.Delete(@"c:\\temporary\\0.jpg");
        //    File.Delete(@"c:\\temporary\\1.jpg");
        //    File.Delete(@"c:\\temporary\\2.jpg");
        //    File.Delete(@"c:\\temporary\\3.jpg");
        //    File.Delete(@"c:\\temporary\\4.jpg");
        //    File.Delete(@"c:\\temporary\\5.jpg");
        //    File.Delete(@"c:\\temporary\\6.jpg");
        //    File.Delete(@"c:\\temporary\\7.jpg");
        //}










    }
}
