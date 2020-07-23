using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class HuntingGroundsService : IHuntingGroundsService
    {
        private readonly Assignment2Context _context;
        private readonly IAssociationService _associationService;
        public HuntingGroundsService(Assignment2Context context, IAssociationService associationService)
        {
            _context = context;
            _associationService = associationService;
        }

        public async Task<HuntingGround> findHuntingGroundByName(string strHG)
        {
            var hunting = await _context.HuntingGround.FirstOrDefaultAsync(x => x.Name == strHG);

            return hunting;
        }

        public async Task<ICollection<HuntingGround>> getHuntingGroundsByAssociationId(int id)
        {
            //var hunting = await _context.HuntingGround.ToListAsync();
            var association = await _associationService.findById(id);
            return association.HuntingGround;
        }
    }
}
