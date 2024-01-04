﻿namespace ReportingProject.Data.Resources
{
    public class ReportAndOperatorResource
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public byte[]? File { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
        public int Approved { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string TelecomName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}