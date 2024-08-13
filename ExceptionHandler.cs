using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using newspaper_office_api.Common;
using newspaper_office_api.DataAccess;
using newspaper_office_api.Model;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace newspaper_office_api.Middleware
{
    internal sealed class ExceptionHandler : IExceptionHandler
    {
        private readonly db_name _db_name;
        private static readonly string log_server_link = AppConfig.GetServerInfo("LogServer", "url");
        private readonly IHttpClientFactory _httpClientFactory;

        public ExceptionHandler(db_name dbName, IHttpClientFactory httpClientFactory)
        {
            _db_name = dbName;
            _httpClientFactory = httpClientFactory;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception.StackTrace != null && exception.StackTrace.Contains(nameof(newspaper_office_api) + nameof(Handlers)))
            {
                _ = Task.Run(() => ExportLogsAsync(exception.ToString()));
            }

            await WriteResponseAsync(PrepareResponseBody(exception), httpContext, cancellationToken);

            return true;
        }

        private responseData PrepareResponseBody(Exception exception)
        {
            return new responseData
            {
                status = 0,
                message = "Lấy dữ liệu không thành công",
                data = exception.ToString()
            };
        }

        private async Task WriteResponseAsync(responseData responseData, HttpContext httpContext, CancellationToken cancellationToken)
        {
            var response = JsonConvert.SerializeObject(responseData);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsync(response, Encoding.UTF8, cancellationToken);
        }

        private async Task ExportLogsAsync(string message)
        {
            try
            {
                if (!string.IsNullOrEmpty(_db_name.name))
                {
                    var log = new logSystem
                    {
                        created_date = DateTime.Now,
                        db_name = _db_name.name,
                        message = message,
                        site = _db_name.name,
                    };
                    var json = JsonConvert.SerializeObject(log);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var client = _httpClientFactory.CreateClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, log_server_link)
                    {
                        Content = content
                    };
                    var response = await client.SendAsync(request);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage(ex.ToString());
            }
        }
    }
}
