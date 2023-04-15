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
    public class AdminController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            /*if ((Program.LoggedInUsers.ContainsKey(AdId) && Program.LoggedInUsers[AdId].AdPermission == "9"))
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    var admins = new List<Admin>(context.Admins);
                    return Ok(admins);
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

        [HttpGet("{AdId}")]

        public IActionResult Get(int AdId)
        {
            /*if ((Program.LoggedInUsers.ContainsKey(AdId) && Program.LoggedInUsers[AdId].AdPermission == "9"))
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    var admins = new List<Admin>(context.Admins);
                    var selection = admins.FirstOrDefault(a => a.AdId == AdId);
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
        [HttpPost("{AdId}")]

        public IActionResult Post(string AdId, Admin admin)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    context.Admins.Add(admin);
                    context.SaveChanges();
                    return Ok("Add user ok.");
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
        [HttpPut("{AdId}")]

        public IActionResult Put(string AdId, Admin admin)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    context.Admins.Update(admin);
                    context.SaveChanges();
                    return Ok("User modification ok.");
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
        [HttpDelete("{AdId}")]

        public IActionResult Delete(string AdId, int adid)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    Admin admin = new Admin();
                    admin.AdId = adid;
                    context.Admins.Remove(admin);
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
