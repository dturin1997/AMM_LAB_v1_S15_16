using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AMM_LAB_v1_S15_16.Interfaces
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
