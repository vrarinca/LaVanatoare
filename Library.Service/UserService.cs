
using System.Threading.Tasks;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Library.Data.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Project.Data
{
    public class UserService : IUserService
    {

        private readonly Assignment2Context _context;

        public UserService(Assignment2Context context)
        {
            _context = context;
        }


        public async Task<List<UserFunction>> getAllUserFunctions()
        {
            var userRole = await _context.UserFunction.ToListAsync();

            return userRole;

        }

        public async Task<User> findById(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
           
            return user;

        }

        public async Task<List<User>> findByName(string name)
        {
            List<User> users = await _context.User.Where(x => x.Name == name).ToListAsync();
            return users;
        }

        public async Task<User> Login(string email, string password)
        {   
            var user = await _context.User.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return null;
            }

            if (password != user.Password)
            {
                return null;
            }

            return user;

            
        }
        //by Horatiuu
        //  |
        //  v
        public async Task<List<User>> getAllUser()
        {
            var users = await _context.User.ToListAsync();
            
            
            return users;
        }

       

        public async void addUserAssoc(int id_user_function,
        int id_association, string email, string password, string cnp, string name,
         string surname, string license, string insurance, string role)
        {
            var user = new User();
            //user.IdAssociation = id_association;
            user.Email = email;
            user.Password = password;
            user.Cnp = cnp;
            user.Name = name;
            user.Surname = surname;
            user.License = license;
            user.Insurance = insurance;
           // user.Role = role;
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        //public async Task<List<User>> getUsersAsociation(User u) 
        //{
        //    int id = (int)u.IdAssociation;
        //    var users = await _context.User.Where(x => x.IdAssociation == id).ToListAsync();
        //    return users;
        //}

        public async void deleteUser(User u)
        {
            _context.User.Remove(u);
            await _context.SaveChangesAsync();

        }
        public async void updateUserSysAdmin(User user,int id_user_function, int id_association, string email, string password, string cnp, string name, string surname, string license, string insurance, string role)
        {
           // var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id_user);
           
            user.Email = email;
            user.Password = password;
            user.Cnp = cnp;
            user.Name = name;
            user.Surname = surname;
            user.License = license;
            user.Insurance = insurance;
           // user.Role = role;
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
        public async void updateUserAsocAdmin(User user, int id_user_function, string email, string password, string cnp, string name, string surname, string license, string insurance,string role)
        {
            user.Email = email;
            user.Password = password;
            user.Cnp = cnp;
            user.Name = name;
            user.Surname = surname;
            user.License = license;
            user.Insurance = insurance;
            //if (role == "Operator" && role == "AssocAdmin")
            //{
            //    user.Role = role;
            //}
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
        public async void updateUserOperator(User user,   string email, string password, string name, string surname,  string insurance )
        {
           // user.IdUserFunction = id_user_function;
           // user.IdAssociation = id_association;
            user.Email = email;
            user.Password = password;
          //  user.Cnp = cnp;
            user.Name = name;
            user.Surname = surname;
           // user.License = license;
            user.Insurance = insurance;
            //user.Role = role;
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public int getNumberOfUsers()
        {
            return _context.User.Count(x => x.Id != -1);
        }

        //public async Task<User> findByNameAndAssociation(string name, int associationId)
        //{
        //    var user = await _context.User.FirstOrDefaultAsync(x => x.Name == name && x.IdAssociation == associationId);
        //    return user;
        //}

        //public int getNumberOfUsersInAssociation(int associationId)
        //{
        //    return _context.User.Count(x => x.Id != -1 && x.IdAssociation == associationId);
        //}

        public async Task<ICollection<UserAssociation>> getAllUserAssociations(int userId)
        {
            User user = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);
            return user.UserAssociation;
        }
    }
}