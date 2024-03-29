﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Volta.Stocks.Application.Commands.CreateStock;
using Volta.Stocks.Domain.Stocks;
using Volta.Stocks.Infrastructure;
using NetArchTest.Rules;

namespace Volta.Stocks.Service.ArchTests.SeedWork
{
    public abstract class TestBase
    {
        protected static Assembly ApplicationAssembly => typeof(CreateStockCommand).Assembly;

        protected static Assembly DomainAssembly => typeof(Stock).Assembly;

        protected static Assembly InfrastructureAssembly => typeof(StocksContext).Assembly;

        protected static void AssertAreImmutable(IEnumerable<Type> types)
        {
            IList<Type> failingTypes = new List<Type>();
            foreach (var type in types)
            {
                if (type.GetFields().Any(x => !x.IsInitOnly) || type.GetProperties().Any(x => x.CanWrite))
                {
                    failingTypes.Add(type);
                    break;
                }
            }

            AssertFailingTypes(failingTypes);
        }

        protected static void AssertFailingTypes(IEnumerable<Type> types)
        {
            types.Should().BeNullOrEmpty();
        }

        protected static void AssertArchTestResult(TestResult result)
        {
            AssertFailingTypes(result.FailingTypes);
        }
    }
}