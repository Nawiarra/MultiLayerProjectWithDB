using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Interfaces;
using WoodWorkshop.Data.Models;
using Dapper;

namespace WoodWorkshop.Data.Repositories
{
    public class WoodWorkshopDapperRepository : IWoodWorkshopRepository
    {
        private readonly string _connectionString;
        public WoodWorkshopDapperRepository()
        {
            _connectionString = "Data Source =(LocalDB)\\MSSQLLocalDB;Initial Catalog = MultiLayerExampleDB;Integrated Security=true";
        }

        public WoodFurnitureOrder Create(WoodFurnitureOrder model)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                var result = connection.Execute("INSERT INTO WoodPiecesOfFurnitureOrders (FullName, PhoneNumber, Date, FurnitureType, Color, WoodType)" +
                    $"OUTPUT (Inserted.Id) " +
                    $"VALUES(\'{model.FullName}\', \'{model.PhoneNumber}\', \'{model.Date}\', \'{model.FurnitureType}\', \'{model.Color}\', \'{model.WoodType}\')");


                var insertedId = Convert.ToInt32(result);

                model.Id = insertedId;

                return model;

            }
        }

        public List<WoodFurnitureOrder> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                return connection.Query<WoodFurnitureOrder>("SELECT * FROM WoodPiecesOfFurniture").ToList();
            }
            
        }

        public WoodFurnitureOrder GetItemById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                var ResultList = connection.Query<WoodFurnitureOrder>($"SELECT * FROM WoodPiecesOfFurnitureOrders WHERE Id = {id}").ToList();

                return ResultList.FirstOrDefault();
            }

            
        }
    }
}
