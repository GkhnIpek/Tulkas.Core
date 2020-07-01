namespace Tulkas.Core.Helpers.Utilities.ElasticSearchOptions.Abstract
{
    public interface IElasticSearchConfigration
    {
        string ConnectionString { get; }
        string AuthUserName { get; }
        string AuthPassWord { get; }
    }
}
