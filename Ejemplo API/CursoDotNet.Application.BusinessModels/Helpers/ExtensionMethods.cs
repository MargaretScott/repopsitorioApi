using CursoDotNet.Application.BusinessModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace CursoDotNet.Application.BusinessModels.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserModel> WithoutPasswords(this IEnumerable<UserModel> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserModel WithoutPassword(this UserModel user)
        {
            user.Password = null;
            return user;
        }
    }
}
