using App.Data;

namespace App.Infrastructure
{
    public interface IPPLQueryExecutor : IQueryExecutor { }

    public class PPLQueryExecutor : QueryExecutor, IPPLQueryExecutor
    {
        public PPLQueryExecutor() : base(ConfigurationSetup.PPLConnectionString) { }
    }
}
