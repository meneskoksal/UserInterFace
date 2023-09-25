using Register.Data.Enum;

namespace Register.ViewModels
{
    public class CreateUserViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string password { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
    }
}
