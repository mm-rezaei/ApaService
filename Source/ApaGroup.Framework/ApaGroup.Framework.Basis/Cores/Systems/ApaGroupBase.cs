using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Basis.Cores.EventTracker;
using ApaGroup.Framework.Basis.Enumerations;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Locks;

namespace ApaGroup.Framework.Basis.Cores.Systems
{
    public abstract class ApaGroupBase<TConstantType> : IEventTracker
        where TConstantType : ConstantBase, new()
    {
        #region Constructors

        protected ApaGroupBase()
        {
            EventTrackerEngine.Attach(this);
        }

        ~ApaGroupBase()
        {
            EventTrackerEngine.Detach(this);
        }

        #endregion

        #region Protected Methods

        protected void EventTracking(string inEvent)
        {
            if (OnEventTracking != null)
            {
                OnEventTracking(this, inEvent, LogType.None);
            }
        }

        #endregion

        #region Protected Class

        protected static class Assistant
        {
            #region Private Fields

            private readonly static TConstantType _Constants = new TConstantType();

            #endregion

            #region Public Properties

            public static TConstantType ConstantValues
            {
                get { return _Constants; }
            }

            #endregion

            #region Public Class

            public static class Configuration
            {
                #region Constructors

                static Configuration()
                {
                    InitializeProperties();
                }

                #endregion

                #region Private Fields

                private static readonly Hashtable _Configurations = new Hashtable();

                #endregion

                #region Private Properties

                private static string ConfigurationFileName
                {
                    get { return "ApaGroupConfigurations.config"; }
                }

                public static ConfigXmlDocument Document { get; private set; }

                private static Hashtable Configurations
                {
                    get { return _Configurations; }
                }

                #endregion

                #region Private Methods

                private static void CheckExistFile()
                {
                    if (!File.Exists(ConfigurationFileName))
                    {
                        var fileStream =
                            File.Create(Path.Combine(Directory.GetCurrentDirectory(), ConfigurationFileName));

                        var streamWriter = new StreamWriter(fileStream);

                        streamWriter.WriteLine("<" + ConfigurationFileName.Replace(".config", "") + ">");
                        streamWriter.Write("</" + ConfigurationFileName.Replace(".config", "") + ">");

                        streamWriter.Close();
                    }
                }

                private static void LoadConfigurationFile()
                {
                    CheckExistFile();

                    Document = new ConfigXmlDocument();

                    Document.Load(Path.Combine(Directory.GetCurrentDirectory(), ConfigurationFileName));
                }

                private static void SaveConfigurationFile()
                {
                    Document.Save(Path.Combine(Directory.GetCurrentDirectory(), ConfigurationFileName));
                }

                private static string NormalizeConfigurationKey(string inConfigurationKey)
                {
                    var result = inConfigurationKey.ToLower().Replace(" ", "");

                    return result;
                }

                #endregion

                #region Public Methods

                public static void InitializeProperties()
                {
                    try
                    {
                        LoadConfigurationFile();

                        for (var index = 0; index < Document.ChildNodes.Count; index++)
                        {
                            var key = NormalizeConfigurationKey(Document.ChildNodes[index].Name);
                            var value = "";

                            var xmlAttributeCollection = Document.ChildNodes[index].Attributes;

                            if (xmlAttributeCollection != null)
                            {
                                value = xmlAttributeCollection["value"].Value;
                            }

                            Configurations[key] = value;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewConfigurationManagementException(ex);
                    }
                }

                public static bool Contains(string inConfigurationKey)
                {
                    var result = Configurations.ContainsKey(NormalizeConfigurationKey(inConfigurationKey));

                    return result;
                }

                public static TConfigurationType GetConfiguration<TConfigurationType>(string inConfigurationKey)
                {
                    var result = default(TConfigurationType);

                    if (Contains(inConfigurationKey))
                    {

                        result = (TConfigurationType)Configurations[NormalizeConfigurationKey(inConfigurationKey)];
                    }

                    return result;
                }

                public static void SetConfiguration<TConfigurationType>(string inConfigurationKey,
                                                                        TConfigurationType inConfigurationValue)
                {
                    try
                    {
                        if (Contains(inConfigurationKey))
                        {
                            XmlNode xmlNode = null;

                            for (var index = 0; index < Document.ChildNodes[0].ChildNodes.Count; index++)
                            {
                                if (NormalizeConfigurationKey(Document.ChildNodes[0].ChildNodes[index].Name) ==
                                    NormalizeConfigurationKey(inConfigurationKey))
                                {
                                    xmlNode = Document.ChildNodes[0].ChildNodes[index];
                                    break;
                                }
                            }

                            if (xmlNode != null)
                            {
                                xmlNode.Value = inConfigurationValue.ToString();
                            }
                        }
                        else
                        {
                            XmlNode node = Document.CreateElement(inConfigurationKey);

                            var attribute = Document.CreateAttribute("value");
                            attribute.Value = inConfigurationValue.ToString();

                            if (node.Attributes != null)
                            {
                                node.Attributes.Append(attribute);
                            }

                            Document.ChildNodes[0].AppendChild(node);
                        }

                        SaveConfigurationFile();

                        Configurations[NormalizeConfigurationKey(inConfigurationKey)] = inConfigurationValue;
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewConfigurationManagementException(ex);
                    }
                }

                #endregion
            }

            public static class Convertion
            {
                #region Public Methods

                public static TCastType GetCastValue<TCastType>(object inObject)
                {
                    TCastType result;

                    try
                    {
                        result = (TCastType)inObject;
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewTypeConversionException(ex);
                    }

                    return result;
                }

                public static byte ToByte(object inObject)
                {
                    byte result;

                    try
                    {
                        result = Convert.ToByte(inObject);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewTypeConversionException(ex);
                    }

                    return result;
                }

                public static int ToInt32(object inObject)
                {
                    int result;

                    try
                    {
                        result = Convert.ToInt32(inObject);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewTypeConversionException(ex);
                    }

                    return result;
                }

                public static double ToDouble(object inObject)
                {
                    double result;

                    try
                    {
                        result = Convert.ToDouble(inObject);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewTypeConversionException(ex);
                    }

                    return result;
                }

                public static float ToFloat(object inObject)
                {
                    float result;

                    try
                    {
                        result = Convert.ToSingle(inObject);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewTypeConversionException(ex);
                    }

                    return result;
                }

                public static byte[] ToByteArray(string inString)
                {
                    return Encoding.UTF8.GetBytes(inString);
                }

                #endregion
            }

            public static class Comparison
            {
                #region Private Class

                private abstract class LetterComparisonBase
                {
                    #region Private Fields

                    private static readonly InternalLock _InternalLock = new InternalLock();

                    #endregion

                    #region Protected Properties

                    protected static InternalLock InternalLock
                    {
                        get { return _InternalLock; }
                    }

                    #endregion

                    #region Protected Methods

                    protected HashSet<char> GetHashSet(string inLettersString)
                    {
                        var result = new HashSet<char>();

                        foreach (var letter in inLettersString)
                        {
                            result.Add(letter);
                        }

                        return result;
                    }

                    #endregion

                    #region Public Methods

                    public abstract bool IsValidLetter(char inLetter);

                    #endregion
                }

                private class WhiteSpaceComparison : LetterComparisonBase
                {
                    #region Private Fields

                    private static readonly LetterComparisonBase _Instance = new WhiteSpaceComparison();

                    #endregion

                    #region Public Properties

                    public static LetterComparisonBase Instance
                    {
                        get { return _Instance; }
                    }

                    #endregion

                    #region Public Methods

                    public override bool IsValidLetter(char inLetter)
                    {
                        var result = char.IsWhiteSpace(inLetter);

                        return result;
                    }

                    #endregion
                }

                private class NumeralComparison : LetterComparisonBase
                {
                    #region Private Fields

                    private static readonly LetterComparisonBase _Instance = new NumeralComparison();

                    #endregion

                    #region Public Properties

                    public static LetterComparisonBase Instance
                    {
                        get { return _Instance; }
                    }

                    #endregion

                    #region Public Methods

                    public override bool IsValidLetter(char inLetter)
                    {
                        var result = ('0' <= inLetter && inLetter <= '9') || ('٠' <= inLetter && inLetter <= '٩');

                        return result;
                    }

                    #endregion
                }

                private class PersianLetterComparison : LetterComparisonBase
                {
                    #region Private Fields

                    private static HashSet<char> _LetterCollection;

                    private static readonly LetterComparisonBase _Instance = new PersianLetterComparison();

                    #endregion

                    #region private Properties

                    private HashSet<char> LetterCollection
                    {
                        get
                        {
                            if (_LetterCollection == null)
                            {
                                lock (InternalLock)
                                {
                                    if (_LetterCollection == null)
                                    {
                                        _LetterCollection = GetHashSet("آأؤإئابةتثجحخدذرزسشصضطظعغـفقكلمنهوىيًٌٍَُِّْٕٖٜٓٔٗ٘ٙٚٛٝٞ٫٬٭ٮٯٰٱٲٳٴٵٶٷٸٹٺٻټٽپٿڀځڂڃڄڅچڇڈډڊڋڌڍڎڏڐڑڒړڔڕږڗژڙښڛڜڝڞڟڠڡڢڣڤڥڦڧڨکڪګڬڭڮگڰڱڲڳڴڵڶڷڸڹںڻڼڽھڿۀہۂۃۄۅۆۇۈۉۊۋی");
                                    }
                                }
                            }

                            return _LetterCollection;
                        }
                    }

                    #endregion

                    #region Public Properties

                    public static LetterComparisonBase Instance
                    {
                        get { return _Instance; }
                    }

                    #endregion

                    #region Public Methods

                    public override bool IsValidLetter(char inLetter)
                    {
                        var result = LetterCollection.Contains(inLetter);

                        return result;
                    }

                    #endregion
                }

                private class EnglishLetterComparison : LetterComparisonBase
                {
                    #region Private Fields

                    private static readonly LetterComparisonBase _Instance = new EnglishLetterComparison();

                    #endregion

                    #region Public Properties

                    public static LetterComparisonBase Instance
                    {
                        get { return _Instance; }
                    }

                    #endregion

                    #region Public Methods

                    public override bool IsValidLetter(char inLetter)
                    {
                        var result = ('a' <= inLetter && inLetter <= 'z') || ('A' <= inLetter && inLetter <= 'Z');

                        return result;
                    }

                    #endregion
                }

                #endregion

                #region Public Methods

                public static bool BinaryArrayEquals(byte[] inBinaryValue1, byte[] inBinaryValue2)
                {
                    var result = true;

                    if (!ReferenceEquals(inBinaryValue1, inBinaryValue2))
                    {
                        var array1 = inBinaryValue1;
                        var array2 = inBinaryValue2;

                        if (array1 != null && array2 != null)
                        {
                            if (array1.Length != array2.Length)
                            {
                                result = false;
                            }
                            else
                            {
                                result = !array1.Where((t, i) => t != array2[i]).Any();
                            }
                        }
                        else
                        {
                            result = false;
                        }
                    }

                    return result;
                }

                public static bool IsSpesificLetter(char inLetter, LetterType inLetterType)
                {
                    var result = WhiteSpaceComparison.Instance.IsValidLetter(inLetter);

                    if (!result)
                    {
                        if ((inLetterType & LetterType.Numeral) == LetterType.Numeral)
                        {
                            result = NumeralComparison.Instance.IsValidLetter(inLetter);
                        }
                    }

                    if (!result)
                    {
                        if ((inLetterType & LetterType.PersianLetter) == LetterType.PersianLetter)
                        {
                            result = PersianLetterComparison.Instance.IsValidLetter(inLetter);
                        }
                    }

                    if (!result)
                    {
                        if ((inLetterType & LetterType.EnglishLetter) == LetterType.EnglishLetter)
                        {
                            result = EnglishLetterComparison.Instance.IsValidLetter(inLetter);
                        }
                    }

                    return result;
                }

                #endregion
            }

            public static class IranDateTime
            {
                #region Private Fields

                private static int? _Days;

                private static int? _Hours;

                private static int? _Minutes;

                private static int? _Seconds;

                #endregion

                #region Private Properties

                private static int Days
                {
                    get
                    {
                        if (!_Days.HasValue)
                        {
                            _Days =
                                Configuration.GetConfiguration<int>(
                                    ApaGroupFrameworkBasisConstant.Instance.IranDateTimeSynchronizedDay);
                        }

                        return _Days.Value;
                    }
                }

                private static int Hours
                {
                    get
                    {
                        if (!_Hours.HasValue)
                        {
                            _Hours =
                                Configuration.GetConfiguration<int>(
                                    ApaGroupFrameworkBasisConstant.Instance.IranDateTimeSynchronizedHour);
                        }

                        return _Hours.Value;
                    }
                }

                private static int Minutes
                {
                    get
                    {
                        if (!_Minutes.HasValue)
                        {
                            _Minutes =
                                Configuration.GetConfiguration<int>(
                                    ApaGroupFrameworkBasisConstant.Instance.IranDateTimeSynchronizedMinute);
                        }

                        return _Minutes.Value;
                    }
                }

                private static int Seconds
                {
                    get
                    {
                        if (!_Seconds.HasValue)
                        {
                            _Seconds =
                                Configuration.GetConfiguration<int>(
                                    ApaGroupFrameworkBasisConstant.Instance.IranDateTimeSynchronizedSecond);
                        }

                        return _Seconds.Value;
                    }
                }

                #endregion

                #region Public Properties

                public static DateTime LocalDateTime
                {
                    get { return DateTime.Now; }
                }

                public static DateTime TehranDateTime
                {
                    get { return ToIranDateTime(DateTime.Now); }
                }

                #endregion

                #region Public Methods

                public static void InitializeProperties()
                {
                    _Days = null;
                    _Hours = null;
                    _Minutes = null;
                    _Seconds = null;
                }

                public static DateTime ToIranDateTime(DateTime inLocalDateTime)
                {
                    var result =
                        inLocalDateTime.AddDays(Days).AddHours(Hours).AddMinutes(Minutes).AddSeconds(Seconds);

                    return result;
                }

                public static DateTime ToLocalDateTime(DateTime inIranDateTime)
                {
                    var result =
                        inIranDateTime.AddDays(-1 * Days).AddHours(-1 * Hours).AddMinutes(-1 * Minutes).AddSeconds(-1 * Seconds);

                    return result;
                }

                #endregion
            }

            public static class Reflection
            {
                #region Public Methods

                public static object GetTypeDefaultValue(Type inType)
                {
                    object result = null;

                    if (inType.IsValueType)
                    {
                        result = Activator.CreateInstance(inType);
                    }

                    return result;
                }

                public static void SetPropertyValue<TPropertyType>(object inObject, string inPropertyName, TPropertyType inValue)
                {
                    try
                    {
                        var propertyInfo = inObject.GetType()
                            .GetProperty(inPropertyName,
                                BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);

                        propertyInfo.SetValue(inObject, inValue);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }
                }

                public static void SetPropertyValue<TClassType, TPropertyType>(string inPropertyName, TPropertyType inValue)
                {
                    try
                    {
                        var propertyInfo = typeof(TClassType)
                            .GetProperty(inPropertyName,
                                BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);

                        propertyInfo.SetValue(null, inValue);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }
                }

                public static TPropertyType GetPropertyValue<TPropertyType>(object inObject, string inPropertyName)
                {
                    TPropertyType result;

                    try
                    {
                        result =
                            (TPropertyType)
                                inObject.GetType()
                                    .GetProperty(inPropertyName,
                                        BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance)
                                    .GetValue(inObject);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static TPropertyType GetPropertyValue<TClassType, TPropertyType>(string inPropertyName)
                {
                    TPropertyType result;

                    try
                    {
                        result =
                            (TPropertyType)
                                typeof(TClassType)
                                    .GetProperty(inPropertyName,
                                        BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static)
                                    .GetValue(null);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static PropertyInfo[] GetProperties<TClassType>()
                {
                    return GetProperties(typeof(TClassType));
                }

                public static PropertyInfo[] GetProperties(Type inClassType)
                {
                    return GetProperties(inClassType, BindingFlags.Default);
                }

                public static PropertyInfo[] GetProperties<TClassType>(BindingFlags inBindingFlags)
                {
                    return GetProperties(typeof(TClassType), inBindingFlags);
                }

                public static PropertyInfo[] GetProperties(Type inClassType, BindingFlags inBindingFlags)
                {
                    PropertyInfo[] result;

                    try
                    {
                        result = inClassType.GetProperties(inBindingFlags);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static MethodInfo[] GetMethods<TClassType>()
                {
                    return GetMethods(typeof(TClassType));
                }

                public static MethodInfo[] GetMethods(Type inClassType)
                {
                    return GetMethods(inClassType, BindingFlags.Default);
                }

                public static MethodInfo[] GetMethods<TClassType>(BindingFlags inBindingFlags)
                {
                    return GetMethods(typeof(TClassType), inBindingFlags);
                }

                public static MethodInfo[] GetMethods(Type inClassType, BindingFlags inBindingFlags)
                {
                    MethodInfo[] result;

                    try
                    {
                        result = inClassType.GetMethods(inBindingFlags);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static IEnumerable<TAttributeType> GetCustomAttributes<TAttributeType, TClassType>(bool inHerit) where TAttributeType : Attribute
                {
                    IEnumerable<TAttributeType> result;

                    try
                    {
                        result = typeof(TClassType).GetCustomAttributes<TAttributeType>(inHerit);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static IEnumerable<Attribute> GetCustomAttributes<TClassType>(bool inHerit)
                {
                    IEnumerable<Attribute> result;

                    try
                    {
                        result = typeof(TClassType).GetCustomAttributes<Attribute>(inHerit);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static IEnumerable<TAttributeType> GetCustomAttributes<TAttributeType>(Type inClassType, bool inHerit) where TAttributeType : Attribute
                {
                    IEnumerable<TAttributeType> result;

                    try
                    {
                        result = inClassType.GetCustomAttributes<TAttributeType>(inHerit);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static IEnumerable<Attribute> GetCustomAttributes(Type inClassType, bool inHerit)
                {
                    IEnumerable<Attribute> result;

                    try
                    {
                        result = inClassType.GetCustomAttributes<Attribute>(inHerit);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static IEnumerable<TAttributeType> GetCustomAttributes<TAttributeType>(PropertyInfo inPropertyInfo, bool inHerit) where TAttributeType : Attribute
                {
                    IEnumerable<TAttributeType> result;

                    try
                    {
                        result = inPropertyInfo.GetCustomAttributes<TAttributeType>(inHerit);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static IEnumerable<Attribute> GetCustomAttributes(PropertyInfo inPropertyInfo, bool inHerit)
                {
                    IEnumerable<Attribute> result;

                    try
                    {
                        result = inPropertyInfo.GetCustomAttributes<Attribute>(inHerit);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static IEnumerable<TAttributeType> GetCustomAttributes<TAttributeType>(MethodInfo inMethodInfo, bool inHerit) where TAttributeType : Attribute
                {
                    IEnumerable<TAttributeType> result;

                    try
                    {
                        result = inMethodInfo.GetCustomAttributes<TAttributeType>(inHerit);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static IEnumerable<Attribute> GetCustomAttributes(MethodInfo inMethodInfo, bool inHerit)
                {
                    IEnumerable<Attribute> result;

                    try
                    {
                        result = inMethodInfo.GetCustomAttributes<Attribute>(inHerit);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static Type GetTypeByName(string inTypeName)
                {
                    Type result;

                    try
                    {
                        result = Type.GetType(inTypeName, true, true);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static Type GetGenericTypeByName(string inTypeName, params Type[] inGenericParameters)
                {
                    Type result = null;

                    try
                    {
                        var typeName = inTypeName;

                        if (inGenericParameters != null)
                        {
                            typeName += "`" + inGenericParameters.Length;
                        }

                        var type = Type.GetType(typeName);

                        if (type != null)
                        {
                            result = GetGenericType(type, inGenericParameters);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static Type GetGenericType(Type inType, params Type[] inGenericParameters)
                {
                    Type result = null;

                    try
                    {
                        if (inType != null)
                        {
                            result = inGenericParameters != null ? inType.MakeGenericType(inGenericParameters) : inType.MakeGenericType();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static TClassType GetNewInstance<TClassType>() where TClassType : class
                {
                    TClassType result;

                    try
                    {
                        result = Activator.CreateInstance<TClassType>();
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static object GetNewInstance(Type inClassType, params object[] inConstructorParameters)
                {
                    object result;

                    try
                    {
                        result = inConstructorParameters == null ? Activator.CreateInstance(inClassType) : Activator.CreateInstance(inClassType, inConstructorParameters);
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static object GetNewInstance(string inClassTypeName)
                {
                    object result;

                    try
                    {
                        result = Activator.CreateInstance(GetTypeByName(inClassTypeName));
                    }
                    catch (Exception ex)
                    {
                        throw ExceptionFactory.GetNewReflectionException(ex);
                    }

                    return result;
                }

                public static object InvokeInstanceMethod<TClassType>(TClassType inObject, string inMethodName, params object[] inParameters)
                {
                    return InvokeInstanceMethod(typeof(TClassType), inObject, inMethodName, inParameters);
                }

                public static object InvokeInstanceMethod(Type inClassType, object inObject, string inMethodName, params object[] inParameters)
                {
                    object result;

                    var instanceMethod =
                        GetMethods(inClassType, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance)
                            .FirstOrDefault(
                                method =>
                                method.Name == inMethodName && method.GetParameters().Length == inParameters.Length);

                    if (instanceMethod != null)
                    {
                        result = instanceMethod.Invoke(inObject, inParameters);
                    }
                    else
                    {
                        throw ExceptionFactory.GetNewReflectionException(null,
                            "Method '" + inMethodName + "' not found.");
                    }

                    return result;
                }

                public static object InvokeStaticMethod<TClassType>(string inMethodName, params object[] inParameters)
                {
                    return InvokeStaticMethod(typeof(TClassType), inMethodName, inParameters);
                }

                public static object InvokeStaticMethod(Type inClassType, string inMethodName, params object[] inParameters)
                {
                    object result;

                    var staticMethod =
                        GetMethods(inClassType, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static)
                            .FirstOrDefault(
                                method =>
                                method.Name == inMethodName && method.GetParameters().Length == inParameters.Length);

                    if (staticMethod != null)
                    {
                        result = staticMethod.Invoke(null, inParameters);
                    }
                    else
                    {
                        throw ExceptionFactory.GetNewReflectionException(null,
                            "Static method '" + inMethodName + "' not found.");
                    }

                    return result;
                }

                public static object InvokeGenericInstanceMethod<TClassType>(TClassType inObject, string inMethodName, Type[] inGenericParameterType, params object[] inParameters)
                {
                    return InvokeGenericInstanceMethod(typeof(TClassType), inObject, inMethodName,
                                                       inGenericParameterType, inParameters);
                }

                public static object InvokeGenericInstanceMethod(Type inClassType, object inObject, string inMethodName, Type[] inGenericParameterType, params object[] inParameters)
                {
                    object result;

                    var genericInstanceMethod =
                        GetMethods(inClassType, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance)
                            .FirstOrDefault(
                                method =>
                                method.Name == inMethodName && method.GetParameters().Length == inParameters.Length && method.IsGenericMethod);

                    if (genericInstanceMethod != null)
                    {
                        genericInstanceMethod = genericInstanceMethod.MakeGenericMethod(inGenericParameterType);
                        result = genericInstanceMethod.Invoke(inObject, inParameters);
                    }
                    else
                    {
                        throw ExceptionFactory.GetNewReflectionException(null,
                            "Generic method '" + inMethodName + "' not found.");
                    }

                    return result;
                }

                public static object InvokeGenericStaticMethod<TClassType>(string inMethodName, Type[] inGenericParameterType, params object[] inParameters)
                {
                    return InvokeGenericStaticMethod(typeof(TClassType), inMethodName,
                                                       inGenericParameterType, inParameters);
                }

                public static object InvokeGenericStaticMethod(Type inClassType, string inMethodName, Type[] inGenericParameterType, params object[] inParameters)
                {
                    object result;

                    var genericInstanceMethod =
                        GetMethods(inClassType, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static)
                            .FirstOrDefault(
                                method =>
                                method.Name == inMethodName && method.GetParameters().Length == inParameters.Length && method.IsGenericMethod);

                    if (genericInstanceMethod != null)
                    {
                        genericInstanceMethod = genericInstanceMethod.MakeGenericMethod(inGenericParameterType);
                        result = genericInstanceMethod.Invoke(null, inParameters);
                    }
                    else
                    {
                        throw ExceptionFactory.GetNewReflectionException(null,
                            "Generic method '" + inMethodName + "' not found.");
                    }

                    return result;
                }

                #endregion
            }

            public static class SafeExecution
            {
                #region Public Methods

                public static void DoSafe(Action inAction)
                {
                    try
                    {
                        inAction();
                    }
                    catch
                    {
                        // Nothing
                    }
                }

                public static void DoSafe<TInputType>(Action<TInputType> inAction, TInputType inInput)
                {
                    try
                    {
                        inAction(inInput);
                    }
                    catch
                    {
                        // Nothing
                    }
                }

                public static void DoSafe<TInput1Type, TInput2Type>(Action<TInput1Type, TInput2Type> inAction, TInput1Type inInput1, TInput2Type inInput2)
                {
                    try
                    {
                        inAction(inInput1, inInput2);
                    }
                    catch
                    {
                        // Nothing
                    }
                }

                public static TOutputType DoSafe<TOutputType>(Func<TOutputType> inFunction)
                {
                    var result = default(TOutputType);

                    try
                    {
                        result = inFunction();
                    }
                    catch
                    {
                        // Nothing
                    }

                    return result;
                }

                public static TOutputType DoSafe<TInputType, TOutputType>(Func<TInputType, TOutputType> inFunction, TInputType inInput)
                {
                    var result = default(TOutputType);

                    try
                    {
                        result = inFunction(inInput);
                    }
                    catch
                    {
                        // Nothing
                    }

                    return result;
                }

                public static TOutputType DoSafe<TInput1Type, TInput2Type, TOutputType>(Func<TInput1Type, TInput2Type, TOutputType> inFunction, TInput1Type inInput1, TInput2Type inInput2)
                {
                    var result = default(TOutputType);

                    try
                    {
                        result = inFunction(inInput1, inInput2);
                    }
                    catch
                    {
                        // Nothing
                    }

                    return result;
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Public Events

        public event EventTrackerHandler OnEventTracking;

        #endregion
    }
}