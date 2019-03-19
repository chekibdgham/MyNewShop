using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewShop.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTimeOffset Created { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Created = DateTime.Now;
        }
    }
}
