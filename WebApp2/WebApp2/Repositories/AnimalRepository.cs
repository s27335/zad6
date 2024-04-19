using System.Data.SqlClient;
using System.Security.Cryptography;
using WebApp2.Models;


namespace WebApp2.Repositories;

public class AnimalRepository : IAnimalRepository
{ 
    //Sql Connect
    //"Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True"
    private IConfiguration _configuration;
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(String orderBy)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var sqlCmd = new SqlCommand();
        sqlCmd.Connection = con;

        if (orderBy.Equals("Name") || orderBy.Equals("Description") || orderBy.Equals("Category") || orderBy.Equals("Area"))
        {
            sqlCmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY " + orderBy;

        }
        
        var dataReader = sqlCmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dataReader.Read())
        {
            var row = new Animal()
            {
                id = (int)dataReader["IdAnimal"],
                name = dataReader["Name"].ToString(),
                description = dataReader["Description"].ToString(),
                category = dataReader["Category"].ToString(),
                area = dataReader["Area"].ToString()
            };
            animals.Add(row);
        }

        return animals;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var sqlCmd = new SqlCommand();
        sqlCmd.Connection = con;
        sqlCmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Name";
        
        var dataReader = sqlCmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dataReader.Read())
        {
            var row = new Animal()
            {
                id = (int)dataReader["IdAnimal"],
                name = dataReader["Name"].ToString(),
                description = dataReader["Description"].ToString(),
                category = dataReader["Category"].ToString(),
                area = dataReader["Area"].ToString()
            };
            animals.Add(row);
        }

        return animals;
    }
    
    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var sqlCmd = new SqlCommand();
        sqlCmd.Connection = con;
        sqlCmd.CommandText = "INSERT INTO Animal(Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";
        sqlCmd.Parameters.AddWithValue("@Name", animal.name);
        sqlCmd.Parameters.AddWithValue("@Description", animal.description);
        sqlCmd.Parameters.AddWithValue("@Category", animal.category);
        sqlCmd.Parameters.AddWithValue("@Area", animal.area);

        return sqlCmd.ExecuteNonQuery();
    }

    public int UpdateAnimal(int idAnimal, Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var sqlCmd = new SqlCommand();
        sqlCmd.Connection = con;
        sqlCmd.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";
        sqlCmd.Parameters.AddWithValue("@Name", animal.name);
        sqlCmd.Parameters.AddWithValue("@Description", animal.description);
        sqlCmd.Parameters.AddWithValue("@Category", animal.category);
        sqlCmd.Parameters.AddWithValue("@Area", animal.area);
        sqlCmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

        return sqlCmd.ExecuteNonQuery();
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        var sqlCmd = new SqlCommand();
        sqlCmd.Connection = con;
        sqlCmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        sqlCmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

        return sqlCmd.ExecuteNonQuery();
    }
}