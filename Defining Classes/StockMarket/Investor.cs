using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        public List<Stock> Portfolio => this.portfolio;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public Investor(string fullName,string emailAddress,decimal moneyToInvest,string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.portfolio = new List<Stock>();
        }
        public int Count => this.portfolio.Count;
        public void BuyStock(Stock stock)
        {
            if(stock.MarketCapitalization>10000 && MoneyToInvest>=stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;
                this.portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            var seachedStock = this.portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (seachedStock==null)
            {
                return $"{companyName} does not exist.";
            }
            else if(seachedStock.PricePerShare>sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                this.portfolio.Remove(seachedStock);
                this.MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName)
        {
            var seachedStock = this.portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if(seachedStock!=null)
            {
                return seachedStock;
            }
            else
            {
                return null;
            }
        }
        public Stock FindBiggestCompany()
        {
            if(this.Count==0)
            {
                return null;
            }
            else
            {
                var biggestCompany = this.portfolio.OrderByDescending(x => x.MarketCapitalization).ToList();
                return biggestCompany[0];
            }
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach(var stock in this.portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
