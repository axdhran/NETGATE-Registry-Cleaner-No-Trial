using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFakeStoreApiMovil.Models
{
    internal class Categoria
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public DateTime creationAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    //public class CreateCategoryRequest
    //{
    //    public string name { get; set; }
    //    public string image { get; set; }
    //}
}
