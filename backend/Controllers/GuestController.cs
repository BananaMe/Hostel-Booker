using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/guest")]
public class GuestController
{
    private readonly HostelBookingContext _context;

    public GuestController(HostelBookingContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("get_all_guests")]
    public IEnumerable<Guest> GetAllGuests()
    {
        return _context.Guests;
    }

    [HttpGet]
    [Route("get_guest")]
    public Guest GetGuest([FromQuery(Name = "id")] int guestID)
    {
        return _context.Guests.FirstOrDefault(g => g.GuestID == guestID);
    }

    [HttpPost]
    [Route("add_guest")]
    public void AddGuest([FromBody] string Ime)
    {
        _context.Guests.Add(new Guest(Ime));
        _context.SaveChanges();
    }
    
    [HttpDelete]
    [Route("delete_guest")]
    public void DeleteGuest([FromQuery(Name = "id")] int guestId)
    {
        var guest = _context.Guests.FirstOrDefault(g => g.GuestID == guestId);
        _context.Remove(guest);
        _context.SaveChanges();
    }
}
