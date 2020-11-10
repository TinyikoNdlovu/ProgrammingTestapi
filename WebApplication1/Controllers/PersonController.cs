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
    public class PersonController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select PersonId,Surname,FirstNames,ContactNumber,
                    convert(varchar(10),DateOfTakingSurvey,120) as DateOfTakingSurvey,
                    Age
                    from
                    dbo.Person
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

        public string Post(Person per)
        {
            try
            {
                string query = @"
                    insert into dbo.Person values
                    (
                    '" + per.Surname + @"'
                    ,'" + per.FirstNames + @"'
                    ,'" + per.ContactNumber + @"'
                    ,'" + per.DateOfTakingSurvey + @"'
                    ,'" + per.Age + @"')
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

        [Route("api/Person/GetAllFoodName")]
        [HttpGet]
        public HttpResponseMessage GetAllDishName()
        {
            string query = @"
                    select FoodId from dbo.Food";

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

        [Route("api/Person/GetAllActivityName")]
        [HttpGet]
        public HttpResponseMessage GetAllScaleName()
        {
            string query = @"
                    select ActivityId from dbo.Activity";

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
