using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Controllers;
using WoodWorkshop.Models.PostModels;

namespace Three_TierProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new WoodFurnitureController();

            var model = new CreateWoodFurniturePostModel
            {
                FullName = "Petr Petrov",
                PhoneNumber = "+380951111133",
                Date = DateTime.UtcNow.ToString("dd.MM.yyyy"),
                FurnitureType = "Chair",
                Color = "Blue",
                WoodType = "Oak"
            };

            controller.CreateWoodFurnitureRequest(model);

            var createWoodFurnitureViewModel = controller.GetItemById(0);


            var model2 = new CreateWoodFurniturePostModel
            {
                FullName = "Petr Petrov",
                PhoneNumber = "+380951111166",
                Date = DateTime.UtcNow.ToString("dd.MM.yyyy"),
                FurnitureType = "Chair",
                Color = "Blue",
                WoodType = "Oak"
            };

            controller.CreateWoodFurnitureRequest(model2);
        }
    }

}
