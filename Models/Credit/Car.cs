using System.Collections.ObjectModel;
using System.Reactive;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace Models.Credit;

public class Car:ReactiveObject {
    private String _Caption;

    public String Caption {
        get => _Caption;
        set {
            this.RaiseAndSetIfChanged(ref _Caption, value);
        } 
    }
    private Decimal _Price;

    public Decimal Price {
        get => _Price;
        set {
            this.RaiseAndSetIfChanged(ref _Price, value);
        }
    }
}


