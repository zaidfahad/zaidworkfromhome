using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;
using System.Data;
using System.Web.Configuration;

namespace DigisensePlatformAPIs.DBUtilities
{
/// <summary>
/// Summary description for DBConnection
/// </summary>
public class DBConnection
{
    //public DBConnection() { }

    /*** PRIVATE FIELDS ***/

    //public static string strDBConnStr;
    private static string strDBConnStr;

    /*** PROPERTIES ***/
    static NpgsqlCommand pgCommand;
    //static NpgsqlConnection pgConnection;
    //static NpgsqlCommandBuilder cmdBuilder;

    public static NpgsqlConnection GetConnection(Int16 BusinessTypeID)
    {
        /*--------------------------------------------------------------------------------------------
         * Function Name:	GetConnection()
         * Description:		Gets connection string from web.config, decrypts it and establishes connection
         *					to the database and returns a handle.
         * Where Used:		In all pages.
         * Returns:			Connection object.
         ---------------------------------------------------------------------------------------------*/
        if (BusinessTypeID > 0)
        {
            try
            {
                string str = string.Empty;// ConfigurationManager.AppSettings["sqlconnectionstring"].ToString();
                if (BusinessTypeID == 1)
                {
                    str = WebConfigurationManager.ConnectionStrings["sqlconnectionstringCommercial"].ToString(); // Commercial DB connection
                }
                else if (BusinessTypeID == 2)
                {
                    str = WebConfigurationManager.ConnectionStrings["sqlconnectionstringCE"].ToString(); // CE connection
                }
                else if (BusinessTypeID == 3)
                {
                    str = WebConfigurationManager.ConnectionStrings["sqlconnectionstringFarm"].ToString(); // Farm DB connection
                }
                else if (BusinessTypeID == 4)
                {
                    str = WebConfigurationManager.ConnectionStrings["sqlconnectionstringMTBD"].ToString(); // MTBD DB connection
                }
                else if (BusinessTypeID == 5)
                {
                    str = WebConfigurationManager.ConnectionStrings["sqlconnectionstringcommon"].ToString(); // Farm DB connection
                }

                if (str == null || str.Length <= 0)
                    throw (new ApplicationException("PostGreSQL Server ConnectionString configuration is missing from your web.config. Contact your administrator."));
                //LogWriter.Write("PostGreSQL Server ConnectionString configuration is missing from web.config." , "Error");
                else
                    strDBConnStr = str;

                NpgsqlConnection connection = new NpgsqlConnection(strDBConnStr);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
            catch (NpgsqlException ex)
            {
                ex.Source += Environment.NewLine + "DBConnection.GetConnection()";
                throw ex;
            }
        }
        else
        {
            
           // LogWriter.WriteDebugTrace("Invalid Business Type : " + BusinessTypeID, BusinessTypeID);
            return null;
        }
    }

    public static void CloseConnection(NpgsqlConnection pgConnection)
    {
        if (pgConnection.State != ConnectionState.Closed)
        {
            pgConnection.Close();
        }
    }

    /// <summary>
    /// GetTable has Output Parameter (retTable) 
    /// </summary>
    /// <param name="sqlQuery"></param>
    /// <param name="retTable"></param>
    /// <returns></returns>
    public string GetTable(string sqlQuery, DataTable retTable)
    {
        pgCommand.CommandText = sqlQuery;
        NpgsqlDataAdapter pgAdapter = new NpgsqlDataAdapter(pgCommand);
        try
        {
            pgAdapter.Fill(retTable);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return String.Empty;
    }

    public object ExecuteScalar(string sqlQuery)
    {
        pgCommand.CommandText = sqlQuery;
        return pgCommand.ExecuteScalar();
    }


    public string SelectQuery(DataTable dtInfo)
    {
        string sqlQuery = "SELECT * FROM \"" + dtInfo.TableName + "\" WHERE ";
        foreach (DataRow dr in dtInfo.Rows)
        {
            sqlQuery += "\"" + dr["Fields"].ToString() + "\" = ";
            if (dr["FldType"].ToString().Equals("NUMBER"))
            {
                sqlQuery += dr["Values"].ToString() + " AND ";
            }
            else
            {
                sqlQuery += "'" + dr["Values"].ToString() + "' AND ";
            }
        }

        return sqlQuery.TrimEnd("AND ".ToCharArray());
    }

    public string InsertQuery(DataTable dtInfo)
    {
        string sqlQuery = "INSERT INTO \"" + dtInfo.TableName + "\" (";
        foreach (DataRow dr in dtInfo.Rows)
        {
            sqlQuery += "\"" + dr["Fields"].ToString() + "\",";
        }

        sqlQuery = sqlQuery.TrimEnd(",".ToCharArray()) + ") VALUES (";

        foreach (DataRow dr in dtInfo.Rows)
        {
            if (!dr["FldType"].ToString().Equals("NUMBER"))
            {
                sqlQuery += "'" + dr["Values"].ToString() + "',";
            }
            else
            {
                sqlQuery += dr["Values"].ToString() + ",";
            }
        }

        sqlQuery = sqlQuery.TrimEnd(",".ToCharArray()) + ")";

        return sqlQuery;
    }


    public DataTable CreateInfoTable(string tblName)
    {
        DataTable dtRetTable = new DataTable(tblName);
        dtRetTable.Columns.Add("Fields", typeof(string));
        dtRetTable.Columns.Add("FldType", typeof(string));
        dtRetTable.Columns.Add("Values", typeof(string));

        return dtRetTable;
    }

    public bool ExecuteQuery(string sqlQuery)
    {
        pgCommand.CommandText = sqlQuery;
        int retVal = pgCommand.ExecuteNonQuery();
        return (retVal == -1) ? false : true;
    }


    public bool InfoExists(DataTable dtInfo)
    {
        bool isExists = true;

        string sqlQuery = SelectQuery(dtInfo);
        DataTable dtResult = new DataTable();
        string errInfo = GetTable(sqlQuery, dtResult);
        if (dtResult.Rows.Count == 0)
        {
            isExists = false;
        }
        return isExists;
    }

    public void ExecuteQuery()
    {
        throw new NotImplementedException();
    }
}

}
