using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biding_XML
{
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Subcategory> Subcategories { get; set; } = new ObservableCollection<Subcategory>();
    }

    public class Subcategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Model> Models { get; set; } = new ObservableCollection<Model>();
    }

    public class Model
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string EngineCapacity { get; set; }
        public string DriveType { get; set; }
    }
}
