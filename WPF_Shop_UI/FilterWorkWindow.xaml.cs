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
using System.Transactions;

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

                var findFilter = context.FilterName
                    .SingleOrDefault(f => f.Name == name);
                if (findFilter == null)
                {
                    FilterName filterName = new FilterName()
                    {
                        Name = name
                    };
                    context.FilterName.Add(filterName);
                    context.SaveChanges();
                    FilterTreeViewItem viewItem = new FilterTreeViewItem()
                    {
                        Id = filterName.Id.ToString(),
                        Name = filterName.Name
                    };
                    TreeViewItem newCh = new TreeViewItem();
                    newCh.Header = viewItem;
                    TreeViewFilterName.Items.Add(newCh);
                }
                {
                    MessageBox.Show("Filter already exists");
                }
            }
        }

        private void btnAddFilterValue_Click(object sender, RoutedEventArgs e)
        {

            string name = txtFilterValue.Text;
            var item = TreeViewFilterName.SelectedItem as TreeViewItem;

            if (!(GetSelectedTreeViewItemParent(item) is TreeViewItem))
            {
                var filterNameId = int.Parse(((FilterTreeViewItem)item.Header).Id);
                using (EFContext context = new EFContext())
                {
                    FilterValue filterValue = new FilterValue
                    {
                        Name = name
                    };
                    context.FilterValue.Add(filterValue);
                    context.SaveChanges();
                    FilterNameGroup filterNameGroup = new FilterNameGroup
                    {
                        FilternameId = filterNameId,
                        FilterValueId = filterValue.Id
                    };
                    context.FilterNameGroup.Add(filterNameGroup);
                    context.SaveChanges();
                }
                RefreshTreeView();
            }
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
            using (EFContext context = new EFContext())
            {
                if (item != null)
                {
                    ItemsControl parent = GetSelectedTreeViewItemParent(item);
                    if (parent != null)
                    {
                        TreeViewItem treeitem = parent as TreeViewItem;
                        FilterTreeViewItem myVal = item.Header as FilterTreeViewItem;
                        FilterTreeViewItem parentItem = treeitem.Header as FilterTreeViewItem;
                        var deleteValue = context.FilterValue
                            .SingleOrDefault(f => f.Id.ToString() == myVal.Id);
                        var deleteGroup = context.FilterNameGroup
                            .SingleOrDefault(f => f.FilternameId.ToString() == parentItem.Id && f.FilterValueId == deleteValue.Id);
                        if (deleteValue != null)
                        {
                            context.FilterNameGroup.Remove(deleteGroup);
                            context.FilterValue.Remove(deleteValue);
                            context.SaveChanges();
                            RefreshTreeView();
                        }
                    }
                }
            }
        }
        private void RefreshTreeView()
        {
            TreeViewFilterName.Items.Clear();
            TreeViewFilterName.DisplayMemberPath = "Name";
            TreeViewFilterName.SelectedValuePath = "Id";
            using (EFContext context = new EFContext())
            {
                var query = (from f in context.VFilterNameGroup.AsQueryable()
                             select new
                             {
                                 FNameId = f.FilterNameId,
                                 FName = f.FilterName,
                                 FValueId = f.FilterValueId,
                                 FValue = f.FilterValue
                             });
                var groupNames = (from f in query
                                  group f by new
                                  {
                                      Id = f.FNameId,
                                      Name = f.FName
                                  } into g
                                  orderby g.Key.Name
                                  select g);
                foreach (var filterNames in groupNames)
                {
                    var FName = new FilterTreeViewItem
                    {
                        Id = filterNames.Key.Id.ToString(),
                        Name = filterNames.Key.Name
                    };

                    TreeViewItem parent = new TreeViewItem();
                    parent.Header = FName;
                    TreeViewFilterName.Items.Add(parent);

                    var fValues = from v in filterNames
                                  group v by new
                                  {
                                      Id = v.FValueId,
                                      Name = v.FValue,
                                  };
                    foreach (var filterValue in fValues)
                    {
                        if (string.IsNullOrEmpty(filterValue.Key.Name))
                            continue;
                        var FVal = new FilterTreeViewItem
                        {
                            Id = filterValue.Key.Id.ToString(),
                            Name = filterValue.Key.Name
                        };

                        TreeViewItem newChild = new TreeViewItem();
                        newChild.Header = FVal;
                        parent.Items.Add(newChild);

                    }
                }
            }
        }

        private void txtFilterValue_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshTreeView();
        }

    }
}
