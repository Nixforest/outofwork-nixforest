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
    /// Business logic class for Disease Before object.
    /// </summary>
    public class DiseaseBeforeBLO
    {
        /// <summary>
        /// Instance of class
        /// </summary>
        private static DiseaseBeforeBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern
        /// </summary>
        /// <returns>Instance of class</returns>
        public static DiseaseBeforeBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DiseaseBeforeBLO();
                }
                return DiseaseBeforeBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Disease Before table.
        /// </summary>
        /// <returns>List of Disease Before object</returns>
        public List<DISEASEBEFORE> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs.ToList();
        }

        /// <summary>
        /// Insert an entity Disease Before to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(DISEASEBEFORE entity)
        {
            GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Disease Before to database.
        /// </summary>
        /// <param name="name">Disease Before</param>
        /// <param name="detail">Detail</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, string detail)
        {
            DISEASEBEFORE entity = new DISEASEBEFORE();
            entity.Name = name;
            entity.Detail = detail;
            GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Disease Before to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(DISEASEBEFORE entity)
        {
            if (IsIdValid(entity.Id))
            {
                DISEASEBEFORE oldEntity =
                    GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs.Single(record => record.Id == entity.Id);
                oldEntity.Name = entity.Name;
                oldEntity.Detail = entity.Detail;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISEASE_BEFORE,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISEASE_BEFORE);
            }
        }

        /// <summary>
        /// Update an entity Disease Before to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="detail">Detail</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, string detail)
        {
            if (IsIdValid(id))
            {
                DISEASEBEFORE entity = new DISEASEBEFORE();
                entity.Id = id;
                entity.Name = name;
                entity.Detail = detail;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISEASE_BEFORE,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISEASE_BEFORE);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISEASE_BEFORE,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISEASE_BEFORE);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Job</param>
        /// <returns>DISEASEBEFORE object</returns>
        public DISEASEBEFORE GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_DISEASE_BEFORE,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_DISEASE_BEFORE);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs.Count() > 0)
            {
                foreach (DISEASEBEFORE item in GlobalVariable.DATA_CONTEXT.DISEASEBEFOREs)
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
