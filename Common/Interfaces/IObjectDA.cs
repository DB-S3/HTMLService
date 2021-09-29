using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IObjectDA
    {
        void AddObject(Common.HTMLObjects Object);
        void ChangeObjectOptions(Common.HTMLObjects NewObject);
        void RemoveObject(string key);
        void AddChildToObject(string key, Common.HTMLObjects Object);
        Common.HTMLObjects GetObject(string key);
    }
}
