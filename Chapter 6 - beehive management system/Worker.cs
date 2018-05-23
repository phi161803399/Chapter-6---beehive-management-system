using System;
using System.Diagnostics;

namespace Chapter_6___beehive_management_system
{
    class Worker
    {
        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        private string currentJob;

        public string CurrentJob
        {
            get { return currentJob; }
        }
        public int ShiftsLeft
        {
            get { return shiftsToWork - shiftsWorked; }
        }

        public Worker(string[] jobs)
        {
            jobsICanDo = jobs;
            shiftsToWork = 0;
            currentJob = "";
        }

        public bool DoThisJob(string todo, int shifts)
        {
            if (!String.IsNullOrEmpty(currentJob))
                return false;
            foreach (string job in jobsICanDo)
            {
                if (job == todo)
                {
                    currentJob = todo;
                    this.shiftsToWork = shifts;
                    shiftsWorked = 0;
                    return true;
                }
            }
            return false;
        }

        public bool DidYouFinish()
        {
            if (String.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                currentJob = "";
                shiftsWorked = 0;
                shiftsToWork = 0;
                return true;
            }
            return false;
        }
    }
}
