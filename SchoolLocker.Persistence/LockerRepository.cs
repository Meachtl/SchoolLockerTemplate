using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Persistence
{
    internal class LockerRepository : ILockerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LockerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LockerWithDetailedBookingsDTO[] GetLockerWithDetailedBookingsDTO()
        {
            var result = _dbContext.Lockers
                .Select(x => new LockerWithDetailedBookingsDTO
                {
                    Number = x.Number,
                    CountBookings = x.Bookings.Count(),
                    FromTime = x.Bookings.OrderByDescending(o => o.From).FirstOrDefault().From,
                    ToTime = x.Bookings.OrderByDescending(o => o.From).FirstOrDefault().To
                })
                .OrderBy(o => o.Number)
                .ToArray();
            return result;
        }
    }
}