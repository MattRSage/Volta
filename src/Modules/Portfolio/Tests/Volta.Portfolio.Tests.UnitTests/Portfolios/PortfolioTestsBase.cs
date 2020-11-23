﻿using System.Collections.Generic;
using System.Linq;
using Volta.Portfolios.Domain.Portfolios;
using Volta.Portfolios.Domain.Stocks;
using Volta.Portfolios.Tests.UnitTests.SeedWork;

namespace Volta.Portfolios.Tests.UnitTests.Portfolios
{
    public class PortfolioTestsBase : TestBase
    {
        protected class HoldingTestDataOptions
        {
            public IEnumerable<HoldingId> Holdings { get; set; } = Enumerable.Empty<HoldingId>();
        }

        protected class PortfolioTestData
        {
            public PortfolioTestData(Portfolio portfolio)
            {
                Portfolio = portfolio;
            }

            public Portfolio Portfolio { get; }
        }

        protected PortfolioTestData CreatePortfolioTestData(HoldingTestDataOptions options)
        {
            var portfolio = new Portfolio("name");

            foreach (var holding in options.Holdings)
            {
                portfolio.AddHolding(holding, MoneyValue.Of(1000,"gbp"), 1);
            }

            return new PortfolioTestData(portfolio);
        }
    }
}