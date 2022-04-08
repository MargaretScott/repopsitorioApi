using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace CursoDotNet.DataAccess.Contracts.Entities
{
    public class BaseEntity
    {
        [Required]
        public int createUserId { get; set; }
        [Required]
        public DateTime createDateTime { get; set; }
        public int? updateUserId { get; set; }
        public DateTime? updateDateTime { get; set; }


        public void SetAudit(EntityState state)
        {
            var now = DateTime.UtcNow;
            if (state == EntityState.Added)
            {
                if (createDateTime == default(DateTime))
                {
                    createDateTime = now;
                }
            }

            updateDateTime = now;
        }
    }
}
