//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Azure.Storage.Blobs;
using Karamem0.Preddy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy
{

    public static class Constants
    {

        public const string BlobName = "azureml-experimentstore";

        public const string ExperimentOutputFileName = "experimentoutput.csv";

        public const string ExperimentInputFileName = "experimentinput.csv";

    }

}
