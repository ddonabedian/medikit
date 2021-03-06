﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Medikit.Api.Common.Application.Domains;
using Medikit.Api.Patient.Application.Domains.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medikit.Api.Patient.Application.Domains
{
    public class PatientAggregate : BaseAggregate
    {
        public PatientAggregate()
        {
            ContactInformations = new List<PatientContactInformation>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public GenderTypes Gender { get; set; }
        public string NationalIdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string LogoUrl { get; set; }
        public string EidCardNumber { get; set; }
        public DateTime? EidCardValidity { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public PatientAddress Address { get; set; }
        public ICollection<PatientContactInformation> ContactInformations { get; set; }

        public static PatientAggregate New(string id, string firstName, string lastName, string nationalIdentityNumber, GenderTypes gender, DateTime birthDate, string logoUrl, string eidCardNumber, DateTime? eidCardValidity, PatientAddress address, ICollection<PatientContactInformation> contactInformations)
        {
            var evt = new PatientAddedEvent(Guid.NewGuid().ToString(), id, 0, firstName, lastName, nationalIdentityNumber, DateTime.UtcNow, DateTime.UtcNow, gender, birthDate, logoUrl, eidCardNumber, eidCardValidity, address, contactInformations);
            var result = new PatientAggregate();
            result.Handle(evt);
            result.DomainEvents.Add(evt);
            return result;
        }

        public static PatientAggregate New(ICollection<DomainEvent> evts)
        {
            var result = new PatientAggregate();
            foreach(var evt in evts)
            {
                result.Handle(evt);
            }

            return result;
        }

        public override object Clone()
        {
            return new PatientAggregate
            {
                CreateDateTime = CreateDateTime,
                Firstname = Firstname,
                Lastname = Lastname,
                NationalIdentityNumber = NationalIdentityNumber,
                Version = Version,
                Id = Id,
                LogoUrl = LogoUrl,
                BirthDate = BirthDate,
                UpdateDateTime = UpdateDateTime,
                Address = Address == null ? null : (PatientAddress)Address.Clone(),
                ContactInformations = ContactInformations.Select(_ => (PatientContactInformation)_.Clone()).ToList(),
                EidCardNumber = EidCardNumber,
                EidCardValidity = EidCardValidity,
                Gender = Gender
            };
        }

        public override void Handle(dynamic obj)
        {
            Handle(obj);
        }

        public void Handle(PatientAddedEvent evt)
        {
            Id = evt.AggregateId;
            CreateDateTime = evt.CreateDateTime;
            UpdateDateTime = evt.UpdateDateTime;
            Firstname = evt.Firstname;
            Lastname = evt.Lastname;
            Gender = evt.Gender;
            NationalIdentityNumber = evt.NationalIdentityNumber;
            BirthDate = evt.BirthDate;
            LogoUrl = evt.LogoUrl;
            EidCardNumber = evt.EidCardNumber;
            EidCardValidity = evt.EidCardValidity;
            Address = evt.Address;
            ContactInformations = evt.ContactInformations;
            Version = evt.Version;
        }

        public string GetStreamName()
        {
            return GetStreamName(Id);
        }

        public static string GetStreamName(string id)
        {
            return $"patients-{id}";
        }
    }
}
