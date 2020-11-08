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
    public class ParticipantController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select ParticipantId,Surname,FirstNames,Dish,Scale,ContactNumber,
                    convert(varchar(10),DateOfTakingSurvey,120) as DateOfTakingSurvey,
                    Age
                    from
                    dbo.Participant
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

        public string Post(Participant par)
        {
            try
            {
                string query = @"
                    insert into dbo.Participant values
                    (
                    '" + par.Surname + @"'
                    '" + par.FirstNames + @"'
                    ,'" + par.Dish + @"'
                    ,'" + par.Scale + @"'
                    ,'" + par.ContactNumber + @"'
                    ,'" + par.DateOfTakingSurvey + @"'
                    ,'" + par.Age + @"')
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

        [Route("api/Participant/GetAllDishName")]
        [HttpGet]   
        public HttpResponseMessage GetAllDishName()
        {
            string query = @"
                    select DishName from dbo.Dish";

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

        [Route("api/Participant/GetAllScaleName")]
        [HttpGet]
        public HttpResponseMessage GetAllScaleName()
        {
            string query = @"
                    select ScaleName from dbo.Scale";

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

    }
}
