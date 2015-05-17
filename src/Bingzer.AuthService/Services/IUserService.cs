using System.Collections.Generic;
using System.Security.Claims;
using Bingzer.StickDraw.AuthService.Entities;

namespace Bingzer.StickDraw.AuthService.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Returns users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Find user by email.
        /// Email is the id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User FindUser(string email);

        /// <summary>
        /// Validate user with his/her password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ValidateUser(string username, string password);

        /// <summary>
        /// Returns identity for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ClaimsIdentity CreateIdentity(User user);
    }
}
