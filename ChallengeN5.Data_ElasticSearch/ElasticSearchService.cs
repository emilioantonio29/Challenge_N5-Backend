using Elasticsearch.Net;
using Nest;

namespace ChallengeN5.Data_ElasticSearch
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IElasticClient _client;

        public ElasticSearchService(IElasticClient client)
        {
            _client = client;
        }

        public async Task CreateElasticDocument(dynamic data)
        {
            // post document to default index -> challengen5_em
            try
            {
                await _client.IndexDocumentAsync(new IndexRequest<dynamic>(data));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR ELASTIC SEARCH: {ex}");
            }
        }

        public async Task<IndexResponse> CreateIndexElasticDocument<T>(T document, string indexName) where T : class
        {
            try
            {
                var indexResponse = await _client.IndexAsync(document, idx => idx.Index(indexName));

                return indexResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR ELASTIC SEARCH: {ex.Message}");

                return new IndexResponse();

            }
        }
    }
}