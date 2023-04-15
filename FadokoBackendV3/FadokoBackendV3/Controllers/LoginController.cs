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
    public class LoginController : ControllerBase
    {
        [HttpPost("SaltRequest/{nev}")]
        public IActionResult SaltRequest(string nev)
        {
            using (mymenuContext context = new mymenuContext())
            {
                try
                {
                    List<Admin> admin = context.Admins.Where(f => f.AdName == nev).ToList();
                    if (admin.Count > 0)
                    {
                        //string salt = Program.GenerateSalt();
                        //string hash = Program.CreateSHA256(Program.CreateSHA256("a" + admin[0].Salt));
                        //return Ok(Program.CreateSHA256("a" + admin[0].Salt));
                        return Ok(admin[0].Salt);
                    }
                    else { return BadRequest("Not a registered name!"); }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPost]
        public IActionResult Login(string nev, string tmpHash)
        {
            using (mymenuContext context = new mymenuContext())
            {
                try
                {
                    List<Admin> admin = context.Admins.Where(f => f.AdName == nev).ToList();
                    if (admin.Count > 0 && admin[0].Active == 1)
                    {
                        //Egyszerre csak egy gépről dolgozhat ha ez a rész benne marad
                        bool talalat = false;
                        int index = 0;
                        int elemSzam = Program.LoggedInUsers.Count;
                        while (!talalat && index < elemSzam)
                        {
                            if (Program.LoggedInUsers.ElementAt(index).Value.AdName == nev)
                            {
                                lock (Program.LoggedInUsers)
                                {
                                    Program.LoggedInUsers.Remove(Program.LoggedInUsers.ElementAt(index).Key);
                                }
                                talalat = true;
                            }
                            index++;
                        }
                        //Egyfelhasználós vége
                        if (Program.CreateSHA256(tmpHash) == admin[0].Hash)
                        {
                            string token = Guid.NewGuid().ToString();
                            lock (Program.LoggedInUsers)
                            {
                                Program.LoggedInUsers.Add(token, admin[0]);
                            }
                            string[] response = new string[3] { token, admin[0].AdName, admin[0].AdPermission.ToString() };
                            return Ok(response);
                        }
                        else
                        {
                            return BadRequest("Hibás jelszó!");
                        }
                    }
                    else
                    {
                        return BadRequest("Hibás felhasználói név!");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
