using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPL2K18.Models;

namespace IPL2K18.Controllers
{
    public class MatchController : Controller
    {
        MatchDataAccessLayer objMatch = new MatchDataAccessLayer();
        // GET: Match
        public ActionResult Index()
        {           
            ViewBag.TeamList1 = new SelectList(GetTeamList(), "Value", "Text");
            ViewBag.TeamList2 = new SelectList(GetTeamList(), "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult Index(Team t)
        {
            //ViewBag.TeamList = new SelectList(GetTeamList(), "Value", "Text");
            //if (!ModelState.IsValid) {

            //}
            //var id = t.TeamName;
            //ViewBag.Message = "Selected Team: " + id.ToString();
            //return View();

            ViewBag.TeamList1 = new SelectList(GetTeamList(), "Value", "Text");
            ViewBag.TeamList2 = new SelectList(GetTeamList(), "Value", "Text");
            t.Team1 = GetTeamList();
            t.Team2 = GetTeamList();

            var selectedItem = t.Team1.Find(team => team.Value == t.TeamId.ToString());
            var selectedItem2 = t.Team2.Find(team => team.Value == t.TeamId.ToString());

            if (selectedItem != null && selectedItem2!= null)
            {
                selectedItem.Selected = true;
                selectedItem2.Selected = true;
                ViewBag.Message = "Selected Team: " + selectedItem.Text + "  " + selectedItem2.Text;
            }
            return View(t);
        }

        public List<SelectListItem> GetTeamList()
        {
            Team objTeam = new Team();
            return objMatch.GetAllTeams();
        }
    }
}