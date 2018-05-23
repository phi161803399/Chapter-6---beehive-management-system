using System;

namespace beehive_2._0
{
    class Queen:Bee
    {
        private Worker[] workers;
        private int shiftNumber = 0;
        public Queen(double weightMg, Worker[] workers):base(weightMg)
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
            double honeyConsumption = 0;
            shiftNumber++;
            string report = String.Empty;
            report += $"Report for shift #{shiftNumber}\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                bool finished;
                finished = workers[i].DidYouFinish();
                if (finished)
                {
                    report += $"Worker #{i + 1} finished the job\r\n";
                }

                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                {
                    report += $"Worker #{i + 1} is not working\r\n";
                }
                else
                    if (workers[i].ShiftsLeft > 0)
                        report += $"Worker #{i + 1} is doing" +
                                  $" '{workers[i].CurrentJob}' for" +
                                  $" {workers[i].ShiftsLeft} more shifts\r\n";
                    else
                    {
                    report += $"Worker #{i + 1} will be done with" +
                              $" '{workers[i].CurrentJob}'" +
                              $" after this shift\r\n";
                }

                honeyConsumption += workers[i].HoneyConsumptionRate();
            }

            honeyConsumption += this.HoneyConsumptionRate();
            report += $"Total honey consumed for the shift: {honeyConsumption} units\r\n";
            return report;
        }
    }
}
