using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;


namespace Models.Credit
{
    public class CarCreditListViewModel : ReactiveObject
    {
        public SourceCache<BankCredit, Int32> Objects = new SourceCache<BankCredit, Int32>(x => x.Id);
        ReadOnlyObservableCollection<CarCreditModelProxy> proxies;
        public ReadOnlyObservableCollection<CarCreditModelProxy> Proxies => proxies;

        public CarCreditListViewModel()
        {
            var a = Objects.Connect().AutoRefresh().Transform(x => new CarCreditModelProxy(x.Id)
            {
                CarCaption = x.Car.Caption,
                CarPrice = x.Car.Price,
                BankCreditPriceKoef = x.BankCreditPrice.Koef,
                BankCreditPriceCaption = x.BankCreditPrice.Caption,
                BankCreditSumm = x.Summ
            }).Bind(out proxies).Subscribe();
        }
    }
}
