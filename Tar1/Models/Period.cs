using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tar1.Models.DAL;

namespace Tar1.Models
{
    public class Period
    {
        DateTime startdate;
        DateTime enddate;
        int unitid;
        bool Preparedness;
        public DateTime Startdate { get => startdate; set => startdate = value; }
        public DateTime Enddate { get => enddate; set => enddate = value; }
        public int Unitid { get => unitid; set => unitid = value; }
        public bool Preparedness1 { get => Preparedness; set => Preparedness = value; }

        public Period() { }

        public Period(DateTime start, DateTime end, int id,bool prep)
        {
            Startdate = start;
            Enddate = end;
            Unitid = id;
            Preparedness1 = prep;
        }

        public void InsertPeriod()
        {
            DBservices dbs = new DBservices();
            dbs.InsertPeriod(this);

        }

        public bool GetPer(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.GetPer(id);
           
        }

    }
}