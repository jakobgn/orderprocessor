using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessorApplication.Models
{
    public abstract class Product
    {
        protected Product()
        {
            Name = "Product has no name";
        }
        protected Product(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public bool IsPhysical { get; set; }
    }

}
