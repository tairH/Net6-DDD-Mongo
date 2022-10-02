using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net6ApiExmple.Domain.Entities;
using Net6ApiExmple.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Net6ApiExmple.Application.Controllers
{
    [Route("api/[controller]")]
    public class LockController : Controller
    {
        private readonly ILockRepository _repository;
        private readonly ILogger<LockController> _logger;

        public LockController(ILockRepository repository, ILogger<LockController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Lock>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Lock>> GetLocks()
        {
            var locks = _repository.FilterBy(_ => true);
            return Ok(locks);
        }

        // GET api/values/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        [HttpGet("{id:length(24)}", Name = "GetLock")]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType(typeof(Lock), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Lock>> GetLockById(string id)
        {
            var _lock = await _repository.FindByIdAsync(id);
            if (_lock == null)
            {
                _logger.LogError($"Lock with id: {id}, not found.");
                return NotFound();
            }
            return Ok(_lock);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(Lock), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Lock>> CreateLock([FromBody] Lock _lock)
        {
            await _repository.InsertOneAsync(_lock);
            //return CreatedAtRoute("GetLock", new { id = _lock.Id }, _lock);
            return Ok(_lock);

        }

        // PUT api/values/5
        /*
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        */
        [HttpPut]
        [ProducesResponseType(typeof(Lock), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateLock([FromBody] Lock _lock)
        {
            await _repository.ReplaceOneAsync(_lock);
            return Ok(_lock);
        }



        // DELETE api/values/5
        /*
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
        [HttpDelete("{id:length(24)}", Name = "DeleteLock")]
        [ProducesResponseType(typeof(Lock), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLockById(string id)
        {
            await _repository.DeleteByIdAsync(id);
            return Ok(id);
        }
    }
}

