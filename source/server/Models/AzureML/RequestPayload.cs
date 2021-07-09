//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models.AzureML
{

    public class RequestPayload
    {

        public RequestPayload()
        {
        }

        public RequestInputs? Inputs { get; set; }

        public RequestGlobalParameters? GlobalParameters { get; set; }

    }

}
