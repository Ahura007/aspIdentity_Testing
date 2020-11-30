using System;

namespace Dotin.Domain.Model.Model.Application.Base
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreateDateTime { get; set; }

        protected Entity()
        {
            CreateDateTime = DateTime.Now;
        }
    }
}