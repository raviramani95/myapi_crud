using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Entities;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
             
            return await _context.Users.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<AppUser>>> PostUser(AppUser user){
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync(); 

        } 

        [HttpPut("{id}")]
        public async Task<ActionResult<AppUser>> PutUser(int id, AppUser user){
            var user_ = await _context.Users.FindAsync(id);
            user_.Id = user.Id;
            user_.UserName = user.UserName;

            _context.Users.Update(user_);
            await _context.SaveChangesAsync();
            return await _context.Users.FindAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<AppUser>>> DeleteUser(int id){
            var user = await _context.Users.FindAsync(id);
            
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteUser(int id){
        //     var user = await _context.Users.FindAsync(id);
            
        //     _context.Users.Remove(user);
        //     await _context.SaveChangesAsync();
        //     return Ok();
        // }
    }
}