using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveBusinessEdi.DataHelpers
{
    public class OohDataExports
    {
        public int ID { get; set; }
        public int GROUP_ID { get; set; }
        public string FILE_ID { get; set; }
        public string USERNAME { get; set; }
        public string PUBLISH_DATE { get; set; }
        public string FILENAME { get; set; }
        public string CLIENT { get; set; }
        public string CAMPAIGN { get; set; }
        public string GROUP_NAME { get; set; }
        public string PERIODS { get; set; }
        public string DOWNLOADED_TIME { get; set; }
        public string DOWNLOADED_BY { get; set; }
        public string STATUS { get; set; }
        public string ETAG { get; set; }
        public string COMMENTS { get; set; }
        public string TYPE { get; set; }
    }

    public class AppSettings
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ProjectId { get; set; }
        public string ContainerName { get; set; }
        public string Region { get; set; }
        public string Interface { get; set; }
        public string CatalogName { get; set; }
        public string CatalogType { get; set; }
    }

    public class DataHandlers
    {
        static string ConnectionString;

        public DataHandlers()
        {
            //ConnectionString = "Server=sl-us-south-1-portal.16.dblayer.com;port=31837;database=aipandl_2010_livecopy;uid=admin;pwd=HEPTCZAEUHCQCVBZ;SslMode=Required;";
            ConnectionString = "Server=sl-us-south-1-portal.19.dblayer.com;port=34034;database=aipandl_2010;uid=admin;pwd=TNJKDNNLFAMYDLBL;SslMode=Required;";
        }

        public IList<OohDataExports> GetOohDataExports()
        {
            IList<OohDataExports> list = new List<OohDataExports>();
            string command = "select ID, GROUP_ID, USERNAME, PUBLISH_DATE, FILENAME, CLIENT," +
                                "CAMPAIGN, GROUP_NAME,PERIODS,DOWNLOADED_TIME,DOWNLOADED_BY, STATUS, ETAG," +
                                "COMMENTS, TYPE from CREATIVE_SUMMARY_PUBLISH_DETAILS where STATUS= 'PUBLISHED' OR STATUS = 'DOWNLOADED' order by ID, PUBLISH_DATE desc;";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                MySqlCommand sqlCmd = new MySqlCommand(command, connection);
                var dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    OohDataExports obj = new OohDataExports();
                    obj.ID = Convert.ToInt32(dr["ID"]);
                    obj.GROUP_ID = Convert.ToInt32(dr["GROUP_ID"]);
                    obj.USERNAME = dr["USERNAME"] == DBNull.Value ? string.Empty : (string)dr["USERNAME"];
                    obj.PUBLISH_DATE = Convert.ToString(dr["PUBLISH_DATE"]) == string.Empty ? string.Empty : Convert.ToDateTime(dr["PUBLISH_DATE"]).ToString("MM/dd/yyyy H:mm:ss");
                    obj.FILENAME = dr["FILENAME"] == DBNull.Value ? string.Empty : (string)dr["FILENAME"];
                    obj.CLIENT = dr["CLIENT"] == DBNull.Value ? string.Empty : (string)dr["CLIENT"];
                    obj.CAMPAIGN = dr["CAMPAIGN"] == DBNull.Value ? string.Empty : (string)dr["CAMPAIGN"];
                    obj.GROUP_NAME = dr["GROUP_NAME"] == DBNull.Value ? string.Empty : (string)dr["GROUP_NAME"];
                    obj.PERIODS = dr["PERIODS"] == DBNull.Value ? string.Empty : (string)dr["PERIODS"];
                    obj.DOWNLOADED_TIME = Convert.ToString(dr["DOWNLOADED_TIME"]) == string.Empty ? string.Empty : Convert.ToDateTime(dr["DOWNLOADED_TIME"]).ToString("MM/dd/yyyy H:mm:ss");
                    obj.DOWNLOADED_BY = dr["DOWNLOADED_BY"] == DBNull.Value ? string.Empty : (string)dr["DOWNLOADED_BY"];
                    obj.STATUS = dr["STATUS"] == DBNull.Value ? string.Empty : (string)dr["STATUS"];
                    obj.ETAG = dr["ETAG"] == DBNull.Value ? string.Empty : (string)dr["ETAG"];
                    obj.COMMENTS = dr["COMMENTS"] == DBNull.Value ? string.Empty : (string)dr["COMMENTS"];
                    obj.TYPE = dr["TYPE"] == DBNull.Value ? string.Empty : (string)dr["TYPE"];
                    list.Add(obj);
                }
            }

            return list;
        }
        public void UpdateDownloadDetails(string username, string filename)
        {
            filename = filename.Replace("'", "''");
            string sqlcommand = "UPDATE CREATIVE_SUMMARY_PUBLISH_DETAILS set DOWNLOADED_TIME=@date, DOWNLOADED_BY = '" + username + "', STATUS = 'DOWNLOADED' where FILENAME='" + filename + "';";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                MySqlCommand sqlCmd = new MySqlCommand(sqlcommand, connection);
                sqlCmd.Parameters.AddWithValue("@date", DateTime.Now);
                sqlCmd.ExecuteNonQuery();
            }

            sqlcommand = "INSERT INTO CREATIVE_DOWNLOAD_DETAILS(DOWNLOADED_ON,DOWNLOADED_BY,FILENAME) VALUES(@date, '" + username + "', '" + filename + "');";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                MySqlCommand sqlCmd = new MySqlCommand(sqlcommand, connection);
                sqlCmd.Parameters.AddWithValue("@date", DateTime.Now);
                sqlCmd.ExecuteNonQuery();
            }
        }

        public static void SelectData(string sqlcommand)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                MySqlCommand sqlCmd = new MySqlCommand(sqlcommand, connection);
                sqlCmd.Parameters.AddWithValue("@date", DateTime.Now);
                sqlCmd.ExecuteNonQuery();
            }
        }


        public AppSettings GetAppSettings()
        {
            string command = "select Id, Url, UserId, Password, ProjectId, ContainerName, Interface, CatalogName, CatalogType,"
                                + "Region from AppSettings order by TimeStamp desc limit 1;";
            AppSettings obj = new AppSettings();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                MySqlCommand sqlCmd = new MySqlCommand(command, connection);
                var dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.Url = dr["Url"] == DBNull.Value ? string.Empty : (string)dr["Url"];
                    obj.UserId = dr["UserId"] == DBNull.Value ? string.Empty : (string)dr["UserId"];
                    obj.Password = dr["Password"] == DBNull.Value ? string.Empty : (string)dr["Password"];
                    obj.ProjectId = dr["ProjectId"] == DBNull.Value ? string.Empty : (string)dr["ProjectId"];
                    obj.ContainerName = dr["ContainerName"] == DBNull.Value ? string.Empty : (string)dr["ContainerName"];
                    obj.Interface = dr["Interface"] == DBNull.Value ? string.Empty : (string)dr["Interface"];
                    obj.CatalogName = dr["CatalogName"] == DBNull.Value ? string.Empty : (string)dr["CatalogName"];
                    obj.CatalogType = dr["CatalogType"] == DBNull.Value ? string.Empty : (string)dr["CatalogType"];
                    obj.Region = dr["Region"] == DBNull.Value ? string.Empty : (string)dr["Region"];
                }
            }
            return obj;
        }
    }
}
