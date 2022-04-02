using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesignPattern
{
    // Bridge Design Pattern nedir?
    /*
    - Bridge tasarım deseni implementasyonları abstractlardan ayırabilmek için kullanılır.
    - 7 structural design pattern'dan biridir, benzer implementasyon class'larinin küçük farklılıkları varsa, araya bir bridge görevi görecek interface yaratıp, o köprü interface'ini kullanarak benzer bütün implementasyonları çağırabiliriz.         
     */


    // ÖRNEK
    // Müşterilerimizi ve firmaları kayıt ettiğimiz bir yazılım yazdığımızı varsayalım. Bu yazılımı geliştirirken veri tabanımıza log yazdıralım.


    // Log yazdıracağımız bir Interface ve durumlara göre yazacağımız ifadeleri belirten sınıflar yazalım.
    public interface ILogWriter
    {
        void LogWrite();
    }

    public class CustomerLog : ILogWriter
    {
        public void LogWrite()
        {
            Console.WriteLine("Customer");
        }
    }

    public class FirmLog : ILogWriter
    {
        public void LogWrite()
        {
            Console.WriteLine("Firm");
        }
    }

    // Log sınıfımızı yazalım ve Interface yapımızı bu sınıfa Injection yapalım.

    public class Log
    {
        public ILogWriter _logWriter { get; set; }
        public Log(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        public virtual void LogWrite()
        {
            _logWriter.LogWrite();
        }
    }

    // İşlem yapacağımız sınıfları yazarak Interface yapısını Base olarak ekleyelim ve Log metodunu da Ovveride ederek işlemlerimizi yazalım.

    public class Customer : Log
    {
        public Customer(ILogWriter writer) : base(writer)
        {

        }

        public override void LogWrite()
        {
            Console.WriteLine("Customer Added");
            base.LogWrite();
        }
    }

    public class Firm : Log
    {
        public Firm(ILogWriter writer) : base(writer)
        {

        }

        public override void LogWrite()
        {
            Console.WriteLine("Firm Added");
            base.LogWrite();
        }
    }
}
