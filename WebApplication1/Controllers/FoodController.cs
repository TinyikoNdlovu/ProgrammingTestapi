using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//Import necessary Models
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication1.Controllers
{
    public class FoodController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select FoodId,Pizza,Pasta,Papandwors,ChickenstirFry,BeefstirFry,
                    Other,PersonId
                    from
                    dbo.Food
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ParticipantAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Food fod)
        {
            try
            {
                string query = @"
                    insert into dbo.Food values
                    (
                    '" + fod.Pizza + @"'
                    ,'" + fod.Pasta + @"'
                    ,'" + fod.Papandwors + @"'
                    ,'" + fod.ChickenstirFry + @"'
                    ,'" + fod.BeefstirFry + @"'
                    ,'" + fod.Other + @"'
                    ,'" + fod.PersonId + @"')
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ParticipantAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Add!";
            }

        }
    }
}
