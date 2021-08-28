namespace CryptorService.Models
{
    public class ParibuApiResponse<TInnerResponse>
    {
        public bool Success { get; set; }

        public TInnerResponse Data { get; set; }
    }
}
