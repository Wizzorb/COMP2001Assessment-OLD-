using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable disable

namespace APIcomp2001.Models
{
    public partial class User
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public string UserEmail { get; set; }
        public string UserPword { get; set; }
    }
}
