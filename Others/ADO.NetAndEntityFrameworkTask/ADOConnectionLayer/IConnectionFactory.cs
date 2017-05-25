using System.Data;

namespace ADOConnectionLayer
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}