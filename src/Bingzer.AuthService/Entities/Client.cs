using System.ComponentModel.DataAnnotations;
using Bingzer.Butler.Entity;

namespace Bingzer.StickDraw.AuthService.Entities
{
    public class Client : Entity
    {
        /// <summary>
        /// Unique ClientId
        /// </summary>
        [Required]
        public string ClientId { get; set; }

        /// <summary>
        /// Secret pass for this client
        /// </summary>
        [Required]
        public string Secret { get; set; }

        /// <summary>
        /// The name of the client
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
