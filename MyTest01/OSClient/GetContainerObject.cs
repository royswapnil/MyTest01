using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace ActiveObjectStore.ContainerObject
{
    public class ContainerData
    {
        public static byte[] bytes;
        public static string getMethodType = "";

        public static string jrequeststring { get; private set; }

        public byte[] GetContainerData(string authurl, string userid, string password, string projectid, string containername, string interfac, string region, string catName, string catType, string objectname, string contenttype, string methodtype)
        {
            try
            {
                string url = string.Empty;
                List<KeyValuePair<string, string>> headers = null;
                string strsbbody = string.Empty;
               // byte[] bytes;
                string requestUrl = string.Empty;
                getMethodType = methodtype;

                GetOSAuthToken.ResponseHeader objresponseheader = new GetOSAuthToken.ResponseHeader();
                GetOSAuthToken.ResponseBody objresponsebody = new GetOSAuthToken.ResponseBody();
                GetOSAuthToken.GetAuthToken objgetauthtoken = new GetOSAuthToken.GetAuthToken();
                GetOSAuthToken.AuthTokenResponse objauthtokenresponse = new GetOSAuthToken.AuthTokenResponse();

                objauthtokenresponse = objgetauthtoken.GetAuthTokenDetails(authurl, userid, password, projectid, interfac, region, catName, catType);

                objresponsebody = objauthtokenresponse.response_Body;
                objresponseheader = objauthtokenresponse.response_Header;

                url = objresponsebody.auth_Url;

                headers = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("X-Auth-Token",objresponseheader.x_Auth_Token),
                    new KeyValuePair<string, string>("ibm-service-instance-id", objresponsebody.service_Instance_Id)
    
                };

                #region ReSTCall

                requestUrl = url + "/" + containername + "/" + Path.GetFileName(objectname);

                HttpWebRequest getdatarequest = WebRequest.Create(requestUrl) as HttpWebRequest;

                getdatarequest.Method = methodtype;
                getdatarequest.ContentType = contenttype;                

                foreach (KeyValuePair<string, string> kp in headers)
                {
                    getdatarequest.Headers[kp.Key] = kp.Value;
                }

                WebResponse response = getdatarequest.GetResponseAsync().Result;

                bytes = StreamToByteArray(response.GetResponseStream());
                
                #endregion

                return bytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static byte[] StreamToByteArray(Stream inputStream)
        {
            byte[] bytes = new byte[16384]; 
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int count;
                while ((count = inputStream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    memoryStream.Write(bytes, 0, count);
                }
                return memoryStream.ToArray();
            }
        }
    }
}