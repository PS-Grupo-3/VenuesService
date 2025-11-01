﻿namespace Application.Models.Responses
{
    public class SectorResponse
    {
        public Guid SectorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsControlled { get; set; }
        public int? SeatCount { get; set; }
        public int? Capacity { get; set; }
        public ShapeResponse Shape { get; set; } = null!;
    }
}