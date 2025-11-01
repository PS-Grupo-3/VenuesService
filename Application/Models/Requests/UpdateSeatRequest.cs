using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class UpdateSeatRequest
    {
        [Range(1, int.MaxValue)]
        public int RowNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int ColumnNumber { get; set; }


        [Range(0, int.MaxValue)]
        public int PosX { get; set; } 

        [Range(0, int.MaxValue)]
        public int PosY { get; set; } 
    }
}