using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Guest
{
    public Guest(string ime)
    {
        Name = ime;
    }

    public Guest() { }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GuestID { get; set; }

    public string Name { get; set; }
}
