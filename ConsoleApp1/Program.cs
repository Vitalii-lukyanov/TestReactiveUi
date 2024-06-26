// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using ConsoleApp1;
using DynamicData;
using DynamicData.Binding;
using DynamicData.PLinq;
using Models;
using ReactiveUI;

/*var so1 = new SomeObject(){Account = "1", AccountSum = 5};
var so2 = new SomeObject(){Account = "2", AccountSum = 7};
var so3 = new SomeObject(){Account = "3", AccountSum = 10};
var so4 = new SomeObject(){Account = "4"};
var so5 = new SomeObject(){Account = "5"};
var som = new SomeObjectModel(so1);
ObservableCollection<SomeObject> col = new ObservableCollection<SomeObject>();
col.Add(so1);
col.Add(so2);
col.Add(so3);
col.Add(so4);
col.Add(so5);

var cache = col.ToObservableChangeSet(s => s.Account).Filter(y=>y.AccountSum > 0 && y.AccountSum < 10).AsObservableCache();
ReadOnlyObservableCollection<SomeObject> _derived;
var iobs = cache.Connect();
var not1 = iobs.Subscribe(Method1);
var not2 = iobs.WhenAnyPropertyChanged().Subscribe(x => Console.WriteLine($"Отслеживание not2 {x.Account}"));
var so6 = new SomeObject() { Account = "6", AccountSum = 8 };
col.Add(so6);
so1.Account = "Account1";
so5.Account = "Account5";*/


//Variants.V2Start();
Variants.V3Start();



void Method1(IChangeSet<SomeObject, string> x) {
     Console.WriteLine($"Отслеживание not1 {x.ToString()}");
 }
