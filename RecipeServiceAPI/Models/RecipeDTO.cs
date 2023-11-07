
using System.ComponentModel.DataAnnotations;

namespace RecipeServiceAPI.Models
{
    public record RecipeDTO
    {

        public RecipeDTO()
        {

        }

        public RecipeDTO(int id)
        {
            this.Id = id; 
        }

        public RecipeDTO(string name, int servingSize, int imageId)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.ImageId = imageId;
        }

        public RecipeDTO(int id, string name, int servingSize, int imageId)
        {
            this.Id = id; 
            this.Name = name;
            this.ServingSize = servingSize;
            this.ImageId = imageId;
        }


        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ServingSize {get; set;}
        public int? ImageId {get; set;}

    }
}