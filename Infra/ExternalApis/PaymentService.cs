using Efipay;
using OikosPortal.Infra.ExternalApis.Interfaces;

namespace OikosPortal.Infra.ExternalApis;

public class PaymentService : IPaymentService
{

    public PaymentService()
    {
    }

    public void ProcessPayment()
    {

        //var efi = new EfiPay("", "", true, "");


        dynamic efi = new EfiPay("client_id", "client_secret", true, "production.p12");

        var body = new
        {
            calendario = new
            {
                expiracao = 3600
            },
            devedor = new
            {
                cpf = "12345678909",
                nome = "Francisco da Silva"
            },
            valor = new
            {
                original = "1.45"
            },
            chave = "71cdf9ba-c695-4e3c-b010-abb521a3f1be",
            solicitacaoPagador = "Informe o número ou identificador do pedido."
        };

        var response = efi.CreatePlan(null, body);
        Console.WriteLine(response);

    }
}
