using System;

namespace beehive_2._0
{
    class Worker:Bee
    {
        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        private string currentJob;
        private const double honeyUnitsPerShiftWorked = .65;

        public string CurrentJob
        {
            get { return currentJob; }
        }
        public int ShiftsLeft
        {
            get { return shiftsToWork - shiftsWorked; }
        }

        public Worker(double weightMg, string[] jobs):base(weightMg)
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

        public override double HoneyConsumptionRate()
        {
            double consumption = base.HoneyConsumptionRate();
            consumption += shiftsWorked * honeyUnitsPerShiftWorked;
            return consumption;
        }
    }
}
