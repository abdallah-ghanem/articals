using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace articals.Data
{
    public interface IDataHelper<Table>//write here table because i don't know number of data
    {
        //read
        List<Table> GetAllData();//get all data
        List<Table> GetDataByUser(int UserId);//get only one colume or element user
        List<Table> Search(string SearchItem);//search in all data
        Table Find(int Id);//search in one element only

        //write
        int Add(Table table);
        int Update(Table table);//wait don't use this now
        int Edit(int Id, Table table);
        int Delete(int Id);

        
    }
}
