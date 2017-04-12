using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class ReminderRepository
    {
        //#region   List of Reminders
        //public static DataSet getReminders(string username,  DateTime fromdate, DateTime todate, int buinessId)
        //{
        //    NpgsqlConnection connection = null;
        //    DataSet dtalerts = new DataSet();
        //    string result = string.Empty;
        //    try
        //    {

        //        object[] oParameters = new object[3];

        //        oParameters[0] = username;
        //        oParameters[1] = fromdate;
        //        oParameters[2] = todate;

        //        NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[3];
        //        oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
        //        oNpgsqlParameter[1] = new NpgsqlParameter("fromdate", DbType.Date);
        //        oNpgsqlParameter[2] = new NpgsqlParameter("todate", DbType.Date);

        //        connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
        //        dtalerts = NpgsqlHelper.ExecuteDataset(connection, "usp_mobileapi_get_reminders", oParameters, oNpgsqlParameter);


        //    }
        //    catch (Exception ex)
        //    {
        //        Convert.ToString(ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();

        //    }
        //    return dtalerts;
        //}
        //#endregion



        /// <summary>
        /// getReminders
        /// </summary>
        /// <returns></returns>
        public static DataSet getReminders(string username, DateTime fromdate, DateTime todate, int buinessId)
        {
            //Declaring Variables
            NpgsqlConnection connection = null;
            DataSet dtWorkGrpDtls = null;
            try
            {
                dtWorkGrpDtls = new DataSet();



                //Get database connection
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));


                //object[] oParameters = new object[1];
                //oParameters[0] = roleid;

                NpgsqlTransaction tr = (NpgsqlTransaction)connection.BeginTransaction();

                NpgsqlCommand cursCmd = new NpgsqlCommand("usp_mobileapi_get_reminders",
                                                        (NpgsqlConnection)connection);


                cursCmd.Transaction = tr;




                NpgsqlParameter rfusername = new NpgsqlParameter("username",
                                                     username);
                rfusername.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(rfusername);

                NpgsqlParameter rffromdate = new NpgsqlParameter("fromdate",
                                                  fromdate);
                rffromdate.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(rffromdate);

                NpgsqlParameter rftodate = new NpgsqlParameter("todate",
                                                  todate);
                rftodate.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(rftodate);



                NpgsqlParameter reffitnesscertification = new NpgsqlParameter("reffitnesscertification",
                                                     NpgsqlTypes.NpgsqlDbType.Refcursor);
                reffitnesscertification.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(reffitnesscertification);


                NpgsqlParameter refinsurancepayment = new NpgsqlParameter("refinsurancepayment",
                                                     NpgsqlTypes.NpgsqlDbType.Refcursor);
                reffitnesscertification.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refinsurancepayment);
                cursCmd.CommandType = CommandType.StoredProcedure;

                var adapter = new NpgsqlDataAdapter(cursCmd);

                adapter.Fill(dtWorkGrpDtls);

                tr.Commit();


            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                // close connection
                if (connection != null)
                    connection.Close();
            }
            return dtWorkGrpDtls;
        }
    }
}