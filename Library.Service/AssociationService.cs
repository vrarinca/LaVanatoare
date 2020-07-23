using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class AssociationService:IAssociationService
    {
        private readonly Assignment2Context _context;

        public AssociationService(Assignment2Context context)
        {
            _context = context;
        }

        public async Task<Association> findById(int id)
        {
            var association = await _context.Association.FirstOrDefaultAsync(x => x.Id == id);
          
            return association;
        }

        public async Task<List<UserAssociation>> getAllUserAss(int userId)
        {
            var ass = await _context.UserAssociation.ToListAsync();
            List<UserAssociation> ret = new List<UserAssociation>();
            foreach(UserAssociation uA in ass)
            {
                if(uA.IdUser == userId)
                {
                    ret.Add(uA);
                }
            }
            return ret;
        }

        public async Task<string> getAssociationNameById(int assocId)
        {
            Association association = await _context.Association.FirstOrDefaultAsync(x => x.Id == assocId);
            return association.Name;
        }

        public async Task<string> getFunctionNameById(int assocId)
        {
            UserFunction userFunction = await _context.UserFunction.FirstOrDefaultAsync(x => x.Id == assocId);
            return userFunction.FunctionName;
        }

        public IQueryable<Association> GetAssociations()
        {
            return _context.Association;
        }

        public IQueryable<UserAssociation> GetUserAssociations()
        {
            return _context.UserAssociation;
        }
    }
}
