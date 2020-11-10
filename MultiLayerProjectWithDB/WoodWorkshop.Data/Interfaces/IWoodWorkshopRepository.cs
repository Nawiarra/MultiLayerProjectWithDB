using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Interfaces
{
    public interface IWoodWorkshopRepository
    {
        WoodFurnitureOrder Create(WoodFurnitureOrder model);
        List<WoodFurnitureOrder> GetAll();
        WoodFurnitureOrder GetItemById(int id);
        WoodFurnitureOrder GetItemsByName(string name);
    }
}
