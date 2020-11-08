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
        WoodFurniture Create(WoodFurniture model);
        List<WoodFurniture> GetAll();
        WoodFurniture GetItemById(int id);
    }
}
