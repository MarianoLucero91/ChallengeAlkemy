using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories.IRepositories
{
    public interface IUsuarioRepository
    {
        Usuario Register(UsuarioAuthDto userRequest);
        Usuario Login(string user, string password);        
    }
}
