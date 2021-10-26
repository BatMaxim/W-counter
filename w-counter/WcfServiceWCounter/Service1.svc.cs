using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceWCounter
{
    public class Service1 : IService1
    {
        public Dictionary<string, int> GetData(string textInFile)
        {
            var type = Type.GetType("TextProcessing.TextParcer, TextProcessing");
            var methodMT = type.GetMethod("ParceTextMultiThread", BindingFlags.Public | BindingFlags.Instance);
            var text = new object[] { textInFile };
            var obj = Activator.CreateInstance(type);
            var words = (Dictionary<string, int>)methodMT.Invoke(obj, text);
            
            return words;  
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
