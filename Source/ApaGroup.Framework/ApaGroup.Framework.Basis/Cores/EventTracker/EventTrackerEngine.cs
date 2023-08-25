
using System;
using ApaGroup.Framework.Basis.EntityModels;
using ApaGroup.Framework.Basis.Enumerations;
using ApaGroup.Framework.Basis.Exceptions;
using ApaGroup.Framework.Basis.Factory;

namespace ApaGroup.Framework.Basis.Cores.EventTracker
{
    public static class EventTrackerEngine
    {
        #region Private Methods

        private static void EventTracker_OnEventTracking(object inTrackedSourceObject, string inEvent, LogType inType)
        {
            try
            {
                using (var context = new ApaLogEntities())
                {
                    var entity = new LogDataModel
                    {
                        IssueDate = DateTime.Now,
                        Type = inType.ToString(),
                        IssueContent = inEvent
                    };

                    context.LogDataModels.Add(entity);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewEventTrackerException(ex);
            }
        }

        #endregion

        #region Public Methods

        public static void Attach(IEventTracker inEventTracker)
        {
            if (inEventTracker.GetType() != typeof(EventTrackerException))
            {
                inEventTracker.OnEventTracking += EventTracker_OnEventTracking;
            }
        }

        public static void Detach(IEventTracker inEventTracker)
        {
            if (inEventTracker.GetType() != typeof(EventTrackerException))
            {
                inEventTracker.OnEventTracking -= EventTracker_OnEventTracking;
            }
        }

        #endregion
    }
}