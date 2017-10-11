using System;
using System.Collections.Generic;

namespace GDOT.SFMC.Domain.Models
{
    [Serializable]
    public class EventDetails
    {
        public string ExternalKey { get; set; }

        public string Brand { get; set; }

        public string EventType { get; set; }

        public List<Dictionary<string, string>> AttributesList { get; set; }
    }
}
