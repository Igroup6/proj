using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tar1.Models.DAL;

namespace Tar1.Models
{
    public class TrainingLevel
    {
        int id;
        string traininglevel;

        public string Traininglevel { get => traininglevel; set => traininglevel = value; }
        public int Id { get => id; set => id = value; }

        public TrainingLevel() { }
        public TrainingLevel(string _TrainingLevel)
        {
            Traininglevel = _TrainingLevel;
        }

        public void InsertTrainingLevel()
        {
            DBservices dbs = new DBservices();
              dbs.InsertTrainingLevel(this);
        }

        public List<TrainingLevel> GetTrainingLevel()
        {
            DBservices dbs = new DBservices();
            return dbs.GetTrainingLevel();
        }

        public void UpdateTL(int id)
        {
            DBservices dbs = new DBservices();
            if (this.Id == 0)
            {
                dbs.updateTLTable(this, id);
            }
            else
            {
                dbs.UpdateGuide(this, id);

            }

        }



    }
}