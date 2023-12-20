using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.FootballTrick.Shared.Entities
{
    public class Team
    {
        public int TeamId {get;set;}
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Name { get; set; }
        public DateTime CreationDate {get;set;}
    }
}