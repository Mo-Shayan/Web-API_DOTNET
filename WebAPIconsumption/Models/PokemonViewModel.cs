using System.ComponentModel;

namespace WebAPIconsumption.Models
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        [DisplayName("Pokemon Name")]
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
