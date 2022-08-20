using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLib.Utility
{
    class AllCmds
    {
        public static string ALL_COMMITS_AUTHOR = "git shortlog -s -n --all --no-merges";
        public static string AUTHOR_LOG = "git log --author='AUTHOR_NAME' --since 'JAN  1 2022'";
        public static string ALL_AUTHOR_ONLY_EMAIL = "git log --pretty='%ae' | sort | uniq";
        public static string ALL_AUTHOR = "git log --pretty='%an %ae%n%cn %ce' | sort | uniq";
        public static string DATE_FORMAT = " --date=format:'%Y-%m-%d %H:%M:%S'";
        public static int TIME_INTERVAL = 10;
        public static string Bash = @"C:\Program Files\Git\bin\bash.exe";
        public static string EMAIL_REGX = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

    }
}
