namespace orangeMartDev.Data
{
    public class User: Entity
    {  
        public string Email { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; } //value object
        //public Object Picture { get; set; }
        public Role Role { get; set; } //Enum
        public UserStatus Status { get; set; }
    }  
}
