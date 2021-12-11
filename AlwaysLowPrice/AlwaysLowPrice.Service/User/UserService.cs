using AlwaysLowPrice.DB.Entities.DataContext;
using AlwaysLowPrice.Model;
using AutoMapper;
using System;
using System.Linq;

namespace AlwaysLowPrice.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;

        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        // Login Process
        public General<Model.User.Login> Login(Model.User.Login user)
        {
            var result = new General<Model.User.Login>();
            var model = mapper.Map<DB.Entities.User>(user);
            using (var srv = new AlwaysLowPriceContext())
            {
                result.Entity = mapper.Map<Model.User.Login>(model);
                result.IsSuccess = srv.User
                    .Any(x => x.Email == user.Email && x.IsActive && !x.IsDeleted && x.Password == user.Password);
            }
            return result;
        }

        // Insert Process
        public General<Model.User.User> Insert(Model.User.User newUser)
        {
            var result = new General<Model.User.User>()
            {
                IsSuccess = false
            };
            var model = mapper.Map<DB.Entities.User>(newUser);
            using (var srv = new AlwaysLowPriceContext())
            {
                model.IdateTime = DateTime.Now;
                srv.User.Add(model);
                srv.SaveChanges();
                result.Entity = mapper.Map<Model.User.User>(model);
                result.IsSuccess = true;
            }

            return result;
        }
        // Update User
        public General<Model.User.User> Update(int id, Model.User.User user)
        {
            var result = new General<Model.User.User>();
            using (var srv = new AlwaysLowPriceContext())
            {
                var check = srv.User.SingleOrDefault(i => i.Id == id);

                check.Name = user.Name;
                check.UserName = user.UserName;
                check.Email = user.Email;
                check.Password = user.Password;

                srv.SaveChanges();

                result.Entity = mapper.Map<Model.User.User>(check);
                result.IsSuccess = true;
            }
            return result;
        }

        // Delete User
        public General<Model.User.User> Delete(int id)
        {
            var result = new General<Model.User.User>();
            using (var srv = new AlwaysLowPriceContext())
            {
                var user = srv.User.SingleOrDefault(i => i.Id == id);

                srv.User.Remove(user);
                srv.SaveChanges();

                result.Entity = mapper.Map<Model.User.User>(user);
                result.IsSuccess = true;

                return result;
            }
        }
    }
}
