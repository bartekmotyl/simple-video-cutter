using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter
{
    public static class Utils
    {
        // Return a deep clone of an object of type T.
        // Copid from http://csharphelper.com/blog/2016/09/clone-serializable-objects-in-c/
        public static T DeepClone<T>(this T obj)
        {
            using (MemoryStream memory_stream = new MemoryStream())
            {
                // Serialize the object into the memory stream.
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memory_stream, obj);

                // Rewind the stream and use it to create a new object.
                memory_stream.Position = 0;
                return (T)formatter.Deserialize(memory_stream);
            }
        }

        public static string GetCurrentRelease()
        {
            var currVer = Assembly.GetExecutingAssembly().GetName().Version;
            var currentRelease = $"{currVer.Major}.{currVer.Minor}.{currVer.Build}";
            return currentRelease;
        }
    }
}
