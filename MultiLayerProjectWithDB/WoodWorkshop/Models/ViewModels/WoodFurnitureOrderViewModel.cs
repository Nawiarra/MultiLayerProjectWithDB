using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Models.ViewModels
{
    public class WoodFurnitureOrderViewModel
    {

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }
        public string FurnitureType { get; set; }
        public string Color { get; set; }
        public string WoodType { get; set; }
    }
}
