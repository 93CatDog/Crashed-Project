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

namespace Books_and_Magazines
{
    /// <summary>
    /// Interaction logic for WindowAddObject.xaml
    /// </summary>
    public partial class WindowAddObject : Window
    {
        public WindowAddObject(string type)
        {
            switch (type)
            {
                case "Writer":
                    Item1.IsSelected = true;
                    break;
                case "Book":
                    Item2.IsSelected = true;
                    break;
                case "Newspaper":
                    Item3.IsSelected = true;
                    break;
            }
                InitializeComponent();
        }
    }
}
