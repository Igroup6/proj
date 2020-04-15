using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tar1.Models.DAL;

namespace Tar1.Models
{
    public class ApplyShift
    {
        string userid;
        int unitid;
        string shifttype;
        string comment;
        DateTime shiftdate;
        bool isaplly;
        string name;
        public string Userid { get => userid; set => userid = value; }
        public int Unitid { get => unitid; set => unitid = value; }
        public string Shifttype { get => shifttype; set => shifttype = value; }
        public string Comment { get => comment; set => comment = value; }
        public DateTime Shiftdate { get => shiftdate; set => shiftdate = value; }
        public bool Isaplly1 { get => isaplly; set => isaplly = value; }
        public string Name { get => name; set => name = value; }

        public ApplyShift() { }
        public ApplyShift(string user, int unit, string type, string comm, DateTime date, bool isapl, string _name)
        {
            Userid = user;
            Unitid = unit;
            Shifttype = type;
            Comment = comm;
            Shiftdate = date;
            Isaplly1 = isapl;
            Name = _name;
        }
        public void InsertApplyShift(List<ApplyShift> AS)
        {
            DBservices dbs = new DBservices();
            dbs.InsertApplyShift(AS);
        }

        public List<ApplyShift> GetApplyShift(int id)
        {
            DBservices dbs = new DBservices();
             return dbs.GetApplyShift(id);
        }

    }
}