using WebApp2.Models;
using WebApp2.Repositories;

namespace WebApp2.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(String orderBy)
    {
        return _animalRepository.GetAnimals(orderBy);
    }

    public int CreateAnimal()
    {
        throw new NotImplementedException();
    }

    public Animal? GetAnimal(int idAnimal)
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