using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class ChequeDigital
{
    public DateTime Date { get; set; }
    public string CheckID { get; set; } = string.Empty;
}

public static class CrediBankClient
{
    // Método para solicitar o cheque digital
    public static async Task<ChequeDigital> ObterChequeDigitalAsync(string creditAccountId, int value)
    {
        // Monta a URL conforme especificação
        string url = $"http://ken.utad.pt:8181/check/{creditAccountId}/amount/{value}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // O endpoint retorna um array JSON com 1 objeto
                    var cheque = JsonConvert.DeserializeObject<ChequeDigital>(json);
                    return cheque;
                }
                else
                {
                    // retorna o erro conforme a mensagem
                    throw new Exception($"Erro na API Credibank: {json}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar com o CrediBank: " + ex.Message);
            }
        }
    }
}

