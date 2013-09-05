using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaiGonDentalManagement.Utilities;
using SaiGonDentalManagement.DataAccess;
using System.Diagnostics;
using System.Windows.Forms;

namespace SaiGonDentalManagement.BusinessLogic
{
    /// <summary>
    /// Business logic class for Customer object.
    /// </summary>
    public class CustomerBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static CustomerBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static CustomerBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerBLO();
                }
                return CustomerBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Customer table.
        /// </summary>
        /// <returns>List of Customer object</returns>
        public List<CUSTOMER> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.CUSTOMERs.ToList();
        }

        /// <summary>
        /// Insert an entity Customer to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public string Insert(CUSTOMER entity)
        {
            // Check Id of City is valid
            if (!CityBLO.IsIdValid(entity.CityId))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CITY);
            }
            // Check Id of District is valid
            if (!DistrictBLO.IsIdValid(entity.DistrictId))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISTRICT);
            }
            // Check Id of Ward is valid
            if ((entity.WardId != null)
                && !WardBLO.IsIdValid(entity.WardId.Value))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_WARD,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_WARD);
            }
            // Check Id of Street is valid
            if ((entity.StreetId != null)
                && !StreetBLO.IsIdValid(entity.StreetId.Value))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET);
            }
            // Check Street in District
            if ((entity.StreetId != null)
                && !DistrictDetailBLO.IsStreetInDistrict(
                entity.DistrictId, entity.StreetId.Value))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT);
            }
            // Check Id of Job is valid
            if (!JobBLO.IsIdValid(entity.JobId))
            {
                LogManagement.WriteMessage(
                    GlobalVariable.INVALID_ID_JOB,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_JOB);
            }
            // Check Id of Branch is valid
            if ((entity.BranchId != null)
                && !BranchBLO.IsIdValid(entity.BranchId.Value))
            {
                LogManagement.WriteMessage(
                    GlobalVariable.INVALID_ID_BRANCH,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_BRANCH);
            }
            // Increase number of customer in a day
            GlobalVariable.CUSTOMER_ID_VIEW++;
            // Generate new Id
            entity.Id = GenerateId();
            GlobalVariable.DATA_CONTEXT.CUSTOMERs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            // Log
            LogManagement.WriteMessage(
                String.Format(GlobalVariable.IFO_INSERT_SUCCESS,
                        this.GetType().Name.Replace(GlobalVariable.BLO,
                            ""),
                    entity.Id),
                new StackTrace(new StackFrame(true)));
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Customer to database.
        /// </summary>
        /// <param name="name">Name of customer</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="gender">Gender: Male is TRUE, FALSE otherwise</param>
        /// <param name="cityId">If of City</param>
        /// <param name="districtId">If of District</param>
        /// <param name="wardId">If of Ward</param>
        /// <param name="streetId">If of Street</param>
        /// <param name="addressDetail">Detail of Address</param>
        /// <param name="phone">Phone</param>
        /// <param name="email">Email</param>
        /// <param name="jobId">Id of Job</param>
        /// <param name="branchId">Id of Branch</param>
        /// <returns>Id of insert row</returns>
        public string Insert(string name, DateTime birthday, bool gender,
            short cityId, short districtId,
            short wardId, short streetId, string addressDetail,
            string phone, string email,
            short jobId, short branchId)
        {
            // Check Id of City is valid
            if (!CityBLO.IsIdValid(cityId))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CITY);
            }
            // Check Id of District is valid
            if (!DistrictBLO.IsIdValid(districtId))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISTRICT);
            }
            // Check Id of Ward is valid
            if (!WardBLO.IsIdValid(wardId))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_WARD,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_WARD);
            }
            // Check Id of Street is valid
            if (!StreetBLO.IsIdValid(streetId))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET);
            }
            // Check Street in District
            if (!DistrictDetailBLO.IsStreetInDistrict(
                districtId, streetId))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT);
            }
            // Check Id of Job is valid
            if (!JobBLO.IsIdValid(jobId))
            {
                LogManagement.WriteMessage(
                    GlobalVariable.INVALID_ID_JOB,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_JOB);
            }
            // Check Id of Branch is valid
            if (!BranchBLO.IsIdValid(branchId))
            {
                LogManagement.WriteMessage(
                    GlobalVariable.INVALID_ID_BRANCH,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_BRANCH);
            }
            // Increase number of customer in a day
            GlobalVariable.CUSTOMER_ID_VIEW++;
            CUSTOMER entity = new CUSTOMER();
            // Generate new Id
            entity.Id = GenerateId();
            entity.Name = name;
            entity.Birthday = birthday;
            entity.Gender = gender;
            entity.CityId = cityId;
            entity.DistrictId = districtId;
            entity.WardId = wardId;
            entity.StreetId = streetId;
            entity.AddressDetail = addressDetail;
            entity.Phone = phone;
            entity.Email = email;
            entity.JobId = jobId;
            entity.BranchId = branchId;
            GlobalVariable.DATA_CONTEXT.CUSTOMERs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            // Log
            LogManagement.WriteMessage(
                String.Format(GlobalVariable.IFO_INSERT_SUCCESS,
                        this.GetType().Name.Replace(GlobalVariable.BLO,
                            ""),
                    entity.Id),
                new StackTrace(new StackFrame(true)));
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Customer to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(CUSTOMER entity)
        {
            if (IsIdValid(entity.Id))
            {
                // Check Id of City is valid
                if (!CityBLO.IsIdValid(entity.CityId))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_CITY);
                }
                // Check Id of District is valid
                if (!DistrictBLO.IsIdValid(entity.DistrictId))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISTRICT,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_DISTRICT);
                }
                // Check Id of Ward is valid
                if ((entity.WardId != null)
                    && !WardBLO.IsIdValid(entity.WardId.Value))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_WARD,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_WARD);
                }
                // Check Id of Street is valid
                if ((entity.StreetId != null)
                    && !StreetBLO.IsIdValid(entity.StreetId.Value))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_STREET);
                }
                // Check Street in District
                if ((entity.StreetId != null)
                    && !DistrictDetailBLO.IsStreetInDistrict(
                    entity.DistrictId, entity.StreetId.Value))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT);
                }
                // Check Id of Job is valid
                if (!JobBLO.IsIdValid(entity.JobId))
                {
                    LogManagement.WriteMessage(
                        GlobalVariable.INVALID_ID_JOB,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_JOB);
                }
                // Check Id of Branch is valid
                if ((entity.BranchId != null)
                    && !BranchBLO.IsIdValid(entity.BranchId.Value))
                {
                    LogManagement.WriteMessage(
                        GlobalVariable.INVALID_ID_BRANCH,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_BRANCH);
                }
                // Update
                CUSTOMER oldEntity = GlobalVariable.DATA_CONTEXT.CUSTOMERs.Single(
                    record => record.Id == entity.Id);
                oldEntity.Name = entity.Name;
                oldEntity.Birthday = entity.Birthday;
                oldEntity.Gender = entity.Gender;
                oldEntity.CityId = entity.CityId;
                oldEntity.DistrictId = entity.DistrictId;
                oldEntity.WardId = entity.WardId;
                oldEntity.StreetId = entity.StreetId;
                oldEntity.AddressDetail = entity.AddressDetail;
                oldEntity.Phone = entity.Phone;
                oldEntity.Email = entity.Email;
                oldEntity.JobId = entity.JobId;
                oldEntity.BranchId = entity.BranchId;

                GlobalVariable.DATA_CONTEXT.SubmitChanges();
                // Log
                LogManagement.WriteMessage(
                    String.Format(GlobalVariable.IFO_UPDATE_SUCCESS,
                        this.GetType().Name.Replace(GlobalVariable.BLO,
                            ""),
                        entity.Id),
                    new StackTrace(new StackFrame(true)));
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
            }
        }

        /// <summary>
        /// Update an entity Customer to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name of customer</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="gender">Gender: Male is TRUE, FALSE otherwise</param>
        /// <param name="cityId">If of City</param>
        /// <param name="districtId">If of District</param>
        /// <param name="wardId">If of Ward</param>
        /// <param name="streetId">If of Street</param>
        /// <param name="addressDetail">Detail of Address</param>
        /// <param name="phone">Phone</param>
        /// <param name="email">Email</param>
        /// <param name="jobId">Id of Job</param>
        /// <param name="branchId">Id of Branch</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(string id, string name, DateTime birthday, bool gender,
           short cityId, short districtId,
           short wardId, short streetId, string addressDetail,
           string phone, string email,
           short jobId, short branchId)
        {
            if (IsIdValid(id))
            {
                // Check Id of City is valid
                if (!CityBLO.IsIdValid(cityId))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_CITY);
                }
                // Check Id of District is valid
                if (!DistrictBLO.IsIdValid(districtId))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISTRICT,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_DISTRICT);
                }
                // Check Id of Ward is valid
                if (!WardBLO.IsIdValid(wardId))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_WARD,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_WARD);
                }
                // Check Id of Street is valid
                if (!StreetBLO.IsIdValid(streetId))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_STREET);
                }
                // Check Street in District
                if (!DistrictDetailBLO.IsStreetInDistrict(
                    districtId, streetId))
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT);
                }
                // Check Id of Job is valid
                if (!JobBLO.IsIdValid(jobId))
                {
                    LogManagement.WriteMessage(
                        GlobalVariable.INVALID_ID_JOB,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_JOB);
                }
                // Check Id of Branch is valid
                if (!BranchBLO.IsIdValid(branchId))
                {
                    LogManagement.WriteMessage(
                        GlobalVariable.INVALID_ID_BRANCH,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_BRANCH);
                }
                CUSTOMER entity      = new CUSTOMER();
                entity.Id            = id;
                entity.Name          = name;
                entity.Birthday      = birthday;
                entity.Gender        = gender;
                entity.CityId        = cityId;
                entity.DistrictId    = districtId;
                entity.WardId        = wardId;
                entity.StreetId      = streetId;
                entity.AddressDetail = addressDetail;
                entity.Phone         = phone;
                entity.Email         = email;
                entity.JobId         = jobId;
                entity.BranchId      = branchId;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
            }
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="id">Id of entity to delete</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Delete(string id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.CUSTOMERs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.CUSTOMERs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
                // Log
                LogManagement.WriteMessage(
                    String.Format(GlobalVariable.IFO_DELETE_SUCCESS,
                        this.GetType().Name.Replace(GlobalVariable.BLO,
                            ""),
                        id),
                    new StackTrace(new StackFrame(true)));
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Customer</param>
        /// <returns>CUSTOMER object</returns>
        public CUSTOMER GetARow(string id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.CUSTOMERs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(string id)
        {
            if (GlobalVariable.DATA_CONTEXT.CUSTOMERs.Count() > 0)
            {
                foreach (CUSTOMER item in GlobalVariable.DATA_CONTEXT.CUSTOMERs)
                {
                    if (item.Id.Equals(id))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Other Methods
        /// <summary>
        /// Generate Id of customer flow this rule:
        /// Id = Header + YYMMDD + View.
        /// With:
        ///     Header is value [Application][CusomerIdHeader] in config file.
        ///     YYMMDD is date of creation.
        ///     View is number of customer in a day.
        /// Length of Id is         12:
        ///     Length of Header is 2;
        ///     Length of YYMMDD is 6;
        ///     Length of View is   4;
        /// If View > 9999, then View will be reduce by module by 10000.
        /// </summary>
        /// <example>
        /// Header = "BN"
        /// Date of creation is 2013/09/04
        /// View = 15
        ///     => Id = BN1309040015
        /// Header = "BN"
        /// Date of creation is 2013/12/30
        /// View = 1577
        ///     => Id = BN1312301577
        /// Header = "BN"
        /// Date of creation is 2013/12/30
        /// View = 10076
        ///     => User must be change value of Header, maybe is BM
        ///         Id = BM1312300076
        /// </example>
        /// <returns>Id of Customer</returns>
        private string GenerateId()
        {
            string id = "";
            int year = DateTime.Now.Year % 100;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            string view = "";

            if (GlobalVariable.CUSTOMER_ID_VIEW <= 9999)
            {
                view = GlobalVariable.CUSTOMER_ID_VIEW.ToString(
                    GlobalVariable.FORMAT_CUSTOMER_VIEW);
            }
            else
            {
                view = (GlobalVariable.CUSTOMER_ID_VIEW % 10000).ToString(
                    GlobalVariable.FORMAT_CUSTOMER_VIEW);
                MessageBox.Show(String.Format(GlobalVariable.ERR_APP_CUSTOMER_MAXIMUM,
                           GlobalVariable.SECTION_APPLICATION,
                           GlobalVariable.KEY_CUSTOMER_ID_HEADER),
                       GlobalVariable.ERR_ERROR,
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
            id = String.Format("{0}{1}{2}{3}{4}",
                GlobalVariable.CUSTOMER_ID_HEADER,
                year.ToString("00"), month.ToString("00"), day.ToString("00"),
                view);

            return id;
        }
        #endregion
    }
}
