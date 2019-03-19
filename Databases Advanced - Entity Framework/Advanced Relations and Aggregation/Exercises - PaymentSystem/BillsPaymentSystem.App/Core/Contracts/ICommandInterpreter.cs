using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App.Core
{
    public interface ICommandInterpreter
    {
        string Read(string[] args, PaymentSystemContext context);
    }
}