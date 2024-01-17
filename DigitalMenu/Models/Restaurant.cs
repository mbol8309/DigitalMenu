using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Models
{
    public class Restaurant
    {

        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Description { set; get; }
        public string? Phone { set; get; }
        public string? Address { set; get; }
        public string? Zip { set; get; }
        public string? Logo { set; get; }
        public bool Base { set; get; }
        public bool Active { set; get; }

    }
}
