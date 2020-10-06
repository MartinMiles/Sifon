using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;

namespace Sifon.Shared.Metacode
{
    internal class DynamicCodeRunner
    {
        public static dynamic RunWithClassicSharpCodeProvider(string type, string method, object[] parameters)
        {
            var compiler = new Microsoft.CSharp.CSharpCodeProvider().CreateCompiler();

            var parms = new CompilerParameters();
            parms.ReferencedAssemblies.Add("System.dll");
            parms.ReferencedAssemblies.Add("System.Core.dll");
            parms.ReferencedAssemblies.Add(typeof(Form).Assembly.Location);
            parms.GenerateInMemory = true;

            string assemblyPath = Assembly.GetExecutingAssembly().Location.Replace("\\", "\\\\");

            var classCode = @"
using System;
using System.Reflection;
using System.Windows.Forms;

namespace DynamicNamespace
{
    public class DynamicClass
    {
        public string ExecuteDynamicMethod(string assemblyPath, string type, string method, object[] parameters) 
        {
            Assembly a = null;
            a = Assembly.LoadFrom(assemblyPath); 

            Type classType = a.GetType(type);
            object obj = Activator.CreateInstance(classType);
            MethodInfo mi = classType.GetMethod(method);
            string str123 = (string) mi.Invoke(obj, parameters);
            return str123;  
        }
    }
}";
            var compilerResults = compiler.CompileAssemblyFromSource(parms, classCode);
            if (compilerResults.Errors.Count > 0)
            {
                Console.WriteLine("*** Compilation Errors");
                foreach (var error in compilerResults.Errors)
                {
                    Console.WriteLine("- " + error);

                    return null;
                }
            }
            
            var assembly = compilerResults.CompiledAssembly;
            dynamic inst = assembly.CreateInstance("DynamicNamespace.DynamicClass");
            return inst.ExecuteDynamicMethod(assemblyPath, type, method, parameters);
        }
    }
}