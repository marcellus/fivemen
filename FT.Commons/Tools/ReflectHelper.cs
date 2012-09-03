using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 反射的工具类，待实现
    /// </summary>
    public class ReflectHelper : BaseHelper
    {
        private static string exePath;

        private ReflectHelper()
        {
        }

        public static object GetObjectPropertyObject(object obj, string property)
        {
            Type type = obj.GetType();
            object value = null;
            value = type.GetProperty(property, BindingFlags.IgnoreCase
                 | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj, null);
            return value;


        }

        public static string GetObjectProperty(object obj, string property)
        {
            Type type = obj.GetType();
            object value = null;
            value = type.GetProperty(property, BindingFlags.IgnoreCase 
                 | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj,null);
            return TransObjectField(value);
            

        }


        /// <summary>
        /// 把实体对象的属性转换成要保存的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string TransObjectField(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            if (value is DateTime)
            {
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            /*if (value is Enum)
            {
                return ((Enum)value).ToString("yyyy-MM-dd HH:mm:ss");
            }*/
            else
            {
                return value.ToString();
            }
        }

        public static void WriteObjectProperty(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] property =type.GetProperties();
            object value = null;
            for (int i = 0; i < property.Length; i++)
            {

                value = property[i].GetValue(obj, null);
              //  value = type.GetProperty(property[i].Name, BindingFlags.IgnoreCase
             //  | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj);
               Console.WriteLine("属性：" + property[i].Name + " 类型：" + property[i].PropertyType.ToString() + " 值：" + value);
            }
        }

        public static void WriteObjectField(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] property = type.GetFields();
            object value = null;
            for (int i = 0; i < property.Length; i++)
            {
                value = property[i].GetValue(obj);
                Console.WriteLine("属性：" + property[i].Name + " 类型：" + property[i].FieldType.ToString() + " 值：" + value);
                //  value = type.GetProperty(field, BindingFlags.IgnoreCase
                //  | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj);
            }
        }

        public static string GetObjectField(object obj, string field)
        {
            Type type = obj.GetType();
            object value = null;
            value = type.GetField(field, BindingFlags.IgnoreCase
                 | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj);
            return TransObjectField(value);

        }

        public static void ShowAssembly(Assembly assembly)
        {
                Console.WriteLine("Assembly FullName:" + assembly.FullName);
                Console.WriteLine("Assembly Location:" + assembly.Location);
                Console.WriteLine("Assembly CodeBase:"+assembly.CodeBase);
                Console.WriteLine("Assembly EscapedCodeBase:" + assembly.EscapedCodeBase);
                //Console.WriteLine("Assembly EntryPoint:" + assembly.EntryPoint.DeclaringType);
                Module[] modules = assembly.GetLoadedModules();
                foreach(Module module in modules)
                {
                   ShowModule(module);
                }

                Console.WriteLine("Assembly GlobalAssemblyCache:" + assembly.GlobalAssemblyCache);
                Console.WriteLine("Assembly ImageRuntimeVersion:" + assembly.ImageRuntimeVersion);
                Console.WriteLine("Assembly ReflectionOnly:" + assembly.ReflectionOnly);
                //Console.WriteLine("Assembly Location:" + assembly.);
                //Console.WriteLine("Assembly Location:" + assembly.Location);
        }

        public static void ShowModule(Module module)
        {
            Console.WriteLine("\tModule Name:" + module.Name);
            Console.WriteLine("\tModule ScopeName:" + module.ScopeName);
            Console.WriteLine("\tModule ModuleVersionId:" + module.ModuleVersionId);
            Console.WriteLine("\tModule MetadataToken:" + module.MetadataToken);
            Console.WriteLine("\tModule MDStreamVersion:" + module.MDStreamVersion);
            Console.WriteLine("\tModule FullyQualifiedName:" + module.FullyQualifiedName);
        }

        public static void ShowAllAssembly()
        {
            Assembly[] assemblies=AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ass in assemblies)
            {
                ShowAssembly(ass);
            }
        }

        public static string GetStartUpPath(string relativePath)
        {
            return GetExePath()  + relativePath;
        }

        /// <summary>
        /// 获取程序集所执行的路径文件夹
        /// </summary>
        /// <returns>程序集所在的执行路径</returns>
        public static string GetExePath()
        {
            if (exePath == null || exePath == string.Empty)
            {
                string temp = Assembly.GetExecutingAssembly().Location;
                int i = temp.LastIndexOf("\\");
                if (i != -1)
                {
                    exePath = temp.Substring(0, i + 1);
                }
                else
                {
                    exePath = temp;
                }
            }
            Debug("获取的程序集执行路径文件夹为->"+exePath);
            return exePath;
        }

       
        /// <summary>
        /// 创建对应实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>对应实例</returns>
        public static object CreateInstance(string type)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug("开始创建类型" + type + "的实例");
            }
            Type tmp =null;
            
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("查找类型"+type+"在程序集"+assemblies[i].FullName);
                }
                tmp = assemblies[i].GetType(type);
                if (tmp != null)
                {
                    return assemblies[i].CreateInstance(type);

                }
                else
                {
                    if (log.IsDebugEnabled)
                    {
                        log.Debug("没有查找到合适的类型！");
                    }
                }
            }
            return null;
            //return Assembly.GetExecutingAssembly().CreateInstance(type);
        }


        /// <summary>
        /// 创建对应实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>对应实例</returns>
        public static object CreateInstance(Type type)
        {
            return CreateInstance(type.FullName);
        }

        
    }
}
