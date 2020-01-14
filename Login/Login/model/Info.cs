using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.model
{
    public class Error
     {
        private int ErrorData;
        private string Message;
        private InfoCusMac InfoCusMac = new InfoCusMac();
        public int c { get => ErrorData; set => ErrorData = value; }
        public string m { get => Message; set => Message = value; }
        public InfoCusMac d { get => InfoCusMac; set => InfoCusMac = value; }
    }

    public class InfoCusMac
    {
        private string CusMac1;
        public string CusMac { get => CusMac1; set => CusMac1 = value; }
    }

}