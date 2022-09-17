using ChallengeAlkemy.Data;
using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Usuario Login(string user, string password)
        {
            var login = _dbContext.Usuario.FirstOrDefault(u => u.UserName == user);

            if (login == null)
            {
                return null;
            }

            if (!VerififyPassword(password, login.Password))
            {
                return null;
            }


            return login;
        }
        
        public Usuario Register(UsuarioAuthDto userRequest)
        {

            userRequest.Password = Helpers.EncryptionHelper.Encrypt(userRequest.Password, Helpers.EncryptionHelper.ENCRYPTION_KEY);

            Usuario user = new Usuario()
            {
                UserName = userRequest.UserName,
                Password = userRequest.Password
            };

             _dbContext.Usuario.Add(user);
             _dbContext.SaveChanges();

            return user;
        }

        private bool VerififyPassword(string password, string loginPassword)
        {
            if (Helpers.EncryptionHelper.Encrypt(password, Helpers.EncryptionHelper.ENCRYPTION_KEY) != loginPassword) return false;
            return true;
        }
       
    }
}
