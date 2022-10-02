using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net6ApiExmple.Domain.Entities;
using Net6ApiExmple.Infrastructure;

namespace Net6ApiExmple.Application.Controllers
{
    /*
    [ApiController]
    public class Lock1Controller : Controller
    {
        private readonly ILockRepository _repository;
        private readonly ILogger<Lock1Controller> _logger;

        public Lock1Controller(ILockRepository repository, ILogger<Lock1Controller> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType (typeof(IEnumerable<Lock>),(int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Lock>> GetLocks()
        {
            var locks =  _repository.FilterBy(_=>true);
            return Ok(locks);
        }
        /*
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
       
        [HttpPost]
        //[ProducesResponseType(typeof(Lock), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Lock>> CreateLock([FromBody]Lock _lock)
        {
            await _repository.InsertOneAsync(_lock) ;
            return CreatedAtRoute("GetLock", new { id = _lock.Id }, _lock);
            
        }

        [HttpPut]
        //[ProducesResponseType(typeof(Lock), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateLock([FromBody]Lock _lock)
        {
            await _repository.ReplaceOneAsync(_lock);
            return Ok(_lock);
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteLock")]
        //[ProducesResponseType(typeof(Lock), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLockById(string id)
        {
            await _repository.DeleteByIdAsync(id);
            return Ok(id);
        }
        
    }*/
}

