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
    /// Business logic class for Academic object.
    /// </summary>
    public class AcademicBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static AcademicBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static AcademicBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AcademicBLO();
                }
                return AcademicBLO.instance;
            }
        }

        #region Default Methods
        /// <summary>
        /// Get all rows in Academic table.
        /// </summary>
        /// <returns>List of Academic object</returns>
        public List<ACADEMIC> GetAllRows()
        {
            return GlobalVariable.DATA_CONTEXT.ACADEMICs.ToList();
        }

        /// <summary>
        /// Insert an entity Academic to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(ACADEMIC entity)
        {
            GlobalVariable.DATA_CONTEXT.ACADEMICs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Insert an entity Academic to database.
        /// </summary>
        /// <param name="name">Name of Academic</param>
        /// <param name="detail">Detail</param>
        /// <returns>Id of insert row</returns>
        public short Insert(string name, string detail)
        {
            ACADEMIC entity = new ACADEMIC();
            entity.Name     = name;
            entity.Detail   = detail;
            GlobalVariable.DATA_CONTEXT.ACADEMICs.InsertOnSubmit(entity);
            GlobalVariable.DATA_CONTEXT.SubmitChanges();
            return entity.Id;
        }

        /// <summary>
        /// Update an entity Academic to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(ACADEMIC entity)
        {
            if (IsIdValid(entity.Id))
            {
                ACADEMIC oldEntity = GlobalVariable.DATA_CONTEXT.ACADEMICs.Single(
                                        record => record.Id == entity.Id);
                oldEntity.Name     = entity.Name;
                oldEntity.Detail   = entity.Detail;
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_ACADEMIC,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_ACADEMIC);
            }
        }

        /// <summary>
        /// Update an entity Academic to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="detail">Detail</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(short id, string name, string detail)
        {
            if (IsIdValid(id))
            {
                ACADEMIC entity = new ACADEMIC();
                entity.Id       = id;
                entity.Name     = name;
                entity.Detail   = detail;
                Update(entity);
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_ACADEMIC,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_ACADEMIC);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.ACADEMICs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.ACADEMICs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_ACADEMIC,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_ACADEMIC);
            }
        }

        /// <summary>
        /// Get a row.
        /// </summary>
        /// <param name="id">Id of Academic</param>
        /// <returns>ACADEMIC object</returns>
        public ACADEMIC GetARow(short id)
        {
            if (IsIdValid(id))
            {
                var entities = from record in GlobalVariable.DATA_CONTEXT.ACADEMICs
                               where record.Id.Equals(id)
                               select record;
                return entities.Single();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_ACADEMIC,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_ACADEMIC);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.ACADEMICs.Count() > 0)
            {
                foreach (ACADEMIC item in GlobalVariable.DATA_CONTEXT.ACADEMICs)
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
