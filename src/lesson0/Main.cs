using System;
using System.Collections.Generic;
using System.Linq;

namespace Concept.Linq.Lesson0 {
    class Product
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
    }

    class Category
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    class Main
    {
        private List<Category> categories = new List<Category>()
        { 
            new Category(){Name="Beverages", ID=001},
            new Category(){ Name="Condiments", ID=002},
            new Category(){ Name="Vegetables", ID=003},         
        };
        private List<Product> products = new List<Product>()
        {
            new Product{Name="Tea",  CategoryID=001},
            new Product{Name="Mustard", CategoryID=002},
            new Product{Name="Pickles", CategoryID=002},
            new Product{Name="Carrots", CategoryID=003},
            new Product{Name="Bok Choy", CategoryID=003},
            new Product{Name="Peaches", CategoryID=005},
            new Product{Name="Melons", CategoryID=005},
            new Product{Name="Ice Cream", CategoryID=007},
            new Product{Name="Mackerel", CategoryID=012},
        };
        public void Run()
        {
            CrossJoin();
            NonEquijoin();
        }
        void CrossJoin()
        {
            var crossJoinQuery =
                from c in categories
                from p in products
                select new { c.ID, p.Name };

            Console.WriteLine("Cross Join Query:");
            foreach (var v in crossJoinQuery)
            {
                Console.WriteLine($"{v.ID,-5}{v.Name}");
            }
        }
        void NonEquijoin()
        {
            var nonEquijoinQuery =
                from p in products
                let catIds = from c in categories
                             select c.ID
                where catIds.Contains(p.CategoryID) == true
                select new { Product = p.Name, CategoryID = p.CategoryID };

            Console.WriteLine("Non-equijoin query:");
            foreach (var v in nonEquijoinQuery)
            {
                Console.WriteLine($"{v.CategoryID,-5}{v.Product}");
            }
        }
    }
}
