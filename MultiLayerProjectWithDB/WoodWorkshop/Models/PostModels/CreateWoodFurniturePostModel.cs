using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WoodWorkshop.Models.PostModels
{
    public class CreateWoodFurniturePostModel
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string FurnitureType { get; set; }
        public string Color { get; set; }
        public string WoodType { get; set; }
    }
}
