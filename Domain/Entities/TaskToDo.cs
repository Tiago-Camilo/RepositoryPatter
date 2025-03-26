using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskToDo : IIdentityEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Start{ get; set; }
        public DateTime DeadLine { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
