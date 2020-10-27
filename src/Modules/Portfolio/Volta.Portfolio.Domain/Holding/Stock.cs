﻿using Volta.BuildingBlocks.Domain;

namespace Volta.Portfolios.Domain.Holding
{
    public class Stock : Entity
    {
        public StockId Id { get; private set; }

        private string _tickerSymbol;
        private decimal _closePrice;

        private Stock()
        {
        }
    }
}