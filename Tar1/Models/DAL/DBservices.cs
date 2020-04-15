using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tar1.Models;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;

namespace Tar1.Models.DAL
{
    public class DBservices
    {
        public SqlConnection connect(String conString)
        {

            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 20;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
        public List<ApartmentType> GetApartmentType()
        {

            List<ApartmentType> A = new List<ApartmentType>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "SELECT * FROM ApartmentType_2020";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    ApartmentType ApartmentType = new ApartmentType();
                    ApartmentType.Apartmenttype = (string)dr["ApartmentType"];
                    ApartmentType.Id = Convert.ToInt32(dr["ApartmentTypeId"]);
                    A.Add(ApartmentType);
                }

                return A;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        public void PostUnit(OrganizeUnit unit)
        {
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            String cStr = BuildInsertCommand(unit);
            cmd = CreateCommand(cStr, con);
            try
            {
                int numEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            if (unit.Unittype == "דירה")
            {
                GetApartmentId(unit);
            }
        }
        private String BuildInsertCommand(OrganizeUnit unit)
        {
            String command;
            StringBuilder sb = new StringBuilder();

            string G = unit.Numofguides.ToString();
            string R = unit.Numofresidents.ToString();
            sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}','{4}','{5}')", unit.Unitname, unit.Numofresidents, unit.Numofguides, unit.City, unit.Street_hnumber, unit.Unittype);
            String prefix = "INSERT INTO OrganizeUnit_2020" + "(UnitName,NumOfResidents,NumOfGuides,City,Street_HNumber,UnitType)";
            command = prefix + sb.ToString();
            return command;
        }
        private void GetApartmentId(OrganizeUnit unit)
        {
            int id = 0;
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select * from Apartment_2020 where ApartmentTypeId is null";
                SqlCommand cmd1 = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd1.ExecuteReader(CommandBehavior.CloseConnection);
                dr.Read();
                id = Convert.ToInt32(dr["UnitId"]);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            UpdateApartmentType(unit.ApartmentType1, id);
        }
        private void UpdateApartmentType(int ApartmentType, int id)
        {
            SqlConnection con;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            String cStr = "UPDATE Apartment_2020 SET ApartmentTypeId = " + ApartmentType.ToString() + " WHERE UnitId = " + id.ToString();
            SqlCommand cmd = CreateCommand(cStr, con);
            try
            {
                int numEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        public List<OrganizeUnit> GetUnit()
        {

            List<OrganizeUnit> OU = new List<OrganizeUnit>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "SELECT * FROM OrganizeUnit_2020";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    OrganizeUnit Unit = new OrganizeUnit();
                    Unit.Id = Convert.ToInt32(dr["UnitId"]);
                    Unit.Unitname = (string)dr["UnitName"];
                    OU.Add(Unit);
                }
                return OU;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }


        }
        public void InsertTrainingLevel(TrainingLevel tl)
        {
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            String cStr = BuildInsertCommand(tl);
            cmd = CreateCommand(cStr, con);
            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private String BuildInsertCommand(TrainingLevel tl)
        {
            String command;

            String prefix = "INSERT INTO TrainingLevel_2020 (TrainingLevel)";
            String str = "Values('" + tl.Traininglevel + "')";
            command = prefix + str;
            return command;
        }
        public List<TrainingLevel> GetTrainingLevel()
        {

            List<TrainingLevel> TL = new List<TrainingLevel>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "SELECT * FROM TrainingLevel_2020";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    TrainingLevel trininglevel = new TrainingLevel();
                    trininglevel.Traininglevel = (string)dr["TrainingLevel"];
                    trininglevel.Id = Convert.ToInt32(dr["TrainingLevelId"]);
                    TL.Add(trininglevel);
                }
                return TL;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }





        }
        public void UpdateGuide(TrainingLevel tl, int id)
        {
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            String cStr = BuildInsertCommand(tl, id);
            cmd = CreateCommand(cStr, con);
            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private String BuildInsertCommand(TrainingLevel tl, int id)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            string p = id.ToString();
            string trl = tl.Id.ToString();


            command = "UPDATE Guide_2020 SET TrainingLevelId =" + trl + " WHERE UserId =" + p;


            return command;
        }
        public void InsertUser(User user)
        {
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            String cStr = BuildInsertCommand(user);
            cmd = CreateCommand(cStr, con);
            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

                if (con != null)
                {
                    con.Close();
                }
            }

        }
        private String BuildInsertCommand(User user)
        {
            String command;
            string Uid;
            StringBuilder sb = new StringBuilder();
            int day = user.Birthdate.Day;
            int month = user.Birthdate.Month;
            int year = user.Birthdate.Year;
            //DateTime d = new DateTime(year,month,day);

            string bdate = month.ToString() + "/" + day.ToString() + "/" + year.ToString();
            //Insert big manager
            if (user.Unitid == 0)
            {
                string um = user.Unitmanager.ToString();
                string bm = user.Bigmanager.ToString();
                String prefix = "INSERT INTO User_2020 (UserId,UPassword,FirstName,LastName,Birthdate,Telephone,UserRole,IsUnitManager,BigManager)";
                sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", user.Userid, user.Password, user.Firstname, user.Lastname, bdate, user.Telephone, user.Role, um, bm);
                command = prefix + sb;
                return command;
            }
            //Insert Guide
            else if (user.Role == "מדריך")
            {
                Uid = user.Unitid.ToString();
                String prefix = "INSERT INTO User_2020 (UserId,UPassword,FirstName,LastName,Birthdate,Telephone,UserRole,UnitId)";
                sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", user.Userid, user.Password, user.Firstname, user.Lastname, bdate, user.Telephone, user.Role, Uid);
                command = prefix + sb;
                return command;

            }
            //Insert unit manager
            else
            {
                string um = user.Unitmanager.ToString();
                string bm = user.Bigmanager.ToString();
                Uid = user.Unitid.ToString();
                String prefix = "INSERT INTO User_2020 (UserId,UPassword,FirstName,LastName,Birthdate,Telephone,UserRole,IsUnitManager,BigManager,UnitId)";
                sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", user.Userid, user.Password, user.Firstname, user.Lastname, bdate, user.Telephone, user.Role, um, bm, Uid);
                command = prefix + sb;
                return command;
            }
        }
        public List<User> GetUser()
        {
            List<User> U = new List<User>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "SELECT * FROM User_2020";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    User us = new User();
                    us.Firstname = (string)dr["FirstName"];
                    us.Lastname = (string)dr["LastName"];
                    us.Password = (string)dr["UPassword"];
                    us.Userid = (string)dr["UserId"];
                    us.Role = (string)dr["UserRole"];
                    if (us.Role == "מנהל מערך הדיור")
                    {
                        us.Unitid = 0;
                    }
                    else
                    {
                        us.Unitid = Convert.ToInt32(dr["UnitId"]);
                    }
                    U.Add(us);
                }
                return U;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public void updateTLTable(TrainingLevel tl, int id)
        {
            {
                SqlConnection con;
                SqlCommand cmd;
                try
                {
                    con = connect("DBConnectionString"); // create the connection
                }
                catch (Exception ex)
                {
                    throw (ex);

                }
                String cStr = BuildInsertCommand1(tl, id);
                cmd = CreateCommand(cStr, con);
                try
                {
                    int numEffected = cmd.ExecuteNonQuery(); // execute the command
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
        }
        private String BuildInsertCommand1(TrainingLevel tl, int id)
        {
            string p = id.ToString();
            return "UPDATE TrainingLevel_2020 SET TrainingLevel ='" + tl.Traininglevel + "' WHERE TrainingLevelId =" + p;
        }
        public bool GetPer(int id)
        {
            SqlConnection con = null;
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            bool preprdness = false;
            try
            {
                con = connect("DBConnectionString");
                String checkSTR = "select preparedness from SchedulingPeriod_2020 where StartPeriod >'" + today + "' and UnitId=" + id;
                SqlCommand cmd1 = new SqlCommand(checkSTR, con);
                SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);
                preprdness = dr1.Read();
                return preprdness;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }


        }
        public List<User> GetUnitUser(int id)
        {
            List<User> U = new List<User>();
            SqlConnection con = null;
            bool preprdness = GetPer(id);
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select * from User_2020 where UnitId = " + id + " and UserRole = 'מדריך'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    User us = new User();
                    us.Firstname = (string)dr["FirstName"];
                    us.Lastname = (string)dr["LastName"];
                    us.Userid = (string)dr["UserId"];
                    User us1 = GuideInfo(us.Userid, preprdness);
                    us.MonthlyHours = us1.MonthlyHours;
                    us.MonthlyExtraHours = us1.MonthlyExtraHours;
                    User us2 = CountShift(us.Userid);
                    us.NumOfPref = us2.NumOfPref;

                    U.Add(us);
                }
                return U;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public User GuideInfo(string Userid, bool preprdness)
        {
            User Os = new User();
            double extra = 0;
            double normal = 0;
            SqlConnection con = null;
            List< Constraint> ConstList = getConstraintM();
            float RegularShift = ConstList[6].ConstraintValue;
            float SpeNightShift = ConstList[7].ConstraintValue;
            try
            {
                string sMonth = DateTime.Now.ToString("MM");
                string year = DateTime.Today.Year.ToString();

                con = connect("DBConnectionString");

                String selectSTR = "select * from OfficialShift_2020 where UserId = " + Userid + " and ShiftDate > '" + year + "-" + sMonth + "-" + "01'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    OfficialShift OffiS = new OfficialShift();
                    OffiS.Shifttype = (string)dr["ShiftType"];
                    TimeSpan myTimeSpan = ((dr).GetTimeSpan(dr.GetOrdinal("StartShift")));
                    OffiS.Startshifthour = new DateTime(myTimeSpan.Ticks);
                    myTimeSpan = ((dr).GetTimeSpan(dr.GetOrdinal("EndShift")));
                    OffiS.Endshifthour = new DateTime(myTimeSpan.Ticks);
                    TimeSpan interval = OffiS.Endshifthour - OffiS.Startshifthour;
                    double x = interval.TotalHours;
                    if (preprdness == true && OffiS.Shifttype == "לילה")
                    {
                        double x1 = 0.0;
                        if (x < 0)
                        {
                            x1 = x + 24.0;
                        }
                        else if (x > 0)
                        {
                            x1 = x;
                        }
                        if (x1 > SpeNightShift)
                        {
                            normal += SpeNightShift;
                            extra += x1 - SpeNightShift;
                        }
                        else
                        {
                            normal += x1;
                            extra += 0.0;
                        }
                    }
                    else
                    {
                        if (x > RegularShift)
                        {
                            normal += RegularShift;
                            extra += x - RegularShift;
                        }
                        else
                        {
                            normal += x;
                            extra += 0.0;
                        }
                    }
                    Os.MonthlyHours = normal;
                    Os.MonthlyExtraHours = extra;
                }
                return Os;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public User CountShift(string Userid)
        {
            User CS = new User();
            SqlConnection con = null;
            try
            {
                string today = DateTime.Today.ToString("yyyy-MM-dd");
                con = connect("DBConnectionString");
                String selectSTR = "SELECT COUNT(isApply)";
                selectSTR += " FROM BlockShift_2020 left join Shift_2020 on BlockShift_2020.ShiftDate = Shift_2020.ShiftDate and BlockShift_2020.ShiftType = Shift_2020.ShiftType";
                selectSTR += " WHERE Shift_2020.StartPeriod > '" + today + "' and BlockShift_2020.UserId = '" + Userid + "' and BlockShift_2020.isApply = '1'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    CS.NumOfPref = Convert.ToInt32(dr[""]);
                }
                return CS;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void InsertPeriod(Period period)
        {
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            String cStr = BuildInsertCommand(period);
            cmd = CreateCommand(cStr, con);
            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

                if (con != null)
                {
                    con.Close();
                }
            }




        }
        private String BuildInsertCommand(Period period)
        {
            String command;
            string Uid;
            StringBuilder sb = new StringBuilder();
            int day = period.Startdate.Day;
            int month = period.Startdate.Month;
            int year = period.Startdate.Year;
            string startsD = month.ToString() + "/" + day.ToString() + "/" + year.ToString();
            int Eday = period.Enddate.Day;
            int Emonth = period.Enddate.Month;
            int Eyear = period.Enddate.Year;
            string EndD = Emonth.ToString() + "/" + Eday.ToString() + "/" + Eyear.ToString();
            Uid = period.Unitid.ToString();
            string s = startsD.ToString();
            string e = EndD.ToString();
            string p = period.Preparedness1.ToString();
            String prefix = "INSERT INTO SchedulingPeriod_2020 (StartPeriod,EndPeriod,UnitId,preparedness)";
            sb.AppendFormat("Values('{0}', '{1}','{2}','{3}')", s, e, Uid, p);
            command = prefix + sb;
            return command;

        }
        public void InsertShiftList(List<Shift> shiftArr)
        {
            SqlConnection con = null;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString");
                foreach (var item in shiftArr)
                {
                    String cStr = BuildInsertCommand(item);
                    cmd = CreateCommand(cStr, con);
                    try
                    {
                        cmd.ExecuteNonQuery(); // execute the command
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        private String BuildInsertCommand(Shift shift)
        {
            string Shiftdate;
            String command;
            StringBuilder sb = new StringBuilder();
            int day = shift.Startperiod.Day;
            int month = shift.Startperiod.Month;
            int year = shift.Startperiod.Year;
            //convert start date of period to string
            string startsPD = month.ToString() + "/" + day.ToString() + "/" + year.ToString();
            int Eday = shift.Endperiod.Day;
            int Emonth = shift.Endperiod.Month;
            int Eyear = shift.Endperiod.Year;
            //convert end date of period to string
            string EndPD = Emonth.ToString() + "/" + Eday.ToString() + "/" + Eyear.ToString();
            //convert start hour of shift to string
            string s = shift.Start.ToString();
            string[] DateTime = s.Split(' ');
            string strH = DateTime[1];
            //convert end hour of shift to string
            string e = shift.End.ToString();
            string[] DateTime1 = e.Split(' ');
            string endH = DateTime1[1];
            //convert unit id to string
            string uid = shift.Uid.ToString();
            day = shift.Shiftdate.Day;
            month = shift.Shiftdate.Month;
            year = shift.Shiftdate.Year;
            //convert date of shift to string
            Shiftdate = month.ToString() + "/" + day.ToString() + "/" + year.ToString();
            //convert number of guides on shift to string
            string num = shift.GuideNum1.ToString();
            sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", shift.Type, strH, endH, uid, startsPD, EndPD, Shiftdate, num);
            String prefix = "INSERT INTO Shift_2020 " + "(ShiftType,StartShift,EndShift,UnitId,StartPeriod,EndPeriod,ShiftDate,NumOfGuides)";
            command = prefix + sb.ToString();
            return command;
        }
        public List<Shift> GetShiftList(int id)
        {
            List<Shift> S = new List<Shift>();
            SqlConnection con = null;
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string unitId = id.ToString();
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "select * from Shift_2020 where UnitId = " + unitId + " AND StartPeriod > '" + today + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Shift shist = new Shift();
                    shist.Startperiod = Convert.ToDateTime(dr["StartPeriod"]).Date;
                    shist.Endperiod = Convert.ToDateTime(dr["EndPeriod"]).Date;
                    shist.Shiftdate = Convert.ToDateTime(dr["ShiftDate"]).Date;
                    shist.Type = Convert.ToString(dr["ShiftType"]);
                    shist.GuideNum1 = Convert.ToInt32(dr["NumOfGuides"]);
                    TimeSpan myTimeSpan = ((dr).GetTimeSpan(dr.GetOrdinal("StartShift")));
                    shist.Start = new DateTime(myTimeSpan.Ticks);
                    myTimeSpan = ((dr).GetTimeSpan(dr.GetOrdinal("EndShift")));
                    //shist.Start = TimeSpan(dr["StartShift"]);
                    shist.End = new DateTime(myTimeSpan.Ticks);
                    S.Add(shist);
                }
                return S;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }



        }
        public void InsertApplyShift(List<ApplyShift> AS)
        {
            SqlConnection con = null;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString");
                foreach (var item in AS)
                {
                    String cStr = BuildInsertCommand(item);
                    cmd = CreateCommand(cStr, con);
                    try
                    {
                        cmd.ExecuteNonQuery(); // execute the command
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        private String BuildInsertCommand(ApplyShift AppS)
        {

            String command;
            StringBuilder sb = new StringBuilder();
            int day = AppS.Shiftdate.Day;
            int month = AppS.Shiftdate.Month;
            int year = AppS.Shiftdate.Year;
            string shiftdate = month.ToString() + "/" + day.ToString() + "/" + year.ToString();
            string Unitid = AppS.Unitid.ToString();
            string isApply = AppS.Isaplly1.ToString();
            sb.AppendFormat("Values('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", AppS.Userid, AppS.Comment, Unitid, AppS.Shifttype, shiftdate, isApply);
            String prefix = "INSERT INTO BlockShift_2020 " + "(UserId,Comments,UnitId,ShiftType,ShiftDate,isApply)";
            command = prefix + sb.ToString();
            return command;
        }
        public List<ApplyShift> GetApplyShift(int id)
        {

            List<ApplyShift> AS = new List<ApplyShift>();
            SqlConnection con = null;
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string unitId = id.ToString();
            try
            {
                con = connect("DBConnectionString");


                String selectSTR = "select BlockShift_2020.ShiftType,BlockShift_2020.UserId, BlockShift_2020.ShiftDate, BlockShift_2020.UserId,BlockShift_2020.isApply, BlockShift_2020.Comments,  User_2020.FirstName,  User_2020.LastName";
                selectSTR += " from BlockShift_2020 left join Shift_2020 on BlockShift_2020.ShiftDate = Shift_2020.ShiftDate and BlockShift_2020.ShiftType = Shift_2020.ShiftType left join User_2020 on BlockShift_2020.UserId = User_2020.UserId";
                selectSTR += " where BlockShift_2020.UnitId = " + id + " AND Shift_2020.StartPeriod >'" + today + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    ApplyShift Applyshift = new ApplyShift();
                    Applyshift.Userid = Convert.ToString(dr["UserId"]);
                    Applyshift.Name = Convert.ToString(dr["FirstName"]) + " " + Convert.ToString(dr["LastName"]);
                    Applyshift.Shiftdate = Convert.ToDateTime(dr["ShiftDate"]).Date;
                    Applyshift.Shifttype = Convert.ToString(dr["ShiftType"]);
                    Applyshift.Isaplly1 = Convert.ToBoolean(dr["isApply"]);
                    Applyshift.Comment = Convert.ToString(dr["Comments"]);
                    AS.Add(Applyshift);
                }
                return AS;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }




        }
        public List<Constraint> getConstraintM()
        {
            List<Constraint> C = new List<Constraint>();
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");
                String selectSTR = "SELECT * FROM ConstraintManagement_2020";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Constraint co = new Constraint();
                    co.ConstraintID = Convert.ToInt32(dr["ConstraintID"]);
                    co.ConstraintName = (string)dr["ConstraintName"];
                    co.ConstraintValue = (float)Convert.ToDouble(dr["ConstraintValue"]);
                    C.Add(co);
                }
                return C;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void PutConstraint(Constraint c)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            String cStr = BuildPutCommandSale(c);
            cmd = CreateCommand(cStr, con);
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private String BuildPutCommandSale(Constraint c)
        {
            string value = c.ConstraintValue.ToString();
            string id = c.ConstraintID.ToString();
            String prefix = "UPDATE ConstraintManagement_2020 SET [ConstraintName] = '" + c.ConstraintName + "', [ConstraintValue] =  '" + value + "' WHERE [ConstraintID] = " + id + "";
            return prefix;
        }



    }


}
