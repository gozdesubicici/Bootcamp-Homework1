using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.ISP
{
    // Interface Segregation Principle - Arayüz Ayrıştırma Prensibi

    // İstemciler, kullanmadıkları hiçbir yöntemi uygulamaya zorlanmamalıdır. Tek bir büyük arayüz yerine, her  arayüzün bir alt modüle hizmet ettiği yöntem gruplarına dayalı çok sayıda küçük arayüz tercih edilir.  
    /*
     1.İlk olarak, hiçbir sınıf, kullanmadıkları bir arabirimin yöntemini/yöntemlerini uygulamaya zorlanmamalıdır.
     2.İkinci olarak, büyük veya büyük diyebileceğiniz arayüzler oluşturmak yerine, client yalnızca kendilerini ilgilendiren yöntemleri düşünmeleri amacıyla birden fazla küçük arayüz oluşturun.
     * Tek Sorumluluk İlkesine göre, sınıflar gibi arayüzlerin de tek bir sorumluluğu olmalıdır. Bu, herhangi bir sınıfı, ihtiyaç duymadıkları herhangi bir yöntemi/yöntemleri uygulamaya zorlamamamız gerektiği anlamına gelir.
     */

    // ÖRNEK
    // IPrinterTasks dört metodla tanımlanmış bir interfaceimiz var bu dört metodu uygulamak isteyen HPLaserJetPrinter classımız var ve bu dört metot içinden sadece Yazdırma ve Tarama olmak üzere yalnızca iki metodu kullanacak LiquidInkjetPrinter classımız var. Biz LiquidInkjetPrinter'a da bu interface'i implement edersek LiquidInkjetPrinter'ın gerektirmediği Fax ve PrinctDulex metotlarını da implement edecektir. Bu da ISP aykırı olacaktır.

    #region ISP'ye uygun olmayan kod
    public interface IPrinterTasks
    {
        void Print(string PrintContent);
        void Scan(string ScanContent);
        void Fax(string FaxContent);
        void PrintDuplex(string PrintDuplexContent);
    }

    public class HPLaserJetPrinter : IPrinterTasks
    {
        public void Print(string PrintContent)
        {
            Console.WriteLine("Print Done");
        }
        public void Scan(string ScanContent)
        {
            Console.WriteLine("Scan content");
        }
        public void Fax(string FaxContent)
        {
            Console.WriteLine("Fax content");
        }
        public void PrintDuplex(string PrintDuplexContent)
        {
            Console.WriteLine("Print Duplex content");
        }

        class LiquidInkjetPrinter : IPrinterTasks
        {
            public void Print(string PrintContent)
            {
                Console.WriteLine("Print Done");
            }
            public void Scan(string ScanContent)
            {
                Console.WriteLine("Scan content");
            }

            // Bu iki metot gerekmediği halde implement edilmek zorunda kalmıştır. Bu da Arayüz Ayrımı Prensibine aykırıdır.
            public void Fax(string FaxContent)
            {
                throw new NotImplementedException();
            }
            public void PrintDuplex(string PrintDuplexContent)
            {
                throw new NotImplementedException();
            }
        }
    }
    #endregion

    // Bu kodu ISP'ye uygun olarak yapmak için bu büyük arayüzü üç küçük arayüze ayırabiliriz. VE sınıflar istedikleri hizmetleri kendilerine göre uygulayabilir.
    #region ISP'ye uygun kod
    public interface IPrinterTasks2
    {
        void Print(string PrintContent);
        void Scan(string ScanContent);
    }
    interface IFaxTasks
    {
        void Fax(string content);
    }
    interface IPrintDuplexTasks
    {
        void PrintDuplex(string content);
    }
    public class HPLaserJetPrinter2 : IPrinterTasks2, IFaxTasks,
                                    IPrintDuplexTasks
    {
        public void Print(string PrintContent)
        {
            Console.WriteLine("Print Done");
        }
        public void Scan(string ScanContent)
        {
            Console.WriteLine("Scan content");
        }
        public void Fax(string FaxContent)
        {
            Console.WriteLine("Fax content");
        }
        public void PrintDuplex(string PrintDuplexContent)
        {
            Console.WriteLine("Print Duplex content");
        }
    }

    class LiquidInkjetPrinter2 : IPrinterTasks2
    {
        public void Print(string PrintContent)
        {
            Console.WriteLine("Print Done");
        }
        public void Scan(string ScanContent)
        {
            Console.WriteLine("Scan content");
        }
    }
    #endregion

}
