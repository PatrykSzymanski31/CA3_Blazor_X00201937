namespace WhoaWebApp
{
    public class WhoaResult
    {
        public string? movie { get; set; }
        public int year { get; set; }
        public string? release_date { get; set; }
        public string? director { get; set; }
        public string? character { get; set; }
        public string? movie_duration { get; set; }
        public string? timestamp { get; set; }
        public string? full_line { get; set; }
        public int current_whoa_in_movie { get; set; }
        public int total_whoas_in_movie { get; set; }
        public Dictionary<string, string> video { get; set; }
        public string? poster { set; get; }
        public string? audio { get; set; }
    }
}
