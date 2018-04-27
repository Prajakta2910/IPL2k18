using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPL2K18.Models
{
    public class Team
    {
        public List<SelectListItem> Team1 { get; set; }

        public List<SelectListItem> Team2 { get; set; }

        public List<Team> lstTeam = new List<Team>();
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}