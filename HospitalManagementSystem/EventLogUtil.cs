using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem
{
    public class EventLogUtil
    {
        private static string folderPath = string.Empty;
        private static string fileName = string.Empty;
        private static int isLogEnable = 1;

        private static void LoadEventLogData()
        {

            System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();

            try
            {
                folderPath = (string)appSettingsReader.GetValue("ActionLogPath", typeof(string));
                fileName = (string)appSettingsReader.GetValue("ActionLogFile", typeof(string));

                string sTmp = DateTime.Today.ToString("dd-MM-yyyy");

                if (!string.IsNullOrEmpty(fileName))
                    folderPath = folderPath + "\\" + sTmp + " - " + fileName;
                else
                    folderPath = folderPath + "\\" + sTmp + ".txt";
            }
            catch (Exception e)
            {

                WriteToEventLog(e.Message);
            }
        }

        private static void WriteToEventLog(string message)
        {

            // Create the source, if it does not already exist. 
            if (!EventLog.SourceExists("HospitalMgtSys"))
            {
                EventLog.CreateEventSource("HospitalMgtSys", "HospitalMgtSysLog");
                return;
            }

            // Create an EventLog instance and assign its source.
            EventLog myLog = new EventLog();
            myLog.Source = "HospitalMgtSys";

            // Write an informational entry to the event log.    
            myLog.WriteEntry(message);

        }

        public static void Log(string sLog)
        {
            Log(sLog, false);
        }

        public static void Log(string sLog, bool lineBreak)
        {
            LoadEventLogData();

            if (isLogEnable == 1 && !string.Empty.Equals(folderPath))
            {
                StreamWriter m_streamWriter = null;
                FileStream fs = null;
                try
                {
                    fs = new FileStream(folderPath, FileMode.OpenOrCreate, FileAccess.Write);
                    m_streamWriter = new StreamWriter(fs);

                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    m_streamWriter.WriteLine(DateTime.Now.ToString("G") + " - " + sLog + "\n");

                    if (lineBreak)
                    {
                        m_streamWriter.WriteLine("\n");
                    }

                }
                catch (Exception e)
                {

                    WriteToEventLog(e.Message);
                }

                finally
                {

                    if (m_streamWriter != null)
                    {
                        m_streamWriter.Flush();
                        m_streamWriter.Close();
                    }

                    if (fs != null)
                    {

                        fs.Close();
                    }

                }
            }
        }
    }
}