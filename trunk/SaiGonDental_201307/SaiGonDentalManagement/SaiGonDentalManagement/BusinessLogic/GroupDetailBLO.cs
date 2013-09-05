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
    /// Business logic class for Group Detail object.
    /// </summary>
    public class GroupDetailBLO
    {
        /// <summary>
        /// Instance of class.
        /// </summary>
        private static GroupDetailBLO instance;

        /// <summary>
        /// Get instance of class - Singleton Pattern.
        /// </summary>
        /// <returns>Instance of class</returns>
        public static GroupDetailBLO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GroupDetailBLO();
                }
                return GroupDetailBLO.instance;
            }
        }

        #region Default Methods

        /// <summary>
        /// Insert an entity Group Detail to database.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns>Id of insert row</returns>
        public short Insert(GROUP_DETAIL entity)
        {
            if (GroupBLO.IsIdValid(entity.GroupId))
            {
                if (RuleBLO.IsIdValid(entity.RuleId))
                {
                    GlobalVariable.DATA_CONTEXT.GROUP_DETAILs.InsertOnSubmit(entity);
                    GlobalVariable.DATA_CONTEXT.SubmitChanges();
                    return entity.Id;
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_RULE);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP);
            }
        }

        /// <summary>
        /// Insert an entity Group Detail to database.
        /// </summary>
        /// <param name="groupId">Id of Group</param>
        /// <param name="ruleId">Id of Rule</param>
        /// <returns>Id of insert row</returns>
        public short Insert(short groupId, short ruleId)
        {
            if (GroupBLO.IsIdValid(groupId))
            {
                if (RuleBLO.IsIdValid(ruleId))
                {
                    GROUP_DETAIL entity = new GROUP_DETAIL();
                    entity.GroupId = groupId;
                    entity.RuleId = ruleId;
                    GlobalVariable.DATA_CONTEXT.GROUP_DETAILs.InsertOnSubmit(entity);
                    GlobalVariable.DATA_CONTEXT.SubmitChanges();
                    return entity.Id;
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_RULE);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP);
            }
        }

        /// <summary>
        /// Update an entity Group Detail to database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="System.Exception">Throw when entity has an invalid Id</exception>
        public void Update(GROUP_DETAIL entity)
        {
            if (IsIdValid(entity.Id))
            {
                if (GroupBLO.IsIdValid(entity.GroupId))
                {
                    if (RuleBLO.IsIdValid(entity.RuleId))
                    {
                        GROUP_DETAIL oldEntity = GlobalVariable.DATA_CONTEXT.GROUP_DETAILs.Single(
                            record => record.Id == entity.Id);
                        oldEntity.GroupId = entity.GroupId;
                        oldEntity.RuleId = entity.RuleId;
                        GlobalVariable.DATA_CONTEXT.SubmitChanges();
                    }
                    else
                    {
                        LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                            new StackTrace(new StackFrame(true)));
                        throw new Exception(GlobalVariable.INVALID_ID_RULE);
                    }
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_GROUP);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP_DETAIL,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP_DETAIL);
            }
        }

        /// <summary>
        /// Update an entity Group Detail to database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="groupId">Id of Group</param>
        /// <param name="ruleId">If of Rule</param>
        public void Update(short id, short groupId, short ruleId)
        {
            if (IsIdValid(id))
            {
                if (GroupBLO.IsIdValid(groupId))
                {
                    if (RuleBLO.IsIdValid(ruleId))
                    {
                        GROUP_DETAIL entity = new GROUP_DETAIL();
                        entity.Id = id;
                        entity.GroupId = groupId;
                        entity.RuleId = ruleId;
                        Update(entity);
                    }
                    else
                    {
                        LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                            new StackTrace(new StackFrame(true)));
                        throw new Exception(GlobalVariable.INVALID_ID_RULE);
                    }
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_GROUP);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP_DETAIL,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP_DETAIL);
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
                var entities = from record in GlobalVariable.DATA_CONTEXT.GROUP_DETAILs
                               where record.Id.Equals(id)
                               select record;
                GlobalVariable.DATA_CONTEXT.GROUP_DETAILs.DeleteAllOnSubmit(entities);
                GlobalVariable.DATA_CONTEXT.SubmitChanges();
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP_DETAIL,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP_DETAIL);
            }
        }

        /// <summary>
        /// Check if an Id is valid.
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>True if Id is valid, false otherwise</returns>
        public static bool IsIdValid(short id)
        {
            if (GlobalVariable.DATA_CONTEXT.GROUP_DETAILs.Count() > 0)
            {
                foreach (GROUP_DETAIL item in GlobalVariable.DATA_CONTEXT.GROUP_DETAILs)
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
        /// Get all Rules in a Group
        /// </summary>
        /// <param name="groupId">Id of Group</param>
        /// <returns>List of RULE</returns>
        public List<RULE> GetAllRuleInGroup(short groupId)
        {
            // Result list
            List<RULE> result = new List<RULE>();
            // Group Business logic object
            GroupBLO groupBLO = new GroupBLO();
            // Get Group object
            GROUP group = groupBLO.GetARow(groupId);

            // Loop for Group Detail list
            foreach (GROUP_DETAIL detail in group.GROUP_DETAILs)
            {
                result.Add(detail.RULE);
            }
            return result;
        }

        /// <summary>
        /// Get all Groups on a Rule
        /// </summary>
        /// <param name="ruleId">Id of Rule</param>
        /// <returns>List of GROUP</returns>
        public List<GROUP> GetAllGroupOnRule(short ruleId)
        {
            // Result list
            List<GROUP> result = new List<GROUP>();
            // Rule Business logic object
            RuleBLO ruleBLO = new RuleBLO();
            // Get Rule object
            RULE rule = ruleBLO.GetARow(ruleId);

            // Loop for Group Detail list
            foreach (GROUP_DETAIL detail in rule.GROUP_DETAILs)
            {
                result.Add(detail.GROUP);
            }
            return result;
        }

        /// <summary>
        /// Check if an Id of Group and Id of Rule is valid.
        /// </summary>
        /// <param name="groupId">Id of Group</param>
        /// <param name="ruleId">Id of Rule</param>
        /// <returns>True if Rule in Group, false otherwise</returns>
        public static bool IsRuleInGroup(short groupId, short ruleId)
        {
            if (GroupBLO.IsIdValid(groupId))
            {
                if (RuleBLO.IsIdValid(ruleId))
                {
                    foreach (RULE item in GroupDetailBLO.Instance.GetAllRuleInGroup(groupId))
                    {
                        if (item.Id.Equals(ruleId))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    LogManagement.WriteMessage(GlobalVariable.INVALID_ID_RULE,
                        new StackTrace(new StackFrame(true)));
                    throw new Exception(GlobalVariable.INVALID_ID_RULE);
                }
            }
            else
            {
                LogManagement.WriteMessage(GlobalVariable.INVALID_ID_GROUP,
                    new StackTrace(new StackFrame(true)));
                throw new Exception(GlobalVariable.INVALID_ID_GROUP);
            }
            return false;
        }
        #endregion
    }
}
