﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorsService _authorsService;

        public AuthorController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<AuthorDTO> Get()
        {
            return _authorsService.GetAuthors();
        }
        /// <summary>
        /// get item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _authorsService.GetAuthor(id);
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
        public IActionResult Create([FromBody] AuthorDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _authorsService.AddAuthor(item);

            return Ok(item);
        }
        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
        /// <summary>
        /// delete item
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorsService.GetAuthor(id);
            if (author == null)
            {
                return BadRequest();
            }
            _authorsService.DeleteAuthor(author);
            return Ok();
        }
    }
}
