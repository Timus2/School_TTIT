using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISwpf.Common
{
    class AppDB
    {
        private static SchoolDBEntities SchoolDB;

        public static SchoolDBEntities GetInstance()
        {
            if(SchoolDB == null)
            {
                SchoolDB = new SchoolDBEntities();
            }
            return SchoolDB;
        }

        public static void RefreshDB()
        {
            SchoolDB = new SchoolDBEntities();
        }
    }
}
