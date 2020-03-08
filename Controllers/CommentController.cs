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
    public class CommentController : ControllerBase
    {
        private readonly CommentContext _commcontext;
        private readonly PostContext _postcontext;

        public CommentController(CommentContext context, PostContext postcontext)
        {
            _commcontext = context;
            _postcontext = postcontext;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _commcontext.Comments.ToListAsync();
        }

        [HttpGet("getall/{id}")]
        public ActionResult getAll(int id)
        {
            var p = _postcontext.Posts.FirstOrDefault(a => a.postId == id);
            var comm = _commcontext.Comments.FirstOrDefault(a => a.postId == id);

            var content = new {
                Post = p,
                comments = comm
            };

            return Ok(content);

        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _commcontext.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.commentId)
            {
                return BadRequest();
            }

            _commcontext.Entry(comment).State = EntityState.Modified;

            try
            {
                await _commcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comment
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _commcontext.Comments.Add(comment);
            await _commcontext.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.commentId }, comment);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _commcontext.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _commcontext.Comments.Remove(comment);
            await _commcontext.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _commcontext.Comments.Any(e => e.commentId == id);
        }
    }
}
