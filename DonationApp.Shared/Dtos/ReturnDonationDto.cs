namespace DonationApp.Shared.Dtos
{
    public class ReturnDonationDto
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ReceiptNumber { get; set; }
        public Guid DonorId { get; set; }
       public string DonorName { get; set; }
    }
}