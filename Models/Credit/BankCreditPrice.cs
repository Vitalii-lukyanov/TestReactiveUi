using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Credit
{
    public class BankCreditPrice : ReactiveObject
    {
        private String _Caption;

        public String Caption
        {
            get => _Caption;
            set
            {
                this.RaiseAndSetIfChanged(ref _Caption, value);
            }
        }
        private Decimal _Koef;

        public Decimal Koef
        {
            get => _Koef;
            set
            {
                this.RaiseAndSetIfChanged(ref _Koef, value);
            }
        }
    }
}
