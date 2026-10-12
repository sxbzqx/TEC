using System.Text;
using System.Xml.Linq;
using Microsoft.Extensions.Caching.Memory;
using tecBackend.Models;

namespace tecBackend.Services;

public class OfficeEquipmentService(HttpClient http, IMemoryCache cache, IConfiguration configuration)
{
    private const int MaxPages = 20;

    static OfficeEquipmentService() =>
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

    public Task<List<OfficeComputerDto>> GetByTypeAsync(int nout, CancellationToken ct)
    {
        string cacheKey = $"office-equipment-{nout}";

        return cache.GetOrCreateAsync(cacheKey, async e =>
        {
            e.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            var all = new List<OfficeComputerDto>();

            var encoding = CodePagesEncodingProvider.Instance.GetEncoding("windows-1251") ?? Encoding.UTF8;
            var sessionId = configuration["TEC_SESSION_ID"];
            
            // Динамический URL в зависимости от nout (0 - ПК, 1 - Ноутбуки)
            var baseUrl = $"http://10.0.70.30:8080/documentooborot/select_comp.php?nout={nout}&page=";

            for (var page = 1; page <= MaxPages; page++)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}{page}");

                if (!string.IsNullOrEmpty(sessionId))
                {
                    request.Headers.Add("Cookie", $"PHPSESSID={sessionId}");
                }
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                request.Headers.Add("Referer", "http://10.0.70.30:8080/");

                var response = await http.SendAsync(request, ct);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    break;
                }

                response.EnsureSuccessStatusCode();

                var responseBytes = await response.Content.ReadAsByteArrayAsync(ct);
                var xmlContent = encoding.GetString(responseBytes);

                using var reader = new StringReader(xmlContent);
                var doc = await XDocument.LoadAsync(reader, LoadOptions.None, ct);

                var items = doc.Root?.Elements("comp").Select(Map).ToList() ?? [];
                if (items.Count == 0) break;

                all.AddRange(items);
            }
            return all;
        })!;
    }

    private static OfficeComputerDto Map(XElement c)
    {
        string V(string n) => ((string?)c.Element(n))?.Trim() ?? "";
        return new(
            int.TryParse(V("id_c"), out var id) ? id : 0,
            V("inv_num"), V("name_c"), V("phone"), V("name_obj"),
            V("id_otd"), V("user_dep"), V("user_fio"),
            V("cpu"), V("ram_1"), V("ram_2"), V("hdd_1"), V("hdd_2"),
            V("optical_1"), V("video"), V("audio"), V("speakers"), V("monitor"),
            V("input_month"), V("input_year"));
    }
}