using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ObjectDA : Common.Interfaces.IObjectDA
    {
        public void AddObject(Common.HTMLObjects Object) {
            using (Database db = new Database()) {
                db.Objects.Add(Object);
                db.SaveChanges();
            }
        }

        public void ChangeObjectOptions(Common.Options _options)
        {
            using (Database db = new Database())
            {
                db.Options.Remove(db.Objects.Where(x => x.key == _options.ObjectId).Include(x => x.options).FirstOrDefault().options);
                db.Options.Add(_options);
                db.SaveChanges();
            }
        }

        public void RemoveObject(string key)
        {
            using (Database db = new Database())
            {
                db.Objects.Remove(db.Objects.Where(x => x.key == key).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void AddChildToObject(string key, Common.HTMLObjects Object)
        {
            using (Database db = new Database())
            {
                db.Objects.Where(x => x.key == key).FirstOrDefault().children.Add(Object);
                db.SaveChanges();
            }
        }

        public Common.HTMLObjects GetObject(string key)
        {
            using (Database db = new Database())
            {
                return db.Objects.Where(x => x.key == key).FirstOrDefault();
            }
        }
    }
}
