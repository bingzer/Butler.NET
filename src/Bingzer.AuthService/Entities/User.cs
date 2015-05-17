using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bingzer.Butler.Entity;

namespace Bingzer.StickDraw.AuthService.Entities
{
    public class User : Entity
    {
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
