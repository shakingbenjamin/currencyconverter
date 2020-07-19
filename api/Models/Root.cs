namespace api.Models
{
    public class Root
    {
        public string FromCode { get; set; }
        public double FromRate { get; set; }
        public string ToCode { get; set; }
        public double ToRate { get; set; }
        public double FromAmount { get; set; }
        public double ToAmount { get; set; }
    }
}