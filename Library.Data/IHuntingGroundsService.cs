using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public interface IHuntingGroundsService
    {
        Task<HuntingGround> findHuntingGroundByName(string strHG);

        //Task<Association> getHuntingGroundAssociation(User u);
        Task<ICollection<HuntingGround>> getHuntingGroundsByAssociationId(int id);
    }
}
