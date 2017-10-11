using GDOT.SFMC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDOT.SFMC.Domain.Models
{
    public class Notification
    {
        public List<EventDetails> EventList { get; set; }

        public Status Status { get; set; } = Status.Success;

        public string ErrorMessage { get; set; }
    }
}
