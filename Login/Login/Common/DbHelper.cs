using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Login.Common
{
    public class DbHelper
    {

        public SqlConnection sqlConnection = null;
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["RemoteConn"].ToString();
        private static SqlConnection commonsqlConnection = new SqlConnection(connectionString);

        /// <summary>
        /// 执行无参存储过程，并返回DataTable对象
        /// </summary>
        /// <param name="safeSql">存储过程名</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteProcGetDataTable(string ProcSql)
         {
             SqlConnection sqlConn = new SqlConnection(connectionString);
             sqlConn.Open();
             DataSet ds = new DataSet();
             SqlCommand cmd = new SqlCommand(ProcSql, sqlConn);
             cmd.CommandType = CommandType.StoredProcedure;
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             da.Fill(ds);
             sqlConn.Close();
             return ds.Tables[0];

        }

        /// <summary>
        /// 执行sql返回dataset
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet ExecuteGetDateSet(string sql)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(ds);
            sqlConnection.Close();
            return ds;

        }

        /// <summary>
        /// 执行无参存储过程，并返回DataTable对象
        /// </summary>
        /// <param name="safeSql">存储过程名</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteSqlGetDataTable(string Sql)
        {
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(Sql, sqlConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlConn.Close();
            return ds.Tables[0];

        }

        /// <summary>
        /// 执行无参SQL语句，并返回执行记录数
        /// </summary>
        /// <param name="safeSql">sql字符串</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteCommand(string safeSql)
          {
             SqlConnection sqlConn = new SqlConnection(connectionString);
              sqlConn.Open();
              SqlCommand cmd = new SqlCommand(safeSql, sqlConn);
              int result = cmd.ExecuteNonQuery();
              sqlConn.Close();
              return result;
         }


        /// <summary>
        /// 增加成功
        /// </summary>
        /// <param name="SqlInsertStr"></param>
        /// <returns></returns>
        public static bool DataTableInsert(string SqlInsertStr)
        {
            try
            {
                commonsqlConnection.Open();
                SqlCommand comm = new SqlCommand(SqlInsertStr, commonsqlConnection);
                comm.ExecuteNonQuery();
                //mySqldb.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// 删除成功
        /// </summary>
        /// <param name="SqlDeleteStr"></param>
        /// <returns></returns>
        public static bool DeleteDataTable(string SqlDeleteStr)
        {
            try
            {
                commonsqlConnection.Open();
                SqlCommand comm = new SqlCommand(SqlDeleteStr, commonsqlConnection);
                comm.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// 更改成功
        /// </summary>
        /// <param name="SqlUpdataStr"></param>
        /// <returns></returns>
        public static bool DataTableUpdate(string SqlUpdataStr)
        {
            try
            {
                commonsqlConnection.Open();
                SqlCommand comm = new SqlCommand(SqlUpdataStr, commonsqlConnection);
                comm.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// 查询成功返回true
        /// </summary>
        /// <param name="SqlSelectStr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool DataTableSelect(string SqlSelectStr, ref DataTable dt)
        {
            try
            {
                //将数据的内容放到MySqlDataAdapter容器中  然后填充到dt表中
                commonsqlConnection.Open();
                SqlCommand comm = new SqlCommand(SqlSelectStr, commonsqlConnection);
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                sda.Fill(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }



    }


}