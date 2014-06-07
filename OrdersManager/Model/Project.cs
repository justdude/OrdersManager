using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdersManager.Model
{
    public class Project
    {

        public int Id 
        { get; set; }

        public int TeamLeadId
        { get; set; }

        public int CostumerId
        { get; set; }

        public float ProjectCost
        { get; set; }

        public string ProjectStatus
        { get; set; }

        public DateTime StartDate
        { get; set; }

        public  DateTime FinalDate
        { get; set; }
    }
}
