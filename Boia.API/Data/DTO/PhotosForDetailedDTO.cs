using System;

namespace Boia.API.Data.DTO
{
    public class PhotosForDetailedDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}
