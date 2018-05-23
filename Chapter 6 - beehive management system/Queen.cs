using System;

namespace Chapter_6___beehive_management_system
{
    class Queen
    {
        private Worker[] workers;
        private int shiftNumber = 0;
        public Queen(Worker[] workers)
        {
            this.workers = workers;
        }

        public bool AssignWork(string job, int shifts)
        {
            foreach (Worker worker in workers)
            {
                if (worker.DoThisJob(job, shifts))
                    return true;
            }

            return false;
        }

        public string WorkTheNextShift()
        {
            shiftNumber++;
            foreach (Worker worker in workers)
                worker.DidYouFinish();
            string report = String.Empty;
            report += $"Report for shift #{shiftNumber}\n";
            for (int i = 0;i<workers.Length;i++)
                if (workers[i].ShiftsLeft == 1)
                    report += $"Worker #{i} will be done with '{workers[i].CurrentJob}' after this shift\n";
                else if (workers[i].ShiftsLeft == 0)
                {
                    report += $"Worker #{i} finished the job\n";
                }
                else
                {
                    report += $"Worker #{i} is doing" +
                              $" '{workers[i].CurrentJob}' for" +
                              $" {workers[i].ShiftsLeft} more shifts\n";
                }
            return report;
        }
    }
}
