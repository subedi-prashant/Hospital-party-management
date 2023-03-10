using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CareLab.Models;

namespace CareLab.Repo
{
    public class DAL
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public List<CreditParty> GetDataList()
        {
            List<CreditParty> lst = new List<CreditParty>();
            SqlCommand cmd = new SqlCommand("SP_SELECT", con);
            cmd.CommandType = CommandType.StoredProcedure; //Since we have created stored procedure instead of sql query
            DataTable dt = new DataTable(); //In .NET framework it represents an in-memory(RAM) representation of data in a tabular form.
            SqlDataAdapter adp = new SqlDataAdapter(cmd);// It is bridge between a DataTable and a SQL Server database.
            adp.Fill(dt); // data table ma insert garyo
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new CreditParty
                {
                    Name = Convert.ToString(dr["Name"]),
                    Codeno = Convert.ToInt32(dr["Codeno"]),
                    PAN = Convert.ToInt32(dr["PAN"]),
                    Email = Convert.ToString(dr["Email"]),
                    Credit = Convert.ToDecimal(dr["Credit"]),
                    Address = Convert.ToString(dr["Address"]),
                    Phoneno = Convert.ToString(dr["Phoneno"]),
                    Description = Convert.ToString(dr["Description"])
                });
            }
            return lst;
        }
        public bool InsertData(CreditParty obj)
        {
            if (obj == null)
                throw new InvalidExpressionException("Empty object");
            int i;
            SqlCommand cmd = new SqlCommand("SP_INSERT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", obj.Name); //AddWithValues" is a method used in ASP.NET to add a new row to a DataTable
            cmd.Parameters.AddWithValue("@Codeno", obj.Codeno);
            cmd.Parameters.AddWithValue("@PAN", obj.PAN);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Credit", obj.Credit);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Phoneno", obj.Phoneno);
            object parameterValue = obj.Description;
            if (string.IsNullOrEmpty(obj.Description))
                parameterValue = DBNull.Value;
            cmd.Parameters.AddWithValue("@Desc", parameterValue);

            con.Open();
            i = cmd.ExecuteNonQuery();//Execute a Transact-SQL statement or a stored procedure that does not return any results.
                                      //This method is commonly used for SQL statements like INSERT, UPDATE, DELETE, etc., which modify data in a database.
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
        public bool UpdateData(CreditParty obj)
        {
            if (obj == null)
                throw new InvalidExpressionException("Empty object");
            int i;
            SqlCommand cmd = new SqlCommand("SP_UPDATE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", obj.Name); 
            cmd.Parameters.AddWithValue("@Codeno", obj.Codeno);
            cmd.Parameters.AddWithValue("@PAN", obj.PAN);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Credit", obj.Credit);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Phoneno", obj.Phoneno);
            object parameterValue = obj.Description;
            if (string.IsNullOrEmpty(obj.Description))
                parameterValue = DBNull.Value;
            cmd.Parameters.AddWithValue("@Desc", parameterValue);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
        public bool DeleteData(CreditParty obj)
        {
            int i;
            SqlCommand cmd = new SqlCommand("SP_DELETE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Codeno", obj.Codeno); 
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
       //REFERRED PROCEDURES
        public List<Referred> GetRefDataList()
        {
            List<Referred> lst = new List<Referred>();
            SqlCommand cmd = new SqlCommand("SP_REF_SELECT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new Referred
                {
                    UserID = Convert.ToInt32(dr["UserID"]),
                    Designation = Convert.ToString(dr["Designation"]),
                    Department = Convert.ToString(dr["Department"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Email = Convert.ToString(dr["Email"]),
                    Office = Convert.ToString(dr["Office"]),
                    NMCno = Convert.ToString(dr["NMCno"]),
                    Entrydate = Convert.ToDateTime(dr["Entrydate"]),
                    Doctorname = Convert.ToString(dr["Doctorname"]),
                    Hospitalname = Convert.ToString(dr["Hospitalname"]),
                    Specilist = Convert.ToString(dr["Specilist"]),
                });
            }
            return lst;
        }
        public bool InsertRefData(Referred obj)
        {
            if (obj == null)
                throw new InvalidExpressionException("Empty object");
            int i;
            SqlCommand cmd = new SqlCommand("SP_REF_INSERT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Designation", obj.Designation);
            cmd.Parameters.AddWithValue("@Department", obj.Department);
            cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@Office", obj.Office);
            cmd.Parameters.AddWithValue("@NMCno", obj.NMCno);
            cmd.Parameters.AddWithValue("@Entrydate", obj.Entrydate);
            cmd.Parameters.AddWithValue("@Doctorname", obj.Doctorname);
            cmd.Parameters.AddWithValue("@Hospitalname", obj.Hospitalname);
            cmd.Parameters.AddWithValue("@Specilist", obj.Specilist);
            object parameterValue = obj.Email;
            if (string.IsNullOrEmpty(obj.Email))
                parameterValue = DBNull.Value;
            cmd.Parameters.AddWithValue("@Email", parameterValue);

            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
        public bool UpdateRefData(Referred obj)
        {
            if (obj == null)
                throw new InvalidExpressionException("Empty object");
            int i;
            SqlCommand cmd = new SqlCommand("SP_REF_UPDATE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@Designation", obj.Designation);
            cmd.Parameters.AddWithValue("@Department", obj.Department);
            cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@Office", obj.Office);
            cmd.Parameters.AddWithValue("@NMCno", obj.NMCno);
            cmd.Parameters.AddWithValue("@Entrydate", obj.Entrydate);
            cmd.Parameters.AddWithValue("@Doctorname", obj.Doctorname);
            cmd.Parameters.AddWithValue("@Hospitalname", obj.Hospitalname);
            cmd.Parameters.AddWithValue("@Specilist", obj.Specilist);
            object parameterValue = obj.Email;
            if (string.IsNullOrEmpty(obj.Email))
                parameterValue = DBNull.Value;
            cmd.Parameters.AddWithValue("@Email", parameterValue);

            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
        public bool DeleteRefData(Referred obj)
        {
            int i;
            SqlCommand cmd = new SqlCommand("SP_REF_DELETE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
        //Requestor Procedure
        public List<Requestor> GetReqDataList()
        {
            List<Requestor> lst = new List<Requestor>();
            SqlCommand cmd = new SqlCommand("SP_REQ_SELECT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new Requestor
                {
                    UserID = Convert.ToInt32(dr["UserID"]),
                    Email = Convert.ToString(dr["Email"]),
                    Contactno = Convert.ToString(dr["Contactno"]),
                    Contactperson = Convert.ToString(dr["Contactperson"]),
                    Mobileno = Convert.ToString(dr["Mobileno"]),
                    Code = Convert.ToString(dr["Code"]),
                    Entrydate = Convert.ToDateTime(dr["Entrydate"]),
                    Requestorname = Convert.ToString(dr["Requestorname"]),
                    Address = Convert.ToString(dr["Address"])
                });
            }
            return lst;
        }
        public bool InsertReqData(Requestor obj)
        {
            if (obj == null)
                throw new InvalidExpressionException("Empty object");
            int i;
            SqlCommand cmd = new SqlCommand("SP_REQ_CREATE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Contactno", obj.Contactno);
            cmd.Parameters.AddWithValue("@Contactperson", obj.Contactperson);
            cmd.Parameters.AddWithValue("@Mobileno", obj.Mobileno);
            cmd.Parameters.AddWithValue("@Code", obj.Code);
            cmd.Parameters.AddWithValue("@Entrydate", obj.Entrydate);
            cmd.Parameters.AddWithValue("@Requestorname", obj.Requestorname);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            object parameterValue = obj.Email;
            if (string.IsNullOrEmpty(obj.Email))
                parameterValue = DBNull.Value;
            cmd.Parameters.AddWithValue("@Email", parameterValue);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool UpdateReqData(Requestor obj)
        {
            if (obj == null)
                throw new InvalidExpressionException("Empty object");
            int i;
            SqlCommand cmd = new SqlCommand("SP_REQ_UPDATE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@Contactno", obj.Contactno);
            cmd.Parameters.AddWithValue("@Contactperson", obj.Contactperson);
            cmd.Parameters.AddWithValue("@Mobileno", obj.Mobileno);
            cmd.Parameters.AddWithValue("@Code", obj.Code);
            cmd.Parameters.AddWithValue("@Entrydate", obj.Entrydate);
            cmd.Parameters.AddWithValue("@Requestorname", obj.Requestorname);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            object parameterValue = obj.Email;
            if (string.IsNullOrEmpty(obj.Email))
                parameterValue = DBNull.Value;
            cmd.Parameters.AddWithValue("@Email", parameterValue);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool DeleteReqData(Requestor obj)
        {
            int i;
            SqlCommand cmd = new SqlCommand("SP_REQ_DELETE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
        // Data Combined 
        public List<CombinedData> ListData()
        {
            List<CombinedData> lst = new List<CombinedData>();
            SqlCommand cmd = new SqlCommand("SP_CombinedData", con);
            cmd.CommandType = CommandType.StoredProcedure; 
            DataTable dt = new DataTable(); 
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt); 
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new CombinedData
                {
                    Name = Convert.ToString(dr["Name"]),
                    ID = Convert.ToString(dr["ID"]),
                    TableName = Convert.ToString(dr["TableName"])
                });
            }
            return lst;
        }
    }
}