using SQLite;
namespace TodoGuru
{
    public class UserTask
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string taskName { get; set; }
        public string logDate { get; set; }
        public string dueDate { get; set; }
        public string description { get; set; }
        public bool complete { get; set; }
    }
}