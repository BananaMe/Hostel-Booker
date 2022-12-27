using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Reservation
{
    public Reservation() { }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReservationID { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Reservee { get; set; }
    public ICollection<Guest> Guests { get; set; }
}
