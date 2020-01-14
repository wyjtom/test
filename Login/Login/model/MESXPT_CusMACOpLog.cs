using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.model
{
    public class MESXPT_CusMACOpLog
    {
        private int Id;
        private string UsedStartMac;
        private string UsedEndMac;
        private string TestStatus;
        private string Operator;
        private enum ActionType {Aplied,Complete }
        private DateTime OperationTime;

        public int Id1 { get => Id; set => Id = value; }
        public string UsedStartMac1 { get => UsedStartMac; set => UsedStartMac = value; }
        public string UsedEndMac1 { get => UsedEndMac; set => UsedEndMac = value; }
        public string TestStatus1 { get => TestStatus; set => TestStatus = value; }
        public string Operator1 { get => Operator; set => Operator = value; }
        public DateTime OperationTime1 { get => OperationTime; set => OperationTime = value; }
    }
}