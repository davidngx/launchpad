using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Launchpad.Models
{
    [DataContract]
    public class LaunchPad
    {
        [DataMember]
        public int padid { get; set; }

        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string full_name { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public Location location { get; set; }

        [DataMember]
        public List<string> vehicles_launched { get; set; }

        [DataMember]
        public int attempted_launches { get; set; }

        [DataMember]
        public int successful_launches { get; set; }

        [DataMember]
        public string wikipedia { get; set; }

        [DataMember]
        public string details { get; set; }
    }

    [DataContract]
    public class Location
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string region { get; set; }

        [DataMember]
        public double latitude { get; set; }

        [DataMember]
        public double longitude { get; set; }
    }
}
