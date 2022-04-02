using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    // Facade deseni, class kullanımını seviyelendiren bir tasarım desenidir. Basitçe herhangi bir class/fonksiyon içinden diğer class/fonksiyon'ları çağırmaya yarayan desendir. Facade deseni sistem karmaşıklığını gizler ve client(istemci)'nin sisteme erişmesini sağlayan bir arabirim görevi üstlenir.

    // Facade Türkçe ’ye cephe olarak çevriliyor. Bu tasarım kalıbı adından da anlaşılacağı üzere yazılımımız için yeni cephe(arayüz) oluşturuyor diyebiliriz.

    // Bu tasarım kalıbı bir veya birden fazla sınıftaki karmaşayı bir cephenin ardına gizler.Karmaşık alt sistemleri olan bir yapıyı; tek , makul bir arayüz sağlayan Facade sınıfı oluşturarak basitleştirebiliriz.

    // Karmaşık ve detaylı olarak nitelendirdiğimiz bu sistemi bir alt sistem olarak varsayarsak eğer bu sistemi kullanacak clientlara daha basit bir arayüz sağlamak ve alt sistemleri bu arayüze organize bir şekilde dahil etmek ve bu alt sistemlerin sağlıklı çalışabilmesi için bu arayüz çatısı altında işin algoritmasına uygun işlev sergilemek istersek Facade Design Pattern’i kullanmaktayız.

    // ÖRNEK
    // Arabanın iskeleti ve  motoruyla birlikte bir araba oluşturalım. İki sınıfımız  olsun ve renkler enum'ı olsun.
    class IskeletOlusturu
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool z { get; set; }
    }

    class MotorOlusturucu
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool z { get; set; }
    }

    enum Renkler
    {
        Kırmızı,
        Mavi,
        Mor,
        Yeşil,
        Sarı
    }

    class Araba
    {
        public Araba(IskeletOlusturu Iskelet, MotorOlusturucu Motor, Renkler Renk)
        {
            Console.WriteLine($"Iskelet x = {Iskelet.x}");
            Console.WriteLine($"Iskelet y = {Iskelet.y}");
            Console.WriteLine($"Iskelet z = {Iskelet.z}");
            Console.WriteLine($"Motor x = {Motor.x}");
            Console.WriteLine($"Motor y = {Motor.y}");
            Console.WriteLine($"Motor z = {Motor.z}");
            Console.WriteLine($"Renk = {Renk}");
        }
    }

    class ArabaOlusturucu
    {
        public IskeletOlusturu Iskelet { get; set; }
        public MotorOlusturucu Motor { get; set; }
        public ArabaOlusturucu(IskeletOlusturu Iskelet, MotorOlusturucu Motor)
        {
            this.Iskelet = Iskelet;
            this.Motor = Motor;
        }

        public Araba Olustur(Renkler renk)
        {
            return new Araba(Iskelet, Motor, renk);
        }
    }

    class FacadeUretici
    {
        IskeletOlusturu iskelet;
        MotorOlusturucu motor;
        ArabaOlusturucu olustur;

        public FacadeUretici()
        {
            iskelet = new IskeletOlusturu() { x = 3, y = 5, z = true };
            motor = new MotorOlusturucu() { x = 2, y = 4, z = false };
            olustur = new ArabaOlusturucu(iskelet, motor);
        }

        public void ArabaUret()
        {
            Araba uretilenAraba = olustur.Olustur(Renkler.Kırmızı);
        }
    }
}
