using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Credit
{
    public class CarCreditModel : ReactiveObject
    {
        private Guid _Id;

        public Guid Id
        {
            get => _Id;
        }
        private Car _Car;
        private BankCreditPrice _BankCreditPrice;
        public BankCreditPrice BankCreditPrice
        {
            get => _BankCreditPrice;
            set => this.RaiseAndSetIfChanged(ref _BankCreditPrice, value);
        }
        private BankCredit _BankCredit;
        public BankCredit BankCredit
        {
            get => _BankCredit;
            set => this.RaiseAndSetIfChanged(ref _BankCredit, value);
        }
        public Decimal[] _Values = new decimal[12];
        public CarCreditModel(BankCredit bankCredit)
        {
            _Id = Guid.NewGuid();
            /*this.WhenAnyValue(x => x.BankCredit, y => y.BankCredit.Summ, p3 => p3.BankCredit.BankCreditPrice,
                p4 => p4.BankCredit.BankCreditPrice.Koef)
                .InvokeCommand(ReactiveCommand.Create<(BankCredit, Decimal, BankCreditPrice, Decimal)>(x => {
                    _Car = x.Item1.Car;
                    _BankCreditPrice = x.Item1.BankCreditPrice;
                    var fullSumm = x.Item1.Summ * _BankCreditPrice.Koef;
                    for (int i = 0; i < 12; i++) {
                        _Values[i] = fullSumm / 12;
                    }
                }));*/
            BankCredit = bankCredit;
            _Car = bankCredit.Car;
            BankCreditPrice = bankCredit.BankCreditPrice;
        }

        public void Init()
        {
            this.WhenAnyValue(x => x.BankCredit, y => y.BankCredit.Summ, p3 => p3.BankCredit.BankCreditPrice,
                    p4 => p4.BankCredit.BankCreditPrice.Koef)
                .InvokeCommand(ReactiveCommand.Create<(BankCredit, Decimal, BankCreditPrice, Decimal)>(x => {
                    _Car = x.Item1.Car;
                    _BankCreditPrice = x.Item1.BankCreditPrice;
                    var fullSumm = x.Item1.Summ * _BankCreditPrice.Koef;
                    for (int i = 0; i < 12; i++)
                    {
                        _Values[i] = fullSumm / 12;
                    }
                }));
        }


    }
}
