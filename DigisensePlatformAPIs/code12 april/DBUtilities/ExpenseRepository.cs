using DigisensePlatformAPIs.Models;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class ExpenseRepository
    {
        #region   View Expense Details
        public static DataTable ExpenseDetails(string username, string vehregno, DateTime startdate, DateTime enddate, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[4];
                oParameters[0] = username;
                oParameters[1] = vehregno;
                oParameters[2] = startdate;
                oParameters[3] = enddate;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", NpgsqlDbType.Text);
                oNpgsqlParameter[1] = new NpgsqlParameter("i_vechile_no", NpgsqlDbType.Text);
                oNpgsqlParameter[2] = new NpgsqlParameter("i_fromdate", NpgsqlDbType.Timestamp);
                oNpgsqlParameter[3] = new NpgsqlParameter("i_enddate", NpgsqlDbType.Timestamp);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_trip_expense_new", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
            }
            return dtalerts;
        }
        #endregion

        #region   View Expense Details
        public static DataTable ExpenseCategoryDetails(string username, string vehregno, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                oParameters[1] = vehregno;
    
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("i_vechile_no ", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_trip_category_new", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                // connection.Close();

            }
            return dtalerts;
        }
        #endregion

        #region   View Expense Details Post
        public static DataTable ExpenseCategoryPlatformPost(string username, string platform, ExpenseRequest expenseRequest, int buinessId)
        {
            //NpgsqlConnection connection = null;
            //DataTable dtalerts = new DataTable();
            //string result = string.Empty;
            try
            {
                //    object[] oParameters = new object[15];
                //    oParameters[0] = username;
                //    oParameters[1] = platform;
                //    oParameters[2] = expenseRequest.fuelCost;
                //    oParameters[3] = expenseRequest.tolltaxEntryTax;
                //    oParameters[4] = expenseRequest.policeRto;
                //    oParameters[5] = expenseRequest.tolltaxEntryTax;
                //    oParameters[6] = expenseRequest.rotiTea;
                //    oParameters[7] = expenseRequest.comission;
                //    oParameters[8] = expenseRequest.prasadOilsoap;
                //    oParameters[9] = expenseRequest.airGreasecloth;
                //    oParameters[10] = expenseRequest.weighBridge;
                //    oParameters[11] = expenseRequest.parkingServiceguide;
                //    oParameters[12] = expenseRequest.salary;
                //    oParameters[13] = expenseRequest.otherExpenses;
                //    oParameters[14] = DateTime.Now;
                //    oParameters[3] = expenseRequest.tolltaxEntryTax;
                //    NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                //    oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                //    oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                //    oNpgsqlParameter[2] = new NpgsqlParameter("_fuelcost", DbType.Double);
                //    oNpgsqlParameter[3] = new NpgsqlParameter("_tolltax_entrytax", DbType.Double);
                //    oNpgsqlParameter[4] = new NpgsqlParameter("_police_rto", DbType.Double);
                //    oNpgsqlParameter[5] = new NpgsqlParameter("_tolltax_entrytax", DbType.Double);
                //    oNpgsqlParameter[6] = new NpgsqlParameter("_roti_tea", DbType.Double);
                //    oNpgsqlParameter[7] = new NpgsqlParameter("_commission", DbType.Double);
                //    oNpgsqlParameter[8] = new NpgsqlParameter("_prasad_oil_soap", DbType.Double);
                //    oNpgsqlParameter[9] = new NpgsqlParameter("_air_grease_cloth", DbType.Double);
                //    oNpgsqlParameter[10] = new NpgsqlParameter("_weighbridge", DbType.Double);
                //    oNpgsqlParameter[11] = new NpgsqlParameter("_phone_parking_service_guide", DbType.Double);
                //    oNpgsqlParameter[12] = new NpgsqlParameter("_salary", DbType.Double);
                //    oNpgsqlParameter[13] = new NpgsqlParameter("_other_expenses", DbType.Double);
                //    oNpgsqlParameter[14] = new NpgsqlParameter("_created_date", DbType.Double);
                //    connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                //    dtalerts = NpgsqlHelper.ExecuteDataTable(connection, " usp_mobileapi_insert_expens", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                //  Convert.ToString(ex.Message);
            }
            finally
            {
                //  connection.Close();
            }
            return null;
        }
        #endregion

        #region   View Expense Details Put
        public static DataTable ExpenseCategoryPlatformPut(string username, string vehicleRegNo, ExpenseRequestPut expenseRequest, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[14];
                oParameters[0] = username;
                oParameters[1] = vehicleRegNo;
                oParameters[2] = Convert.ToDouble(expenseRequest.fuelCost);
                oParameters[3] = Convert.ToDouble(expenseRequest.tolltaxEntryTax);
                oParameters[4] = Convert.ToDouble(expenseRequest.policeRto);
                oParameters[5] = Convert.ToDouble(expenseRequest.rotiTea);
                oParameters[6] = Convert.ToDouble(expenseRequest.comission);
                oParameters[7] = Convert.ToDouble(expenseRequest.prasadOilsoap);
                oParameters[8] = Convert.ToDouble(expenseRequest.airGreasecloth);
                oParameters[9] = Convert.ToDouble(expenseRequest.weighBridge);
                oParameters[10] = Convert.ToDouble(expenseRequest.parkingServiceguide);
                oParameters[11] = Convert.ToDouble(expenseRequest.salary);
                oParameters[12] = Convert.ToDouble(expenseRequest.otherExpenses);
                oParameters[13] = Convert.ToDateTime(DateTime.Now);// "2017-01-24");
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[14];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", NpgsqlDbType.Text);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", NpgsqlDbType.Text);
                oNpgsqlParameter[2] = new NpgsqlParameter("_fuelcost", NpgsqlDbType.Double);
                oNpgsqlParameter[3] = new NpgsqlParameter("_tolltax_entrytax", NpgsqlDbType.Double);
                oNpgsqlParameter[4] = new NpgsqlParameter("_police_rto", NpgsqlDbType.Double);
                oNpgsqlParameter[5] = new NpgsqlParameter("_roti_tea", NpgsqlDbType.Double);
                oNpgsqlParameter[6] = new NpgsqlParameter("_commission", NpgsqlDbType.Double);
                oNpgsqlParameter[7] = new NpgsqlParameter("_prasad_oil_soap", NpgsqlDbType.Double);
                oNpgsqlParameter[8] = new NpgsqlParameter("_air_grease_cloth", NpgsqlDbType.Double);
                oNpgsqlParameter[9] = new NpgsqlParameter("_weighbridge", NpgsqlDbType.Double);
                oNpgsqlParameter[10] = new NpgsqlParameter("_phone_parking_service_guide", NpgsqlDbType.Double);
                oNpgsqlParameter[11] = new NpgsqlParameter("_salary", NpgsqlDbType.Double);
                oNpgsqlParameter[12] = new NpgsqlParameter("_other_expenses", NpgsqlDbType.Double);
                oNpgsqlParameter[13] = new NpgsqlParameter("_created_date", NpgsqlDbType.Date);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                //usp_mobileapi_insert_expense
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_insert_expense", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dtalerts;
        }

        #endregion

        #region  UpdateExpense
        public static DataTable UpdateExpense(string username, string i_vechile_no, string _lables, string _values,DateTime _created_date, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[5];
                oParameters[0] = username;
                oParameters[1] = i_vechile_no;
                oParameters[2] = _lables;
                oParameters[3] = _values;
                oParameters[4] = Convert.ToDateTime(_created_date);
                
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[5];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", NpgsqlDbType.Text);
                oNpgsqlParameter[1] = new NpgsqlParameter("i_vechile_no", NpgsqlDbType.Text);
                oNpgsqlParameter[2] = new NpgsqlParameter(" _lables", NpgsqlDbType.Text);
                oNpgsqlParameter[3] = new NpgsqlParameter("_values", NpgsqlDbType.Text);
                oNpgsqlParameter[4] = new NpgsqlParameter("_created_date", NpgsqlDbType.Date);
            
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                //
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_insert_expense_new", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dtalerts;
        }
        #endregion


        #region  insertExpense
        public static DataTable insertExpense(string username, string i_vechile_no, string _lables, string _values, DateTime _created_date, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[5];
                oParameters[0] = username;
                oParameters[1] = i_vechile_no;
                oParameters[2] = _lables;
                oParameters[3] = _values;
                oParameters[4] = _created_date;

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[5];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", NpgsqlDbType.Text);
                oNpgsqlParameter[1] = new NpgsqlParameter("i_vechile_no", NpgsqlDbType.Text);
                oNpgsqlParameter[2] = new NpgsqlParameter(" _lables", NpgsqlDbType.Text);
                oNpgsqlParameter[3] = new NpgsqlParameter("_values", NpgsqlDbType.Text);
                oNpgsqlParameter[4] = new NpgsqlParameter("_created_date", NpgsqlDbType.Timestamp);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                //
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_insert_expense_latest", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dtalerts;
        }
        #endregion
    }
}