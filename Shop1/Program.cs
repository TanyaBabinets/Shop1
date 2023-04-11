using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//5.2  Добавьте к уже созданному классу информацию о площади магазина. Выполните перегрузку +
//(для увеличения площади магазина на указанную величину), — (для уменьшения площади магазина на
//указанную величину), == (проверка на равенство площадей магазинов), < и > (проверка на меньше или больше
//площади магазина), != и Equals.Используйте механизм свойств для полей класса.
namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Store st = new Store("Tavria", "Koroleva, 32", "products", "05033344455", "market@gmail.com", 56);
            Console.WriteLine(st);

            Console.WriteLine("На какое количество кв.м следует увеличить площадь первого магазина?");
            int n = Convert.ToInt32(Console.ReadLine());
            st = st + n;
            Console.WriteLine($"При увеличении площади магазина на это кол-во кв.м получится площадь {st.Square}");

           

            Store st1 = new Store("Mr.Dog", "Vavilova, 2", "goods for animals", "05022244400", "pet@gmail.com", 67);
            Console.WriteLine(st1);
            Console.WriteLine($"Сравнение площадей 2-х магазинов через metod Equals = {st.Equals(st1)}");

            Console.WriteLine($"Сравнение площадей 2-х магазинов через operator \'>\' = { st > st1}");
            Console.WriteLine("На какое количество кв.м следует уменьшить площадь второго магазина?");
            n = Convert.ToInt32(Console.ReadLine());
            st1 = st1 - n;
            Console.WriteLine($"При уменьшении площади магазина на это кол-во кв.м получится площадь { st1.Square}\n");
            Console.WriteLine($"Сравнение площадей 2-х магазинов через operator \'==\' = { st == st1}");
            Console.ReadLine();
        }


    }

    class Store

    {
        private double square;

        public double Square
        {
            get { return square; }
            set
            {
                if (value > 0)
                    square = value;
            }
        }

        public Store() { Console.WriteLine("default const"); }


        public Store(string n, string ad, string type, string t, string em, double sq) // Конструктор класса
        {
            Name = n;
            Address = ad;
            info = type;
            Tel = t;
            Email = em;
            square = sq;

        }
        public static Store operator +(Store ob, double n)
        {
            return new Store(ob.name, ob.address, ob.info, ob.tel, ob.email, ob.square + n);
        }

        public static Store operator -(Store ob, double n)
        {
            return new Store(ob.name, ob.address, ob.info, ob.tel, ob.email, ob.square - n);
        }

        public static bool operator >(Store ob1, Store ob2)
        {
            return ob1.square > ob2.square;
        }

        public static bool operator <(Store ob1, Store ob2)
        {
            return !(ob1 > ob2);
        }

        public static bool operator ==(Store ob1, Store ob2)
        {
            return ob1.square == ob2.square;
        }

        public static bool operator !=(Store ob1, Store ob2)
        {
            return !(ob1 == ob2);
        }

        public override bool Equals(object obj)
        {

            if (obj == null)
                return false;

            Store store = (Store)obj;

            if (square == store.square)
                return true;

            return false;
        }




        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != "")
                    name = value;
            }
        }

        string address;
        public string Address
        {
            get
            { return address; }
            set
            {
                if (value != "")
                    address = value;
            }
        }
        public string info { get; set; }

        string tel;
        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                if (value != "")
                    tel = value;
            }
        }
        string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value != "")
                    email = value;
            }
        }


        public override string ToString()
        {
            string result = "";
            result += $"Our store named {Name} has address {Address} and sells {info}. \n";
            result += $"Our tel. is { Tel } and our email is {Email}\n";
            result += $"Our store has square { square } ";
            return result;
        }

        public override int GetHashCode()
        {
            int hashCode = -707588619;
            hashCode = hashCode * -1521134295 + square.GetHashCode();
            hashCode = hashCode * -1521134295 + Square.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(info);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(tel);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Tel);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }
    }
}

