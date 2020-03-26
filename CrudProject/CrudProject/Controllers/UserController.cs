using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProject.Dal;
using CrudProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrudProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        IDataRepositoy<UserDto, int> _repository;
      

        public UserController(IDataRepositoy<UserDto, int> repository)
        {
           
            _repository = repository;
        }

        [HttpGet]
        public List<UserDto> Get()
        {
            return _repository.GetAll();

        }

        [HttpGet("{id}")]
        public UserDto Get( int id)
        {
            return _repository.GetById(id);
        }
        [HttpPut]
        public void Put(UserDto user)
        {
            _repository.Update(user);
        }
        [HttpPost]
        public void Post([FromBody]UserDto user)
        {
            _repository.Add(user);

        }
        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
