using Xunit;
using CinemaTicketSystem;

namespace TestProject1
{
    public class CinemaTicketSystemTests
    {
        public const decimal DefaultPrice = 300;
        public const decimal Free = 0;
        public const double Students_Twenty_Persent_Discount = 0.8;
        public const double Kids_Fourty_Persent_Discount = 0.6;
        public const double OldPeople_Fifty_Persent_Discount = 0.5;
        public const double WednesDay_Thirty_Persent_Discount = 0.7;
        public const decimal OneHundred_Persent_Price = 2;
        public const double Morning_Fifteen_Persent_Discount = 0.85;


        [Fact]
        //обычный
        public void BasicTicket_ReturnBasic()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 40,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(18, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            Assert.Equal(DefaultPrice, Calculator.CalculatePrice(TotalPrice));

        }
        [Fact]
        //детский до 6
        public void KidsBeforeSixTicket_ReturnFree()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 4,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(18, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            Assert.Equal(Free, Calculator.CalculatePrice(TotalPrice));

        }
        [Fact]
        //дети 6-17
        public void KidsTicket_ReturnFourtyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 8,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(18, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)Kids_Fourty_Persent_Discount);


            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //студент
        public void StudentTicket_ReturnTwentyPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 19,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(18, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (decimal)(DefaultPrice * (decimal)Students_Twenty_Persent_Discount);

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }
        [Fact]
        //пожилой
        public void OldTicket_ReturnFiftyPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 67,
                IsStudent =false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(18, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)OldPeople_Fifty_Persent_Discount);

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Среда
        public void WednesdayTicket_ReturnThirtyPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 40,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(18, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (decimal)(DefaultPrice * (decimal)WednesDay_Thirty_Persent_Discount);

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //утро
        public void MorningTicket_ReturnFifteenPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 40,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Sunday,
                SessionTime = new TimeSpan(11, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (decimal)(DefaultPrice * (decimal)Morning_Fifteen_Persent_Discount);

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //вип
        public void VipTicket_ReturnPlusOneHundredPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 40,
                IsStudent = false,
                IsVip = true,
                Day = DayOfWeek.Sunday,
                SessionTime = new TimeSpan(15, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price =DefaultPrice * OneHundred_Persent_Price;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Дети 7-16 и Утро
        public void KidsAndMorningDiscountTicket_ReturnFourtyAndfiftyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 8,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(10, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)Kids_Fourty_Persent_Discount)*(decimal)Morning_Fifteen_Persent_Discount;

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));
        }

        [Fact]
        //Дети 7-16 и Утро среды
        public void KidsAndMorningWednesdayDiscountTicket_ReturnFourtyAndfiftyAndThirtyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 8,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(10, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)Kids_Fourty_Persent_Discount) * (decimal)Morning_Fifteen_Persent_Discount * (decimal)WednesDay_Thirty_Persent_Discount;

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));
        }

        [Fact]
        //Дети 7-16 и Утро среды максимальная скидка 40
        public void KidsAndMorningWednesdayMaxDiscountTicket_ReturnFourtyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 8,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(10, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)Kids_Fourty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));
        }

        [Fact]
        //Дети 7-16 и среда
        public void KidsAndWednesdayDiscountTicket_ReturnFourtyAndThirtyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 8,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(14, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)Kids_Fourty_Persent_Discount) * (decimal)WednesDay_Thirty_Persent_Discount;

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));
        }

        [Fact]
        //пожилой утром
        public void OldAndMorningTicket_ReturnFiftyAndFifteenPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 67,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(10, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)OldPeople_Fifty_Persent_Discount * (decimal)Morning_Fifteen_Persent_Discount);

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //пожилой в среду
        public void OldAndWednesdayTicket_ReturnFiftyAndThirtyPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 67,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(10, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)OldPeople_Fifty_Persent_Discount * (decimal)WednesDay_Thirty_Persent_Discount);

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //пожилой в среду утром
        public void OldAndWednesdayMorningTicket_ReturnFiftyAndThirtyAndFifteenPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 67,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(10, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)OldPeople_Fifty_Persent_Discount * (decimal)WednesDay_Thirty_Persent_Discount * (decimal)Morning_Fifteen_Persent_Discount);

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //пожилой в среду утром максимальная скидка 50
        public void OldAndWednesdayMorningMaxTicket_ReturnFiftyPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 67,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(10, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)OldPeople_Fifty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Студент утром
        public void StudentAndMorningTicket_ReturnTwentyAndFifteenPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 20,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(10, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = ((decimal)DefaultPrice * (decimal)Students_Twenty_Persent_Discount * (decimal)Morning_Fifteen_Persent_Discount);

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Студент в среду
        public void StudentAndWednesdayTicket_ReturnTwentyAndThirtyPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 20,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)Students_Twenty_Persent_Discount * (decimal)WednesDay_Thirty_Persent_Discount;

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Студент в среду утром
        public void StudentAndWednesdayMorningTicket_ReturnTwentyAndThirtyAndFifteenPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 20,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)Students_Twenty_Persent_Discount * (decimal)WednesDay_Thirty_Persent_Discount * (decimal)Morning_Fifteen_Persent_Discount;

            Assert.NotEqual(Price, Calculator.CalculatePrice(TotalPrice));

        }
        [Fact]
        //Студент в среду утром максимальная 30
        public void StudentAndWednesdayMorningMaxTicket_ReturnThirtyPersent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 20,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)WednesDay_Thirty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Студент вип
        public void StudentVipTicket_ReturnTwentyPersentPlus()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 20,
                IsStudent = true,
                IsVip = true,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)Students_Twenty_Persent_Discount)*OneHundred_Persent_Price;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Пожилой вип
        public void OldVipTicket_ReturnFiftyPersentPlus()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 99,
                IsStudent = false,
                IsVip = true,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)OldPeople_Fifty_Persent_Discount) * OneHundred_Persent_Price;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //ребенок вип
        public void KIdVipTicket_ReturnFourtyPersentPlus()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 8,
                IsStudent = false,
                IsVip = true,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = (DefaultPrice * (decimal)Kids_Fourty_Persent_Discount) * OneHundred_Persent_Price;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //минимальный возраст
        public void MinAgeTicket_ReturnFree()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 0,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * Free;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Максимальный возраст
        public void MaxAgeTicket_ReturnFiftyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 70,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)OldPeople_Fifty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }


        [Fact]
        //максимальный возраст скидки 100%
        public void FiveAgeBabyTicket_ReturnFree()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 5,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * Free;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //минимальный возраст скидки 40%
        public void SixAgeKidTicket_ReturnFortyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 6,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)Kids_Fourty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //максимальный возраст скидки 40%
        public void SeventeenAgeKidTicket_ReturnFortyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 17,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)Kids_Fourty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //минимальный возраст скидки 20%
        public void EighteenAgeStudentTicket_ReturnTwentyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 18,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)Students_Twenty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Максимальный возраст скидки 20%
        public void TwentyFiveAgeStudentTicket_ReturnTwentyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 25,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)Students_Twenty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //минимальный возраст обычной цены
        public void TwentySixAgeTicket_ReturnDefault()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 25,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //максимальный возраст обычной цены
        public void SixtyFourAgeTicket_ReturnDefault()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 64,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Минимальный возраст Пенсионера
        public void SixtyFiveAgeTicket_ReturnFiftyPercent()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 65,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            TicketPriceCalculator Calculator = new();

            decimal Price = DefaultPrice * (decimal)OldPeople_Fifty_Persent_Discount;

            Assert.Equal(Price, Calculator.CalculatePrice(TotalPrice));

        }

        [Fact]
        //Пустой ввод
        public void NullRequest_ReturnException()
        {
            var TotalPrice = new TicketPriceCalculator();

            Assert.Throws<ArgumentNullException>(
                () => TotalPrice.CalculatePrice(null)
            );

        }

        [Fact]
        //Минусовой ввод возраста
        public void MinusOneAgeTicket_ReturnException()
        {
            var TotalPrice = new TicketRequest
            {
                Age = -1,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            var calc = new TicketPriceCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => calc.CalculatePrice(TotalPrice)
            );

        }

        [Fact]
        // ввод возраста юольше 120
        public void ThreeHundredAgeTicket_ReturnException()
        {
            var TotalPrice = new TicketRequest
            {
                Age = 300,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Friday,
                SessionTime = new TimeSpan(13, 55, 11)
            };

            var calc = new TicketPriceCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => calc.CalculatePrice(TotalPrice)
            );

        }
    }
}
