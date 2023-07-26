using steven_api.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace steven_api.Data
{
    public class CharacterDbContext : DbContext
    {
        public string ConnectionString { get; set; }
        
        public CharacterDbContext(string connectionString) 
        {
            this.ConnectionString = connectionString;
        }

        public DbSet<Character> Characters { get; set; }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Character> GetCharacters()
        {
            List<Character> list = new List<Character>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from characters", conn);

        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                list.Add(new Character()
                {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader["Name"].ToString(),
                    gemStone = reader["gemStone"].ToString(),
                    affiliations = reader["affiliations"].ToString(),
                    alignment = reader["alignment"].ToString(),
                    status = reader["status"].ToString()//,
                    //friends = reader
                });
                }
            }
        }
        return list;
        
    }
    // TODO: Is there a more concise way to do the following? (Less repeated codeh)
    public Character FilterCharacterByName(String name)
    {
        Character character = new Character();
        using (MySqlConnection conn = GetConnection())
        {
            var sql = $"select * from characters where name = @name";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("name", name);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    character = (new Character()
                    {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader["Name"].ToString(),
                    gemStone = reader["gemStone"].ToString(),
                    affiliations = reader["affiliations"].ToString(),
                    alignment = reader["alignment"].ToString(),
                    status = reader["status"].ToString()//,
                    
                    
                }); 
                }
            }
        }
        return character;
    }
public List<Character> FilterCharacterByGem(String gemStone)
    {
        List <Character> list = new List<Character>();
        using (MySqlConnection conn = GetConnection())
        {
            var sql = $"select * from characters where gemStone = @gemStone";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("gemStone", gemStone);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Character()
                    {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader["Name"].ToString(),
                    gemStone = reader["gemStone"].ToString(),
                    affiliations = reader["affiliations"].ToString(),
                    alignment = reader["alignment"].ToString(),
                    status = reader["status"].ToString()//,
                    
                    
                }); 
                }
            }
        }
        return list;
    }


    public List<Character> FilterCharacterByStatus(String status)
    {
        List <Character> list = new List<Character>();
        using (MySqlConnection conn = GetConnection())
        {
            var sql = $"select * from characters where status = @status";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("status", status);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Character()
                    {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader["Name"].ToString(),
                    gemStone = reader["gemStone"].ToString(),
                    affiliations = reader["affiliations"].ToString(),
                    alignment = reader["alignment"].ToString(),
                    status = reader["status"].ToString()
                    
                    
                }); 
                }
            }
        }
        return list;
    }



    public List<Character> FilterCharacterByAlignment(String alignment)
    {
        List <Character> list = new List<Character>();
        using (MySqlConnection conn = GetConnection())
        {
            var sql = $"select * from characters where alignment = @alignment";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("alignment", alignment);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Character()
                    {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader["Name"].ToString(),
                    gemStone = reader["gemStone"].ToString(),
                    affiliations = reader["affiliations"].ToString(),
                    alignment = reader["alignment"].ToString(),
                    status = reader["status"].ToString()//,
                    
                    
                }); 
                }
            }
        }
        return list;
    }


}
}