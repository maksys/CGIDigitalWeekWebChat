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

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonIgnore()]
        public DateTime Timestamp { get; set; }

        #endregion Properties

        #region Constructors

        public StandInfo(string deviceId, int persons, string message, DateTime timestamp)
        {
            DeviceId = deviceId;
            Persons = persons;
            Message = message;
            Timestamp = timestamp;
        }

        public StandInfo()
        {
        }

        #endregion Constructors
    }
}