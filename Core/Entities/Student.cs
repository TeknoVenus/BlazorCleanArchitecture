namespace Core.Entities
{
    public class Student
    {
        public string id { get; set; }
        public string upi { get; set; }
        public string mis_id { get; set; }
        public string initials { get; set; }
        public string surname { get; set; }
        public string forename { get; set; }
        public object middle_names { get; set; }
        public string legal_surname { get; set; }
        public string legal_forename { get; set; }
        public string gender { get; set; }
        public DateOfBirth date_of_birth { get; set; }
        public CreatedAt created_at { get; set; }
        public UpdatedAt updated_at { get; set; }
    }
}