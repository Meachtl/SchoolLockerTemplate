using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLocker.Core.DataTransferObjects
{
    public class LockerWithDetailedBookingsDTO
    {
        public int Number { get; set; }

        public int CountBookings { get; set; }


        public DateTime? FromTime { get; set; }

        public DateTime? ToTime { get; set; }

    }
}
