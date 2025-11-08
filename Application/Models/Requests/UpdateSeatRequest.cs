using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class UpdateSeatRequest
    {
        [Range(int.MinValue, int.MaxValue)]
        public int RowNumber { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int ColumnNumber { get; set; }


        [Range(int.MinValue, int.MaxValue)]
        public int PosX { get; set; } 

        [Range(int.MinValue, int.MaxValue)]
        public int PosY { get; set; } 
    }
}