using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public abstract class BaseEntity
	{
        public int Id { get; set; }
		public string? Name { get; set; }
        public Status? Status { get; set; } = Enums.Status.Active;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
	}
}
