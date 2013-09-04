using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaiGonDentalManagement.Utilities;
using SaiGonDentalManagement.DataAccess;
using System.Diagnostics;

namespace SaiGonDentalManagement.BusinessLogic
{
    /// <summary>
    /// Business logic class for Customer object.
    /// </summary>
    public class CustomerBLO
    {
        /// <summary>
        /// Instance of class
        /// </summary>
        private static CustomerBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern
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

            //GlobalVariable.DATA_CONTEXT.BRANCHes.InsertOnSubmit(entity);
            //GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
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
        private string GenerateId()
        {
            string id = "";
            int year = DateTime.Now.Year / 100;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            string view = Configuration.LoadCustomerIdView();
            id = String.Format("{0}{1}{2}{3}{4}",
                GlobalVariable.CUSTOMER_ID_HEADER,
                year, month, day,
                )
            return id;
        }
        #endregion
    }
}
