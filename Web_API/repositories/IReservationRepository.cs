using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;
using WebApplicationfin.Models;

namespace WebApplicationfin.repositories
{
    public interface IReservationRepository
    {
        Reservation GetById(int id);
        IEnumerable<Reservation> GetAll();
        void Insert(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
    }

    public class ReservationRepository : IReservationRepository
    {
        private readonly RoommeetContext _dbContext;

        public ReservationRepository(RoommeetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Reservation GetById(int id)
        {
            return _dbContext.Reservations.Find(id);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _dbContext.Reservations.ToList();
        }

        public void Insert(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }

        public void Update(Reservation reservation)
        {
            _dbContext.Reservations.Update(reservation);
            _dbContext.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            _dbContext.Reservations.Remove(reservation);
            _dbContext.SaveChanges();
        }
    }
  
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetAllReservations()
        {
            var reservations = _reservationRepository.GetAll();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservationById(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpPost]
        public ActionResult<Reservation> CreateReservation(Reservation reservation)
        {
            _reservationRepository.Insert(reservation);
            return CreatedAtRoute("GetReservationById", new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id}")]
        public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            var existingReservation = _reservationRepository.GetById(id);
            if (existingReservation == null)
                return NotFound();

            existingReservation.MeetingDate = reservation.MeetingDate;
            existingReservation.StartTime = reservation.StartTime;
            existingReservation.EndTime = reservation.EndTime;
            existingReservation.RoomId = reservation.RoomId;
            existingReservation.NumberOfAttendees = reservation.NumberOfAttendees;
            existingReservation.MeetingStatus = reservation.MeetingStatus;

            _reservationRepository.Update(existingReservation);
            return Ok(existingReservation);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            var existingReservation = _reservationRepository.GetById(id);
            if (existingReservation == null)
                return NotFound();

            _reservationRepository.Delete(existingReservation);
            return NoContent();
        }
    }
}
