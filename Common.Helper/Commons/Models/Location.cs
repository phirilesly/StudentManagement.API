

using System.Runtime.Serialization;

namespace Common.Helper.Commons.Models
{
    [DataContract]
    public class Location
    {
        /// <summary>
        /// The longitude of the location.
        /// </summary>
        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// The latitude of the location.
        /// </summary>
        [DataMember(Name = "lattitude")]
        public string Lattitude { get; set; }

        /// <summary>
        /// The additional details about the location
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        ///Event's address as location 
        /// </summary>
        [DataMember(Name = "address")]
        public Address Address { get; set; }
    }
}
