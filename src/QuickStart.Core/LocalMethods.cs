﻿using System;
using System.Threading.Tasks;

namespace QuickStart.Core
{
    public class LocalMethods
    {
        public async Task<object> GetAppDomainDirectory(dynamic input)
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public async Task<object> GetCurrentTime(dynamic input)
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public async Task<object> UseDynamicInput(dynamic input)
        {
            // return $".NET Core welcomes {input}";
            return $".NET welcomes {input}";
        }

        public async Task<object> Sum5(dynamic input)
        {
            return 5 + input;
        }
    }
}
