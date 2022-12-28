using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoomID { get; set; }

    public int RoomNumber { get; set; }
    public int GuestCapacity { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }

    public Room(int roomNum, int guestCapacity)
    {
        RoomNumber = roomNum;
        GuestCapacity = guestCapacity;
    }

    public Room() { }
}
