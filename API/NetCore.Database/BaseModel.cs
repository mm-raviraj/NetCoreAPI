using System;

namespace Code.Database
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}