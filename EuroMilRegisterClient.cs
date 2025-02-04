using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

// Supondo que os stubs gerados definem o namespace 'euromil' e a classe 'EuroMil.EuroMilClient'
public static class EuroMilRegisterClient
{
    public static async Task<string> RegistrarApostaAsync(string key, string checkID)
    {
        // Como o serviço não usa SSL, usa "http" e configura para aceitar ligações inseguras
        var channel = GrpcChannel.ForAddress("http://ken.utad.pt:8282");

        // Cria o cliente gRPC (ajuste o nome conforme o gerado pelo .proto)
        var client = new euromil.EuroMil.EuroMilClient(channel);

        // Cria o pedido com os dados necessários
        var request = new euromil.RegisterRequest
        {
            Key = key,
            Checkid = checkID
        };

        try
        {
            var reply = await client.RegisterEuroMilAsync(request);
            return reply.Message; // Mensagem de sucesso ou erro
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao registar aposta via EuroMilRegister: " + ex.Message);
        }
    }
}
