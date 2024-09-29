using articals.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace articals.Data.SqlServerEF
{
    public class CatigoryEntity : IDataHelper<Catigory>
    {
        private DBContext db;
        private Catigory _table;
        public CatigoryEntity()
        {
            db=new DBContext();
        }
        public int Add(Catigory table)
        {
            if (db.Database.CanConnect())
            {
                db.Catigory.Add(table);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            if (db.Database.CanConnect())
            {
                _table = Find(Id);
                db.Catigory.Remove(_table);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Catigory table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Catigory.Add(table);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Catigory Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Catigory.Where(x => x.id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Catigory> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Catigory.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Catigory> GetDataByUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public List<Catigory> Search(string SearchItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Catigory.Where(x => x.name.Contains(SearchItem) 
                ||x.id.ToString().Contains(SearchItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }

        public int Update(Catigory table)
        {
            throw new NotImplementedException();
        }
    }
}
