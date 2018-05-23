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
            shiftsWorked = 0;
            shiftsToWork = 0;
        }

        public bool DoThisJob(string todo, int shifts)
        {
            if (shiftsToWork != 0)
                return false;
            foreach (string job in jobsICanDo)
            {
                if (job == todo)
                    currentJob = todo;
                    return true;
            }
            return false;
        }

        public bool DidYouFinish()
        {
            
        }
    }
}
