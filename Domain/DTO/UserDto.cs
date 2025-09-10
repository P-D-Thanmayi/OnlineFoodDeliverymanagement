namespace FoodDeliveryProject.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password{ get; set; }
        public string Phoneno { get; set; }

        public bool IsValid { get; set; }

        public string Role { get; set; }
    }
}
