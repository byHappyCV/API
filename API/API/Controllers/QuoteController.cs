using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Quote")]
    public class QuoteController : Controller
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<QuoteDTO> Get()
        {
            return _quoteService.GetQuotes();
        }
        /// <summary>
        /// get item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _quoteService.GetQuote(id);
            if (result == null)
            {
                return BadRequest();
            }
            return new JsonResult(result);
        }
        /// <summary>
        /// Create item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] QuoteDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _quoteService.AddQuote(item);

            return Ok(item);
        }
        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody]QuoteDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _quoteService.EditQuote(item);
            return Ok(item);

        }
        /// <summary>
        /// delete item
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _quoteService.GetQuote(id);
            if (author == null)
            {
                return BadRequest();
            }
            _quoteService.DeleteQuote(author);
            return Ok();
        }
    }
}