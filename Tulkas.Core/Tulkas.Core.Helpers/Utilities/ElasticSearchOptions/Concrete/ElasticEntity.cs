using Nest;
using Tulkas.Core.Helpers.Utilities.ElasticSearchOptions.Abstract;

namespace Tulkas.Core.Utilities.ElasticSearchOptions.Concrete
{
    public class ElasticEntity<TEntityKey> : IElasticEntity<TEntityKey>
    {
        public virtual TEntityKey Id { get; set; }
        public virtual CompletionField Suggest { get; set; }
        public virtual string SearchingArea { get; set; }
        public virtual double? Score { get; set; }
    }
}
