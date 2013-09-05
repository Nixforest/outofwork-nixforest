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
    /// Business logic class for District object.
    /// </summary>
    public class DistrictBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static DistrictBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static DistrictBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DistrictBLO();
                }
                return DistrictBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in District table.
        /// </summary>
        /// <returns>List of District object</returns>
        public List<DISTRICT> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.DISTRICTs.ToList();
        }

        /// <summary>
        /// Insert an entity District to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(DISTRICT entity)
        {
            if (CityBLO.IsIdValid(entity.CityId))
            {
                GlobalVariable.DATA_CONTEXT.DISTRICTs.InsertOnSubmit(entity);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
                return entity.Id;
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CITY);
            }
        }

        /// <summary>
        /// Insert an entity District to database.
        /// </summary>
        /// <param name="name">Name of District</param>
        /// <param name="cityId">Id of City</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, short cityId)
        {
            if (CityBLO.IsIdValid(cityId))
            {
                DISTRICT entity = new DISTRICT();
                entity.Name = name;
                entity.CityId = cityId;
                GlobalVariable.DATA_CONTEXT.DISTRICTs.InsertOnSubmit(entity);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
                return entity.Id;
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_CITY);
            }
        }

        /// <summary>
        /// Update an entity District to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(DISTRICT entity)
        {
            if (IsIdValid(entity.Id))
            {
                if (CityBLO.IsIdValid(entity.CityId))
                {
                    DISTRICT oldEntity =
                        GlobalVariable.DATA_CONTEXT.DISTRICTs.Single(record => record.Id == entity.Id);
                    oldEntity.Name = entity.Name;
                    oldEntity.CityId = entity.CityId;
                    GlobalVariable.DATA_CONTEXT.SubmitChanges();
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_CITY);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISTRICT);
            }
        }

        /// <summary>
        /// Update an entity District to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="cityId">Id of City</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, short cityId)
        {
            if (IsIdValid(id))
            {
                if (CityBLO.IsIdValid(cityId))
                {
                    DISTRICT entity = new DISTRICT();
                    entity.Id = id;
                    entity.Name = name;
                    entity.CityId = cityId;
                    Update(entity);
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CITY,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_CITY);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISTRICT);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.DISTRICTs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.DISTRICTs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISTRICT);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of District</param>
        /// <returns>DISTRICT object</returns>
        public DISTRICT GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.DISTRICTs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISTRICT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISTRICT);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.DISTRICTs.Count() > 0)
            {
                foreach (DISTRICT item in GlobalVariable.DATA_CONTEXT.DISTRICTs)
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
        /// Get all Branches in a District
        /// </summary>
        /// <param name="districtId">Id of District</param>
        /// <returns>List of Branches</returns>
        //public List<BRANCH> GetAllBranchesInDistrict(short districtId)
        //{
        //    if (IsIdValid(districtId))
        //    {
        //        var entities = from record in GlobalVariable.DATA_CONTEXT.DISTRICTs
        //                       where record.Id.Equals(districtId)
        //                       select record;
        //        return entities.Single().BRANCHes.ToList();
        //    }
        //    else
        //    {
        //        throw new Exception(GlobalVariable.INVALID_ID);
        //    }
        //}
        //public List<>
        #endregion
    }
}
