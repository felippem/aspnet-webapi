using System.Collections.Generic;
using System.Linq;

namespace SharedKernel.Models
{
    public class EntityContract<T, TId> : Entity<TId>
    {
        public HashSet<BrokenRules<T>> BrokenRules { get; private set; }

        public virtual bool IsValid
        {
            get { return this.BrokenRules.Count == 0; }
        }

        public EntityContract()
        {
            this.BrokenRules = new HashSet<BrokenRules<T>>();
        }

        public void Add(T brokenRule, string errorMessage)
        {
            this.BrokenRules.Add(new BrokenRules<T>(brokenRule, errorMessage));
        }
    }
}
