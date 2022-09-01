using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Some decrciption
    /// </summary>
    public class UserClass
    {
        [Required]
        public uint Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Birth { get; set; } 

    }
}
