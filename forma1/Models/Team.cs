using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace forma1.Models
{
    public class Team
    {
        public long ID { get; set; }

        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Range(1900, 2100)]
        [Display(Name = "Year founded")]
        public int YearFounded { get; set; }

        [Range(0, 1000)]
        [Display(Name = "World Championships won")]
        public int WorldChampionshipsWon { get; set; }

        [Display(Name = "Paid entry fee")]
        public bool PaidEntryFee { get; set; }
    }
}
