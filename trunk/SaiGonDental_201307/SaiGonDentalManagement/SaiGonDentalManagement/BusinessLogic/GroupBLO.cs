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
    /// Business logic class for Group object.
    /// </summary>
    public class GroupBLO
    {
        /// <summary>
        /// Instance of class
        /// </summary>
        private static GroupBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern
        /// </summary>
        /// <returns>Instance of class</returns>
        public static GroupBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GroupBLO();
                }
                return GroupBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Group table.
        /// </summary>
        /// <returns>List of Group object</returns>
        public List<GROUP> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.GROUPs.ToList();
        }

        /// <summary>
        /// Insert an entity Group to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(GROUP entity)
        {
            GlobalVariable.DATA_CONTEXT.GROUPs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Group to database.
        /// </summary>
        /// <param name="name">Name of Group</param>
        /// <param name="detail">Detail</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, string detail)
        {
            GROUP entity  = new GROUP();
            entity.Name   = name;
            entity.Detail = detail;
            GlobalVariable.DATA_CONTEXT.GROUPs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Group to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(GROUP entity)
        {
            if (IsIdValid(entity.Id))
            {
                GROUP oldEntity  = GlobalVariable.DATA_CONTEXT.GROUPs.Single(
                                        record => record.Id == entity.Id);
                oldEntity.Name   = entity.Name;
                oldEntity.Detail = entity.Detail;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP);
            }
        }

        /// <summary>
        /// Update an entity Group to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="detail">Detail</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, string detail)
        {
            if (IsIdValid(id))
            {
                GROUP entity  = new GROUP();
                entity.Id     = id;
                entity.Name   = name;
                entity.Detail = detail;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.GROUPs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.GROUPs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Group</param>
        /// <returns>GROUP object</returns>
        public GROUP GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.GROUPs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.GROUPs.Count() > 0)
            {
                foreach (GROUP item in GlobalVariable.DATA_CONTEXT.GROUPs)
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
