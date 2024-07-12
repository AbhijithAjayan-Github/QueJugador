using System.ComponentModel.DataAnnotations;

namespace QueJugadorApp.Models
{
    public class AddPlayerViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string PlayerName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string PlayerAddress { get; set; }

        [Required(ErrorMessage = "Mail Id is required")]
        public string PlayerMail { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "10 Digit Phone number is required")]
        public string PlayerPhone { get; set; }
        public string PlayerPosition { get; set; }
        public string PlayerGroup { get; set; }
    }
}
