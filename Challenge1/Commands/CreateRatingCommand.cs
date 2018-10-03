using System.ComponentModel.DataAnnotations;
using AzureFromTheTrenches.Commanding.Abstractions;
using Challenge1.Models;

namespace Challenge1.Commands
{
    public class CreateRatingCommand: ICommand<RatingModel>
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string productId { get; set; }
        public string locationName { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Can only be between 0 .. 5")]
        public int rating { get; set; }
        public string userNotes { get; set; }
    }
}
