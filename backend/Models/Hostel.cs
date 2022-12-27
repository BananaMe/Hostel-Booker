using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Hostel
{
    public Hostel() { }

    public Hostel(string ime)
    {
        Name = ime;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HostelID { get; set; }

    public ICollection<Room> Rooms { get; set; }
    public string Name { get; set; }
}
