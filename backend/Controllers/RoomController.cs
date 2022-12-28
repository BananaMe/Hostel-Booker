using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/room")]
public class RoomController
{
    private readonly HostelBookingContext _context;

    public RoomController(HostelBookingContext context)
    {
        _context = context;
    }

    public record AddReservationData(Reservation Reservation, int RoomId);

    [HttpGet]
    [Route("get_all_rooms")]
    public IEnumerable<Room> GetAllRooms(int hostelId)
    {
        return _context.Hostels.Include(h => h.Rooms).FirstOrDefault(h => h.HostelID == hostelId).Rooms;
    }

    [HttpPost]
    [Route("add_reservation")]
    public void AddReservation(AddReservationData data)
    {
        var reservation = data.Reservation;
        var roomId = data.RoomId;
        var room = _context.Rooms
            .Include(r => r.Reservations)
            .FirstOrDefault(r => r.RoomID == roomId);
        room.Reservations.Add(reservation);
        _context.Rooms.Update(room);
        _context.SaveChanges();
    }
}
