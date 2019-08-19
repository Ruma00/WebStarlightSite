using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarlightProject_Site.Models
{
    public class StoryModel
    {
        public StoryModel()
        {

        }

        public StoryModel(string name, int id, string img)
        {
            StoryName = name;
            StoryID = id;
            StoryImg = img;
        }

        [Key]
        public int StoryID { get; set; }
        public string StoryName { get; set; }
        public string StoryImg { get; set; }
    }
}
