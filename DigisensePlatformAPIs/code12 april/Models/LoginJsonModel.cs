using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace DigisensePlatformAPIs.JsonResponseModel
{
    public class LoginJsonModel
    {
        public string jwt { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public List<ServiceAvailable> serviceAvailable = new List<ServiceAvailable>();
        public List<ServiceAvailable> serviceAvailables
        {
            get { return serviceAvailable; }
            set { serviceAvailable = value; }
        }
    }

    
    public class ServiceAvailable
    {
        public string name { get; set; }
        public string role { get; set; }
        // public List<Roledata> roledata = new List<Roledata>();
        public string roledata { get; set; }
    }
    /*
    public class Roledata
    {
        public List<Role> roles = new List<Role>();
    }
    public class Role
    {
        public List<Template1> template1 = new List<Template1>();
        public List<Template2> template2 = new List<Template2>();
        public List<Template3> template3 = new List<Template3>();
    }
    #region Template1
    public class Template1
    {
        public string chartHeading { get; set; }
        public List<DataObject> dataObject = new List<DataObject>();
    }

    public class DataObject
    {
        public List<Data> Data = new List<Data>();
    }

   
    #endregion
    #region Template2
    public class Template2
    {
        public string listHeading { get; set; }
        public List<DataObjects> dataObject = new List<DataObjects>();
    }

    public class DataObjects
    {
        public string alertTitle { get; set; }
        public List<Data> Data = new List<Data>();
    }
    #endregion
    #region Templates 3
    public class Template3
    {
        public List<DataObject> DataObjects = new List<DataObject>();
    }
    #endregion
    #region Comman Data
    public class Data
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Editable { get; set; }
    }
    #endregion

    */
}