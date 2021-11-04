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
    public class UserApplication : IUserApplication
    {
        private IUserRepository _repo;
        
        public UserApplication(IUserRepository userRepository)
        {
            _repo = userRepository;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll();
        }

        public User GetByID(int id)
        {
            return _repo.GetByID(id);
        }

        public bool Login(string email, string password)
        {
            var hashedPassword = CreateMD5(password);

            var userExists = _repo.Login(email, hashedPassword);

            return userExists;
        }

        public void Save(User newModel)
        {
            newModel.Password = CreateMD5(newModel.Password);

            _repo.Save(newModel);
        }

        public void Update(User updatedModel)
        {
            _repo.Update(updatedModel);
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
