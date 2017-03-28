#region "Reference Assemblies"
using System;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

#endregion

namespace DigisensePlatformAPIs.Utilities
{
  public class RandomPasswordGenerator
  {      
      #region CreateRandomPassword
      /// <summary>
      /// method for generating random password
      /// </summary>
      /// <param name="passwordLength"></param>
      /// <returns></returns>
      public  string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789@_";
            char[] chars = new char[passwordLength];
            Random rd = new Random();
            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }
      #endregion

      #region Encryption
      /// <summary>
      /// method for string encryption
      /// </summary>
      /// <param name="toEncrypt"></param>
      /// <param name="useHashing"></param>
      /// <returns></returns>
      public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] resultArray=null ;

            byte[] keyArray;
            try
            {

         
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                        typeof(String));
            //string key = "satyam123$";
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
          
            }
            catch (Exception ex)
            {
               return Convert.ToString(ex.Message);
            }
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
      #endregion

      #region Decryption
      /// <summary>
      /// method for string decryption
      /// </summary>
      /// <param name="cipherString"></param>
      /// <param name="useHashing"></param>
      /// <returns></returns>
      public  string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
      #endregion

      #region Password updation
      /// <summary>
      /// generate radom password and update that password in database      /// </summary>
      /// <param name="userName"></param>      /// <returns></returns>
      public string GeneratePassword(string userName)
      {
          //declaring variables                   
          string newPassword = string.Empty;
          RandomPasswordGenerator objRadomPasswordGenerator = null;
          try
          {
              objRadomPasswordGenerator = new RandomPasswordGenerator();
              newPassword = objRadomPasswordGenerator.CreateRandomPassword(6);
          }
          catch (Exception ex)
          {
            //  LogWriter.Write("RandomPasswordGenerator:GeneratePassword: " + ex.Message, "Error");
          } 
          return newPassword;
      }
      #endregion

    }

}
