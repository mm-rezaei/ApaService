using System;
using System.Collections.Generic;
using System.Reflection;
using ApaGroup.Framework.Basis.Constants;
using ApaGroup.Framework.Basis.Cores.Helpers;

namespace ApaGroup.Framework.Basis.Helpers
{
    public sealed class ReflectionHelper : HelperBase<ApaGroupFrameworkBasisConstant>
    {
        #region Public Methods

        public static object GetTypeDefaultValue(Type inType)
        {
            return Assistant.Reflection.GetTypeDefaultValue(inType);
        }

        public static void SetPropertyValue<TPropertyType>(object inObject, string inPropertyName, TPropertyType inValue)
        {
            Assistant.Reflection.SetPropertyValue(inObject, inPropertyName, inValue);
        }

        public static void SetPropertyValue<TClassType, TPropertyType>(string inPropertyName, TPropertyType inValue)
        {
            Assistant.Reflection.SetPropertyValue<TClassType, TPropertyType>(inPropertyName, inValue);
        }

        public static TPropertyType GetPropertyValue<TPropertyType>(object inObject, string inPropertyName)
        {
            return Assistant.Reflection.GetPropertyValue<TPropertyType>(inObject, inPropertyName);
        }

        public static TPropertyType GetPropertyValue<TClassType, TPropertyType>(string inPropertyName)
        {
            return Assistant.Reflection.GetPropertyValue<TClassType, TPropertyType>(inPropertyName);
        }

        public static PropertyInfo[] GetProperties<TClassType>()
        {
            return Assistant.Reflection.GetProperties<TClassType>();
        }

        public static PropertyInfo[] GetProperties(Type inClassType)
        {
            return Assistant.Reflection.GetProperties(inClassType);
        }

        public static PropertyInfo[] GetProperties<TClassType>(BindingFlags inBindingFlags)
        {
            return Assistant.Reflection.GetProperties<TClassType>(inBindingFlags);
        }

        public static PropertyInfo[] GetProperties(Type inClassType, BindingFlags inBindingFlags)
        {
            return Assistant.Reflection.GetProperties(inClassType, inBindingFlags);
        }

        public static MethodInfo[] GetMethods<TClassType>()
        {
            return Assistant.Reflection.GetMethods<TClassType>();
        }

        public static MethodInfo[] GetMethods(Type inClassType)
        {
            return Assistant.Reflection.GetMethods(inClassType);
        }

        public static MethodInfo[] GetMethods<TClassType>(BindingFlags inBindingFlags)
        {
            return Assistant.Reflection.GetMethods<TClassType>(inBindingFlags);
        }

        public static MethodInfo[] GetMethods(Type inClassType, BindingFlags inBindingFlags)
        {
            return Assistant.Reflection.GetMethods(inClassType, inBindingFlags);
        }

        public static IEnumerable<TAttributeType> GetCustomAttributes<TAttributeType, TClassType>(bool inHerit) where TAttributeType : Attribute
        {
            return Assistant.Reflection.GetCustomAttributes<TAttributeType, TClassType>(inHerit);
        }

        public static IEnumerable<Attribute> GetCustomAttributes<TClassType>(bool inHerit)
        {
            return Assistant.Reflection.GetCustomAttributes<TClassType>(inHerit);
        }

        public static IEnumerable<TAttributeType> GetCustomAttributes<TAttributeType>(Type inClassType, bool inHerit) where TAttributeType : Attribute
        {
            return Assistant.Reflection.GetCustomAttributes<TAttributeType>(inClassType, inHerit);
        }

        public static IEnumerable<Attribute> GetCustomAttributes(Type inClassType, bool inHerit)
        {
            return Assistant.Reflection.GetCustomAttributes(inClassType, inHerit);
        }

        public static IEnumerable<TAttributeType> GetCustomAttributes<TAttributeType>(PropertyInfo inPropertyInfo, bool inHerit) where TAttributeType : Attribute
        {
            return Assistant.Reflection.GetCustomAttributes<TAttributeType>(inPropertyInfo, inHerit);
        }

        public static IEnumerable<Attribute> GetCustomAttributes(PropertyInfo inPropertyInfo, bool inHerit)
        {
            return Assistant.Reflection.GetCustomAttributes(inPropertyInfo, inHerit);
        }

        public static IEnumerable<TAttributeType> GetCustomAttributes<TAttributeType>(MethodInfo inMethodInfo, bool inHerit) where TAttributeType : Attribute
        {
            return Assistant.Reflection.GetCustomAttributes<TAttributeType>(inMethodInfo, inHerit);
        }

        public static IEnumerable<Attribute> GetCustomAttributes(MethodInfo inMethodInfo, bool inHerit)
        {
            return Assistant.Reflection.GetCustomAttributes(inMethodInfo, inHerit);
        }

        public static Type GetTypeByName(string inTypeName)
        {
            return Assistant.Reflection.GetTypeByName(inTypeName);
        }

        public static Type GetGenericTypeByName(string inTypeName, params Type[] inGenericParameters)
        {
            return Assistant.Reflection.GetGenericTypeByName(inTypeName, inGenericParameters);
        }

        public static Type GetGenericType(Type inType, params Type[] inGenericParameters)
        {
            return Assistant.Reflection.GetGenericType(inType, inGenericParameters);
        }

        public static TClassType GetNewInstance<TClassType>() where TClassType : class
        {
            return Assistant.Reflection.GetNewInstance<TClassType>();
        }

        public static object GetNewInstance(Type inClassType, params object[] inConstructorParameters)
        {
            return Assistant.Reflection.GetNewInstance(inClassType, inConstructorParameters);
        }

        public static object GetNewInstance(string inClassTypeName)
        {
            return Assistant.Reflection.GetNewInstance(inClassTypeName);
        }

        public static object InvokeInstanceMethod<TClassType>(TClassType inObject, string inMethodName, params object[] inParameters)
        {
            return Assistant.Reflection.InvokeInstanceMethod(inObject, inMethodName, inParameters);
        }

        public static object InvokeInstanceMethod(Type inClassType, object inObject, string inMethodName, params object[] inParameters)
        {
            return Assistant.Reflection.InvokeInstanceMethod(inClassType, inObject, inMethodName, inParameters);
        }

        public static object InvokeStaticMethod<TClassType>(string inMethodName, params object[] inParameters)
        {
            return Assistant.Reflection.InvokeStaticMethod<TClassType>(inMethodName, inParameters);
        }

        public static object InvokeStaticMethod(Type inClassType, string inMethodName, params object[] inParameters)
        {
            return Assistant.Reflection.InvokeStaticMethod(inClassType, inMethodName, inParameters);
        }

        public static object InvokeGenericInstanceMethod<TClassType>(TClassType inObject, string inMethodName, Type[] inGenericParameterType, params object[] inParameters)
        {
            return Assistant.Reflection.InvokeGenericInstanceMethod(inObject, inMethodName, inGenericParameterType,
                                                                    inParameters);
        }

        public static object InvokeGenericInstanceMethod(Type inClassType, object inObject, string inMethodName, Type[] inGenericParameterType, params object[] inParameters)
        {
            return Assistant.Reflection.InvokeGenericInstanceMethod(inClassType, inObject, inMethodName, inGenericParameterType,
                                                                    inParameters);
        }

        public static object InvokeGenericStaticMethod<TClassType>(string inMethodName, Type[] inGenericParameterType, params object[] inParameters)
        {
            return Assistant.Reflection.InvokeGenericStaticMethod<TClassType>(inMethodName, inGenericParameterType,
                inParameters);
        }

        public static object InvokeGenericStaticMethod(Type inClassType, string inMethodName,
            Type[] inGenericParameterType, params object[] inParameters)
        {
            return Assistant.Reflection.InvokeGenericStaticMethod(inClassType, inMethodName, inGenericParameterType,
                inParameters);
        }

        #endregion
    }
}