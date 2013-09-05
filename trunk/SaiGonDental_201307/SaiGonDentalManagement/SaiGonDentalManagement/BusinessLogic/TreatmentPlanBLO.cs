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
    /// Business logic class for Treatment Plan object.
    /// </summary>
    public class TreatmentPlanBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static TreatmentPlanBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static TreatmentPlanBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TreatmentPlanBLO();
                }
                return TreatmentPlanBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Treatment Plan table.
        /// </summary>
        /// <returns>List of Treatment Plan object</returns>
        public List<TREATMENTPLAN> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.TREATMENTPLANs.ToList();
        }

        /// <summary>
        /// Insert an entity Treatment Plan to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(TREATMENTPLAN entity)
        {
            GlobalVariable.DATA_CONTEXT.TREATMENTPLANs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Treatment Plan to database.
        /// </summary>
        /// <param name="name">Treatment Plan</param>
        /// <param name="detail">Detail</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, string detail)
        {
            TREATMENTPLAN entity = new TREATMENTPLAN();
            entity.Name   = name;
            entity.Detail = detail;
            GlobalVariable.DATA_CONTEXT.TREATMENTPLANs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Treatment Plan to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(TREATMENTPLAN entity)
        {
            if (IsIdValid(entity.Id))
            {
                TREATMENTPLAN oldEntity =
                    GlobalVariable.DATA_CONTEXT.TREATMENTPLANs.Single(record => record.Id == entity.Id);
                oldEntity.Name   = entity.Name;
                oldEntity.Detail = entity.Detail;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_TREATMENT_PLAN,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_TREATMENT_PLAN);
            }
        }

        /// <summary>
        /// Update an entity Treatment Plan to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="detail">Detail</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, string detail)
        {
            if (IsIdValid(id))
            {
                TREATMENTPLAN entity = new TREATMENTPLAN();
                entity.Id = id;
                entity.Name = name;
                entity.Detail = detail;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_TREATMENT_PLAN,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_TREATMENT_PLAN);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.TREATMENTPLANs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.TREATMENTPLANs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_TREATMENT_PLAN,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_TREATMENT_PLAN);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Job</param>
        /// <returns>TREATMENTPLAN object</returns>
        public TREATMENTPLAN GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.TREATMENTPLANs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_TREATMENT_PLAN,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_TREATMENT_PLAN);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.TREATMENTPLANs.Count() > 0)
            {
                foreach (TREATMENTPLAN item in GlobalVariable.DATA_CONTEXT.TREATMENTPLANs)
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
