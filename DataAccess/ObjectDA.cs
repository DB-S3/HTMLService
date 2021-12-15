using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ObjectDA : Common.Interfaces.IObjectDA
    {
        private readonly Database _db;
        public ObjectDA(DataAccess.Database db) {
            _db = db;
        }

        public void AddObject(Common.HTMLObjects Object)
        {
                _db.Objects.Add(Object);
                _db.SaveChanges();
        }

        public void ChangeObjectOptions(Common.Options _options)
        {
                _db.Options.Remove(_db.Objects.Where(x => x.key == _options.ObjectId).Include(x => x.options).FirstOrDefault().options);
                _db.Options.Add(_options);
                _db.SaveChanges();
        }

        public void RemoveObject(string key)
        {
                _db.Objects.Remove(_db.Objects.Where(x => x.key == key).FirstOrDefault());
                _db.SaveChanges();
        }

        public void AddChildToObject(string key, Common.HTMLObjects Object)
        {
                _db.Objects.Where(x => x.key == key).FirstOrDefault().children.Add(Object);
                _db.SaveChanges();
        }

        public Common.HTMLObjects GetObject(string key)
        {
                return _db.Objects.Where(x => x.key == key).FirstOrDefault();
        }
    }
}
