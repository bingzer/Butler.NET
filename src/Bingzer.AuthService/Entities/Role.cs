using System.ComponentModel.DataAnnotations;
using Bingzer.Butler.Entity;

namespace Bingzer.StickDraw.AuthService.Entities
{
    public class Role : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
