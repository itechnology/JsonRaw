using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JsonR
{
    using Models;

    public class Parser
    {
        public enum Style
        {
            Keys,
            Values,
            Type,
            Hint,
            Full
        }

        #region Singleton
        /// <summary>
        /// Fourth version Simplified
        /// http://www.yoda.arachsys.com/csharp/singleton.html
        /// </summary>
        public static readonly Parser Current = new Parser();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Parser() { }

        Parser()
        {
            // eventual init code            
        }
        #endregion

        public object Parse(IList items, Style style = Style.Full)
        {
            var jsonR = new JsonR();

            Type itemType = GetListItemType(items.GetType());
            jsonR.Type    = itemType.Name;

            SplitKeyValues(items, jsonR.Keys, jsonR.Values);
            switch (style)
            {
                case Style.Keys:
                    return jsonR.Keys;

                case Style.Values:
                    return jsonR.Values;

                case Style.Type:
                    return jsonR.Type;

                case Style.Hint:
                    return new {jsonR.Type, jsonR.Values };
            }

            return jsonR;
        }

        #region HelperMethods
        /// <summary>
        /// These helper methods are incomplete, non optimized, and do not work with anonymous methods
        /// If you feel like you can contribute by making them faster, more compatible, please do so !
        /// 
        /// The current two methods below where written by: Olivier Jacot-Descombes
        /// http://stackoverflow.com/questions/13843038/splitting-a-complex-object-to-two-separated-key-and-value-collections
        /// 
        /// Big kudos to him for this !
        /// </summary>

        public void SplitKeyValues(IList source, List<object> keys, List<object> values)
        {
            Type itemType             = GetListItemType(source.GetType());
            PropertyInfo[] properties = itemType.GetProperties();

            var length = source.Count;
            for (int i = 0; i < length; i++)
            {
                object item    = source[i];
                var itemValues = new List<object>();

                values.Add(itemValues);
                foreach (PropertyInfo prop in properties)
                {
                    if (typeof(IList).IsAssignableFrom(prop.PropertyType) && prop.PropertyType.IsGenericType)
                    {
                        // We have a List<T> or array
                        Type genericArgType = GetListItemType(prop.PropertyType);
                        if (genericArgType.IsValueType || genericArgType == typeof(string))
                        {
                            // We have a list or array of a simple type
                            if (i == 0)
                            {
                                keys.Add(prop.Name);
                            }

                            var subValues = new List<object>();

                            itemValues.Add(subValues);
                            subValues.AddRange(((IEnumerable)prop.GetValue(item, null)).Cast<object>());
                        }
                        else
                        {
                            // We have a list or array of a complex type
                            var subKeys = new List<object>();
                            if (i == 0)
                            {
                                keys.Add(new Dictionary<string, object>(1) { { prop.Name, subKeys } });
                            }

                            var subValues = new List<object>();

                            itemValues.Add(subValues);
                            SplitKeyValues((IList)prop.GetValue(item, null), subKeys, subValues);
                        }
                    }
                    else if (prop.PropertyType.IsValueType || prop.PropertyType == typeof(string))
                    {
                        // We have a simple type
                        if (i == 0)
                        {
                            keys.Add(prop.Name);
                        }

                        itemValues.Add(prop.GetValue(item, null));
                    }
                }
            }
        }
        private Type GetListItemType(Type listType)
        {
            Type itemType = null;

            foreach (Type interfaceType in listType.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    itemType = interfaceType.GetGenericArguments()[0];
                    break;
                }
            }

            return itemType;
        }
        #endregion
    }
}
