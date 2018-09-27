#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor
{
    public static class DataGenerator
    {

        private static int cpuUnits = 0;

        private static int memoryUnits = 0;

        private static int downLoadRate = 0;

        private static int usedSpace = 0;



        public static int CPUUnits { get { return getCPUUnits(); } set { cpuUnits = value; } }

        public static int MemoryUnits { get { return getMemoryUnits(); } set { memoryUnits = value; } }

        public static int DownLoadRate { get { return getDownloadRate(); } set { downLoadRate = value; } }

        public static int UsedSpace { get { return getUsedSpace(); } set { usedSpace = value; } }

        private static int getCPUUnits()
        {
            var now = DateTime.Now.Second;

            if (now % 9 == 0)
                return 85 - now;
            else if (now % 3 == 0)
                return 20;
            else if (now % 5 == 0)
                return 17;
            else if (now % 4 == 0)
                return 12;
            else if (now % 2 == 0)
                return 17;
            else if (now % 7 == 0)
                return 19;

            return 15;
        }

        private static int getMemoryUnits()
        {
            var now = DateTime.Now.Second;

            Random r = new Random();

            if (now % 10 == 1)
                return r.Next (50,60);
            else if (now % 10 == 2)
                return r.Next(50, 60);
            else if (now % 10 == 3)
                return r.Next(50, 60);
            else if (now % 10 == 4)
                return r.Next(50, 60);
            else if (now % 10 == 5)
                return r.Next(50, 60);
            else if (now % 10 == 0)
                return r.Next(50, 60);

            return 59;
        }

        private static int getDownloadRate()
        {
            var now = DateTime.Now.Second;

            Random r = new Random();

            if (now % 9 == 0)
                return 15;
            else if (now % 8 == 0)
                return r.Next(10,20);
            else if (now % 7 == 0)
                return 8;
            else if (now % 5 == 0)
                return r.Next(20,56);
            else if (now % 3 == 0)
                return r.Next (10,60);
            else if (now % 2 == 0)
                return 10;
            else if (now % 1 == 0)
                return r.Next (25,60);

            return 34;
        }

        private static int getUsedSpace()
        {
            return 54;
        }

    }
}
