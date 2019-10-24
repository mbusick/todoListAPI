using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todoListAPI.Models
{
    public class EditTodoRequest
    {
        public string Task { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}