using EntityProjectTest.Entities;
using Microsoft.Win32;
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

namespace WPF_Shop_UI
{
    /// <summary>
    /// Interaction logic for ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
                    //public static ObservableCollection<Category> cat;
            //public static ObservableCollection<Photo> Photos = new ObservableCollection<Photo>();
            public PhotoCollection Photos;
            public ProductAddWindow()
            {

                InitializeComponent();
                var z = (PhotoCollection)(this.Resources["Photos"] as ObjectDataProvider).Data;
                this.Photos = (PhotoCollection)(this.Resources["Photos"] as ObjectDataProvider).Data;
                //is.Photos. = //Environment.CurrentDirectory + "\\Images";
                //this.textBox1.Text = mainWindow.Photos.Path;

                // Photos = new ObservableCollection<Photo>();
                //cat = new ObservableCollection<Category>();
                //using (EFContext context = new EFContext())
                //{
                    //cat  = context.Categories.ToList();
                    //treeView1.ItemsSource = (from c in context.Categories
                    //                select new { c.Id, c.Name}).ToList();

                    //foreach (var item in context.Categories)
                    //{
                    //    ComboCategory.Items.Add(item.Name);
                    //}
                    //ComboCategory.ItemsSource = (from c in context.Categories
                    //                             select new { c.Name }).ToList();
                //}
                //ComboCategory.ItemsSource = cat;
                //PhotosListBox.ItemsSource = Photos;
            }

            private void ButtonAdd_Click(object sender, RoutedEventArgs e)
            {
                
            foreach(var foto in Photos)
            {
                MessageBox.Show(foto.SourceOriginal);
            }


                //using (EFContext context = new EFContext())
                //{
                //    Product product = new Product
                //    {
                //        Name = TxtBoxName.Text,
                //        Price = float.Parse(TxtBoxPrice.Text),
                //        Quantity = int.Parse(TxtBoxQty.Text),
                //        DateCreate = DateTime.Now,
                //        //ProductImages = Photos
                //    };
                //    context.Products.Add(product);
                //    context.SaveChanges();

                //}
            }

            private void ButtonAddImage_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string filename in openFileDialog.FileNames) // мульти добавление изображений
                    {
                        this.Photos.AddImage(filename);
                    }
                }

            }
        
    }
}
