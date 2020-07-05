using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emajMVC.Areas.Site.Models
{
    public class cls_vm_Books
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string PictureName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}