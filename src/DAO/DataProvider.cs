using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DataProvider
    {

        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }
        public static string connectionSTR
        {
            get
            {

                return System.Configuration.ConfigurationManager.ConnectionStrings["QUANLICAFE36"].ConnectionString;
            }
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        command.Parameters.AddRange(parameter);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message);
            }

            return data;
        }

        public static void ExcuteNonQuery(string sql, CommandType type, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionSTR))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    cmd.CommandType = type;
                    cmd.CommandText = sql;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public int ExecuteNonQuery(string query, SqlParameter[] parameter = null)
        {
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        command.Parameters.AddRange(parameter);
                    }

                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message);
            }

            return result;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        command.Parameters.AddRange(parameter);
                    }

                    data = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message);
            }

            return data;
        }

        public static DataTable SelectData(string sql, CommandType type, SqlParameter[] parameters)
        {
            DataTable kq = new DataTable();
            SqlConnection sqlcon = new SqlConnection(connectionSTR);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = sql;
            cmd.CommandType = type;
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(kq);
            sqlcon.Close();
            return kq;


        }
        public static DataSet SelectMultiData(string sql)
        {
            DataSet kq = new DataSet();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionSTR))
                {
                    sqlConnection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnection);
                    da.Fill(kq);
                }
            }
            catch (Exception ex)
            {

            }

            return kq;
        }
    }
}
