//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using Azure.Identity;
using Azure.Storage.Blobs;
using CsvHelper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models
{

    public class BlobStorageContext
    {

        private readonly BlobStorageOptions options;

        public BlobStorageContext(HttpClient httpClient, IOptions<BlobStorageOptions> options)
        {
            this.options = options.Value;
        }

        public async Task UploadAsync<T>(string name, T[] values)
        {
            var endpoint = this.options.Endpoint ?? throw new ArgumentNullException(this.options.Endpoint);
            var encoding = Encoding.UTF8;
            var culture = CultureInfo.InvariantCulture;
            using var stream = new MemoryStream();
            using var writer = new CsvWriter(new StreamWriter(stream, encoding), culture);
            writer.WriteHeader<T>();
            writer.NextRecord();
            writer.WriteRecords(values);
            writer.Flush();
            stream.Position = 0;
            var credential = new DefaultAzureCredential();
            var client = new BlobContainerClient(new Uri(endpoint), credential);
            _ = await client.GetBlobClient(name).UploadAsync(stream, true);
        }

    }

}
