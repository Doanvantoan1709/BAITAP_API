using LearnAPI.Model;
using LearnAPI.Service.IUser;

namespace LearnAPI.Service.User
{
    public class UserService : IUserService
    {
        public Users SetInfo(Users users)
        {
            var userList = new Users()
            {
                Name = users.Name,
                Address = users.Address,
                Age = users.Age,
                Email = users.Email,
            };


            return userList;
        }

        public string GetName(string name)
        {
            return name;
        }

        public int GetOld(int year)
        {
            int yearNow = DateTime.Now.Year;
            return yearNow - year;
        }
    }
}
