using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Dao
{
    internal class StoreDao
    {

        //Cadastrar a loja
        public bool CreateStore(StoreModel store)
        {
            try
            {

                MySqlConnection conn = new MySqlConnection(ConnectDatabase.connectDB);
                conn.Open();

                string insert = $"INSERT INTO stores (name, cnpj, address, description) VALUES('{store.Name}', '{store.Cnpj}','{store.Address}', '{store.Description}');";
                MySqlCommand commandSql = conn.CreateCommand();
                commandSql.CommandText = insert;

                commandSql.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados" + ex.Message);
                return false;
            }
        }


        //Buscar uma loja pelo ID
        public StoreModel SearchStoreForId(int id)
        {
            try
            {
                StoreModel store = null;

                MySqlConnection conn = new MySqlConnection(ConnectDatabase.connectDB);
                conn.Open();

                string select = "SELECT * FROM stores WHERE id = @id;";
                MySqlCommand commandSql = new MySqlCommand(select, conn);
                commandSql.Parameters.AddWithValue("@id", id);

                var reader = commandSql.ExecuteReader();
                if (reader.Read())
                {
                    store = new StoreModel
                    {
                        Name = reader.GetString("name"),
                        Cnpj = reader.GetString("cnpj"),
                        Address = reader.GetString("address"),
                        Description = reader.GetString("description"),
                        Id = reader.GetInt32("id"),
                    };
                }

                return store;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados" + ex.Message);
                return null;
            }
        }

        //Deletar uma loja pelo ID
        public bool DeleteStore(int id)
        {
            try
            {
                StoreModel store = null;

                MySqlConnection conn = new MySqlConnection(ConnectDatabase.connectDB);
                conn.Open();

                string select = "DELETE FROM stores WHERE id = @id;";
                MySqlCommand commandSql = new MySqlCommand(select, conn);
                commandSql.Parameters.AddWithValue("@id", id);

                commandSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados" + ex.Message);
                return false;
            }
        }

        // Listar as lojas
        public List<StoreModel> GetStoreList()
        {
            try
            {
                List<StoreModel> stores = new List<StoreModel>();

                MySqlConnection conn = new MySqlConnection(ConnectDatabase.connectDB);
                conn.Open();

                string select = "SELECT * FROM stores;";
                MySqlCommand commandSql = conn.CreateCommand();
                commandSql.CommandText = select;

                var reader = commandSql.ExecuteReader();
                while (reader.Read())
                {
                    StoreModel model = new StoreModel();
                    model.Name = reader.GetString("name");
                    model.Cnpj = reader.GetString("cnpj");
                    model.Address = reader.GetString("address");
                    model.Description = reader.GetString("description");
                    model.Id = reader.GetInt32("id");

                    stores.Add(model);
                }

                return stores;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados" + ex.Message);
                return null;
            }
        }

        //Buscar uma loja pelo ID
        public bool UpdateStore(StoreModel store)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConnectDatabase.connectDB);
                conn.Open();

                string select = "UPDATE stores SET name=@name,cnpj=@cnpj,description=@description,address=@address WHERE id = @id;";
                MySqlCommand commandSql = new MySqlCommand(select, conn);
                commandSql.Parameters.AddWithValue("@name", store.Name);
                commandSql.Parameters.AddWithValue("@description", store.Description);
                commandSql.Parameters.AddWithValue("@cnpj", store.Cnpj);
                commandSql.Parameters.AddWithValue("@address", store.Address);
                commandSql.Parameters.AddWithValue("@id", store.Id);


                commandSql.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados" + ex.Message);
                return false;
            }
        }

    }
}
