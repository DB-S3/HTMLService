using Common.Enums;
using System;

namespace Logic
{
    public class ObjectLogic
    {
        Common.Interfaces.IObjectDA ObjectDataAccess;
        Common.Interfaces.IPagesDA PageDataAccess;


        public void CreateObject(string pageId, Common.HTMLObjects newObject, int type)
        {
            newObject.type = (HtmlTypes)type;
            PageDataAccess.AddObjectToPage(pageId, newObject);
        }

        public void EditObjectOptions(Common.Options _options)
        {
            ObjectDataAccess.ChangeObjectOptions(_options);
        }

        public void DeleteObject(string key)
        {
            ObjectDataAccess.RemoveObject(key);
        }

        public void AddObjectToParent(string key, Common.HTMLObjects ChildObject) {
            ObjectDataAccess.AddChildToObject(key, ChildObject);
        }

        public void ChangeObjectParent(string pageId, string objectKey,string newParentObjectKey)
        {
            Common.HTMLObjects currentObject;
            if (newParentObjectKey == "none") {
                currentObject = ObjectDataAccess.GetObject(objectKey);
                ObjectDataAccess.RemoveObject(objectKey);
                PageDataAccess.AddObjectToPage(pageId, currentObject);
            }
            else
            {
                currentObject = ObjectDataAccess.GetObject(objectKey);
                ObjectDataAccess.RemoveObject(objectKey);
                ObjectDataAccess.AddChildToObject(newParentObjectKey, currentObject);
            }
            
        }



        public ObjectLogic(DataAccess.Database db)
        {
            ObjectDataAccess = Factory.Factory.ObjectDataAccess(db);
            PageDataAccess = Factory.Factory.PageDataAccess(db);
        }
    }

}

