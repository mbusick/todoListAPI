using System;

namespace todoListAPI.Models
{
    public class TodoRequest
    {
        public string Task { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}