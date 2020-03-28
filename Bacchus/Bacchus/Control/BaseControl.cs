using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.Data;

namespace Bacchus
{
    /// <summary>
    /// Structure of a dataBase Interaction
    /// </summary>
    abstract class BaseControl<Obj>
    {
        /// Attributs d'instances
        private string dataBaseName;
        private string databaseSource;
        private SQLiteConnection Connection;
        private SQLiteCommand Command;

        // Attributes with modified set 
        public string DataBaseName{
            get { return dataBaseName; }
            set { dataBaseName = value;
                  DatabaseSource = value;
            }
        }
        public String DatabaseSource{
            get { return databaseSource; }
            set { databaseSource = "data source=" + value + "; Pooling=True;"; }
        }

        /// <summary>
        /// Constructor for abstract DataBase class
        /// </summary>
        public BaseControl(string DbName = "Bacchus.sqlite")
        {
            DataBaseName = DbName;
        }

        /// <summary>
        /// Open a connection, use for child Class Queries - Updates
        /// Must be closed !
        /// </summary>
        /// <returns></returns>
        public bool OpenConnection()
        {
            if(IsOpened() == false)
            {
                Connection = new SQLiteConnection(DatabaseSource);
                Command = new SQLiteCommand(Connection);
                try
                {
                    Connection.Open();
                }
                catch (SQLiteException Except)
                {
                    Console.WriteLine("ERREUR : " + Except);
                    return false;
                }
                return true;
            }
            //Already opened
            return false;
        }

        /// <summary>
        /// Close the connection
        /// </summary>
        /// <returns></returns>
        public bool CloseConnection()
        {
            if(IsOpened())
                Connection.Close();
            return !IsOpened();
        }

        public bool IsOpened()
        {
            if (Connection == null || Connection.State == ConnectionState.Closed)
                return false;
            else
                return true;
        }


        /// <summary>
        /// For INSERT - UPDATE Query (Writing)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public bool ExecuteUpdate(string Query) {

            if (IsOpened())
            {
                try
                {
                    // Insert - Update
                    Command.CommandText = Query;
                    Command.ExecuteNonQuery();
                }
                catch (SQLiteException Except)
                {
                    Console.WriteLine("ERREUR : " + Except);
                    return false;
                }

                return true;
            }
            else
                return false;            
        }

        /// <summary>
        /// For SELECT Query (Reading)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteSelect(string Query)
        {
            if (IsOpened())
            {
                // Insert - Update
                Command.CommandText = Query;
                try
                {
                    SQLiteDataReader Reader = Command.ExecuteReader();
                    return Reader;
                }
                catch (SQLiteException Except)
                {
                    Console.WriteLine("ERREUR : " + Except);
                    return null;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Create an object in DataBase
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public abstract bool Create(Obj Objet);
        /// <summary>
        /// Update an object in DataBase
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public abstract bool Update(Obj Objet);
        /// <summary>
        /// Update an object in DataBase
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public abstract bool Delete(Obj Objet);
        /// <summary>
        /// Get all Elements in a table from database
        /// </summary>
        /// <returns></returns>
        public abstract HashSet<Obj> GetAll();
    }
}
