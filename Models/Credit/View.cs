

namespace Models.Credit
{
    public class View
    {
        private CarCreditModel _Model;
        public View(CarCreditModel model)
        {
            _Model = model;
        }

        public void Show()
        {
            Console.Write($"{_Model.BankCredit.Car.Caption}  {_Model.BankCredit.Summ}  {_Model.BankCredit.BankCreditPrice.Koef}   ");
            foreach (var value in _Model._Values)
            {
                Console.Write($"{value}    ");
            }
            Console.WriteLine();
        }
    }
}
