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
    public class CommodityController : ControllerBase
    {
        [HttpGet("{CoId}")]

        public IActionResult Get(int CoId)
        {
            /*if ((Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9"))
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    var commodities = new List<Commodity>(context.Commodities);
                    var selection = commodities.FirstOrDefault(a => a.CoId == CoId);
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
        [HttpPost("{CoId}")]

        public IActionResult Post(string CoId, Commodity commodity)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    context.Commodities.Add(commodity);
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
        [HttpPut("{CoId}")]

        public IActionResult Put(string CoId, Commodity commodity)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    context.Commodities.Update(commodity);
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
        [HttpDelete("{CoId}")]

        public IActionResult Delete(string CoId, int coid)
        {
            /*if (Program.LoggedInUsers.ContainsKey(uId) && Program.LoggedInUsers[uId].AdPermission == "9")
            {*/
            using (var context = new mymenuContext())
            {
                try
                {
                    Commodity commodity = new Commodity();
                    commodity.CoId = coid;
                    context.Commodities.Remove(commodity);
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
