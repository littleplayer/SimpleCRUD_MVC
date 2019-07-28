using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Object.CRUD
{
    public class CRUDHelper
    {
        public static CRUDModel CRUD(string action)
        {
            CRUDModel CRUD = new CRUDModel();
            return CRUD;
        }

        public CRUDModel C()
        {
            CRUDModel CRUD = new CRUDModel();
            return CRUD;
        }

        public CRUDModel R()
        {
            CRUDModel CRUD = new CRUDModel();
            return CRUD;
        }

        public CRUDModel U()
        {
            CRUDModel CRUD = new CRUDModel();
            return CRUD;
        }

        public CRUDModel D()
        {
            CRUDModel CRUD = new CRUDModel();
            return CRUD;
        }
    }
}