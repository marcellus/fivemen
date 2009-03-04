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
