using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Linq;
using System.Text;

namespace BOSLib
{
    public class RequiredAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the resource type to get error message
        /// </summary>
        public Type ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the resource name to get error message
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or setse the error message
        /// </summary>
        public string ErrorMessage { get; set; }
        public RequiredAttribute(string errorMsg)
        {
            ErrorMessage = errorMsg;
        }

        public RequiredAttribute(Type resourceType, string resourceName)
        {
            PropertyInfo[] props = resourceType.GetProperties();
            foreach (PropertyInfo staticProperty in props)
            {
                if (staticProperty.PropertyType == typeof(ResourceManager))
                {
                    ResourceManager resourceManager = (ResourceManager)staticProperty.GetValue(null, null);
                    ErrorMessage = resourceManager.GetString(resourceName);                    
                }                
            }            
        }
    }
}
