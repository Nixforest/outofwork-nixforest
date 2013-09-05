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
    /// Business logic class for Rule object.
    /// </summary>
    public class RuleBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static RuleBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static RuleBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RuleBLO();
                }
                return RuleBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Rule table.
        /// </summary>
        /// <returns>List of Group object</returns>
        public List<RULE> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.RULEs.ToList();
        }

        /// <summary>
        /// Insert an entity Rule to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(RULE entity)
        {
            GlobalVariable.DATA_CONTEXT.RULEs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Rule to database.
        /// </summary>
        /// <param name="name">Name of Rule</param>
        /// <param name="detail">Detail</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, string detail)
        {
            RULE entity   = new RULE();
            entity.Name   = name;
            entity.Detail = detail;
            GlobalVariable.DATA_CONTEXT.RULEs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Rule to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(RULE entity)
        {
            if (IsIdValid(entity.Id))
            {
                RULE oldEntity = GlobalVariable.DATA_CONTEXT.RULEs.Single(
                                        record => record.Id == entity.Id);
                oldEntity.Name   = entity.Name;
                oldEntity.Detail = entity.Detail;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_RULE);
            }
        }

        /// <summary>
        /// Update an entity Rule to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="detail">Detail</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, string detail)
        {
            if (IsIdValid(id))
            {
                RULE entity   = new RULE();
                entity.Id     = id;
                entity.Name   = name;
                entity.Detail = detail;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_RULE);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.RULEs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.RULEs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_RULE);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Rule</param>
        /// <returns>RULE object</returns>
        public RULE GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.RULEs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_RULE);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.RULEs.Count() > 0)
            {
                foreach (RULE item in GlobalVariable.DATA_CONTEXT.RULEs)
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
