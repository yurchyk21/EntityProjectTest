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
        List<ParentViewItem> parentItems = new List<ParentViewItem>();

        public FilterWorkWindow()
        {
            InitializeComponent();
        }

        private void btnAddFilterName_Click(object sender, RoutedEventArgs e)
        {
            string name = txtFilterName.Text;
            ParentViewItem newItem = new ParentViewItem()
            {
                Name = name,
                Id = Guid.NewGuid().ToString(),
                children = new List<string>()
            };
            parentItems.Add(newItem);

            TreeViewItem newChild = new TreeViewItem();
            newChild.Header = newItem;
            TreeViewFilterName.Items.Add(newChild);

            //using (EFContext context = new EFContext())
            //{
            //    string name = txtFilterName.Text;

            //    var findFilter = context.FilterName.SingleOrDefault(f => f.Name == name);
            //    if (findFilter != null)
            //    {
            //        FilterName filterName = new FilterName()
            //        {
            //            Name = name
            //        };
            //        context.FilterName.Add(filterName);
            //        context.SaveChanges();
            //        FilterTreeViewItem viewItem = new FilterTreeViewItem()
            //        {
            //            Id = filterName.Id,
            //            Name = filterName.Name
            //        };
            //        TreeViewItem newCh = new TreeViewItem();
            //        newCh.Header = viewItem;
            //        TreeViewFilterName.Items.Add(newCh);
            //    }
            //    {
            //        MessageBox.Show("Filter already exists");
            //    }
            //}
        }

        private void btnAddFilterValue_Click(object sender, RoutedEventArgs e)
        {

            string name = txtFilterValue.Text;
            TreeViewItem newChild = new TreeViewItem();
            newChild.Header = name;

            var item = TreeViewFilterName.SelectedItem as TreeViewItem;

            if (item.Header is ParentViewItem)
            {
                ParentViewItem newIt = item.Header as ParentViewItem;
                parentItems.SingleOrDefault(p => p.Id == newIt.Id).children.Add(name);
                item.Items.Add(newChild);
            }



            //var Parent = (TreeViewFilterName.SelectedItem as TreeView);
            //Parent.Items.Add(newChild);


            //string filterName = txtFilterValue.Text;
            //ParentViewItem newItem = new ParentViewItem()
            //{
            //    Name = name,
            //    Id = Guid.NewGuid().ToString()
            //};
            //parentItems.Add(newItem);

            //TreeViewItem newChild = new TreeViewItem();
            //newChild.Header = newItem;
            //TreeViewFilterName.Items.Add(newChild);

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
            using (EFContext context = new EFContext())
            {
                TreeViewItem item = TreeViewFilterName.SelectedItem as TreeViewItem;
                if (item != null)
                {
                    ItemsControl parent = GetSelectedTreeViewItemParent(item);
                    if (parent != null)
                    {
                        TreeViewItem treeitem = parent as TreeViewItem;
                        FilterTreeViewItem myVal = item.Header as FilterTreeViewItem;
                        FilterTreeViewItem parentItem = treeitem.Header as FilterTreeViewItem;
                        var deleteValue = context.FilterValue
                            .SingleOrDefault(f => f.Id == myVal.Id);
                        var deleteGroup = context.FilterNameGroup
                            .SingleOrDefault(f => f.FilternameId == parentItem.Id);
                        if (deleteValue != null)
                        {
                            context.FilterNameGroup.Remove(deleteGroup);
                            context.FilterValue.Remove(deleteValue);
                            context.SaveChanges();
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
                        Id = filterNames.Key.Id,
                        Name = filterNames.Key.Name
                    };

                    TreeViewItem parent = new TreeViewItem();
                    parent.Header = FName;
                    TreeViewFilterName.Items.Add(parent);

                    //MessageBox.Show(filterNames.Key.Name);
                    var fValues = from v in filterNames
                                  group v by new
                                  {
                                      Id = v.FValueId,
                                      Name = v.FValue,
                                  };
                    foreach (var filterValue in fValues)
                    {
                        var FVal = new FilterTreeViewItem
                        {
                            Id = filterValue.Key.Id,
                            Name = filterValue.Key.Name
                        };
                        parent.Items.Add(FVal);
                        //TreeViewItem newChild = new TreeViewItem();
                        //newChild.Header = filterValue.Key;
                        //TreeViewFilterName.Items.Add(newChild);

                        //   MessageBox.Show(filterValue.Key.Name);

                    }
                }
            }
        }

        private void txtFilterValue_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshTreeView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (EFContext context = new EFContext())
            {
                foreach (var item in parentItems)
                {
                    if (item.children.Count > 0)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            FilterName filtername = new FilterName()
                            {
                                Name = item.Name,
                            };
                            context.FilterName.Add(filtername);
                            context.SaveChanges();
                            foreach (var child in item.children)
                            {
                                FilterValue filterValue = new FilterValue()
                                {
                                    Name = child
                                };
                                context.FilterValue.Add(filterValue);
                                context.SaveChanges();
                                FilterNameGroup filterNameGroup = new FilterNameGroup()
                                {
                                    FilternameId = filtername.Id,
                                    FilterValueId = filterValue.Id
                                };
                                context.FilterNameGroup.Add(filterNameGroup);
                                context.SaveChanges();
                            }
                            scope.Complete();
                            parentItems.Clear();

                            RefreshTreeView();
                        }
                    }
                }
            }
        }
    }
}
