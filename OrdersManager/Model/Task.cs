using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdersManager.Model
{
    public class Task
    {
        public int Id
        { get; set; }

        public int ProjectId
        { get; set; }

        public int ExecutorId
        { get; set; }

        public string Name
        { get; set; }

        public string TaskStatus
        { get; set; }

        public DateTime StartDate
        { get; set; }

        public DateTime EstimateDate
        { get; set; }
    }
}
