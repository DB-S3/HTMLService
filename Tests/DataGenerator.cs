using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DataGenerator
    {
        private readonly DataAccess.Database _dataAccess;
        public DataGenerator(DataAccess.Database dataAccess) {
            _dataAccess = dataAccess;
        }
        public void Initialize(IServiceProvider serviceProvider)
        {

                // Look for any board games.
                if (_dataAccess.Pages.Any() || _dataAccess.Websites.Any())
                {
                    _dataAccess.Pages.Clear();
                    _dataAccess.Websites.Clear();
                }

                _dataAccess.Websites.Add(new Common.Website() { OwnerId = "testOwnerId", Id = "testId", Url = "testUrl" });
                _dataAccess.Pages.Add(new Common.Page() { Id = "pageId", Name = "pageName", Objects = new List<Common.HTMLObjects>() });
                _dataAccess.SaveChanges();
            }
        
    }
}

