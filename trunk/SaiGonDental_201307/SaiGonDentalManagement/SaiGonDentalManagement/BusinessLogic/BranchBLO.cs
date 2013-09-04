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

            GlobalVariable.DATA_CONTEXT.BRANCHes.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
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
            BRANCH entity        = new BRANCH();
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

        /// <summary>
        /// Update an entity Branch to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(BRANCH entity)
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
                BRANCH oldEntity        = GlobalVariable.DATA_CONTEXT.BRANCHes.Single(
                                            record => record.Id == entity.Id);
                oldEntity.Name          = entity.Name;
                oldEntity.CityId        = entity.CityId;
                oldEntity.DistrictId    = entity.DistrictId;
                oldEntity.WardId        = entity.WardId;
                oldEntity.StreetId      = entity.StreetId;
                oldEntity.AddressDetail = entity.AddressDetail;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_BRANCH,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_BRANCH);
            }
        }

        /// <summary>
        /// Update an entity Branch to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name of Branch</param>
        /// <param name="cityId">If of City</param>
        /// <param name="districtId">If of District</param>
        /// <param name="wardId">If of Ward</param>
        /// <param name="streetId">If of Street</param>
        /// <param name="addressDetail">Detail of Address</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, short cityId, short districtId,
            short wardId, short streetId, string addressDetail)
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
                BRANCH entity        = new BRANCH();
                entity.Name          = name;
                entity.CityId        = cityId;
                entity.DistrictId    = districtId;
                entity.WardId        = wardId;
                entity.StreetId      = streetId;
                entity.AddressDetail = addressDetail;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_BRANCH,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_BRANCH);
            }
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="id">Id of entity to delete</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Delete(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.BRANCHes
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.BRANCHes.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_BRANCH,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_BRANCH);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Branch</param>
        /// <returns>BRANCH object</returns>
        public BRANCH GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.BRANCHes
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_BRANCH,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_BRANCH);
            }
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
