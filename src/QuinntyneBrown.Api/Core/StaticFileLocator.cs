using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace QuinntyneBrown.Api.Core
{
    internal class StaticFileLocator
    {
        public static string GetAsString(string name)
        {
            var fullName = default(string);
            var assembly = default(Assembly);
            var embededResourceNames = new List<string>();

            foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                foreach (Assembly _assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        foreach (var item in _assembly.GetManifestResourceNames()) embededResourceNames.Add(item);

                        if (!string.IsNullOrEmpty(_assembly.GetManifestResourceNames().SingleOrDefaultResourceName(name)))
                        {
                            fullName = _assembly.GetManifestResourceNames().SingleOrDefaultResourceName(name);
                            assembly = _assembly;
                        }
                    }
                    catch
                    {

                    }
                }
            }

            if (fullName == default && assembly == default)
                return null;

            try
            {
                using (var stream = assembly.GetManifestResourceStream(fullName))
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static byte[] Get(string name)
        {
            var fullName = default(string);
            var assembly = default(Assembly);
            var embededResourceNames = new List<string>();

            foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                foreach (Assembly _assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        foreach (var item in _assembly.GetManifestResourceNames()) embededResourceNames.Add(item);

                        if (!string.IsNullOrEmpty(_assembly.GetManifestResourceNames().SingleOrDefaultResourceName(name)))
                        {
                            fullName = _assembly.GetManifestResourceNames().SingleOrDefaultResourceName(name);
                            assembly = _assembly;
                        }
                    }
                    catch
                    {

                    }
                }
            }

            if (fullName == default && assembly == default)
                return null;

            try
            {
                using (var stream = assembly.GetManifestResourceStream(fullName))
                {
                    MemoryStream ms = new MemoryStream();
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }

    public static class StringListExtensions
    {
        public static string SingleOrDefaultResourceName(this string[] collection, string name)
        {
            try
            {
                string result = null;

                if (collection.Length == 0) return null;

                result = collection.SingleOrDefault(x => x.EndsWith(name));

                if (result != null)
                    return result;

                return collection.SingleOrDefault(x => x.EndsWith($".{name}.txt"));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}