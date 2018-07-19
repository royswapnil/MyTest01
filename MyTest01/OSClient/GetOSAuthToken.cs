using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace ActiveObjectStore.GetOSAuthToken
{
    public class GetAuthToken
    {
        private static ManualResetEvent allDone = new ManualResetEvent(false);
        public static string jrequeststring = "";
        public static string responseString = "";
        public static string headerToken = "";
        public AuthTokenResponse GetAuthTokenDetails(string url, string usedid, string password, string projectid, string interfac, string region, string catName, string catType)
        {
            try
            {
                #region Variables
                AuthTokenResponse objauthtokenresponse = new AuthTokenResponse();
                AuthResponseBody.RootObject objauthresponsebody = new AuthResponseBody.RootObject();
                AuthResponseHeader.RootObject objauthresponseheader = new AuthResponseHeader.RootObject();
                RootObject objrootreq = new RootObject();
                Auth objauthreq = new Auth();
                Identity objidentityreq = new Identity();
                Scope objscopereq = new Scope();
                Project objprojectreq = new Project();
                Password objpasswordreq = new Password();
                User objuserreq = new User();
                #endregion

                #region RequestObjectCreation
                objuserreq.id = usedid;

                objuserreq.password = password;

                objpasswordreq.user = objuserreq;

                objidentityreq.password = objpasswordreq;

                List<string> lstmethods = new List<string>();
                lstmethods.Add("password");

                objidentityreq.methods = lstmethods;

                objprojectreq.id = projectid;

                objscopereq.project = objprojectreq;

                objauthreq.scope = objscopereq;

                objauthreq.identity = objidentityreq;

                objrootreq.auth = objauthreq;

                #endregion

                #region ReSTCall

                jrequeststring = JsonConvert.SerializeObject(objrootreq);

                string requestUrl = url;
                HttpWebRequest authrequest = WebRequest.Create(requestUrl) as HttpWebRequest;

                authrequest.Method = "POST";
                authrequest.ContentType = "application/json";

                Byte[] btauthrequest = Encoding.UTF8.GetBytes(jrequeststring);
                authrequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), authrequest);
                allDone.WaitOne();
                objauthresponsebody = JsonConvert.DeserializeObject<AuthResponseBody.RootObject>(responseString);
                objauthresponseheader.x_subject_token = headerToken;

                #endregion

                #region BuildAuthResponse

                ResponseHeader objresponseheader = new ResponseHeader();
                ResponseBody objresponsebody = new ResponseBody();

                objresponseheader.x_Auth_Token = objauthresponseheader.x_subject_token;

                if (objauthresponsebody != null)
                {
                    if (objauthresponsebody.token != null)
                    {
                        if (objauthresponsebody.token.catalog != null)
                        {
                            foreach (AuthResponseBody.Catalog cat in objauthresponsebody.token.catalog)
                            {
                                if (cat.name == catName && cat.type == catType)
                                {
                                    if (cat.endpoints != null)
                                    {
                                        foreach (AuthResponseBody.Endpoint endp in cat.endpoints)
                                        {
                                            if (endp.region == region.Trim() && endp.@interface == interfac.Trim())
                                            {
                                                objresponsebody.auth_Url = endp.url;
                                                objresponsebody.region = endp.region;
                                                objresponsebody.service_Instance_Id = endp.id;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                objauthtokenresponse.response_Header = objresponseheader;
                objauthtokenresponse.response_Body = objresponsebody;

                #endregion

                return objauthtokenresponse;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);

            // Convert the string into a byte array.
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jrequeststring);

            // Write to the request stream.
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Dispose();

            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }

        public static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            responseString = streamRead.ReadToEnd();
            
            headerToken = response.Headers["X-Subject-Token"];
            // Close the stream object
            streamResponse.Dispose();
            streamRead.Dispose();

            // Release the HttpWebResponse
            response.Dispose();
            allDone.Set();
        }

    }
       
    public class AuthTokenResponse
    {
        public ResponseHeader response_Header;
        public ResponseBody response_Body;
    }

    public class ResponseHeader
    {
        public string x_Auth_Token;
    }

    public class ResponseBody
    {
        public string region;
        public string auth_Url;
        public string service_Instance_Id;
    }

    public class User
    {
        public string id { get; set; }
        public string password { get; set; }
    }

    public class Password
    {
        public User user { get; set; }
    }

    public class Identity
    {
        public List<string> methods { get; set; }
        public Password password { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
    }

    public class Scope
    {
        public Project project { get; set; }
    }

    public class Auth
    {
        public Identity identity { get; set; }
        public Scope scope { get; set; }
    }

    public class RootObject
    {
        public Auth auth { get; set; }
    }

   
}