using DNCD.Services.Features.Customer.Model;

namespace DNCD.Services.Features.Student.Model
{
    public class CustomerModel : BaseModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
