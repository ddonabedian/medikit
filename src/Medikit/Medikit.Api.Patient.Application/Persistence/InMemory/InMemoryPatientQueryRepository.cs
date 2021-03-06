﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Medikit.Api.Common.Application.Extensions;
using Medikit.Api.Common.Application.Persistence;
using Medikit.Api.Patient.Application.Domains;
using Medikit.Api.Patient.Application.Queries;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Medikit.Api.Patient.Application.Persistence.InMemory
{
    public class InMemoryPatientQueryRepository : IPatientQueryRepository
    {
        private static Dictionary<string, string> MAPPING_PATIENT_TO_PROPERTYNAME = new Dictionary<string, string>
        {
            { "firstname", "Firstname" },
            { "lastname", "Lastname" },
            { "niss", "NationalIdentityNumber" },
            { "create_datetime", "CreateDateTime" },
            { "update_datetime", "UpdateDateTime" }
        };
        private readonly ConcurrentBag<PatientAggregate> _patients;

        public InMemoryPatientQueryRepository(ConcurrentBag<PatientAggregate> patients)
        {
            _patients = patients;
        }

        public Task<PatientAggregate> GetById(string id, CancellationToken token)
        {
            return Task.FromResult(_patients.FirstOrDefault(_ => _.Id == id));
        }

        public Task<PatientAggregate> GetByNiss(string niss, CancellationToken token)
        {
            return Task.FromResult(_patients.FirstOrDefault(p => p.NationalIdentityNumber == niss));
        }

        public Task<PagedResult<PatientAggregate>> Search(SearchPatientsQuery parameter, CancellationToken token)
        {
            IQueryable<PatientAggregate> patients = _patients.AsQueryable();
            if (MAPPING_PATIENT_TO_PROPERTYNAME.ContainsKey(parameter.OrderBy))
            {
                patients = patients.InvokeOrderBy(MAPPING_PATIENT_TO_PROPERTYNAME[parameter.OrderBy], parameter.Order);
            }

            if (!string.IsNullOrWhiteSpace(parameter.Niss))
            {
                patients = patients.Where(r => r.NationalIdentityNumber.StartsWith(parameter.Niss, System.StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(parameter.Firstname))
            {
                patients = patients.Where(r => r.Firstname.StartsWith(parameter.Firstname, System.StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(parameter.Lastname))
            {
                patients = patients.Where(r => r.Lastname.StartsWith(parameter.Lastname, System.StringComparison.InvariantCultureIgnoreCase));
            }

            int totalLength = patients.Count();
            patients = patients.Skip(parameter.StartIndex).Take(parameter.Count);
            return Task.FromResult(new PagedResult<PatientAggregate>
            {
                StartIndex = parameter.StartIndex,
                Count = parameter.Count,
                TotalLength = totalLength,
                Content = (ICollection<PatientAggregate>)patients.ToList()
            });
        }
    }
}
