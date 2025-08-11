using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace BOSLib
{
    /// <summary>
    /// uthv 21/02/2019 caching and turning performance
    /// </summary>
    public class BaseClassFactory
    {
        private static Assembly BOSERP;
        private static Assembly BOSComponent;
        private static Assembly BOSEntity;
        private static Assembly BOSBase;
        private static Assembly BOSLib;
        private static object AssemblyTypesLock = new object();
        private static object AssemblyControllerInstancesLock = new object();
        private static Dictionary<string, Type> AssemblyTypes = new Dictionary<string, Type>();
        //Controller co the cache dc, nhung object khac thi ko
        private static Dictionary<string, object> AssemblyControllerInstances = new Dictionary<string, object>();
        public static object GetClass(String strClassName)
        {
            var isController = strClassName.EndsWith("Controller");
            if (isController && AssemblyControllerInstances.ContainsKey(strClassName))
                return AssemblyControllerInstances[strClassName];

            Type type = null;
            if (AssemblyTypes.ContainsKey(strClassName))
                type = AssemblyTypes[strClassName];
            else
            {
                type = GetClassType(strClassName);
                if (type != null)
                {
                    lock (AssemblyTypesLock)
                    {
                        if (!AssemblyTypes.ContainsKey(strClassName))
                            AssemblyTypes.Add(strClassName, type);
                    }
                }
            }

            if (type != null)
            {
                object obj = type.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                if (isController)
                    lock (AssemblyControllerInstancesLock)
                    {
                        AssemblyControllerInstances.Add(strClassName, obj);
                    }
                return obj;
            }
            return null;
        }

        public static Type GetClassType(String strClassName)
        {
            Type type = GetClassTypeFromAssembly("EMR.exe", strClassName);
            if (type == null)
                type = GetClassTypeFromAssembly("BOSComponent.dll", strClassName);
            if (type == null)
                type = GetClassTypeFromAssembly("BOSEntity.dll", strClassName);
            if (type == null)
                type = GetClassTypeFromAssembly("BOSBase.dll", strClassName);
            if (type == null)
                type = GetClassTypeFromAssembly("BOSLib.dll", strClassName);
            return type;
        }


        private static Type GetClassTypeFromAssembly(String assemblyName, String className)
        {
            Type type = null;
            try
            {
                switch (assemblyName)
                {
                    case "EMR.exe":
                        if (BOSERP == null)
                            BOSERP = Assembly.LoadFrom(Application.StartupPath + "\\" + assemblyName);
                        return BOSERP.GetType(className);
                    case "BOSComponent.dll":
                        if (BOSComponent == null)
                            BOSComponent = Assembly.LoadFrom(Application.StartupPath + "\\" + assemblyName);
                        return BOSComponent.GetType(className);
                    case "BOSEntity.dll":
                        if (BOSEntity == null)
                            BOSEntity = Assembly.LoadFrom(Application.StartupPath + "\\" + assemblyName);
                        return BOSEntity.GetType(className);
                    case "BOSBase.dll":
                        if (BOSBase == null)
                            BOSBase = Assembly.LoadFrom(Application.StartupPath + "\\" + assemblyName);
                        return BOSBase.GetType(className);
                    case "BOSLib.dll":
                        if (BOSLib == null)
                            BOSLib = Assembly.LoadFrom(Application.StartupPath + "\\" + assemblyName);
                        return BOSLib.GetType(className);
                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }
            return type;
        }
    }
}
