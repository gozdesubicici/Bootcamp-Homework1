using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SRP
{
    // Single Responsibility Principle - Tek Sorumluluk Prensibi

    // ÖRNEK
    // Elimizde Ekleme, Silme, Hata Kaydı ve Eposta Gönderme yapan bir Fatura sınıfımız olsun. Yani biz dört işi aynı sınıf içerisine koymuş oluyoruz. Aslında bizim Fatura sınıfımızın yapması gereken sorumluluk yalnızca Faturayla ilgili olan Fatura Ekleme ve Silmedir, exstra olarak mail gönderme ve hata kaydını da ekleyerek SRP yi ihlal etmiş oluyoruz çünkü bir sınıfımızın birden çok sorumluluğu olmuş oluyor. Aşağıdaki kod SRP'ye uygun olmayan şekildedir.

    // SRP'de kastedilen sorumluluktur iş değildir. Yani bir sınıf yalnızca bir yöntem ya da özellik içermesine gerek yoktur. Tek bir sorumluluk ile ilgili oldukları sürece birden fazla üyeye (yöntem veya özellik) sahip olabilirsiniz.

    #region SRP'ye uygun olmayan kod
    public class Invoice
    {
        public long InvAmount { get; set; }
        public DateTime InvDate { get; set; }
        public void AddInvoice()
        {
            try
            {
                // Here we need to write the Code for adding invoice
                // Once the Invoice has been added, then send the  mail
                MailMessage mailMessage = new MailMessage("EMailFrom", "EMailTo", "EMailSubject", "EMailBody");
                this.SendInvoiceEmail(mailMessage);
            }
            catch (Exception ex)
            {
                //Error Logging
                System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
            }
        }
        public void DeleteInvoice()
        {
            try
            {
                //Here we need to write the Code for Deleting the already generated invoice
            }
            catch (Exception ex)
            {
                //Error Logging
                System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
            }
        }
        public void SendInvoiceEmail(MailMessage mailMessage)
        {
            try
            {
                // Here we need to write the Code for Email setting and sending the invoice mail
            }
            catch (Exception ex)
            {
                //Error Logging
                System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
            }
        }
    }

    #endregion

    // SRP'ye uygun şekilde düzeltmek için Invoice yani Fatura sınıfını üç sınıf olacak şekilde parçalıyoruz. Fatura sınıfında sadece fatura ile ilgili işlevler uygulanacaktır. Logger sınıfı sadece loglama amacıyla kullanılacaktır. Benzer şekilde, E-posta sınıfı E-posta etkinliklerini yönetecektir. Artık her sınıfın yalnızca kendi sorumlulukları olacaktır.
    #region SRP'ye uygun kod
    public interface ILogger
    {
        void Info(string info);
        void Debug(string info);
        void Error(string message, Exception ex);
    }
    public class Logger : ILogger
    {
        public Logger()
        {
            // here we need to write the Code for initialization 
            // that is Creating the Log file with necesssary details
        }
        public void Info(string info)
        {
            // here we need to write the Code for info information into the ErrorLog text file
        }
        public void Debug(string info)
        {
            // here we need to write the Code for Debug information into the ErrorLog text file
        }
        public void Error(string message, Exception ex)
        {
            // here we need to write the Code for Error information into the ErrorLog text file
        }
    }

    public class MailSender
    {
        public string EMailFrom { get; set; }
        public string EMailTo { get; set; }
        public string EMailSubject { get; set; }
        public string EMailBody { get; set; }
        public void SendEmail()
        {
            // Here we need to write the Code for sending the mail
        }
    }

    public class Invoice2
    {
        public long InvAmount { get; set; }
        public DateTime InvDate { get; set; }
        private ILogger fileLogger;
        private MailSender emailSender;
        public Invoice2()
        {
            fileLogger = new Logger();
            emailSender = new MailSender();
        }
        public void AddInvoice()
        {
            try
            {
                fileLogger.Info("Add method Start");
                // Here we need to write the Code for adding invoice
                // Once the Invoice has been added, then send the  mail
                emailSender.EMailFrom = "emailfrom@xyz.com";
                emailSender.EMailTo = "emailto@xyz.com";
                emailSender.EMailSubject = "Single Responsibility Princile";
                emailSender.EMailBody = "A class should have only one reason to change";
                emailSender.SendEmail();
            }
            catch (Exception ex)
            {
                fileLogger.Error("Error Occurred while Generating Invoice", ex.Message);
            }
        }
        public void DeleteInvoice()
        {
            try
            {
                //Here we need to write the Code for Deleting the already generated invoice
                fileLogger.Info("Delete Invoice Start at @" + DateTime.Now);
            }
            catch (Exception ex)
            {
                fileLogger.Error("Error Occurred while Deleting Invoice", ex);
            }
        }
    }



    #endregion
}


