﻿using System;

namespace FreakyTrader.Business
{
    public class Currency
    {
        private decimal _usdValue;
        public string CurrencySign { get; set; }
        public decimal Open { get; private set; }
        public decimal Low { get; private set; }
        public decimal High { get; private set; }
        public decimal LastChange { get; private set; }

        public decimal RateChange
        {
            get
            {
                return USDValue - Open;
            }
        }

        public double PercentChange
        {
            get
            {
                return (double)Math.Round(RateChange / USDValue, 4);
            }
        }

        public decimal USDValue
        {
            get
            {
                return _usdValue;
            }
            set
            {
                if (_usdValue == value)
                {
                    return;
                }

                LastChange = value - _usdValue;
                _usdValue = value;

                if (Open == 0)
                {
                    Open = _usdValue;
                }
                if (_usdValue < Low || Low == 0)
                {
                    Low = _usdValue;
                }
                if (_usdValue > High)
                {
                    High = _usdValue;
                }
            }
        }
    }
}
