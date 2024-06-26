using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Credit;

namespace Models.Credit
{
    public class BankCredit : ReactiveObject
    {
        public BankCredit(Int32 id) {
            _Id = id;
        }
        private Int32 _Id;

        public Int32 Id
        {
            get => _Id;
        }
        private Car _Car;

        public Car Car
        {
            get => _Car;
            set => this.RaiseAndSetIfChanged(ref _Car, value);
        }
        private BankCreditPrice _BankCreditPrice;

        public BankCreditPrice BankCreditPrice
        {
            get => _BankCreditPrice;
            set => this.RaiseAndSetIfChanged(ref _BankCreditPrice, value);
        }
        private Decimal _Summ;
        public Decimal Summ
        {
            get => _Summ;
            set
            {
                this.RaiseAndSetIfChanged(ref _Summ, value);
            }
        }
    }
}
public class CarCreditModelProxy {
    public CarCreditModelProxy(Int32 id) {
        Id = id;
    }

    public CarCreditModelProxy(BankCredit bankCredit)
    {
        Id = bankCredit.Id;
        CarCaption = bankCredit.Car.Caption;
        CarPrice = bankCredit.Car.Price;
        BankCreditSumm = bankCredit.Summ;
        BankCreditPriceKoef = bankCredit.BankCreditPrice.Koef;
        BankCreditPriceCaption = bankCredit.BankCreditPrice.Caption;
    }

    public Int32 Id { get; }
    public String CarCaption { get; set; }
    public Decimal CarPrice { get; set; }
    public Decimal BankCreditSumm {get; set;}
    public Decimal BankCreditPriceKoef {get;set;}
    public String BankCreditPriceCaption {get;set;}
}
