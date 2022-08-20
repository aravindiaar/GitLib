using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GitLib.Utility;

namespace GitLib
{
    class Program
    {
        public static void Main(string[] args)
        {
            string workspace = @"D:\HRMS-19\DSRC_HRMS";
            var Authors = Utility.BashProcess.GET_AUTHOR(workspace, AllCmds.ALL_AUTHOR_ONLY_EMAIL);

            int tnt = 0;
            int score = 0;
            foreach (var item in Authors)
            {
                bool isEmail = Regex.IsMatch(item, AllCmds.EMAIL_REGX, RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    continue;
                }
                var Author_Date_Commits = Utility.BashProcess.GET_AUTHOR_LOG(workspace, AllCmds.AUTHOR_LOG, item);
                if (Author_Date_Commits.Count > 1)
                {
                    tnt++;
                    var sc = CalculateScore.Cal(Author_Date_Commits);
                    score = score + sc;
                }
            }
            int SCORE_OUT = (int)Math.Round((double)(score) / tnt);
            int xx =Convert.ToInt32(SCORE_OUT * .1);
        }
    }
}
