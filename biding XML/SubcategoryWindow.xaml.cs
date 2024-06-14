using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy SubcategoryWindow.xaml
    /// </summary>
    public partial class SubcategoryWindow : Window
    {
        public ObservableCollection<Subcategory> Subcategories { get; set; }

        public SubcategoryWindow(Category category)
        {
            InitializeComponent();
            SubcategoryDetails.Text = category.Description;
            Subcategories = category.Subcategories;
            SubcategoryListView.ItemsSource = Subcategories;
        }

        private void SubcategoryListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SubcategoryListView.SelectedItem is Subcategory selectedSubcategory)
            {
                ModelWindow modelWindow = new ModelWindow(selectedSubcategory);
                modelWindow.Show();
            }
        }
    }
}
