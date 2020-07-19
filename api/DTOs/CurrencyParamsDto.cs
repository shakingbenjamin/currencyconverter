namespace api.DTOs
{
    public class CurrencyParamsDto
    {
        public string FromAmount { get; set; }
        public string FromCode { get; set; }
        public string ToCode { get; set; }
        public string Rate { get; set; }
    }
}