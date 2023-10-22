using Nest;

namespace ChallengeN5.Data_ElasticSearch
{
    public interface IElasticSearchService
    {
        public Task CreateElasticDocument(dynamic data);
        public Task<IndexResponse> CreateIndexElasticDocument<T>(T document, string indexName) where T : class;
    }
}
