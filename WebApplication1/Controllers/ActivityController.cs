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
    public class ActivityController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select ActivityID,ILikeToEatOut,ILikeToWatchMovies,ILikeToWatchTV,ILikeToListenToTheRadio,
                    PersonId
                    from
                    dbo.Activity
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

        public string Post(Activity act)
        {
            try
            {
                string query = @"
                    insert into dbo.Activity values
                    (
                    '" + act.ILikeToEatOut + @"'
                    ,'" + act.ILikeToWatchMovies + @"'
                    ,'" + act.ILikeToWatchTV + @"'
                    ,'" + act.iLikeToListenToTheRadio + @"'
                    ,'" + act.PersonId + @"')
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
