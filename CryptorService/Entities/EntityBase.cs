using System;

namespace CryptorService.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
