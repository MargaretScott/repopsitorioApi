using AutoMapper;
using CursoDotNet.Application.BusinessModels.Helpers;
using CursoDotNet.Application.BusinessModels.Models;
using CursoDotNet.CrossCutting.Contracts.Services;
using CursoDotNet.DataAccess.Contracts.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CursoDotNet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository)); ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
        }

        public UserModel Authenticate(string username, string password)
        {
            var user = _userRepository.Get(x => x.email == username && x.password == password, null, "role").FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            UserModel _user = _mapper.Map<UserModel>(user);

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.id.ToString()),
                    new Claim(ClaimTypes.Role, user.role.description)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            _user.Token = tokenHandler.WriteToken(token);

            return _user.WithoutPassword();
        }
    }
}
