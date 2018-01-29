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
using EntityProjectTest;
using EntityProjectTest.Entities;

namespace WPF_Shop_UI
{
    /// <summary>
    /// Interaction logic for FilterWorkWindow.xaml
    /// </summary>
    public partial class FilterWorkWindow : Window
    {
        public FilterWorkWindow()
        {
            InitializeComponent();
        }

        private void btnAddFilterName_Click(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                string name = txtFilterName.Text;
                TreeViewItem newChild = new TreeViewItem();
                newChild.Header = name;
                TreeViewFilterName.Items.Add(newChild);

                var findFilter = context.FilterName.SingleOrDefault(f => f.Name == name);
                if (findFilter != null)
                //{
                //    FilterName filterName = new FilterName()
                //    {
                //        Name = name
                //    };
                //    context.FilterName.Add(filterName);
                //    context.SaveChanges();
                //}
                {
                    MessageBox.Show("Filter already exists");
                }
            }
        }

        private void btnAddFilterValue_Click(object sender, RoutedEventArgs e)
        {
            string name = txtFilterValue.Text;
            TreeViewItem newChild = new TreeViewItem();
            newChild.Header = name;
            var Parent = (TreeViewFilterName.SelectedItem as TreeView);
            Parent.Items.Add(newChild);
        }
    }
}
