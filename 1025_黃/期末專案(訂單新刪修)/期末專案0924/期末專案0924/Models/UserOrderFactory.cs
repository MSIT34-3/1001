using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 期末專案0924.Models
{
    public class UserOrderFactory
    {
        public List<cUserOrder> queryAll()
        {
            string sql = "SELECT *  FROM tUserOrder ";
            return queryBySql(sql, null);
        }

        private List<cUserOrder> queryBySql(string sql, List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(local);Initial Catalog=dbTravelWeb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
            {
                foreach (SqlParameter p in paras)
                {
                    cmd.Parameters.Add(p);
                }
            }
            SqlDataReader reader = cmd.ExecuteReader();
            List<cUserOrder> list = new List<cUserOrder>();
            while (reader.Read())
            {

                cUserOrder x = new cUserOrder();
                x.cOrderSN = (int)reader["cOrderSN"];
                x.cOrderID = (int)reader["cOrderID"];
                x.cGuestSN = (int)reader["cGuestSN"];
                x.cOrderDate = (DateTime)reader["cOrderDate"];
                x.cCheckInDate = (DateTime)reader["cCheckInDate"];
                x.cCheckOutDate = (DateTime)reader["cCheckOutDate"];
                if (reader["cOrderStatus"].ToString() == "")
                    x.cOrderStatus = "審核中";
                else
                    x.cOrderStatus = reader["cOrderStatus"].ToString();
                if (reader["cStaffProfileSN"].ToString() == "")
                    x.cStaffProfileSN = -1;
                else
                    x.cStaffProfileSN = (int?)reader["cStaffProfileSN"];
                x.cHotelRoomTypeSN = (int)reader["cHotelRoomTypeSN"];
                x.cOrderNotes = reader["cOrderNotes"].ToString();
                x.cOrderPrice = (decimal)reader["cOrderPrice"];
                list.Add(x);
            }
            return list;
        }

        internal void delete(int cOrderSN)
        {
            string sql = "DELETE FROM tUserOrder WHERE cOrderSN=@K_CORDERSN";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_CORDERSN", (object)cOrderSN));
            executeSql(sql, paras);
        }

        internal void update(cUserOrder x)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            string sql = "UPDATE tUserOrder SET ";
            if (!string.IsNullOrEmpty((x.cOrderID).ToString()))
            {
                sql += "cOrderID=@K_CORDERID,";
                paras.Add(new SqlParameter("K_CORDERID", (object)x.cOrderID));
            }
            if (!string.IsNullOrEmpty((x.cGuestSN).ToString()))
            {
                sql += "cGuestSN=@K_GUESTSN,";
                paras.Add(new SqlParameter("K_GUESTSN", (object)x.cGuestSN));
            }
            if (!string.IsNullOrEmpty((x.cOrderDate).ToString()))
            {
                sql += "cOrderDate=@K_CORDERDATE,";
                paras.Add(new SqlParameter("K_CORDERDATE", (object)x.cOrderDate));
            }
            if (!string.IsNullOrEmpty((x.cCheckInDate).ToString()))
            {
                sql += "cCheckInDate=@K_CCHECKINDATE,";
                paras.Add(new SqlParameter("K_CCHECKINDATE", (object)x.cCheckInDate));
            }
            if (!string.IsNullOrEmpty((x.cCheckOutDate).ToString()))
            {
                sql += "cCheckOutDate=@K_CCHECKOUTDATE,";
                paras.Add(new SqlParameter("K_CCHECKOUTDATE", (object)x.cCheckOutDate));
            }
            if (!string.IsNullOrEmpty((x.cHotelRoomTypeSN).ToString()))
            {
                sql += "cHotelRoomTypeSN=@K_CHOTELROOMTYPESN,";
                paras.Add(new SqlParameter("K_CHOTELROOMTYPESN", (object)x.cHotelRoomTypeSN));
            }
            if (!string.IsNullOrEmpty(x.cOrderNotes))
            {
                sql += "cOrderNotes=@K_CORDERNOTES,";
                paras.Add(new SqlParameter("K_CORDERNOTES", (object)x.cOrderNotes));
            }
            if (!string.IsNullOrEmpty((x.cOrderPrice).ToString()))
            {
                sql += "cOrderPrice=@K_CORDERPRICE,";
                paras.Add(new SqlParameter("K_CORDERPRICE", (object)x.cOrderPrice));
            }
            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
            {
                sql = sql.Substring(0, sql.Length - 1);
            }
            sql += " WHERE cOrderSN=@K_CORDERSN";
            paras.Add(new SqlParameter("K_CORDERSN", (object)x.cOrderSN));
            executeSql(sql, paras);
        }

        internal cUserOrder queryById(int cOrderSN)
        {
            string sql = "SELECT * FROM tUserOrder WHERE cOrderSN=@K_CORDERSN";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_CORDERSN", (object)cOrderSN));
            List<cUserOrder> list = queryBySql(sql, paras);
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public void create(cUserOrder x)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            string sql = "INSERT INTO tUserOrder(";
            if (!string.IsNullOrEmpty((x.cOrderID).ToString()))
                sql += "cOrderID,";
            if (!string.IsNullOrEmpty((x.cGuestSN).ToString()))
                sql += "cGuestSN,";
            if (!string.IsNullOrEmpty((x.cOrderDate).ToString()))
                sql += "cOrderDate,";
            if (!string.IsNullOrEmpty((x.cCheckInDate).ToString()))
                sql += "cCheckInDate,";
            if (!string.IsNullOrEmpty((x.cCheckOutDate).ToString()))
                sql += "cCheckOutDate,";
            if (!string.IsNullOrEmpty((x.cHotelRoomTypeSN).ToString()))
                sql += "cHotelRoomTypeSN,";
            if (!string.IsNullOrEmpty(x.cOrderNotes))
                sql += "cOrderNotes,";
            if (!string.IsNullOrEmpty((x.cOrderPrice).ToString()))
                sql += "cOrderPrice,";
            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1,1) == ",")
            {
                sql = sql.Substring(0, sql.Length - 1);
            }
            sql += ")VALUES(";
            if (!string.IsNullOrEmpty((x.cOrderID).ToString()))
            {
                sql += "@K_CORDERID,";
                paras.Add(new SqlParameter("K_CORDERID", (object)x.cOrderID));
            }  
            if (!string.IsNullOrEmpty((x.cGuestSN).ToString()))
            {
                sql += "@K_CGUESTSN,";
                paras.Add(new SqlParameter("K_CGUESTSN", (object)x.cGuestSN));
            }
            if (!string.IsNullOrEmpty((x.cOrderDate).ToString()))
            {
                sql += "@K_CORDERDATE,";
                paras.Add(new SqlParameter("K_CORDERDATE", (object)x.cOrderDate));
            }
            if (!string.IsNullOrEmpty((x.cCheckInDate).ToString()))
            {
                sql += "@K_CCHECKINDATE,";
                paras.Add(new SqlParameter("K_CCHECKINDATE", (object)x.cCheckInDate));
            }
            if (!string.IsNullOrEmpty((x.cCheckOutDate).ToString()))
            {
                sql += "@K_CCHECKOUTDATE,";
                paras.Add(new SqlParameter("K_CCHECKOUTDATE", (object)x.cCheckOutDate));
            }
            if (!string.IsNullOrEmpty((x.cHotelRoomTypeSN).ToString()))
            {
                sql += "@K_CHOTELROOMTYPESN,";
                paras.Add(new SqlParameter("K_CHOTELROOMTYPESN", (object)x.cHotelRoomTypeSN));
            };
            if (!string.IsNullOrEmpty(x.cOrderNotes))
            {
                sql += "@K_CORDERNOTES,";
                paras.Add(new SqlParameter("K_CORDERNOTES", (object)x.cOrderNotes));
            }
            if (!string.IsNullOrEmpty((x.cOrderPrice).ToString()))
            {
                sql += "@K_CORDERPRICE,";
                paras.Add(new SqlParameter("K_CORDERPRICE", (object)x.cOrderPrice));
            }
            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
            {
                sql = sql.Substring(0, sql.Length - 1);
            }
            sql += ")";
            executeSql(sql, paras);

        }

        private void executeSql(string sql, List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(local);Initial Catalog=dbTravelWeb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
            {
                foreach (SqlParameter p in paras)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.ExecuteNonQuery();
            }
        }

        internal List<cUserOrder> queryByKetword(string keyword)
        {
            string sql = "SELECT *  FROM UserOrder WHERE OrderID LIKE @K_KEYWORD";
            sql += " OR OrderPassengerName LIKE @K_KEYWORD";
            sql += " OR OrderPassengerPhone LIKE @K_KEYWORD";
            sql += " OR OrderPassengerEmail LIKE @K_KEYWORD";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_KEYWORD", "%" + (object)keyword + "%"));
            return queryBySql(sql, paras);
        }
    }
}