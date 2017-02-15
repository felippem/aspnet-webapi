using System;

namespace SharedKernel.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IDisposable
    {
        public TId Id { get; private set; }

        protected Entity()
        {
            // O Entity framework requer um contructor "protected" vazio.
        }

        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
                throw new ArgumentException("O id não deve ter o valor padrão do seu tipo", "Id");

            this.Id = id;
        }

        ~Entity()
        {
            this.Dispose();
        }

        public bool Equals(Entity<TId> other)
        {
            return (other != null && this.Id.Equals(other.Id));
        }

        public override bool Equals(object otherObject)
        {
            var entity = (Entity<TId>)otherObject;
            
            return (entity != null ? this.Equals(entity) : base.Equals(otherObject));
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
