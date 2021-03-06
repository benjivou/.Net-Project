﻿using System;
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
        /// <summary>
        /// Name of the database
        /// </summary>
        private string dataBaseName;
        /// <summary>
        /// URL / Source of the database
        /// </summary>
        private string databaseSource;
        /// <summary>
        /// Connection with the database
        /// </summary>
        private SQLiteConnection Connection;
        /// <summary>
        /// Command with the database
        /// </summary>
        protected SQLiteCommand Command { get; set; }

        /// <summary>
        /// Name of a table in the database
        /// </summary>
        protected string TableName { get; set; }
        /// <summary>
        /// Name of the id / ref of the database (primary key)
        /// </summary>
        protected string RefName { get; set; }

        /// <summary>
        /// Database name public get and set
        /// </summary>
        public string DataBaseName{
            get { return dataBaseName; }
            set { dataBaseName = value;
                  DatabaseSource = value;
            }
        }
        /// <summary>
        /// Data base source / url with public get and set
        /// </summary>
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

        /// <summary>
        /// Check if a database is opened
        /// </summary>
        /// <returns></returns>
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
            if (Query == null)
                return false;

            OpenConnection();
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
                    CloseConnection();
                    return false;
                }
                CloseConnection();
                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }

        /// <summary>
        /// For SELECT Query (Reading) 
        /// WARNING : Need to open and close a connection
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
        /// Return true if its empty
        /// </summary>
        /// <returns></returns>
        public bool TableIsEmpty()
        {
            bool Res = false;
            if (TableName != null)
            {
                OpenConnection();
                var Result = ExecuteSelect("SELECT * FROM " + TableName);
                if (Result.Read())
                    Res = false;
                else
                    Res = true;
                CloseConnection();
            }
            else
                Res = false;
            return Res;
        }

        /// <summary>
        /// Count all the element in a table
        /// </summary>
        /// <returns></returns>
		public int GetCountRef()
		{
			if (TableIsEmpty() == true)
				return 0;
			OpenConnection();
			var Result = ExecuteSelect("SELECT Count(*) FROM " + TableName);
			int Ref;
			if (Result.Read())
			{
				Ref = Result.GetInt16(0);
			}
			else
				Ref = 0;

			CloseConnection();
			return Ref;
		}

        /// <summary>
        /// Check if an object already exist
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
		public bool Exist(Obj Objet)
		{

			Obj Result = GetByName(Objet);
			bool state = !(Result == null);

			return state;
		}
		/// <summary>
		/// Create an object in DataBase
		/// </summary>
		/// <param name="Objet"></param>
		/// <returns></returns>
		public abstract bool Insert(Obj Objet);
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
        /// <returns> true = " job done ", false = "problem lors de la deletion" </returns>
        public abstract bool Delete(Obj Objet);
        /// <summary>
        /// Get all Elements in a table from database
        /// </summary>
        /// <returns></returns>
        public abstract HashSet<Obj> GetAll();

		/// <summary>
		/// the Objectif is to retrive the real reference in the Database of the Object but 
		/// </summary>
		/// <param name="Obj">the partial Object </param>
		/// <returns>if you don't have the Object in the database the return will be a null</returns>
		public abstract Obj GetByName(Obj Obj);
		
		/// <summary>
		/// Flush the Table Elements and Set to O the autoIncrement element
		/// </summary>
		public void FlushTable()
		{
			HashSet<Obj> Liste = GetAll();

			foreach(Obj Obj in Liste)
			{
				Delete(Obj);
			}

			OpenConnection();
			var Result = ExecuteSelect("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='"+this.TableName+"'");
			CloseConnection();
		}

    }
}
