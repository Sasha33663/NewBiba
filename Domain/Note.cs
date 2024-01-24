namespace WebApplication3.Domain
{
    
        public class Note
        {
            public Guid ID { get; set; }
            public string Header { get; set; }
            public string Text { get; set; }
            public DateTime Date { get; set; }
            public bool Status { get; set; }
        }
    
}
