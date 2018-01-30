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


        public ItemsControl GetSelectedTreeViewItemParent(TreeViewItem item)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(item);
            while (!(parent is TreeViewItem || parent is TreeView))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as ItemsControl;
        }

        private void btnGetParent_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = TreeViewFilterName.SelectedItem as TreeViewItem;
            if (item != null)
            {
                ItemsControl parent = GetSelectedTreeViewItemParent(item);

                TreeViewItem treeitem = parent as TreeViewItem;
                string MyValue = treeitem.Header.ToString();//Gets you the immediate parent
                MessageBox.Show(MyValue);
            }
        }

        private void txtFilterValue_Loaded(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                var query = (from f in context.VFilterNameGroup.AsQueryable()
                            select new {
                                FNameId = f.FilterNameId,
                                FName = f.FilterName,
                                FValueId = f.FilterValueId,
                                FValue = f.FilterValue
                            });
                var groupNames=(from f in query
                               group f by new {
                                   Id = f.FNameId,
                                   Name=f.FName
                               } into g
                               orderby g.Key.Name
                               select g);
                foreach (var filterNames in groupNames)
                {
                    var FName = new
                    {
                        Id = filterNames.Key.Id,
                        Name = filterNames.Key.Name
                    };
                    var fValues = from v in filterNames
                                  group v by new
                                  {
                                      Id = v.FValueId,
                                      Name = v.FValue,
                                  };
                    MessageBox.Show(filterNames.Key.Name);
                    foreach (var filterValue in fValues)
                    {
                        MessageBox.Show(filterValue.Key.Name);

                    }
                }
            }
        }
    }
}
