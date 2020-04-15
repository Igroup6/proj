using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tar1.Models.DAL;

namespace Tar1.Models
{
    public class Shift
    {
        string type;
        DateTime start;
        DateTime end;
        int uid;
        DateTime startperiod;
        DateTime endperiod;
        DateTime shiftdate;
        int GuideNum;

        public string Type { get => type; set => type = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public int Uid { get => uid; set => uid = value; }
        public DateTime Startperiod { get => startperiod; set => startperiod = value; }
        public DateTime Endperiod { get => endperiod; set => endperiod = value; }
        public DateTime Shiftdate { get => shiftdate; set => shiftdate = value; }
        public int GuideNum1 { get => GuideNum; set => GuideNum = value; }

        public Shift() { }
        public Shift(string _type, DateTime _str, DateTime _end, int unit, DateTime strP, DateTime endP, DateTime shiftD, int G)
        {
            Type = _type;
            Start = _str;
            End = _end;
            Uid = unit;
            Startperiod = strP;
            Endperiod = endP;
            Shiftdate = shiftD;
            GuideNum1 = G;
        }

        public void PostShifts(List<Shift> ShiftArr) {
            DBservices dbs = new DBservices();
            dbs.InsertShiftList(ShiftArr);
        }

        public List<Shift> GetShifts(int id){
            DBservices dbs = new DBservices();

       return dbs.GetShiftList(id);


        }

    }
}