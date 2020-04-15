using System.Collections.Generic;
using Tar1.Models.DAL;

namespace Tar1.Models
{
    public class OrganizeUnit
    {
        int id;
        string unitname;
        int numofresidents;
        int numofguides;
        string city;
        string street_hnumber;
        string unittype;
        int ApartmentType;

        public string Unitname { get => unitname; set => unitname = value; }
        public int Numofresidents { get => numofresidents; set => numofresidents = value; }
        public int Numofguides { get => numofguides; set => numofguides = value; }
        public string City { get => city; set => city = value; }
        public string Street_hnumber { get => street_hnumber; set => street_hnumber = value; }
        public string Unittype { get => unittype; set => unittype = value; }
        public int ApartmentType1 { get => ApartmentType; set => ApartmentType = value; }
        public int Id { get => id; set => id = value; }

        public OrganizeUnit() { }
        public OrganizeUnit(int id,string _unitname, int _numofresidents, int _numofguides, string _city, string _street, string _unittype, int _at)
        {
            Id = id;
            Unitname = _unitname;
            Numofresidents = _numofresidents;
            Numofguides = _numofguides;
            City = _city;
            Street_hnumber = _street;
            Unittype = _unittype;
            ApartmentType1 = _at;
        }
        public void PostUnit()
        {
            DBservices dbs = new DBservices();
            dbs.PostUnit(this);
        }
        
        public List<OrganizeUnit> GetOrganizeUnit()
        {
            DBservices dbs = new DBservices();
             return dbs.GetUnit();
        }


    }
}