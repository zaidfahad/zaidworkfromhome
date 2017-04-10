using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{

    #region GET expense/vehicleRegNo
    public class ExpenseResponse
    {
        public string tripName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string tripStatus { get; set; }

        [JsonProperty(PropertyName = "expense")]
        public List<PayoutDetailsResponse> PayoutDetailsResponse = new List<PayoutDetailsResponse>();
    }
    public class PayoutDetailsResponse
    {
        public string label { get; set; }
        public string value { get; set; }
      //  public string date { get; set; }
       // public string createdBy { get; set; }

    }
    #endregion

    #region Expenses Category Response Post
    public class ExpenseCategory
    {
        public string fuelCost { get; set; }
        public string tolltaxEntryTax { get; set; }
        public string policeRto { get; set; }
        public string rotiTea { get; set; }
        public string comission { get; set; }
        public string prasadOilsoap { get; set; }
        public string airGreasecloth { get; set; }
        public string weighBridge { get; set; }
        public string parkingServiceguide { get; set; }
        public string salary { get; set; }
        public string otherExpenses { get; set; }
    }
    #endregion

    #region Expenses Category Label Name

    #endregion



    #region Request Property For Put
    public class ExpenseRequestPut
    {
      

        public string fuelCost { get; set; }
        public string tolltaxEntryTax { get; set; }
        public string policeRto { get; set; }
        public string rotiTea { get; set; }
        public string comission { get; set; }
        public string prasadOilsoap { get; set; }
        public string airGreasecloth { get; set; }

        public string weighBridge { get; set; }
        public string parkingServiceguide { get; set; }
        public string salary { get; set; }
        public string otherExpenses { get; set; }
    }
    public class ExpenseResponsePut
    {
        /*
        public ExpenseResponsePut()
        {
            Fuel_Cost = new FuelCostPut();
            Tolltax_EntryTax = new TollTaxEntryTaxPut();
            Police_Rto = new PoliceRToPut();
            Roti_Tea = new RotiTeaPut();
            Commission = new ComissionPut();
            Prasad_Oil_Soap = new PrasadOilSoapPut();
            Air_Grease_Cloth = new AirGreaseClothPut();
            Weigh_Bridge = new WeighBridgePut();
            Phone_Parking_Service_Guide = new ParkingServiceGuidePut();
            Salary = new SalaryPut();
            Other_Expenses = new OtherExpensesPut();

        }
        public FuelCostPut Fuel_Cost { get; set; }
        public TollTaxEntryTaxPut Tolltax_EntryTax { get; set; }
        public PoliceRToPut Police_Rto { get; set; }
        public RotiTeaPut Roti_Tea { get; set; }
        public ComissionPut Commission { get; set; }
        public PrasadOilSoapPut Prasad_Oil_Soap { get; set; }
        public AirGreaseClothPut Air_Grease_Cloth { get; set; }

        public WeighBridgePut Weigh_Bridge { get; set; }
        public ParkingServiceGuidePut Phone_Parking_Service_Guide { get; set; }
        public SalaryPut Salary { get; set; }
        public OtherExpensesPut Other_Expenses { get; set; }
         * */

        public ExpenseAttributeInfo fuelcost { get; set; }
        public ExpenseAttributeInfo tolltaxentrytax { get; set; }
        public ExpenseAttributeInfo policerto { get; set; }
        public ExpenseAttributeInfo rotitea { get; set; }
        public ExpenseAttributeInfo comission { get; set; }
        public ExpenseAttributeInfo prasadoilsoap { get; set; }
        public ExpenseAttributeInfo airgreasecloth { get; set; }

        public ExpenseAttributeInfo weighbridge { get; set; }
        public ExpenseAttributeInfo parkingserviceguide { get; set; }
        public ExpenseAttributeInfo salary { get; set; }
        public ExpenseAttributeInfo otherexpenses { get; set; }
    }
    public class ExpenseCategoryResponse
    {
        public string label { get; set; }
    }
    public class ExpenseAttributeInfo
    {
        public string label { get; set; }
        public string value { get; set; }
         public string date { get; set; }
        public string createdBy { get; set; }
        
    }


    public class PoliceRToPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class OtherExpensesPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class SalaryPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class ParkingServiceGuidePut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class WeighBridgePut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class AirGreaseClothPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class PrasadOilSoapPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class ComissionPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class RotiTeaPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class TollTaxEntryTaxPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }

    public class FuelCostPut
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public string date { get; set; }
    }
    #endregion

}