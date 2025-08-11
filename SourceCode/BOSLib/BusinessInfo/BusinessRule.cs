using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    public delegate bool RuleDelegate(String propertyName);
    public class BusinessRule
    {
        private string _description;
        private string _propertyName;
        private RuleDelegate _ruleDelegate;


        public BusinessRule()
        {

        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="propertyName">The name of the property the rule is based on. This may be blank if the rule is not for any specific property.</param>
        /// <param name="brokenDescription">A description of the rule that will be shown if the rule is broken.</param>
        /// <param name="ruleDelegate"></param>
        public BusinessRule(string propertyName, string brokenDescription, RuleDelegate ruleDelegate)
        {
            this.Description = brokenDescription;
            this.PropertyName = propertyName;
            this.RuleDelegate = ruleDelegate;
        }

        /// <summary>
        /// Gets descriptive text about this broken rule.
        /// </summary>
        public virtual string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }

        /// <summary>
        /// Gets the name of the property the rule belongs to.
        /// </summary>
        public virtual string PropertyName
        {
            get { return (_propertyName ?? string.Empty).Trim(); }
            protected set { _propertyName = value; }
        }

        public virtual RuleDelegate RuleDelegate
        {
            get { return _ruleDelegate; }
            set { _ruleDelegate = value; }
        }

        /// <summary>
        /// Validates that the rule has been followed.
        /// </summary>
        public bool ValidateRule(BusinessObject domainObject)
        {
            return RuleDelegate(PropertyName);
        }


        /// <summary>
        /// Gets a string representation of this rule.
        /// </summary>
        /// <returns>A string containing the description of the rule.</returns>
        public override string ToString()
        {
            return this.Description;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. System.Object.GetHashCode()
        /// is suitable for use in hashing algorithms and data structures like a hash
        /// table.
        /// </summary>
        /// <returns>A hash code for the current rule.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
