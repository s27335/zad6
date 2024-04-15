using Microsoft.AspNetCore.Mvc;
using WebApp2.Services;

namespace WebApp2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController
{
    private IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
}