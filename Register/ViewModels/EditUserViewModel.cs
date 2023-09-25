using Register.Data.Enum;

namespace Register.ViewModels
{
    public class EditUserViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        
        public string? Email { get; set; }
        public string? phone { get; set; }
    }
}
