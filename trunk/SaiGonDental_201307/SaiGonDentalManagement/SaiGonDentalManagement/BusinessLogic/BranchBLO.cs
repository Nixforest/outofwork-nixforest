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
    /// Business logic class for Branch object.
    /// </summary>
    public class BranchBLO
    {
        /// <summary>
        /// Instance of class
        /// </summary>
        private static BranchBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern
        /// </summary>
        /// <returns>Instance of class</returns>
        public static BranchBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BranchBLO();
                }
                return BranchBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Branch table.
        /// </summary>
        /// <returns>List of Branch object</returns>
        public List<BRANCH> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.BRANCHes.ToList();
        }

        /// <summary>
        /// Insert an entity Branch to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(BRANCH entity)
        {
            // Check Id of City is valid
            if (!CityBLO.IsIdValid(entity.CityId))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CITY);
            }
            // Check Id of District is valid
            if ((entity.DistrictId != null)
                && !DistrictBLO.IsIdValid(entity.DistrictId.Value))
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
                && (entity.DistrictId != null)
                && !DistrictDetailBLO.IsStreetInDistrict(
                entity.DistrictId.Value, entity.StreetId.Value))
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET_NOT_IN_DISTRICT);
            }
            //    && DistrictBLO.IsIdValid(entity.DistrictId)
            //    && WardBLO.IsIdValid(entity.WardId)
            //    && StreetBLO.IsIdValid(entity.StreetId))
            //{
            //GlobalVariable.DATA_CONTEXT.BRANCHes.InsertOnSubmit(entity);
            //GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
            //}
            //else
            //{
            //    throw new Exception(GlobalVariable.INVALID_ID);
            //}
        }

        /// <summary>
        /// Insert an entity Branch to database.
        /// </summary>
        /// <param name="name">Name of Branch</param>
        /// <param name="cityId">If of City</param>
        /// <param name="districtId">If of District</param>
        /// <param name="wardId">If of Ward</param>
        /// <param name="streetId">If of Street</param>
        /// <param name="addressDetail">Detail of Address</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, short cityId, short districtId,
            short wardId, short streetId, string addressDetail)
        {
            if (CityBLO.IsIdValid(cityId)
                && DistrictBLO.IsIdValid(districtId)
                && WardBLO.IsIdValid(wardId)
                && StreetBLO.IsIdValid(streetId))
            {
                BRANCH entity = new BRANCH();
                entity.Name          = name;
                entity.CityId        = cityId;
                entity.DistrictId    = districtId;
                entity.WardId        = wardId;
                entity.StreetId      = streetId;
                entity.AddressDetail = addressDetail;
                GlobalVariable.DATA_CONTEXT.BRANCHes.InsertOnSubmit(entity);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
                return entity.Id;
            }
            else
            {
                throw new Exception(GlobalVariable.INVALID_ID);
            }
        }

        /// <summary>
        /// Update an entity Treatment Plan to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(TREATMENTPLAN entity)
        {
            //if (IsIdValid(entity.Id))
            //{
            //    TREATMENTPLAN oldEntity =
            //        GlobalVariable.DATA_CONTEXT.TREATMENTPLANs.Single(record => record.Id == entity.Id);
            //    oldEntity.Name = entity.Name;
            //    oldEntity.Detail = entity.Detail;
            //    GlobalVariable.DATA_CONTEXT.SubmitChanges();
            //}
            //else
            //{
            //    throw new Exception(GlobalVariable.INVALID_ID);
            //}
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.BRANCHes.Count() > 0)
            {
                foreach (BRANCH item in GlobalVariable.DATA_CONTEXT.BRANCHes)
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
        #endregion
    }
}
