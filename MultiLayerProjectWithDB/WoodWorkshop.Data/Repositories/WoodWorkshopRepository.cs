using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Interfaces;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class WoodWorkshopRepository : IWoodWorkshopRepository
    {
        private readonly string _connectionString;

        public WoodWorkshopRepository()
        {
            _connectionString = "Data Source =(LocalDB)\\MSSQLLocalDB;Initial Catalog = MultiLayerExampleDB;Integrated Security=true";
        }

        public WoodFurnitureOrder Create(WoodFurnitureOrder model)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO WoodPiecesOfFurniture (FullName, PhoneNumber, Date, FurnitureType, Color, WoodType)" +
                    $"OUTPUT (Inserted.Id) " +
                    $"VALUES(\'{model.FullName}\', \'{model.PhoneNumber}\', \'{model.Date}\', \'{model.FurnitureType}\', \'{model.Color}\', \'{model.WoodType}\')";


                var insertedId = Convert.ToInt32(command.ExecuteScalar());

                model.Id = insertedId;

                return model;

            }
        }

        public WoodFurnitureOrder GetItemById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            WoodFurnitureOrder FinedItem = new WoodFurnitureOrder();

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * " +
                    "FROM WoodPiecesOfFurniture " +
                    $"WHERE Id = {id}";


                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    FinedItem.Id = reader.GetInt32(0);
                    FinedItem.PhoneNumber = reader.GetString(1);
                    FinedItem.FullName = reader.GetString(2);
                    FinedItem.Date = reader.GetString(3);
                    FinedItem.FurnitureType = reader.GetString(4);
                    FinedItem.Color = reader.GetString(5);
                    FinedItem.WoodType = reader.GetString(6);

                }

                reader.Close();

            }

            return FinedItem;
    
        }
        public List <WoodFurnitureOrder> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            WoodFurnitureOrder FinedItem;
            List<WoodFurnitureOrder> result = new List<WoodFurnitureOrder>();

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM WoodPiecesOfFurniture";


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FinedItem = new WoodFurnitureOrder();

                    FinedItem.Id = reader.GetInt32(0);
                    FinedItem.PhoneNumber = reader.GetString(1);
                    FinedItem.FullName = reader.GetString(2);
                    FinedItem.Date = reader.GetString(3);
                    FinedItem.FurnitureType = reader.GetString(4);
                    FinedItem.Color = reader.GetString(5);
                    FinedItem.WoodType = reader.GetString(6);

                    result.Add(FinedItem);
                }

                reader.Close();

            }

            return result;
            //  return WoodFurnitures;
        }
    }
}
