using System;
using System.Collections;
using ApaGroup.Framework.Basis.Cores.EventTracker;
using ApaGroup.Framework.Basis.Enumerations;

namespace ApaGroup.Framework.Basis.Cores.Exceptions
{
    [Serializable]
    public abstract class ExceptionBase : Exception, IEventTracker
    {
        #region Constructors

        protected ExceptionBase(ExceptionArgs inArgument, bool inLogExceptionInformation = true)
            : base("", inArgument.InnerException)
        {
            EventTrackerEngine.Attach(this);

            InitializeProperties(inArgument, inLogExceptionInformation);
        }

        ~ExceptionBase()
        {
            EventTrackerEngine.Detach(this);
        }

        #endregion

        #region Private  Fields

        private readonly static Hashtable _Messages = new Hashtable
        {
            {ExceptionType.Unknown, "در روند اجرایی جاری خطایی نامشخص رخ داده است."},
            {ExceptionType.ConfigurationManagement, "در استفاده از فایل تنظیمات خطایی رخ داده است."},
            {ExceptionType.Concurrency, "اعمال تغییرات به علت تغیییرات دیگر کاربران امکان پذیر نمی باشد. اطلاعات خود را قبل از اعمال تغییرات، بروز کنید."},
            {ExceptionType.Database, "در کار با پایگاه داده خطایی رخ داده است."},
            {ExceptionType.Reflection, "در استفاده از توابع انعکاسی خطایی رخ داده است."},
            {ExceptionType.InvalidServiceAction, "عملیات درخواستی با جریان کاری مطابقت ندارد."},
            {ExceptionType.ModelValidation, "داده های ارسالی برای ثبت، مجاز نمی یاشند."},
            {ExceptionType.WorkflowActionNotFound, "عملیات در جریان کاری موجود نمی باشد."},
            {ExceptionType.WorkflowStateNotFound, "حالت در جریان کاری موجود نمی باشد."},
            {ExceptionType.Factory, "ساخت شی با خطا مواجه گردیده است."},
            {ExceptionType.TypeConversion, "روند تبدیل نوع با خطا مواجه گردیده است."},
            {ExceptionType.EventTracker, "ثبت رویداد گزارش شده، با خطا مواجه گردیده است."},
            {ExceptionType.File, "عملیات بر روی فایل با خطا مواجه گردیده است."},
            {ExceptionType.Registry, "عملیات بر روی رجیستری با خطا مواجه گردیده است."},
            {ExceptionType.GeneralIssue, " روند اجرای برنامه با خطایی با موضوع عمومی مواجه گردیده است."},
            {ExceptionType.SecurityControl, "عملیات جاری با خطای مجوز روبرو گردیده است."},
            {ExceptionType.Cache, "عملیات کشینگ اطلاعات با خطا مواجه گردیده است."}
        };

        #endregion

        #region Private Properties

        private ExceptionArgs ExceptionInformation { get; set; }

        private static Hashtable Messages
        {
            get { return _Messages; }
        }

        #endregion

        #region Private Methods

        private void InitializeProperties(ExceptionArgs inArgument, bool inLogExceptionInformation)
        {
            ExceptionInformation = inArgument;

            if (inLogExceptionInformation)
            {
                LogExceptionInformation();
            }
        }

        #endregion

        #region Protected Methods

        protected virtual void LogExceptionInformation()
        {
            if (OnEventTracking != null)
            {
                OnEventTracking(this, ToString(), LogType.Exception);
            }
        }

        #endregion

        #region Public Events

        public event EventTrackerHandler OnEventTracking;

        #endregion

        #region Public Properties

        public ExceptionBase InnerExceptionBase
        {
            get { return InnerException as ExceptionBase; }
        }

        public object OccurrenceSource
        {
            get { return Source; }
        }

        public bool HasOccurrenceSource
        {
            get { return OccurrenceSource != null; }
        }

        public Type OccurrenceSourceType
        {
            get
            {
                Type result = null;

                if (HasOccurrenceSource)
                {
                    result = OccurrenceSource.GetType();
                }

                return result;
            }
        }

        public abstract ExceptionType Type { get; }

        public override string Message
        {
            get
            {
                var result = Messages.ContainsKey(Type)
                                    ? Messages[Type].ToString()
                                    : Messages[ExceptionType.Unknown].ToString();

                return result;
            }
        }

        public string SpecialMessage
        {
            get { return ExceptionInformation.SpecialMessage; }
        }

        public object SpecialData
        {
            get { return ExceptionInformation.SpecialData; }
        }

        public string TecnicalMessage
        {
            get { return ExceptionInformation.TecnicalMessage; }
        }

        #endregion
    }
}