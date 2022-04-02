using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LSP
{
    // Liskov Substitution Principle - Liskov İkame Prensibi

    // Liskov Değiştirme İlkesi, nesne yönelimli programlama dilinde bir Değiştirilebilirlik ilkesidir. Bu ilke, S'nin T'nin bir alt türü olması durumunda, T türündeki nesnelerin S türündeki nesnelerle değiştirilebilmesi gerektiğini belirtir .

    // Bir temel sınıf ve alt sınıf ilişkilerimiz, yani kalıtım ilişkilerimiz olduğunda, o zaman bir üst sınıfın nesnesini/örneğini başarılı bir şekilde alt sınıfın bir nesnesi/örneğini ile değiştirebilirsek  o zaman Liskov Değiştirme İlkesinde olduğu söylenir.

    // ÖRNEK 1
    // Bir base Ördek sınıfımız olsun. Bu ördek sınıfından miras alan Yeşilbaşlı Ördek, Yaz ördeği, Plastik Ördek sınıfları olsun. Plastik Ördekler uçamayacağı için base sınıftan aldığı bu özelliği gerçekleştiremeyecektir. Yani Duck sınıf örneğini Plastik Ördek sınıf ördeğiyle değiştiremezsin. Yani değiştirsen de yanlış davranış sergilenmiş olur.

    #region LSP'ye uygun olmayan kod
    public abstract class Duck
    {
        public abstract void Quack();
        public abstract void Swim();
        public abstract void Fly();
    }

    public class MallardDuck : Duck
    {
        public override void Quack()
        {
            System.Console.WriteLine("Quack!");
        }

        public override void Swim()
        {
            System.Console.WriteLine("Swimming!");
        }

        public override void Fly()
        {
            System.Console.WriteLine("Flying!");
        }
    }

    public class MarbledDuck : Duck
    {
        public override void Quack()
        {
            System.Console.WriteLine("Quack!");
        }

        public override void Swim()
        {
            System.Console.WriteLine("Swimming!");
        }

        public override void Fly()
        {
            System.Console.WriteLine("Flying!");
        }
    }

    public class RubberDuck : Duck
    {
        public override void Quack()
        {
            System.Console.WriteLine("Squeak!");
        }

        public override void Swim()
        {
            System.Console.WriteLine("Floating!");
        }

        public override void Fly()
        {
            throw new Exception("Rubber ducks can't fly!");
        }
    }
    #endregion

    // O zaman plastik ördek (RubberDuck) sınıfımız uçamayacağı için, burada bağırma, yüzme ve uçma gibi özelliklerimizi bir Interface olarak tanımlayacağız. Böylelikle ördeklere interfaceler yardımıyla yapabilecekleri özellikleri verebiliriz.
    #region LSP'ye uygun kod

    public interface IFly
    {
        void Fly();
    }

    public interface ISwim
    {
        void Swim();
    }

    public interface IQuack
    {
        void Quack();
    }

    public class MallardDuck2 : IFly, ISwim, IQuack
    {
        public void Quack()
        {
            System.Console.WriteLine("Quack!");
        }

        public void Swim()
        {
            System.Console.WriteLine("Swimming!");
        }

        public void Fly()
        {
            System.Console.WriteLine("Flying!");
        }
    }

    public class MarbledDuck2 : IFly, ISwim, IQuack
    {
        public void Quack()
        {
            System.Console.WriteLine("Quack!");
        }

        public void Swim()
        {
            System.Console.WriteLine("Swimming!");
        }

        public void Fly()
        {
            System.Console.WriteLine("Flying!");
        }
    }

    public class RubberDuck2 : ISwim, IQuack
    {
        public void Quack()
        {
            System.Console.WriteLine("Squeak!");
        }

        public void Swim()
        {
            System.Console.WriteLine("Floating!");
        }
    }

    #endregion


}
