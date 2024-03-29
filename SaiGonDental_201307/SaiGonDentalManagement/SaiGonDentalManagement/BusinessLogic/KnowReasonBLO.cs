﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaiGonDentalManagement.Utilities;
using SaiGonDentalManagement.DataAccess;
using System.Diagnostics;

namespace SaiGonDentalManagement.BusinessLogic
{
    /// <summary>
    /// Business logic class for Know Reason object.
    /// </summary>
    public class KnowReasonBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static KnowReasonBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static KnowReasonBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KnowReasonBLO();
                }
                return KnowReasonBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Know Reason table.
        /// </summary>
        /// <returns>List of Know Reason object</returns>
        public List<KNOWREASON> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.KNOWREASONs.ToList();
        }

        /// <summary>
        /// Insert an entity Know Reason to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(KNOWREASON entity)
        {
            GlobalVariable.DATA_CONTEXT.KNOWREASONs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Know Reason to database.
        /// </summary>
        /// <param name="name">Know Reason</param>
        /// <param name="detail">Detail</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, string detail)
        {
            KNOWREASON entity = new KNOWREASON();
            entity.Name = name;
            entity.Detail = detail;
            GlobalVariable.DATA_CONTEXT.KNOWREASONs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Know Reason to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(KNOWREASON entity)
        {
            if (IsIdValid(entity.Id))
            {
                KNOWREASON oldEntity =
                    GlobalVariable.DATA_CONTEXT.KNOWREASONs.Single(record => record.Id == entity.Id);
                oldEntity.Name = entity.Name;
                oldEntity.Detail = entity.Detail;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
            }
        }

        /// <summary>
        /// Update an entity Know Reason to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="detail">Detail</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, string detail)
        {
            if (IsIdValid(id))
            {
                KNOWREASON entity = new KNOWREASON();
                entity.Id = id;
                entity.Name = name;
                entity.Detail = detail;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.KNOWREASONs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.KNOWREASONs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Job</param>
        /// <returns>KNOWREASON object</returns>
        public KNOWREASON GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.KNOWREASONs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.KNOWREASONs.Count() > 0)
            {
                foreach (KNOWREASON item in GlobalVariable.DATA_CONTEXT.KNOWREASONs)
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
