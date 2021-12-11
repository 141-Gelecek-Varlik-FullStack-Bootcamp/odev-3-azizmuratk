using AlwaysLowPrice.Model;

namespace AlwaysLowPrice.Service.User
{
    public interface IUserService
    {
        public General<Model.User.User> Insert(Model.User.User newUser);
        public General<Model.User.Login> Login(Model.User.Login user);
        public General<Model.User.User> Update(int id, Model.User.User user);
        public General<Model.User.User> Delete(int id);
    }
}
