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
    /// Business logic class for Street object.
    /// </summary>
    public class StreetBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static StreetBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static StreetBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StreetBLO();
                }
                return StreetBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Street table.
        /// </summary>
        /// <returns>List of Street object</returns>
        public List<STREET> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.STREETs.ToList();
        }

        /// <summary>
        /// Insert an entity Street to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(STREET entity)
        {
            GlobalVariable.DATA_CONTEXT.STREETs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Street to database.
        /// </summary>
        /// <param name="name">Name of Street</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name)
        {
            STREET entity = new STREET();
            entity.Name = name;
            GlobalVariable.DATA_CONTEXT.STREETs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Street to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(STREET entity)
        {
            if (IsIdValid(entity.Id))
            {
                STREET oldEntity =
                    GlobalVariable.DATA_CONTEXT.STREETs.Single(record => record.Id == entity.Id);
                oldEntity.Name = entity.Name;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET);
            }
        }

        /// <summary>
        /// Update an entity Street to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name)
        {
            if (IsIdValid(id))
            {
                STREET entity = new STREET();
                entity.Id = id;
                entity.Name = name;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.STREETs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.STREETs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Street</param>
        /// <returns>STREET object</returns>
        public STREET GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.STREETs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_STREET,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_STREET);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.STREETs.Count() > 0)
            {
                foreach (STREET item in GlobalVariable.DATA_CONTEXT.STREETs)
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
