﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Medikit.Api.Common.Application.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medikit.Api.Common.Application
{
    public interface ICommitAggregateHelper
    {
        Task Commit<T>(T aggregate, string streamName, string queueName) where T : BaseAggregate;
        Task Commit<T>(T aggregate, ICollection<DomainEvent> evts, int aggregateVersion, string streamName, string queueName) where T : BaseAggregate;
    }
}
