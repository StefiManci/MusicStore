﻿using Microsoft.AspNetCore.Http;

namespace MusicStore.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
request.QueryString.HasValue
? $"{request.Path}{request.QueryString}"
: request.Path.ToString();
    }
}
