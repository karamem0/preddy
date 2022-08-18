//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Azure.Storage.Blobs;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models
{

    public class BlobStorageContext
    {

        private readonly BlobContainerClient client;

        public BlobStorageContext(BlobContainerClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<T>> DownloadAsync<T>(string name)
        {
            var culture = CultureInfo.InvariantCulture;
            var response = await this.client.GetBlobClient(name)
                .DownloadAsync()
                .ConfigureAwait(false);
            var reader = new CsvReader(new StreamReader(response.Value.Content), culture);
            return reader.GetRecords<T>();
        }

        public async Task UploadAsync<T>(string name, T[] values)
        {
            var encoding = Encoding.UTF8;
            var culture = CultureInfo.InvariantCulture;
            using var stream = new MemoryStream();
            using var writer = new CsvWriter(new StreamWriter(stream, encoding), culture);
            writer.WriteHeader<T>();
            writer.NextRecord();
            writer.WriteRecords(values);
            writer.Flush();
            stream.Position = 0;
            _ = await this.client.GetBlobClient(name)
                .UploadAsync(stream, true)
                .ConfigureAwait(false);
        }

    }

}
