using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class Expense
    {
        public string label { get; set; }
        public string value { get; set; }
        public DateTime date { get; set; }
        public string createdBy { get; set; }
    }

    #region Request Property For Put
    public class ExpenseRequest
    {

        public FuelCost fuelCost { get; set; }
        public TollTaxEntryTax tolltaxEntryTax { get; set; }
        public PoliceRTo policeRto { get; set; }
        public RotiTea rotiTea { get; set; }
        public Comission comission { get; set; }
        public PrasadOilSoap prasadOilsoap { get; set; }
        public AirGreaseCloth airGreasecloth { get; set; }

        public WeighBridge weighBridge { get; set; }
        public ParkingServiceGuide parkingServiceguide { get; set; }
        public Salary salary { get; set; }
        public OtherExpenses otherExpenses { get; set; }
    }

    public class PoliceRTo
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class OtherExpenses
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class Salary
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class ParkingServiceGuide
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class WeighBridge
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class AirGreaseCloth
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class PrasadOilSoap
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class Comission
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class RotiTea
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class TollTaxEntryTax
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }

    public class FuelCost
    {
        public string label { get; set; }
        public string value { get; set; }
        public string createdBy { get; set; }
        public DateTime date { get; set; }
    }
    #endregion
}