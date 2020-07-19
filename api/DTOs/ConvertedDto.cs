namespace api.DTOs
{
    public class ConvertedDto
    {
        public decimal Result { get; set; }
        public decimal Amount { get; set; }
        public string FromCode { get; set; }
        public string ToCode { get; set; }
        public decimal Rate { get; set; }
    }
}