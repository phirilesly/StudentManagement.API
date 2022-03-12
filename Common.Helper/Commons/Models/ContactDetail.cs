

using System.Runtime.Serialization;

namespace Common.Helper.Commons.Models
{
    [DataContract]
    public class ContactDetail
    {
        [DataMember(Name = "contactType")]
        public string ContactType { get; set; }

        [DataMember(Name = "contact")]
        public string Contact { get; set; }
    }
}
