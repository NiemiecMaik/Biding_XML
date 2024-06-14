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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace biding_XML
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            public ObservableCollection<Category> Categories { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadCategories();
            CategoryListView.ItemsSource = Categories;
        }


        private void LoadCategories()
        {
            Categories = new ObservableCollection<Category>();
            XDocument doc = XDocument.Load("categories.xml");

            foreach (var category in doc.Descendants("Category"))
            {
                Category cat = new Category
                {
                    Name = (string)category.Attribute("Name"),
                    Description = (string)category.Attribute("Description")
                };

                foreach (var subcategory in category.Descendants("Subcategory"))
                {
                    Subcategory sub = new Subcategory
                    {
                        Name = (string)subcategory.Attribute("Name"),
                        Description = (string)subcategory.Attribute("Description")
                    };

                    foreach (var model in subcategory.Descendants("Model"))
                    {
                        Model mod = new Model
                        {
                            Name = (string)model.Attribute("Name"),
                            Year = (int)model.Attribute("Year"),
                            EngineCapacity = (string)model.Attribute("EngineCapacity"),
                            DriveType = (string)model.Attribute("DriveType")
                        };
                        sub.Models.Add(mod);
                    }

                    cat.Subcategories.Add(sub);
                }

                Categories.Add(cat);
            }
        }

        private void CategoryListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CategoryListView.SelectedItem is Category selectedCategory)
            {
                Console.WriteLine($"Double-clicked on category: {selectedCategory.Name}");

                SubcategoryWindow subcategoryWindow = new SubcategoryWindow(selectedCategory);
                subcategoryWindow.Show();
            }
        }
    }
    
}
