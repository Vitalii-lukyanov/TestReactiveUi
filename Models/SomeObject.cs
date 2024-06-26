using DynamicData.Binding;
using ReactiveUI;

namespace Models;

public class SomeObject: ReactiveObject {
    private Decimal _AccountSumm;
    public Decimal AccountSum { get=>_AccountSumm;
        set {
            this.RaiseAndSetIfChanged(ref _AccountSumm, value);
        }
    } 
    private Decimal _MaxLimitAccountSum;

    public Decimal MaxLimitAccountSum {
        get => _MaxLimitAccountSum;
        set {
            this.RaiseAndSetIfChanged(ref _MaxLimitAccountSum, value);
        }
    }

    private String _Account;

    public String Account {
        get => _Account;
        set {
            this.RaiseAndSetIfChanged(ref _Account, value);
        } 
        
    }
}

public class SomeObject2 : ReactiveObject {
    private String _Account;

    public String Account {
        get => _Account;
        set {
            this.RaiseAndSetIfChanged(ref _Account, value);
        } 
        
    }
}
public class SomeObjectProxy {
    public string Account { get; set; }
    public Decimal Summ { get; set; }
}

public class SomeObjectModel : ReactiveObject {
    private SomeObject _SomeObject;
    public SomeObject SomeObject {
        get => _SomeObject;
        set => _SomeObject = value ?? throw new ArgumentNullException(nameof(value));
    }

    public SomeObjectModel(SomeObject someObject) {
        _SomeObject = someObject;
        var a = _SomeObject.WhenAnyPropertyChanged().Subscribe(x => Console.WriteLine($"Отслеживание из модели {x.AccountSum}"));
    }
}

public class SomeObjectProxySubscriber:ReactiveObject {
    private SomeObject _SomeObject;
    private Decimal _AccountSumm;
    public Decimal AccountSum { get=>_AccountSumm;
        set {
            this.RaiseAndSetIfChanged(ref _AccountSumm, value);
        }
    } 
    private Decimal _MaxLimitAccountSum;

    public Decimal MaxLimitAccountSum {
        get => _MaxLimitAccountSum;
        set {
            this.RaiseAndSetIfChanged(ref _MaxLimitAccountSum, value);
        }
    }

    private String _Account;

    public String Account {
        get => _Account;
        set {
            this.RaiseAndSetIfChanged(ref _Account, value);
        } 
        
    }
    public SomeObjectProxySubscriber(SomeObject someObject) {
        _SomeObject = someObject;
        //var a = _SomeObject.WhenPropertyChanged(x=>x.AccountSum).ToProperty(_SomeObject, x=>x.AccountSum * 1000);
    }
}