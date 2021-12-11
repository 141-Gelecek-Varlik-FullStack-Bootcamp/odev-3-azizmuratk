using System.ComponentModel.DataAnnotations;

namespace AlwaysLowPrice.Model.User

{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [MinLength(4), MaxLength(12)]
        public string Password { get; set; }
    }
}
