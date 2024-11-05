namespace KashmiriTourister.Models
{
    public class AddLandmarkDTO
    {
        //public Guid Id { get; set; }
        //public required string Name { get; set; }
        //public required string Location { get; set; }
        //public required string Type { get; set; }
        //public string Properties { get; set; }

        public Guid id { get; set; }
        public string landmark { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string[] properties { get; set; }
        public string image { get; set; }
        public string iframesrc { get; set; }
        public string[] highlights { get; set; }
        public string about { get; set; }
        public string best_time_to_visit{ get; set; }

    }
}
