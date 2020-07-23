using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Models;
using Project.Models;

namespace Library.Data
{
    public interface IUserService
    {
        Task<User> Login(string email, string password);

        Task<User> findById(int id);
        Task<List<User>> findByName(String name);

        Task<List<User>> getAllUser();

        Task<List<UserFunction>> getAllUserFunctions();

       // Task<List<User>> getUsersAsociation(User u);

        void addUserAssoc(int id_user_function,int id_association, string email, string password, string cnp, string name, string surname, string license, string insurance, string role);
        void deleteUser(User u);

        void updateUserSysAdmin(User user,int id_user_function, int id_association, string email, string password, string cnp, string name, string surname, string license, string insurance, string role);

        void updateUserAsocAdmin(User user, int id_user_function, string email, string password, string cnp, string name, string surname, string license, string insurance,string role);

        void updateUserOperator(User user,   string email, string password, string name, string surname,  string insurance );

        int getNumberOfUsers();

        //Task<User> findByNameAndAssociation(string name, int associationId);

        //int getNumberOfUsersInAssociation(int associationId);

        Task<ICollection<UserAssociation>> getAllUserAssociations(int userId);


    }
}
