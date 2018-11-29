using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IAuthorsService _authorsService;

        public ValuesController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public IEnumerable<AuthorDTO> Get()
        {
            return _authorsService.GetAuthors();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _authorsService.GetAuthor(id);
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AuthorDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _authorsService.AddAuthor(item);

            return Ok(item);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]AuthorDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _authorsService.EditAuthor(item);
            return Ok(item);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
