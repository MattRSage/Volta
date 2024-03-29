﻿using NetArchTest.Rules;
using Volta.Stocks.Service.ArchTests.SeedWork;
using Xunit;

namespace Volta.Stocks.Service.ArchTests.Layers
{
    public class LayersTests : TestBase
    {
        [Fact]
        public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer()
        {
            var result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
                .GetResult();

            AssertArchTestResult(result);
        }

        [Fact]
        public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer()
        {
            var result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
                .GetResult();

            AssertArchTestResult(result);
        }

        [Fact]
        public void ApplicationLayer_DoesNotHaveDependency_ToInfrastructureLayer()
        {
            var result = Types.InAssembly(ApplicationAssembly)
                .Should()
                .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}