using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.model
{
    public class MESXPT_CusMACResource
    {
        private int Id;
        private string StartMac;
        private string EndMac;
        private string CusCode;
        private enum MACType {WIFI,BT };
        private enum ActionType {New,Modification };
        private string Maker;
        private DateTime OperationTime;

        public int Id1 { get => Id; set => Id = value; }
        public string StartMac1 { get => StartMac; set => StartMac = value; }
        public string EndMac1 { get => EndMac; set => EndMac = value; }
        public string CusCode1 { get => CusCode; set => CusCode = value; }
        public string Maker1 { get => Maker; set => Maker = value; }
        public DateTime OperationTime1 { get => OperationTime; set => OperationTime = value; }
    }
}