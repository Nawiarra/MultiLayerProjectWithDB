using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Controllers;
using WoodWorkshop.Models.PostModels;

namespace MultiLayerProjectWithDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new WoodFurnitureController();

            var model = new CreateWoodFurniturePostModel
            {
                FullName = "Petr Petrov",
                PhoneNumber = "+380951111111",
                FurnitureType = "Chair",
                Color = "Blue",
                WoodType = "Oak"
            };

            controller.CreateWoodFurnitureRequest(model);

            var model2 = new CreateWoodFurniturePostModel
            {
                FullName = "Petr Petrov",
                PhoneNumber = "+380951111155",
                FurnitureType = "Chair",
                Color = "Blue",
                WoodType = "Oak"
            };

            controller.CreateWoodFurnitureRequest(model2);
        }
    }
}
