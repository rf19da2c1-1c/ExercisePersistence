using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercisePersistencyREST.DBUtil
{
    public class DBSingleton
    {
        /*
         * singleton
         */
        private static DBSingleton instance = new DBSingleton();

        public static DBSingleton Instance => instance;

        private DBSingleton()
        {
            _conn = new SqlConnection(ConnectionString);
            _conn.Open();
        }

        /*
         * The 'normal' class
         */
        private const String ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ClassDemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        private SqlConnection _conn;

        public SqlCommand GetSQLCommand(String sql)
        {
            return new SqlCommand(sql, _conn);
        }


    }
}