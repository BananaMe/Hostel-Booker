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

    public record DeleteReservationData(int ReservationId, int RoomId);

    [HttpGet]
    [Route("get_hostel_rooms")]
    public IEnumerable<Room> GetHostelRooms(int hostelId)
    {
        return _context.Hostels.Where(h => h.Rooms.Any()).FirstOrDefault(h => h.HostelID == hostelId)?.Rooms;
    }
    

    [HttpGet]
    [Route("get_reservation")]
    public IEnumerable<Reservation> GetReservation(int roomId)
    {
        return _context.Rooms.FirstOrDefault(r => r.RoomID == roomId).Reservations;
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
    
    [HttpDelete]
    [Route("delete_reservation")]
    public void DeleteReservation(DeleteReservationData data)
    {
        var reservationId = data.ReservationId;
        var roomId = data.RoomId;
        var reservation = _context.Reservations.FirstOrDefault(r => r.ReservationID == reservationId);
        var room = _context.Rooms
            .Include(r => r.Reservations).FirstOrDefault(r => r.RoomID == roomId);
        _context.Reservations.Remove(reservation);
        _context.SaveChanges();
    }
}
