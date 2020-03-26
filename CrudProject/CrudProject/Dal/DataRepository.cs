using CrudProject.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProject.Dal
{
    public class DataRepository: IDataRepositoy <UserDto, int>
    {

        ApplicationContext _context;
          ILogger _log;
       
        public DataRepository(ApplicationContext context , ILogger<DataRepository> log )
        {
            _context = context;
            _log = log;
        }


        public List<UserDto> GetAll()
        {
            try
            {

              
                 _log.LogInformation("getAll user");
                return _context.UserDto.ToList();

            }
            catch
            {
                _log.LogError(" dont getAll user");
                return null;
            }
        }
        public UserDto GetById(int id)
        {
            try
            {
                _log.LogInformation("get user");
                return _context.UserDto.FirstOrDefault(x => x.userId.Equals(id));
            }
            catch
            {
                 _log.LogError("dont delete user");
                return null;
            }

        }
        public void Add(UserDto user)
        {
            try
            {
                _context.UserDto.Add(user);
                _context.SaveChanges();
                _log.LogInformation("Add user");
            }
            catch
            {
                _log.LogError("user dont add " + user.firstName + user.lastName);
            }
        }

        public void Delete(int id)
        {
            try
            {
                UserDto t = _context.UserDto.Find(id);
                _context.UserDto.Remove(t);
                _context.SaveChanges();
                //_log.LogInformation("delete user");
            }

            catch
            {
                //  _log.LogError("dont delete user");
            }
        }



        public void Update(UserDto user)
        {
            try
            {

                UserDto u = _context.UserDto.Find(user.userId);
                u.userId = user.userId;
                u.firstName = user.firstName;
                u.lastName = user.lastName;
                u.age = user.age;
                _context.SaveChanges();
                //_log.LogInformation("update user");
            }
            catch
            {
                // _log.LogError("dont update user");
            }
        }

    }
}
