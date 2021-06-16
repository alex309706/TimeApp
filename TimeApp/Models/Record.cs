using System;

namespace TimeApp.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public DateTime BeginOfWork { get; set; }
        public DateTime EndOfWork { get; set; }
        public DateTime SpentTime { get; set; }
        public string Employment { get; set; }
    }
}
