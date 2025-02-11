namespace IceArena.Web.Models
{
    public class MatchDto
    {
        public int Team1Id { get; set; }  
        public int Team2Id { get; set; } 
        public string Location { get; set; }
        public string Result { get; set; }
        public DateTime MatchDate { get; set; } 
    }
}
