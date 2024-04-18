using WebApp2.Models;

namespace WebApp2.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(String orderBy);
    int CreateAnimal();
    Animal GetAnimal(int idAnimal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}