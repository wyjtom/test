using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.model
{
    public class MESXPT_ModuleMiscInfo
    {
        private int Id;
        private string CusMac;
        private string MesId;
        private string EspMac;
        private string Btmac;
        private string ModuleVer;
        private string TestResult;
        private int Status;
        private string LabelContent;
        private string ModuleType;
        private DateTime Time;

        public int Id1 { get => Id; set => Id = value; }
        public string CusMac1 { get => CusMac; set => CusMac = value; }
        public string MesId1 { get => MesId; set => MesId = value; }
        public string EspMac1 { get => EspMac; set => EspMac = value; }
        public string Btmac1 { get => Btmac; set => Btmac = value; }
        public string ModuleVer1 { get => ModuleVer; set => ModuleVer = value; }
        public string TestResult1 { get => TestResult; set => TestResult = value; }
        public int Status1 { get => Status; set => Status = value; }
        public string LabelContent1 { get => LabelContent; set => LabelContent = value; }
        public string ModuleType1 { get => ModuleType; set => ModuleType = value; }
        public DateTime Time1 { get => Time; set => Time = value; }
    }
}