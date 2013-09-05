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
    /// Business logic class for Know Reason Detail object.
    /// </summary>
    public class KnowReasonDetailBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static KnowReasonDetailBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static KnowReasonDetailBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KnowReasonDetailBLO();
                }
                return KnowReasonDetailBLO.instance;
            }
        }

        #region Default Methods

        /// <summary>
        /// Insert an entity Know Reason to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public int Insert(KNOWREASON_DETAIL entity)
        {
            if (KnowReasonBLO.IsIdValid(entity.KnowReasonId))
            {
                if (CustomerBLO.IsIdValid(entity.CustomerId))
                {
                    GlobalVariable.DATA_CONTEXT.KNOWREASON_DETAILs.InsertOnSubmit(entity);
                    GlobalVariable.DATA_CONTEXT.SubmitChanges();
                    // Log
                    LogManagement.WriteMessage(
                        String.Format(GlobalVariable.IFO_INSERT_SUCCESS,
                                this.GetType().Name.Replace(GlobalVariable.BLO,
                                    ""),
                            entity.Id),
                        new StackTrace(new StackFrame(true)));
                    return entity.Id;
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
            }
        }

        /// <summary>
        /// Insert an entity KnowReason Detail to database.
        /// </summary>
        /// <param name="knowReasonId">Id of KnowReason</param>
        /// <param name="customerId">Id of Customer</param>
        /// <returns>Id of insert row</returns>
        public int Insert(short knowReasonId, string customerId)
        {
            if (KnowReasonBLO.IsIdValid(knowReasonId))
            {
                if (CustomerBLO.IsIdValid(customerId))
                {
                    KNOWREASON_DETAIL entity = new KNOWREASON_DETAIL();
                    entity.KnowReasonId = knowReasonId;
                    entity.CustomerId = customerId;
                    GlobalVariable.DATA_CONTEXT.KNOWREASON_DETAILs.InsertOnSubmit(entity);
                    GlobalVariable.DATA_CONTEXT.SubmitChanges();
                    // Log
                    LogManagement.WriteMessage(
                        String.Format(GlobalVariable.IFO_INSERT_SUCCESS,
                                this.GetType().Name.Replace(GlobalVariable.BLO,
                                    ""),
                            entity.Id),
                        new StackTrace(new StackFrame(true)));
                    return entity.Id;
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
            }
        }

        /// <summary>
        /// Update an entity KnowReason Detail to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(KNOWREASON_DETAIL entity)
        {
            if (IsIdValid(entity.Id))
            {
                if (KnowReasonBLO.IsIdValid(entity.KnowReasonId))
                {
                    if (CustomerBLO.IsIdValid(entity.CustomerId))
                    {
                        KNOWREASON_DETAIL oldEntity =
                        GlobalVariable.DATA_CONTEXT.KNOWREASON_DETAILs.Single(record => record.Id == entity.Id);
                        oldEntity.KnowReasonId = entity.KnowReasonId;
                        oldEntity.CustomerId = entity.CustomerId;
                        GlobalVariable.DATA_CONTEXT.SubmitChanges();
                        // Log
                        LogManagement.WriteMessage(
                            String.Format(GlobalVariable.IFO_UPDATE_SUCCESS,
                                this.GetType().Name.Replace(GlobalVariable.BLO,
                                    ""),
                                entity.Id),
                            new StackTrace(new StackFrame(true)));
                    }
                    else
                    {
                        LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                            new StackTrace(new StackFrame(true)));
                        throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
                    }
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON_DETAIL,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON_DETAIL);
            }
        }

        /// <summary>
        /// Update an entity Know Reason Detail to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="knowReasonId">Id of Know Reason</param>
        /// <param name="customerId">If of Customer</param>
        public void Update(short id, short knowReasonId, string customerId)
        {
            if (IsIdValid(id))
            {
                if (KnowReasonBLO.IsIdValid(knowReasonId))
                {
                    if (CustomerBLO.IsIdValid(customerId))
                    {
                        KNOWREASON_DETAIL entity = new KNOWREASON_DETAIL();
                        entity.Id = id;
                        entity.KnowReasonId = knowReasonId;
                        entity.CustomerId = customerId;
                        Update(entity);
                    }
                    else
                    {
                        LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                            new StackTrace(new StackFrame(true)));
                        throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
                    }
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON_DETAIL,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON_DETAIL);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.KNOWREASON_DETAILs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.KNOWREASON_DETAILs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
                // Log
                LogManagement.WriteMessage(
                    String.Format(GlobalVariable.IFO_DELETE_SUCCESS,
                        this.GetType().Name.Replace(GlobalVariable.BLO,
                            ""),
                        id),
                    new StackTrace(new StackFrame(true)));
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON_DETAIL,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON_DETAIL);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(int id)
        {
            if (GlobalVariable.DATA_CONTEXT.KNOWREASON_DETAILs.Count() > 0)
            {
                foreach (KNOWREASON_DETAIL item in GlobalVariable.DATA_CONTEXT.KNOWREASON_DETAILs)
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
        /// Get all Customers has the same KnowReason
        /// </summary>
        /// <param name="knowReasonId">Id of KnowReason</param>
        /// <returns>List of CUSTOMER</returns>
        public List<CUSTOMER> GetAllCustomerHasSameKnowReason(short knowReasonId)
        {
            // Result list
            List<CUSTOMER> result = new List<CUSTOMER>();
            // KnowReason Business logic object
            KnowReasonBLO KnowReasonBLO = new KnowReasonBLO();
            // Get KnowReason object
            KNOWREASON KnowReason = KnowReasonBLO.GetARow(knowReasonId);

            // Loop for KnowReason Detail list
            foreach (KNOWREASON_DETAIL detail in KnowReason.KNOWREASON_DETAILs)
            {
                result.Add(detail.CUSTOMER);
            }
            return result;
        }

        /// <summary>
        /// Get all KnowReasons of a Customer
        /// </summary>
        /// <param name="customerId">Id of Customer</param>
        /// <returns>List of KnowReason</returns>
        public List<KNOWREASON> GetAllKnowReasonOfCustomer(string customerId)
        {
            // Result list
            List<KNOWREASON> result = new List<KNOWREASON>();
            // Customer Business logic object
            CustomerBLO CustomerBLO = new CustomerBLO();
            // Get Customer object
            CUSTOMER Customer = CustomerBLO.GetARow(customerId);

            // Loop for KnowReason Detail list
            foreach (KNOWREASON_DETAIL detail in Customer.KNOWREASON_DETAILs)
            {
                result.Add(detail.KNOWREASON);
            }
            return result;
        }

        /// <summary>
        /// Check if an Id of KnowReason and Id of Customer is valid.
        /// </summary>
        /// <param name="KnowReasonId">Id of KnowReason</param>
        /// <param name="CustomerId">Id of Customer</param>
        /// <returns>True if Customer in KnowReason, false otherwise</returns>
        public static bool IsKnowReasonOfCustomer(short KnowReasonId, string CustomerId)
        {
            if (KnowReasonBLO.IsIdValid(KnowReasonId))
            {
                if (CustomerBLO.IsIdValid(CustomerId))
                {
                    foreach (KNOWREASON item in KnowReasonDetailBLO.Instance.GetAllKnowReasonOfCustomer(CustomerId))
                    {
                        if (item.Id.Equals(KnowReasonId))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_CUSTOMER,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_CUSTOMER);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_KNOW_REASON,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_KNOW_REASON);
            }
            return false;
        }
        #endregion
    }
}
