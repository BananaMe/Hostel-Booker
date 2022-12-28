﻿using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/hostel")]
public class HostelController
{
    private readonly HostelBookingContext _context;

    public HostelController(HostelBookingContext context)
    {
        _context = context;
    }

    public record RoomAndHostel(Room room, int hostelId);

    public record CheckAvailabilityData(DateOnly StartDate, DateOnly EndDate, int HostelId);

    [HttpGet]
    [Route("get_all_hostels")]
    public IEnumerable<Hostel> GetAllHostels()
    {
        return _context.Hostels;
    }
    
    [HttpGet]
    [Route("get_hostel")]
    public Hostel GetHostel([FromQuery(Name = "id")] int hostelID)
    {
        return _context.Hostels.FirstOrDefault(h => h.HostelID == hostelID);
    }

    [HttpPost]
    [Route("add_hostel")]
    public void AddHostel([FromBody] string ime)
    {
        _context.Hostels.Add(new Hostel(ime));
        _context.SaveChanges();
    }

    [HttpPost]
    [Route("add_room")]
    public void AddRoom(RoomAndHostel data)
    {
        var room = data.room;
        var hostelId = data.hostelId;
        _context.Rooms.Add(room);
        _context.SaveChanges();

        var hostel = _context.Hostels
            .Include(h => h.Rooms)
            .FirstOrDefault(h => h.HostelID == hostelId);
        hostel.Rooms.Add(room);
        _context.Hostels.Update(hostel);
        _context.SaveChanges();
    }

    [HttpPost]
    [Route("get_available_rooms")]
    public IEnumerable<Room> GetAvailableRooms(CheckAvailabilityData data)
    {
        var startDate = data.StartDate;
        var endDate = data.EndDate;
        var hostelId = data.HostelId;
        var hostel = _context.Hostels.FirstOrDefault(h => h.HostelID == hostelId);
        if (startDate > endDate)
        {
            return new List<Room>();
        }

        return hostel.Rooms.Where(
            h =>
                h.Reservations.All(
                    reservation =>
                        (reservation.StartDate > startDate && reservation.StartDate > endDate)
                        || (reservation.EndDate < endDate && reservation.EndDate < startDate)
                )
        );
    }
}
