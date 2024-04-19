using WebApp2.Models;

namespace WebApp2.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(String OrderBy);
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    int UpdateAnimal(int idAnimal, Animal animal);
    int DeleteAnimal(int idAnimal);
}