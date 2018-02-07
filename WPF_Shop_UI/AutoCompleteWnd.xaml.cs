using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for AutoCompleteWnd.xaml
    /// </summary>
    /// 
    public partial class AutoCompleteWnd : Window
    {
        List<Person> _list;
        public AutoCompleteWnd()
        {
            InitializeComponent();
            _list = new List<Person>()
           {
               new Person
               {
                   Id=1,
                   ImageName="1.jpg",
                   Name="asdfasdf",
                   Birthday=DateTime.Now
               },
               new Person
               {
                   Id=2,
                   ImageName="2.jpg",
                   Name="uuvvv",
                   Birthday=DateTime.Now
               },
               new Person
               {
                   Id =3,
                   ImageName="3.jpg",
                   Name="ttvvv",
                   Birthday=DateTime.Now
               },
               new Person
               {
                   Id =4,
                   ImageName="4.jpg",
                  Name="rrvvv",
                   Birthday=DateTime.Now
               },
               new Person
               {
                   Id =5,
                   ImageName="5.jpg",
                   Name="vvrv",
                   Birthday=DateTime.Now
               }
           };
        }

        private void tlACPeople_Populating(object sender, PopulatingEventArgs e)
        {
            string text = tlACPeople.Text;
            var result = _list.Where(p=> p.Name.Contains(text));
            tlACPeople.ItemsSource = result;
            tlACPeople.PopulateComplete();
            
            //var result = _filterProvider.GetNamesProducts(text);
            //tlACPeople.ItemsSource = result;
            //tlACPeople.PopulateComplete();
        }

        private void tlACPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tlACPeople.SelectedItem != null)
            {
                txtboc.Text = (tlACPeople.SelectedItem as Person).Id.ToString();
            }
            
        }
    }
    public class Person
    {
        private string imageName;
        public string ImageName {
            get { return ConfigurationManager.AppSettings["ImagesPath"] + imageName; }
            set { imageName = value; } }
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
    }

    public interface IPeopleViewModel
    {
        IEnumerable<Person> People { get; }
        Person SelectedPerson { get; set; }
    }
}
