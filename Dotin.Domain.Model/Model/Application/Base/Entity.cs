using System;


namespace Dotin.HostApi.Domain.Model.Application.Base
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreateDateTime { get; set; }
    }
}