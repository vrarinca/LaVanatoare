using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public interface IAssociationService
    {
        Task<Association> findById(int id);

        Task<List<UserAssociation>> getAllUserAss(int userId);

        Task<string> getAssociationNameById(int assocID);

        IQueryable<Association> GetAssociations();

        IQueryable<UserAssociation> GetUserAssociations();
    }


}
