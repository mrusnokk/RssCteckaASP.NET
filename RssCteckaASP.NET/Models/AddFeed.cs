using System.ComponentModel.DataAnnotations;

namespace RssCteckaASP.NET.Models
{
    public class AddFeed
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "Je potreba vybrat stitek bby!")]
        [MaxLength(200)]
        public string Nazev { get; set; }
        [Required(ErrorMessage = "Je potreba vybrat stitek bby!")]
        [RegularExpression(@"^https://[a-zA-Z.]+/.+")]
        public string URL { get; set; }
        [MaxLength(1000)]
        public string popis { get; set; }
        [Required(ErrorMessage ="Je potreba vybrat stitek bby!")]
        public string Stitek { get; set; }

    }
}
