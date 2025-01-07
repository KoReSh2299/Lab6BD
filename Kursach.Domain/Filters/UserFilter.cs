using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class UserFilter
    {
        public string? Username { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
        public DateTime? MinCreatedAt { get; set; } = null;
        public DateTime? MaxCreatedAt { get; set; } = null;
    }
}
