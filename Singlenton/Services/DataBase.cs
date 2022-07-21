using Singlenton.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Singlenton.Services
{
    public class DataBase
    {
        private readonly SQLiteAsyncConnection dbase;
        private readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDatabase.db3");

        private static DataBase _database;

        public static DataBase GetInstance
        {
            get
            {
                if (_database == null)
                {
                    _database = new DataBase();
                }

                return _database;
            }
        }

        private DataBase()
        {
            dbase = new SQLiteAsyncConnection(path);
            dbase.CreateTableAsync<Log>();
        }

        #region Log
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateLog(Log Log)
        {
            if (Log.Id != 0)
            {
                return dbase.UpdateAsync(Log);
            }
            else
            {
                return dbase.InsertAsync(Log);
            }
        }

        //Metodos CRUD - READ
        public Task<List<Log>> getListLog()
        {
            return dbase.Table<Log>().ToListAsync();
        }

        public Task<Log> getLog(int id)
        {
            return dbase.Table<Log>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteLog(Log Log)
        {
            return dbase.DeleteAsync(Log);
        }

        #endregion Log
    }
}
