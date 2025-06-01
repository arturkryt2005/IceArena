namespace IceArena.Web.Models
{
    public class MatchDto
    {
        public int Team1Id { get; set; }  
        public int Team2Id { get; set; } 
        public string Location { get; set; }
        public string Result { get; set; }
        public DateTime? MatchDate { get; set; }

        public string Team1Name { get; set; } = "Неизвестная команда";
        public string Team2Name { get; set; } = "Неизвестная команда";
    }
}
