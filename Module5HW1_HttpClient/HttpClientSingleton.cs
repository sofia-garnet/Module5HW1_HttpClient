﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1
{
    public class HttpClientSingleton : IDisposable
    {
        private static object _locker = new object();
        private static volatile HttpClient _client;

        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    lock (_locker)
                    {
                        if (_client == null)
                        {
                            _client = new HttpClient();
                        }
                    }
                }

                return _client;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_client != null)
                {
                    _client.Dispose();
                }

                _client = null;
            }
        }
    }

}
