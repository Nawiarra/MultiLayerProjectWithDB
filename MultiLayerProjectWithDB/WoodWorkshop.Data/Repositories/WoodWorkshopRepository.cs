using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class WoodWorkshopRepository
    {
        private readonly string _connectionString;
        private List<WoodFurniture> WoodFurnitures { get; set; }

        public WoodWorkshopRepository()
        {
            WoodFurnitures = new List<WoodFurniture>();
            _connectionString = "Data Source =.; Initial Catalog = MultiLayerExampleDB; Integrated Sequrity = true";
        }

        public void Create(WoodFurniture model)
        {
            WoodFurnitures.Add(model);
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM WoodsWorkShop";
            }
        }

        public WoodFurniture GetItemById(int id)
        {
            return WoodFurnitures.First(x => x.Id == id); //  .ToArray()[id];
        }
        public List<WoodFurniture> GetItemsWithSameName(string name)
        {
            return WoodFurnitures.Where(x => x.FullName == name).ToList();
        }
        public List<WoodFurniture> GetAll(string name)
        {
            return WoodFurnitures;
        }
    }
}
