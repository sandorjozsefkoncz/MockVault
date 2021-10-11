using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MockVault
{
    public class VaultService
    {
        private readonly ConcurrentDictionary<string, string> vault = new();

        public VaultService()
        {
        }

        public void Add(string secretPath, string secret)
        {
            vault.TryAdd(secretPath, secret);
        }

        public string Get(string secretPath)
        {
            if (vault.TryGetValue(secretPath, out var secret))
            {
                return secret;
            }

            return null;
        }
    }
}
