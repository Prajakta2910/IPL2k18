using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPL2K18.Models
{
    public class MatchDataAccessLayer
    {
        public List<SelectListItem> GetAllTeams()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Prajakta\MVC Projects\IPL2018.accdb";
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                //OleDbDataReader reader = null;
                OleDbCommand command = new OleDbCommand("SELECT * from  tblTeamDetails", connection);
                //command.Parameters.AddWithValue("@1", userName);
                //reader = command.ExecuteReader();

                OleDbDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new SelectListItem
                    {
                        Text = rdr["TeamName"].ToString(),
                        Value = rdr["TeamId"].ToString()
                    });
                }
                connection.Close();
            }
            return items;
        }

        
    }
}