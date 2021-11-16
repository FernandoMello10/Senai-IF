using SenaiChamados.Domain;
using SenaiChamados.Interfaces;
using SenaiChamados.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenaiChamados.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private IUsuarioRepository _repository;
        
        public UsuarioApplication(IUsuarioRepository userRepository)
        {
            _repository = userRepository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public bool Login(string email, string password)
        {
            var hashedPassword = CreateMD5(password);

            var userExists = _repository.Login(email, hashedPassword);

            return userExists;
        }

        public void Save(User newModel)
        {
            newModel.Password = CreateMD5(newModel.Password);

            _repository.Save(newModel);
        }

        public void Update(User updatedModel)
        {
            _repository.Update(updatedModel);
        }

        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
