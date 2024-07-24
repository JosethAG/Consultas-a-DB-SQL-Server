namespace ConexionesDB.Models
{
    public class User
    {
        public int UserID { get; set; }        
        public string FirstName { get; set; }  
        public string LastName { get; set; }   
        public string Email { get; set; }      
        public DateTime BirthDate { get; set; }
        public string City { get; set; }       
        public string Country { get; set; }
    }
}
