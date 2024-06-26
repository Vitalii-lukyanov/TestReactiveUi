using DynamicData;
using Models.Credit;

namespace TestReactiveUISpeed;

public class UnitTest1
{
    [Fact]
    public void TestAdd100k()
    {
        var Model = new CarCreditListViewModel();
        var data = new List<CarCreditModelProxy>(1000000);
        var cars = new Car[10];
        var prices = new BankCreditPrice[10];
        for (int i = 1; i <= 10; i++) {
            var car = new Car() { Caption = $"Жигули-{i}", Price = i*250000 };
            cars[i - 1] = car;
            var BankCreditPrice = new BankCreditPrice() { Caption = $"Кредит-{i}", Koef = i * 0.1M };
            prices[i - 1] = BankCreditPrice;
        }
        
       
        
        Random rand = new Random();
        for (int i = 0; i < 100000; i++) {
            var randInt = rand.Next(0, 9);
            var credit = new BankCredit(i) { BankCreditPrice = prices[randInt], Car = cars[randInt], Summ = 700000 };
            var sw = System.Diagnostics.Stopwatch.StartNew();
            Model.Objects.AddOrUpdate(credit);
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 100);
            sw.Reset();
        }
        
    }
    public void TestAdd1M()
    {
        var Model = new CarCreditListViewModel();
        var data = new List<CarCreditModelProxy>(1000000);
        var cars = new Car[10];
        var prices = new BankCreditPrice[10];
        for (int i = 1; i <= 10; i++) {
            var car = new Car() { Caption = $"Жигули-{i}", Price = i*250000 };
            cars[i - 1] = car;
            var BankCreditPrice = new BankCreditPrice() { Caption = $"Кредит-{i}", Koef = i * 0.1M };
            prices[i - 1] = BankCreditPrice;
        }
        
       
        
        Random rand = new Random();
        for (int i = 0; i < 1000000; i++) {
            var randInt = rand.Next(0, 9);
            var credit = new BankCredit(i) { BankCreditPrice = prices[randInt], Car = cars[randInt], Summ = 700000 };
            var sw = System.Diagnostics.Stopwatch.StartNew();
            Model.Objects.AddOrUpdate(credit);
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 150);
            sw.Reset();
        }
    }

    public void TestChangeField1Million()
    {
        var Model = new CarCreditListViewModel();
        var data = new List<CarCreditModelProxy>(1000000);
        var cars = new Car[10];
        var prices = new BankCreditPrice[10];
        for (int i = 1; i <= 10; i++) {
            var car = new Car() { Caption = $"Жигули-{i}", Price = i*250000 };
            cars[i - 1] = car;
            var BankCreditPrice = new BankCreditPrice() { Caption = $"Кредит-{i}", Koef = i * 0.1M };
            prices[i - 1] = BankCreditPrice;
        }
        
       
        
        Random rand = new Random();
        for (int i = 0; i < 1000000; i++) {
            var randInt = rand.Next(0, 9);
            var credit = new BankCredit(i) { BankCreditPrice = prices[randInt], Car = cars[randInt], Summ = 700000 };
            Model.Objects.AddOrUpdate(credit);
        }

        var CreditForTest = Model.Objects.Items.First(x => x.Id == 999999);
        var carForTest = CreditForTest.Car;
        var proxy = Model.Proxies.First(x => x.Id == CreditForTest.Id);
        var sw = System.Diagnostics.Stopwatch.StartNew();
        carForTest.Caption = "NewCarName";
        Assert.Equal("NewCarName", proxy.CarCaption);
        sw.Stop();
        Assert.True(sw.ElapsedMilliseconds < 50);
    }
}