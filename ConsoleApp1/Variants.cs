using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Binding;
using DynamicData.PLinq;
using Models;
using Models.Credit;
using ReactiveUI;

namespace ConsoleApp1;

public class Variants {
    public static void V1Start() {
        var so2_1 = new SomeObject2(){Account = "1"};
        var so2_2 = new SomeObject2(){Account = "2"};
        var so2_3 = new SomeObject2(){Account = "3"};
        var so2_4 = new SomeObject2(){Account = "4"};
        var so2_5 = new SomeObject2(){Account = "5"};
        ObservableCollection<SomeObject2> col2 = new ObservableCollection<SomeObject2>();
        ReadOnlyObservableCollection<SomeObjectProxy> proxies;
        Dictionary<SomeObject2, SomeObjectProxy> dict = new Dictionary<SomeObject2, SomeObjectProxy>();
        col2.Add(so2_1);
        col2.Add(so2_2);
        col2.Add(so2_3);
        col2.Add(so2_4);
        col2.Add(so2_5);
        var cache2 = col2.ToObservableChangeSet(s => s.Account).AsObservableCache();

        var connect = cache2.Connect().Transform(x=> {
            var proxy = new SomeObjectProxy() { Account = x.Account };
            dict[x] = proxy;
            return proxy;
        }).Bind(out proxies).Subscribe();
        cache2.Connect().WhenAnyPropertyChanged().Subscribe((object2 => {
            var proxy = dict[object2];
            proxy.Account = object2.Account;
        }));
        foreach (var proxy in proxies) {
            Console.WriteLine(proxy.Account);
        }

        so2_1.Account = "New Account";
        foreach (var proxy in proxies) {
            Console.WriteLine(proxy.Account);
        }
    }

    public static void V2Start() {
        var so2_1 = new SomeObject(){Account = "1", AccountSum = 1};
        var so2_2 = new SomeObject(){Account = "2", AccountSum = 1};
        var so2_3 = new SomeObject(){Account = "3", AccountSum = 1};
        var so2_4 = new SomeObject(){Account = "4", AccountSum = 1};
        var so2_5 = new SomeObject(){Account = "5", AccountSum = 1};
        SourceCache<SomeObject, string> col2 = new SourceCache<SomeObject, string>(o=>o.Account);
        ReadOnlyObservableCollection<SomeObjectProxy> proxies;
        col2.AddOrUpdate(so2_1);
        col2.AddOrUpdate(so2_2);
        col2.AddOrUpdate(so2_3);
        col2.AddOrUpdate(so2_4);
        col2.AddOrUpdate(so2_5);
        var cansel = col2.Connect().Transform(x => new SomeObjectProxy() { Account = x.Account, Summ = x.AccountSum })
            .Bind(out proxies).Subscribe();
        
        foreach (var proxy in proxies) {
            Console.WriteLine($"{proxy.Account} => {proxy.Summ}");
        }
        var so2_6 = new SomeObject(){Account = "6", AccountSum = 1};
        col2.AddOrUpdate(so2_6);
        so2_1.AccountSum = 5000;
        
        foreach (var proxy in proxies) {
            Console.WriteLine($"{proxy.Account} => {proxy.Summ}");
        }
    }

    public static void V3Start() {
        var car = new Car() { Caption = "Жигули", Price = 1000000 };
        var BankCreditPrice = new BankCreditPrice() { Caption = "Ахренеть как выгоВно", Koef = 1.3M };
        var credit = new BankCredit(1) { BankCreditPrice = BankCreditPrice, Car = car, Summ = 700000 };
        var model = new CarCreditModel(credit);
        var view = new View(model);
        view.Show();
        
        var BankCreditPrice2 = new BankCreditPrice() { Caption = "Еще более выгоВно", Koef = 1.5M };
        credit.BankCreditPrice = BankCreditPrice2;
        view.Show();
        credit.BankCreditPrice.Koef = 2;
        view.Show();
        credit.Summ = 1500000;
        view.Show();
    }
}