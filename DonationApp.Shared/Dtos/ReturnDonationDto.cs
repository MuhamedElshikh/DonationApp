namespace DonationApp.Shared.Dtos
    {
    public class ReturnDonationDto
        {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public string ReceiptNumber { get; set; }
        public Guid DonorId { get; set; }
        public string DonorName { get; set; }
        }
    }