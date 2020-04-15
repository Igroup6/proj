using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tar1.Models
{
    public class OfficialShift
    {
        string userid;
        DateTime startshifthour;
        DateTime endshifthour;
        int unitid;
        string shifttype;
        DateTime shiftdate;

        public string Userid { get => userid; set => userid = value; }
        public DateTime Startshifthour { get => startshifthour; set => startshifthour = value; }
        public DateTime Endshifthour { get => endshifthour; set => endshifthour = value; }
        public int Unitid { get => unitid; set => unitid = value; }
        public string Shifttype { get => shifttype; set => shifttype = value; }
        public DateTime Shiftdate { get => shiftdate; set => shiftdate = value; }

        public OfficialShift() { }
        public OfficialShift(string user,DateTime start, DateTime end,int unit, string type, DateTime date)
        {
            Userid = user;
            Startshifthour = start;
            Endshifthour = end;
            Unitid = unit;
            Shifttype = type;
            Shiftdate = date;
        }

    
    
    }
}