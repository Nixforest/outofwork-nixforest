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
    /// Business logic class for Department object.
    /// </summary>
    public class DepartmentBLO
    {
        /// <summary>
        /// Instance of class
        /// </summary>
        private static DepartmentBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern
        /// </summary>
        /// <returns>Instance of class</returns>
        public static DepartmentBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DepartmentBLO();
                }
                return DepartmentBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Department table.
        /// </summary>
        /// <returns>List of Department object</returns>
        public List<DEPARTMENT> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.DEPARTMENTs.ToList();
        }

        /// <summary>
        /// Insert an entity Department to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(DEPARTMENT entity)
        {
            GlobalVariable.DATA_CONTEXT.DEPARTMENTs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Department to database.
        /// </summary>
        /// <param name="name">Name of Department</param>
        /// <param name="detail">Detail</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, string detail)
        {
            DEPARTMENT entity = new DEPARTMENT();
            entity.Name       = name;
            entity.Detail     = detail;
            GlobalVariable.DATA_CONTEXT.DEPARTMENTs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Department to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(DEPARTMENT entity)
        {
            if (IsIdValid(entity.Id))
            {
                DEPARTMENT oldEntity = GlobalVariable.DATA_CONTEXT.DEPARTMENTs.Single(
                                        record => record.Id == entity.Id);
                oldEntity.Name       = entity.Name;
                oldEntity.Detail     = entity.Detail;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DEPARTMENT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DEPARTMENT);
            }
        }

        /// <summary>
        /// Update an entity Department to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="detail">Detail</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, string detail)
        {
            if (IsIdValid(id))
            {
                DEPARTMENT entity = new DEPARTMENT();
                entity.Id = id;
                entity.Name = name;
                entity.Detail = detail;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DEPARTMENT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DEPARTMENT);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.DEPARTMENTs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.DEPARTMENTs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DEPARTMENT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DEPARTMENT);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Department</param>
        /// <returns>DEPARTMENT object</returns>
        public DEPARTMENT GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.DEPARTMENTs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DEPARTMENT,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DEPARTMENT);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.DEPARTMENTs.Count() > 0)
            {
                foreach (DEPARTMENT item in GlobalVariable.DATA_CONTEXT.DEPARTMENTs)
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
