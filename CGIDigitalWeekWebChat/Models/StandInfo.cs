using Newtonsoft.Json;
using System;

namespace CGIDigitalWeekWebChat.Models
{
    public class StandInfo
    {
        #region Properties

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("persons")]
        public int Persons { get; set; }

        [JsonIgnore()]
        public DateTime Timestamp { get; set; }

        #endregion Properties

        #region Constructors

        public StandInfo(string deviceId, int persons, DateTime timestamp)
        {
            DeviceId = deviceId;
            Persons = persons;
            Timestamp = timestamp;
        }

        public StandInfo()
        {
        }

        #endregion Constructors
    }
}