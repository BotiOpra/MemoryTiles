using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTilesGame.Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string ImageSource { get; set; }

        public PictureModel(int id, string imageSource)
        {
            Id = id;
            ImageSource = imageSource;
        }
    }
}
