using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tar1.Models.DAL;

namespace Tar1.Models
{
    public class ApartmentType
    {
        int id;
        string apartmenttype;

        public string Apartmenttype { get => apartmenttype; set => apartmenttype = value; }
        public int Id { get => id; set => id = value; }

        public ApartmentType() { }
         public ApartmentType(int _id,string _apartmenttype)
        {
            Id = _id;
            Apartmenttype = _apartmenttype;

        }
        public List<ApartmentType> get()
        {
            DBservices dbs = new DBservices();
            return dbs.GetApartmentType();

        }

    }
}