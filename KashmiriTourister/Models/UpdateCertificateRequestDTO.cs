﻿namespace KashmiriTourister.Models
{
    public class UpdateCertificateRequestDTO
    {
        public string email { get; set; }

        public string landmark { get; set; }

        public string image { get; set; }

        public bool hallOfTravellers { get; set; }

        public bool issueStatus { get; set; }
    }
}
