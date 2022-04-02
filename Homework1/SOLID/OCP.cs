using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP
{
    // Open-Closed Principle - Açık-Kapalı Prensibi

    //  “ modüller, sınıflar, fonksiyonlar vb. yazılım varlıklarının genişletilmeye açık, ancak değiştirilmeye kapalı olması gerektiğini ” belirtir. 

    // İlki Uzatmaya Açık, ikincisi ise Değiştirilmeye Kapalıdır. Genişletmeye Açık, yazılım modüllerini/sınıflarını, yeni gereksinimler geldiğinde yeni sorumluluklar veya işlevler kolayca eklenecek şekilde tasarlamamız gerektiği anlamına gelir. Öte yandan, Modifikasyona Kapalı, bazı hatalar bulana kadar sınıfı/modülü değiştirmememiz gerektiği anlamına gelir. Bunun nedeni, zaten bir sınıf/modül geliştirmiş olmamız ve birim test aşamasından geçmiş olmasıdır.

    // Basit bir ifadeyle, kaynak kodunu değiştirmeden davranışının genişletilmesine izin verecek şekilde bir modül/sınıf geliştirmemiz gerektiğini söyleyebiliriz.

    /* C#'da Açık-Kapalı İlke (OCP) için Uygulama Yönergeleri
 1. Açık-Kapalı İlkesini C#'ta uygulamanın en kolay yolu, orijinal temel sınıftan devralınması gereken yeni türetilmiş sınıflar oluşturarak yeni işlevleri eklemektir.
 2. Başka bir yol, istemcinin orijinal sınıfa soyut bir arayüzle erişmesine izin vermektir.
 3. Bu nedenle, herhangi bir zamanda, gereksinimde bir değişiklik olduğunda veya herhangi bir yeni gereksinim geldiğinde, mevcut işlevselliğe dokunmak yerine yeni türetilmiş sınıflar oluşturmak ve orijinal sınıf uygulamasını olduğu gibi bırakmak her zaman daha iyidir ve önerilir. */

    // ÖRNEK
    // Şimdi burada Fatura sınıfımızın içine GetInvoiceDiscount() metodunu oluşturduk ve bu yöntemde Fatura türüne göre bize son tutarı bize verecek. Elimizde iki Fatura Tipi var bu tiplere göre if-else yapısı oluşturarak o tipe göre bize son miktarını verecek. Ama bir zaman sonra yeni bir Fatura Tipi eklenmek istese bir tane daha else if koşulu eklememiz gerekecek.Yani yazdığımız Fatura sınıfını değiştirmiş olacağız.Buda Değişime Kapalı olması gerekliliğine aykırıdır.
    #region OCP'ye uygun olmayan kod

    public class Invoice
    {
        public double GetInvoiceDiscount(double amount, InvoiceType invoiceType)
        {
            double finalAmount = 0;
            if (invoiceType == InvoiceType.FinalInvoice)
            {
                finalAmount = amount - 100;
            }
            else if (invoiceType == InvoiceType.ProposedInvoice)
            {
                finalAmount = amount - 50;
            }
            return finalAmount;
        }
    }
    public enum InvoiceType
    {
        FinalInvoice,
        ProposedInvoice
    };
    #endregion
    // Bunun yerine base Fatura sınıfı oluşturup diğer Fatura türlerini bu Fatura sınıfından miras aldırabiliriz. Miras alan bu sınıflar base Fatura sınıfındaki virtual GetInvoiceDiscount() metodunu kendilerine göre override ederek kullanabilir. Ve yeni Fatura türleri eklendikçe base sınıfı değiştirmek zorunda kalmayız.
    #region OCP'ye uygun kod

    public class Invoice2
    {
        public virtual double GetInvoiceDiscount(double amount)
        {
            return amount - 10;
        }
    }

    public class FinalInvoice : Invoice2
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 50;
        }
    }
    public class ProposedInvoice : Invoice2
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 40;
        }
    }
    public class RecurringInvoice : Invoice2
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 30;
        }
    }
    #endregion
}
