using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class WoodWorkshopRepository
    {
        private List<WoodFurniture> WoodFurnitures { get; set; }

        public WoodWorkshopRepository()
        {
            WoodFurnitures = new List<WoodFurniture>();
        }

        public void Create(WoodFurniture model)
        {
            WoodFurnitures.Add(model);
        }
    }
}
