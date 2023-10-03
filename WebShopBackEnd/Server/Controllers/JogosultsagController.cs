using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Server.DatabaseManager;
using Server.Models;

namespace Server.Controllers
{
    public class JogosultsagController : BaseDatabaseManager, IDML
    {
        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM jogosultsagok ORDER BY Szint";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Jogosultsag egyJogosultsag = new Jogosultsag();
                    egyJogosultsag.Id = int.Parse(reader["Id"].ToString());
                    egyJogosultsag.Szint = int.Parse(reader["Szint"].ToString());
                    egyJogosultsag.Nev = reader["Nev"].ToString();
                    list.Add(egyJogosultsag);
                }
            }
            catch (Exception ex)
            {
                Jogosultsag jogosultsag = new Jogosultsag();
                jogosultsag.Id = -1;
                jogosultsag.Nev = ex.Message;
                list.Add(jogosultsag);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public string Insert(Record record)
        {
            Jogosultsag jogosultsag = record as Jogosultsag;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"INSERT INTO jogosultsagok (Szint, Nev) VALUES (@Szint, @Nev);";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@Szint", MySqlDbType.Int32)).Value = jogosultsag.Szint;
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = jogosultsag.Nev;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return "Sikeres adattárolás.";
        }

        public string Update(Record record)
        {
            Jogosultsag jogosultsag = record as Jogosultsag;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"UPDATE jogosultsagok SET Szint=@Szint, Nev=@Nev WHERE Id=@Id";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32)).Value = jogosultsag.Id;
                cmd.Parameters.Add(new MySqlParameter("@Szint", MySqlDbType.Int32)).Value = jogosultsag.Szint;
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = jogosultsag.Nev;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return "Sikerese adatmódosítás.";
        }

        public string Delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"DELETE FROM `jogosultsagok` WHERE Id=@Id";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32)).Value = id;
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return "Nincs ilyen Id-vel rendelkező rekord!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return "Sikeres törlés";
        }
    }
}
