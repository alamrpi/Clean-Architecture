﻿namespace BuberDinner.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<TId> where TId : notnull
    {
        public TId Id { get; set; }
        protected Entity(TId id)
        { 
            Id = id;
        }
        public Entity()
        {
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(TId? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right) 
        { 
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
