namespace CryptorService.Entities
{
    public class TickerData : EntityBase
    {


        public string MainCcy { get; set; }

        public string CounterCcy { get; set; }

        // En yüksek alış talebi
        public decimal Bid { get; set; }

        // En düşük satış arzı
        public decimal Ask { get; set; }

        // 24 saatlik en düşük tutar
        public decimal Low { get; set; }

        // 24 saatlik en yüksek tutar
        public decimal High { get; set; }

        // 24 saatlik ortalama tutar
        public decimal Average { get; set; }

        // 24 saatlik işlem hacmi(MainCcy cinsinden)
        public int Volume { get; set; }

        // 24 saat önceki son işlem tutarı
        public decimal Open { get; set; }

        // Son işlem tutarı
        public decimal Close { get; set; }

        // Değişim tutarı
        public decimal Change { get; set; }
    }
}
