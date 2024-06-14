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

namespace biding_XML
{
    /// <summary>
    /// Logika interakcji dla klasy ModelWindow.xaml
    /// </summary>
    public partial class ModelWindow : Window
    {
        public ModelWindow(Subcategory subcategory)
        {
            InitializeComponent();
            ModelDetails.Text = subcategory.Description;
            ModelDataGrid.ItemsSource = subcategory.Models;
        }
    }
}
