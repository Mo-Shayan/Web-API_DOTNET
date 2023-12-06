using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPIconsumption.Models;
using System.Net.Http;

namespace WebAPIconsumption.Controllers
{

    public class PokemonController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7045/api");

        private readonly HttpClient _client;

        public PokemonController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<PokemonViewModel> pokemonList = new List<PokemonViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Pokemon").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                pokemonList = JsonConvert.DeserializeObject<List<PokemonViewModel>>(data);
            }
            return View(pokemonList);
        }


        [HttpGet("Pokemon/{pokeId}")]
        public IActionResult GetPokemonById(int pokeId)
        {
            PokemonViewModel pokemon = new PokemonViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Pokemon/" + pokeId).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                pokemon = JsonConvert.DeserializeObject<PokemonViewModel>(data);
            }

            return View(pokemon);
        }


        [HttpGet("Pokemon/{pokeId}/rating")]
        public IActionResult GetPokemonRating(int pokeId)
        {
            PokemonViewModel rating = new PokemonViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Pokemon/" + pokeId + "/rating").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                rating = JsonConvert.DeserializeObject<PokemonViewModel>(data);
            }

            return View(rating);
        }

    }
}
