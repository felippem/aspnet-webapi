
namespace SharedKernel.Models
{
    public class BrokenRules<T>
    {
        public T BrokenRule { get; private set; }
        public string ErrorMessage { get; private set; }

        public BrokenRules(T brokenRule, string errorMessage)
        {
            this.BrokenRule = brokenRule;
            this.ErrorMessage = errorMessage;
        }
    }
}
