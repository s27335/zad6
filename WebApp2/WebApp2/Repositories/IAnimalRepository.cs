using WebApp2.Models;

namespace WebApp2.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(String orderBy);
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    int UpdateAnimal(int idAnimal, Animal animal);
    int DeleteAnimal(int idAnimal);
}