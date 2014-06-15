using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdersManager.Model
{
    public class Project
    {

        public long Id 
        { get; set; }

        public long TeamLeadId
        { get; set; }

        public long CostumerId
        { get; set; }

        public float ProjectCost
        { get; set; }

        public string ProjectStatus
        { get; set; }

        public DateTime StartDate
        { get; set; }

        public  DateTime FinalDate
        { get; set; }

        public string ProjectName
        { get; set; }
    }
}
