using fullstackCsharp.Models;
using System.Data.Common;
using System.Data;
using Microsoft.Data.SqlClient;

namespace fullstackCsharp.DAO
{
    public class StaffDAO
    {
        public List <Staff> GetStaffList()
        {
            List<Staff> list = new List<Staff>();
            string connectionString = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=QuanLy;Integrated Security=false";

            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                DbTransaction transaction = dbConnection.BeginTransaction();
                try
                {
                    int timeout = 30;
                    string commandText = "SELECT * FROM Nhan_Vien WHERE MaNV=@ID_NV";
                    SqlCommand command = new SqlCommand(commandText, (SqlConnection)transaction.Connection, (SqlTransaction)transaction);
                    command.CommandTimeout = timeout;
                    // set param
                    command.Parameters.Add("@ID_NV", SqlDbType.VarChar).Value = "001";
                    // load

                    // nếu là select
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // return danh sách nhân viên ở đây
                            Console.WriteLine(String.Format("{0}", reader[0]));
                        }
                    }
                    // nếu là insert, update, delete
                    // command.ExecuteNonQuery(); 

                    // vì là select nên không thay đổi gì db, sau khi select xong thì rollback cho chắc
                    transaction.Rollback();
                    // nếu là insert, update, delete thì dùng: transaction.Commit();

                }
                catch
                {
                    // Nếu có lỗi xảy ra thì rollback để tránh làm mất dữ liệu DB
                    transaction.Rollback();
                    throw;
                }
            }

            return list;
        }
    }
}
