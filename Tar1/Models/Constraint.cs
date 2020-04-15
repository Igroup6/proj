using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tar1.Models.DAL;

namespace Tar1.Models
{
    public class Constraint
    {
        int constraintID;
        string constraintName;
        float constraintValue;
        public int ConstraintID { get => constraintID; set => constraintID = value; }
        public string ConstraintName { get => constraintName; set => constraintName = value; }
        public float ConstraintValue { get => constraintValue; set => constraintValue = value; }
        public Constraint() { }
        public Constraint(int _constraintID, string _constraintName, float _constraintValue)
        {
            ConstraintID = _constraintID;
            ConstraintName = _constraintName;
            ConstraintValue = _constraintValue;

        }
        public List<Constraint> getConstraint()
        {

            DBservices dbs = new DBservices();
            return dbs.getConstraintM();
        }
        public void upadteConstraint(Constraint c)
        {
            DBservices dbs = new DBservices();
            dbs.PutConstraint(c);
        }
    }
}
