using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.Models
{
    public class UserToken
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
