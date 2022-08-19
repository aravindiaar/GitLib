using GitLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLib
{
   public class InvokeGit
    {
        public int Score(string workspace)
        {
            var Authors = Utility.BashProcess.GET_AUTHOR(workspace, AllCmds.ALL_AUTHOR_ONLY_EMAIL);
            int tnt = 0;
            int score = 0;
            foreach (var item in Authors)
            {
                var Author_Date_Commits = Utility.BashProcess.GET_AUTHOR_LOG(workspace, AllCmds.AUTHOR_LOG, item);
                if (Author_Date_Commits.Count > 1)
                {
                    tnt++;
                    var sc = CalculateScore.Cal(Author_Date_Commits);
                    score = score + sc;
                }
            }
            int SCORE_OUT = (int)Math.Round((double)(score) / tnt);
            return Convert.ToInt32(SCORE_OUT * .1);
        }
    }
}
