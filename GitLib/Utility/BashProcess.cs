using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLib.Utility;

namespace GitLib.Utility
{
    class BashProcess
    {
        public static string[] GET_AUTHOR(string workspace, string command)
        {
            var OUT = start(workspace, command);
            return  OUT.Split(new string[] { "\r\n", "\r", "\n" },StringSplitOptions.None);
        }

        public static List<DateTime> GET_AUTHOR_LOG(string workspace, string command, string Author)
        {
            //"ethomson@edwardthomson.com"
            command = command.Replace("AUTHOR_NAME", Author) +AllCmds.DATE_FORMAT;
            var OUT = start(workspace, command);
            string[] Data= OUT.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            List<DateTime> ob = new List<DateTime>();

            foreach (var item in Data)
            {
                if (item.Contains("Date:"))
                {
                    try
                    {
                        string d = item.Replace("Date:", "").Trim();
                        DateTime dt = Convert.ToDateTime(d);
                        ob.Add(dt);
                    }
                    catch (Exception ex)
                    { }
                }
            }
            return ob;
        }

        

        public static string start(string workspace, string command)
        {

            ProcessStartInfo processStartInfo = new ProcessStartInfo(AllCmds.Bash, "-c \" " + command + " \"")
            {
                WorkingDirectory = workspace,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            var process = Process.Start(processStartInfo);
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            var exitCode = process.ExitCode;
            process.Close();
            return output;
        }
    }
}
