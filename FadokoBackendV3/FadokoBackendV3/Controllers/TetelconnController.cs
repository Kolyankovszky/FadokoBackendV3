using FadokoBackendV3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FadokoBackendV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TetelconnController : ControllerBase
    {
        [HttpGet("{OrId}")]

        public IActionResult Get(int OrId)
        {
            /*if ((Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9"))
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    var tetelconns = new List<Tetelconn>(context.Tetelconns);
                    var selection = tetelconns.FirstOrDefault(a => a.OrId == OrId);
                    return Ok(selection);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }/*
            }
            else
            {
                return BadRequest("Error!");
            }*/
        }
        [HttpPost("{OrId}")]

        public IActionResult Post(string OrId, Tetelconn tetelconn)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    context.Tetelconns.Add(tetelconn);
                    context.SaveChanges();
                    return Ok("Add tetelconn ok.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }/*
            }
            else
            {
                return BadRequest("Error!");
            }*/
        }
        [HttpPut("{OrId}")]

        public IActionResult Put(string OrId, Tetelconn tetelconn)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    context.Tetelconns.Update(tetelconn);
                    context.SaveChanges();
                    return Ok("tetelconn modification ok.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            /*}
            else
            {
                return BadRequest("Error!");
            }*/
        }
        [HttpDelete("{OrId}")]

        public IActionResult Delete(string OrId, int orid)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    Tetelconn tetelconn = new Tetelconn();
                    tetelconn.OrId = orid;
                    context.Tetelconns.Remove(tetelconn);
                    context.SaveChanges();
                    return Ok("Delete ok.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }/*
            }
            else
            {
                return BadRequest("Error!");
            }*/
        }
    }
}
