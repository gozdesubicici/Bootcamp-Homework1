// See https://aka.ms/new-console-template for more information
using BridgeDesignPattern;

Console.WriteLine("Hello, World!");

Log logCustomer = new Customer(new CustomerLog());
logCustomer.LogWrite();

Log logFirm = new Firm(new FirmLog());
logFirm.LogWrite();



