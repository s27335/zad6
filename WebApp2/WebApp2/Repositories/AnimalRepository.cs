using System.Data.SqlClient;
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

        if (orderBy.Equals("IdAnimal") || orderBy.Equals("Name") || orderBy.Equals("Description") || orderBy.Equals("Category") || orderBy.Equals("Area"))
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

    public int CreateAnimal()
    {
        throw new NotImplementedException();
    }

    public Animal GetAnimal(int idAnimal)
    {
        throw new NotImplementedException();
    }

    public int UpdateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public int DeleteAnimal(int idAnimal)
    {
        throw new NotImplementedException();
    }
}