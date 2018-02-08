using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Shop_UI
{
    public class PhotoCollection : ObservableCollection<Photo>
    {
        private DirectoryInfo _directory;
        public PhotoCollection() { }

        public PhotoCollection(string path) : this(new DirectoryInfo(path)) { }
        public PhotoCollection(DirectoryInfo directory)
        {
            _directory = directory;
            Update();
        }
        public void AddImage(string pathFile)
        {
            Add(new Photo(pathFile));
        }
        public string Path
        {
            set
            {
                _directory = new DirectoryInfo(value);
                Update();
            }
            get { return _directory.FullName; }

        }
        public DirectoryInfo Directory
        {
            set
            {
                _directory = value;
                Update();
            }
            get { return _directory; }
        }

        private void Update()
        {
            this.Clear();
            try
            {
                //foreach (FileInfo f in _directory.GetFiles("*.jpg"))
                //{
                //    Add(new Photo(f.FullName));
                //}
            }
            catch (DirectoryNotFoundException)
            {
                System.Windows.MessageBox.Show("No Such Directory");
            }
        }

    }
}
