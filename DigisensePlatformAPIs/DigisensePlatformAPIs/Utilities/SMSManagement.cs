using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.Net;
using System.IO;
 
using System.Configuration;


namespace DigisensePlatformAPIs.Utilities
{
    public class SMSManagement
    {
        public static void SendSMS(string smstext, string mobilenumber)
        {
            string format = Convert.ToString(ConfigurationManager.AppSettings["smsFormat"]);
            string URL = Convert.ToString(ConfigurationManager.AppSettings["smsURL"]);
            string UserName = Convert.ToString(ConfigurationManager.AppSettings["smsUserName"]);
            string Password = Convert.ToString(ConfigurationManager.AppSettings["smsPassword"]);
            string SenderId = Convert.ToString(ConfigurationManager.AppSettings["senderID"]);
            string applicationurl = Convert.ToString(ConfigurationManager.AppSettings["ApplicationURL"]);
            string phNumbers = mobilenumber;
            string smsURL = String.Format(format, URL, UserName, Password, SenderId, phNumbers, smstext);
            WebRequest wrGETURL = WebRequest.Create(smsURL);
            wrGETURL.Proxy = WebRequest.DefaultWebProxy;
            wrGETURL.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wrGETURL.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            try
            {
                StreamReader objReader = new StreamReader(wrGETURL.GetResponse().GetResponseStream());
                objReader.Close();
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}