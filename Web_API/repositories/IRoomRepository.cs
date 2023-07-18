using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;
using WebApplicationfin.Models;

namespace WebApplicationfin.repositories
{
    public interface IRoomRepository
    {
        Room GetById(int id);
        IEnumerable<Room> GetAll();
        void Insert(Room room);
        void Update(Room room);
        void Delete(Room room);
    }

    public class RoomRepository : IRoomRepository
    {
        private readonly RoommeetContext _dbContext;

        public RoomRepository(RoommeetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room GetById(int id)
        {
            return _dbContext.Rooms.Find(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _dbContext.Rooms.ToList();
        }

        public void Insert(Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
        }

        public void Update(Room room)
        {
            _dbContext.Rooms.Update(room);
            _dbContext.SaveChanges();
        }

        public void Delete(Room room)
        {
            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();
        }
    }
  
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetAllCompanies()
        {
            var companies = _companyRepository.GetAll();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetCompanyById(int id)
        {
            var company = _companyRepository.GetById(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpPost]
        public ActionResult<Company> CreateCompany(Company company)
        {
            _companyRepository.Insert(company);
            return CreatedAtRoute("GetCompanyById", new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public ActionResult<Company> UpdateCompany(int id, Company company)
        {
            var existingCompany = _companyRepository.GetById(id);
            if (existingCompany == null)
                return NotFound();

            existingCompany.Name = company.Name;
            existingCompany.Description = company.Description;
            existingCompany.Email = company.Email;
            existingCompany.Logo = company.Logo;
            existingCompany.Active = company.Active;
            existingCompany.UserId = company.UserId;

            _companyRepository.Update(existingCompany);
            return Ok(existingCompany);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCompany(int id)
        {
            var existingCompany = _companyRepository.GetById(id);
            if (existingCompany == null)
                return NotFound();

            _companyRepository.Delete(existingCompany);
            return NoContent();
        }
    }
 
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = _roomRepository.GetAll();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public ActionResult<Room> GetRoomById(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public ActionResult<Room> CreateRoom(Room room)
        {
            _roomRepository.Insert(room);
            return CreatedAtRoute("GetRoomById", new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public ActionResult<Room> UpdateRoom(int id, Room room)
        {
            var existingRoom = _roomRepository.GetById(id);
            if (existingRoom == null)
                return NotFound();

            existingRoom.Name = room.Name;
            existingRoom.Location = room.Location;
            existingRoom.Capacity = room.Capacity;
            existingRoom.RoomDescription = room.RoomDescription;
            existingRoom.CompanyId = room.CompanyId;

            _roomRepository.Update(existingRoom);
            return Ok(existingRoom);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRoom(int id)
        {
            var existingRoom = _roomRepository.GetById(id);
            if (existingRoom == null)
                return NotFound();

            _roomRepository.Delete(existingRoom);
            return NoContent();
        }
    }
}
