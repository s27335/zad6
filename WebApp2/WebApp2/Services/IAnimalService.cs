using WebApp2.Models;

namespace WebApp2.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(String OrderBy);
    int CreateAnimal();
    Animal? GetAnimal(int idAnimal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}