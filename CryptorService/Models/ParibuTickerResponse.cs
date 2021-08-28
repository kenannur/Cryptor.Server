using System.Text.Json.Serialization;

namespace CryptorService.Models
{
    public class ParibuTickerResponse
    {
        [JsonPropertyName("btc-tl")]
        public BtcTlTickerResult BtcTlTickerResult { get; set; }
    }

    public class BtcTlTickerResult
    {
        // For example: "btc-tl"
        public string Pair { get; set; }

        // En düşük satış arzı
        public decimal Ask { get; set; }

        // En yüksek alış talebi
        public decimal Bid { get; set; }

        // 24 saatlik en düşük tutar
        public decimal Low { get; set; }

        // 24 saatlik en yüksek tutar
        public decimal High { get; set; }

        // 24 saatlik ortalama tutar
        public decimal Average { get; set; }

        // 24 saatlik işlem hacmi(BTC cinsinden)
        public string Volume { get; set; }

        // 24 saat önceki son işlem tutarı
        public decimal Open { get; set; }

        // Son işlem tutarı
        public decimal Close { get; set; }

        // Değişim tutarı
        public decimal Change { get; set; }
    }
}
