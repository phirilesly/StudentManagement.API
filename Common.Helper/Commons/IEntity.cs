using System;


namespace Common.Helper.Commons
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
        bool IsNew { get; set; }
    }
}
