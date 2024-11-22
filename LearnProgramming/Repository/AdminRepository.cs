using RMA.Models;

namespace RMA.Repository
{
    public class AdminRepository :IAdminRepository
    {
        public readonly ApplicationDbContext _Context;
        public AdminRepository(ApplicationDbContext context)
        { 
              _Context = context;
        }



    }
}
