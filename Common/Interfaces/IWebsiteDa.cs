using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IWebsiteDa
    {
        Task AddWebsite(Website website);
        Task<int> CheckIfOwnerHasWebsite(string ownerID);
        Task<int> CheckIfURLHasBeenTaken(string URL);
    }
}
