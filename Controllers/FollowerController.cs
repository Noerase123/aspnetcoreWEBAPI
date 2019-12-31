using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly FollowerContext _context;

        public FollowerController(FollowerContext context)
        {
            _context = context;
        }

        // GET: api/Follower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follower>>> GetFollowers()
        {
            return await _context.Followers.ToListAsync();
        }

        // GET: api/Follower/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follower>> GetFollower(int id)
        {
            var follower = await _context.Followers.FindAsync(id);

            if (follower == null)
            {
                return NotFound();
            }

            return follower;
        }

        // PUT: api/Follower/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollower(int id, Follower follower)
        {
            if (id != follower.followerId)
            {
                return BadRequest();
            }

            _context.Entry(follower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Follower
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Follower>> PostFollower(Follower follower)
        {
            _context.Followers.Add(follower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollower", new { id = follower.followerId }, follower);
        }

        // DELETE: api/Follower/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Follower>> DeleteFollower(int id)
        {
            var follower = await _context.Followers.FindAsync(id);
            if (follower == null)
            {
                return NotFound();
            }

            _context.Followers.Remove(follower);
            await _context.SaveChangesAsync();

            return follower;
        }

        private bool FollowerExists(int id)
        {
            return _context.Followers.Any(e => e.followerId == id);
        }
    }
}
