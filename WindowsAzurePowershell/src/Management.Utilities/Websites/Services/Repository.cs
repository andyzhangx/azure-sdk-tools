﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.Utilities.Websites.Services
{
    using System;
    using System.Linq;
    using WebEntities;

    public class Repository
    {
        public string PublishingUsername { get; set; }
        public string PublishingPassword { get; set; }
        public string PublishingAuth
        {
            get { return string.Format("{0}:{1}", PublishingUsername, PublishingPassword); }
        }
        
        public string RepositoryUri { get; set; }

        public Repository(Site site)
        {
            RepositoryUri = site.SiteProperties.Properties.Where(p => p.Name.Equals("RepositoryUri", StringComparison.OrdinalIgnoreCase)).Select(p => p.Value).FirstOrDefault();
            if (RepositoryUri != null && !RepositoryUri.EndsWith("/"))
            {
                RepositoryUri += "/";
            }

            PublishingUsername = site.SiteProperties.Properties.Where(p => p.Name.Equals("PublishingUsername", StringComparison.OrdinalIgnoreCase)).Select(p => p.Value).FirstOrDefault();
            PublishingPassword = site.SiteProperties.Properties.Where(p => p.Name.Equals("PublishingPassword", StringComparison.OrdinalIgnoreCase)).Select(p => p.Value).FirstOrDefault();
        }
    }
}
