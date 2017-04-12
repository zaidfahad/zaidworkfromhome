using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DigisensePlatformAPIs.Utilities;
using System.Reflection;

namespace DigisensePlatformAPIs.BLUtilities
{
     
    public class Expense_BL
    {
        #region View Expense Response
        public static List<ExpenseResponse> ExpenseResponse(DataTable dt)
        {
            PayoutDetailsResponse clsPayoutDetailsResponse = null;
            List<PayoutDetailsResponse> sublist = null;
            ExpenseResponse clsExpenseResponse = null;
            List<ExpenseResponse> list = new List<ExpenseResponse>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sublist = new List<PayoutDetailsResponse>();
                    //TollTax
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["tolltaxentrytax"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["tolltaxentrytax"].ToString() == "" ? "0" : dt.Rows[i]["tolltaxentrytax"].ToString();
                    //clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                   // clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);

                    //DriverPayout
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["salary"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["salary"].ToString() == "" ? "0" : dt.Rows[i]["salary"].ToString();
                   // clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                    //clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);

                    //OtherPayout
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["otherexpenses"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value =dt.Rows[i]["otherexpenses"].ToString() == "" ? "0" : dt.Rows[i]["otherexpenses"].ToString();
                   // clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                   // clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);

                    //FuelCharges
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["fuelcost"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["fuelcost"].ToString() == "" ? "0" : dt.Rows[i]["fuelcost"].ToString();
                    //clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                    //clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);

                    //Police RTO 
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["policerto"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["policerto"].ToString() == "" ? "0" : dt.Rows[i]["policerto"].ToString();
                   // clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                   // clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);
                    //Roti Tea
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["rotiTea"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["rotiTea"].ToString() == "" ? "0" : dt.Rows[i]["rotiTea"].ToString();
                   // clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                   // clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);

                    //Comission
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["comission"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["comission"].ToString() == "" ? "0" : dt.Rows[i]["comission"].ToString();
                    //clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                    //clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);
                    clsExpenseResponse = new ExpenseResponse();

                    //Prasad Oil Soap
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["prasadoilsoap"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["prasadoilsoap"].ToString() == "" ? "0" : dt.Rows[i]["prasadoilsoap"].ToString();
                   // clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                   // clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);
                    //Prasad Oil Soap
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["airgreasecloth"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value =  dt.Rows[i]["airgreasecloth"].ToString() == "" ? "0" : dt.Rows[i]["airgreasecloth"].ToString();
                    //clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                   // clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);


                    //Weigh_Bridge
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["weighbridge"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["weighbridge"].ToString() == "" ? "0" : dt.Rows[i]["weighbridge"].ToString();
                   // clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                   // clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);

                    //Phone_Parking_Service_Guide
                    clsPayoutDetailsResponse = new PayoutDetailsResponse();
                    clsPayoutDetailsResponse.label = dt.Columns["parkingserviceguide"].ColumnName.ToString();
                    clsPayoutDetailsResponse.value = dt.Rows[i]["parkingserviceguide"].ToString() == "" ? "0" : dt.Rows[i]["parkingserviceguide"].ToString();
                    //clsPayoutDetailsResponse.date = dt.Rows[i]["ExpenseCreatedDate"].ToString();
                   // clsPayoutDetailsResponse.createdBy = dt.Rows[i]["CreatedBy"].ToString();
                    sublist.Add(clsPayoutDetailsResponse);

                    clsExpenseResponse = new ExpenseResponse();

                    clsExpenseResponse.tripName = dt.Rows[i]["tripname"].ToString();
                    //clsExpenseResponse.startDate = dt.Rows[i]["Trip_Start"].ToString();
                    clsExpenseResponse.startDate = Convert.ToDateTime(dt.Rows[0]["Trip_Start"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                   // clsExpenseResponse.endDate = dt.Rows[i]["Trip_End"].ToString();
                    clsExpenseResponse.endDate = Convert.ToDateTime(dt.Rows[0]["Trip_End"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    clsExpenseResponse.tripStatus = dt.Rows[i]["Trip_Status"].ToString();
                    clsExpenseResponse.PayoutDetailsResponse = sublist;
                    list.Add(clsExpenseResponse);
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region View Expense Category Response
        public static List<ExpenseCategoryResponse> ExpenseCategoryResponse(DataTable dt)
        {
            List<ExpenseCategoryResponse> expenses = new List<ExpenseCategoryResponse>();
          
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ExpenseCategoryResponse obj = new ExpenseCategoryResponse();
                    obj.label = dt.Rows[i]["expense_type"].ToString();
                    // string customColumns = dt.Columns[i].ColumnName.ToString().ToLower().CustomClassPropertyName();
                    //if (Convert.ToString(dt.Rows[0][icount]) != null)
                    //{
                    //    expenses.Add(Convert.ToString(dt.Columns[icount].ColumnName), dt.Rows[0][icount].ToString());
                    //}
                    //else
                    //{
                    //    expenses.Add(Convert.ToString(dt.Columns[icount].ColumnName), "00.00");
                    //}
                    expenses.Add(obj);
                }
            }
            catch (Exception ex)
            {
            }
            return expenses;
        }
        #endregion

        #region Expense Category Post Response

        public static List<ExpenseCategory> ExpenseCategoryPostResponse(DataTable dt)
        {
            List<ExpenseCategory> expenseCategory = new List<ExpenseCategory>();
            try
            {
            }
            catch (Exception ex)
            {
            }
            return expenseCategory;
        }
        #endregion

        #region Expense Category Post Response

        public static ExpenseAttributeInfo ExpenseCategoryPutResponse(DataTable dt)
        {
            ExpenseAttributeInfo expenseCategory = new ExpenseAttributeInfo();
            List<ExpenseAttributeInfo> obj = new List<ExpenseAttributeInfo>();
         
            try
            {
                if (dt.Rows.Count > 0)
                {
                    //obj.Add(new ExpenseAttributeInfo { label = dt.Rows[0]["label"].ToString(), value = dt.Rows[0]["value"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                    expenseCategory.label = dt.Rows[0]["label"].ToString();
                    expenseCategory.value = dt.Rows[0]["value"].ToString();
                   // expenseCategory.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    expenseCategory.date = Convert.ToDateTime(dt.Rows[0]["ExpenseCreatedDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                   
                    expenseCategory.createdBy = dt.Rows[0]["CreatedBy"].ToString();
                    /*
                    obj.Add(new ExpenseAttributeInfo { label = dt.Columns["tolltaxentrytax"].ColumnName.ToString(), value = dt.Rows[0]["tolltaxentrytax"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                     obj.Add( new ExpenseAttributeInfo { label = dt.Columns["salary"].ColumnName.ToString(), value = dt.Rows[0]["salary"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                    obj.Add( new ExpenseAttributeInfo { label = dt.Columns["otherexpenses"].ColumnName.ToString(), value = dt.Rows[0]["otherexpenses"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                    obj.Add( new ExpenseAttributeInfo { label = dt.Columns["fuelcost"].ColumnName.ToString(), value = dt.Rows[0]["fuelcost"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                    obj.Add( new ExpenseAttributeInfo { label = dt.Columns["policerto"].ColumnName.ToString(), value = dt.Rows[0]["policerto"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                     obj.Add( new ExpenseAttributeInfo { label = dt.Columns["rotitea"].ColumnName.ToString(), value = dt.Rows[0]["rotitea"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                     obj.Add( new ExpenseAttributeInfo { label = dt.Columns["comission"].ColumnName.ToString(), value = dt.Rows[0]["comission"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                     obj.Add( new ExpenseAttributeInfo { label = dt.Columns["prasadoilsoap"].ColumnName.ToString(), value = dt.Rows[0]["prasadoilsoap"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                     obj.Add( new ExpenseAttributeInfo { label = dt.Columns["airgreasecloth"].ColumnName.ToString(), value = dt.Rows[0]["airgreasecloth"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                     obj.Add( new ExpenseAttributeInfo { label = dt.Columns["weighbridge"].ColumnName.ToString(), value = dt.Rows[0]["weighbridge"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                     obj.Add(new ExpenseAttributeInfo { label = dt.Columns["parkingserviceguide"].ColumnName.ToString(), value = dt.Rows[0]["parkingserviceguide"].ToString(), date = dt.Rows[0]["ExpenseCreatedDate"].ToString(), createdBy = dt.Rows[0]["CreatedBy"].ToString() });
                     */
                    //TollTax

                    //expenseCategory.tolltaxentrytax.label = dt.Columns["tolltaxentrytax"].ColumnName.ToString();
                    //expenseCategory.tolltaxentrytax.value = dt.Rows[0]["tolltaxentrytax"].ToString();
                    //expenseCategory.tolltaxentrytax.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.tolltaxentrytax.createdBy = dt.Rows[0]["CreatedBy"].ToString();

                    ////DriverPayout

                    //expenseCategory.salary.label = dt.Columns["salary"].ColumnName.ToString();
                    //expenseCategory.salary.value = dt.Rows[0]["salary"].ToString();
                    //expenseCategory.salary.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.salary.createdBy = dt.Rows[0]["CreatedBy"].ToString();
                    ////OtherPayout

                    //expenseCategory.otherexpenses.label = dt.Columns["otherexpenses"].ColumnName.ToString();
                    //expenseCategory.otherexpenses.value = dt.Rows[0]["otherexpenses"].ToString();
                    //expenseCategory.otherexpenses.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.otherexpenses.createdBy = dt.Rows[0]["CreatedBy"].ToString();


                    ////FuelCharges

                    //expenseCategory.fuelcost.label = dt.Columns["fuelcost"].ColumnName.ToString();
                    //expenseCategory.fuelcost.value = dt.Rows[0]["fuelcost"].ToString();
                    //expenseCategory.fuelcost.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.fuelcost.createdBy = dt.Rows[0]["CreatedBy"].ToString();


                    ////Police RTO 

                    //expenseCategory.policerto.label = dt.Columns["policerto"].ColumnName.ToString();
                    //expenseCategory.policerto.value = dt.Rows[0]["policerto"].ToString();
                    //expenseCategory.policerto.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.policerto.createdBy = dt.Rows[0]["CreatedBy"].ToString();

                    ////Roti Tea

                    //expenseCategory.rotitea.label = dt.Columns["rotiTea"].ColumnName.ToString();
                    //expenseCategory.rotitea.value = dt.Rows[0]["rotiTea"].ToString();
                    //expenseCategory.rotitea.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.rotitea.createdBy = dt.Rows[0]["CreatedBy"].ToString();


                    ////Comission

                    //expenseCategory.comission.label = dt.Columns["comission"].ColumnName.ToString();
                    //expenseCategory.comission.value = dt.Rows[0]["comission"].ToString();
                    //expenseCategory.comission.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.comission.createdBy = dt.Rows[0]["CreatedBy"].ToString();

                    ////Prasad Oil Soap


                    //expenseCategory.prasadoilsoap.label = dt.Columns["prasadoilsoap"].ColumnName.ToString();
                    //expenseCategory.prasadoilsoap.value = dt.Rows[0]["prasadoilsoap"].ToString();
                    //expenseCategory.prasadoilsoap.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.prasadoilsoap.createdBy = dt.Rows[0]["CreatedBy"].ToString();

                    ////Air_Grease_Cloth

                    //expenseCategory.airgreasecloth.label = dt.Columns["airgreasecloth"].ColumnName.ToString();
                    //expenseCategory.airgreasecloth.value = dt.Rows[0]["airgreasecloth"].ToString();
                    //expenseCategory.airgreasecloth.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.airgreasecloth.createdBy = dt.Rows[0]["CreatedBy"].ToString();



                    ////Weigh_Bridge

                    //expenseCategory.weighbridge.label = dt.Columns["weighbridge"].ColumnName.ToString();
                    //expenseCategory.weighbridge.value = dt.Rows[0]["weighbridge"].ToString();
                    //expenseCategory.weighbridge.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.weighbridge.createdBy = dt.Rows[0]["CreatedBy"].ToString();


                    ////Phone_Parking_Service_Guide

                    //expenseCategory.parkingserviceguide.label = dt.Columns["parkingserviceguide"].ColumnName.ToString();
                    //expenseCategory.parkingserviceguide.value = dt.Rows[0]["parkingserviceguide"].ToString();
                    //expenseCategory.parkingserviceguide.date = dt.Rows[0]["ExpenseCreatedDate"].ToString();
                    //expenseCategory.parkingserviceguide.createdBy = dt.Rows[0]["CreatedBy"].ToString();

                }

            }
            catch (Exception ex)
            {
            }
            return expenseCategory;
        }
        #endregion
    }
}