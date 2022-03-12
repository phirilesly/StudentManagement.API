
using Common.Helper.Commons.Enums;
using System;
using System.Collections.Generic;

using System.Runtime.Serialization;


namespace Common.Helper.Commons
{
    [DataContract]
    public class CustomField
    {


        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public string PlaceHolder { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public string Hint { get; set; }

        [DataMember]
        public int Order { get; set; }

        [DataMember]
        public string Validator { get; set; }

        [DataMember]
        public ValidatorType ValidatorType { get; set; }

        [DataMember]
        public dynamic Value { get; set; }

        [DataMember]
        public string ValueType { get; set; }

        [DataMember]
        public ControlType ControlType { get; set; }


        [DataMember]
        public string Appearance { get; set; }

        [DataMember]
        public bool Disabled { get; set; }

        [DataMember]
        public bool ReadOnly { get; set; }

        [DataMember]
        public bool IsLookUp { get; set; }

        [DataMember]
        public Guid LookUpId { get; set; }

        [DataMember]
        public bool Required { get; set; }

        [DataMember]
        public bool ShowIcon { get; set; }

        [DataMember]
        public bool ShowHint { get; set; }

        [DataMember]
        public List<string> Options { get; set; }
    }
}
