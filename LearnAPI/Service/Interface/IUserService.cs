using LearnAPI.Model;

namespace LearnAPI.Service.IUser
{
    public interface IUserService
    {
        public string GetName(string name);
        public int GetOld(int year);
        public Users SetInfo(Users users);
    }
}
