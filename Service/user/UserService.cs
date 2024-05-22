using Entities;
using Repository.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Service.user;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await userRepository.Get();
    }
    public async Task<User> GetUsreById(int id)
    {
        return await userRepository.GetById(id);
    }
    public async Task<User> Register(User user)
    {
        var res = Core.EvaluatePassword(user.Password);
        if (res.Score >= 2)
        {
            return await userRepository.Register(user);
        }
        else return null;
    }
    public async Task<User> Login(string userName, string password)
    {
        return await userRepository.Login(userName, password);
    }
    public async Task<User> UpdateUser(int id, User user)
    {
        return await userRepository.Put(id, user);
    }

}
