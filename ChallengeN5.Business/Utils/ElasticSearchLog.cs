using ChallengeN5.Data_ElasticSearch;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using System.Net;

namespace ChallengeN5.Business.Utils
{
    public class ElasticSearchLog
    {
        private readonly ElasticSearchService _elasticSearchService;

        public ElasticSearchLog(ElasticSearchService elasticSearchService) 
        {
            _elasticSearchService = elasticSearchService;
        }

        /// <summary>
        /// This method saves the document in the default ElasticSearch index: challengen5_em
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task CreateIndexDocument(string endpoint, int statusCode, dynamic data = null) 
        {

            dynamic document = new ExpandoObject();

            if (data != null)
            {
                document.date = DateTime.Now;
                document.endpoint = endpoint;
                document.statusCode = statusCode;
                document.data = data;
            }
            else
            {
                document.date = DateTime.Now;
                document.endpoint = endpoint;
                document.statusCode = statusCode;
            }

            await _elasticSearchService.CreateElasticDocument(document);
        }

        public async Task CreateDocument(string endpoint, int statusCode, dynamic data = null)
        {

            dynamic document = new ExpandoObject();

            if (data != null)
            {
                document.date = DateTime.Now;
                document.endpoint = endpoint;
                document.statusCode = statusCode;
                document.data = data;
            }
            else
            {
                document.date = DateTime.Now;
                document.endpoint = endpoint;
                document.statusCode = statusCode;
            }

            // SAVE DATA BUT REQUIRES THE INDEX
            await _elasticSearchService.CreateIndexElasticDocument(document, "challengen5_em");
        }
    }
}
