using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProject.Models
{
    public class Recipe
    {
        public string strMeal { get; set; }
        public string strMealThumb { get; set; }
        public string idMeal { get; set; }
    }

    public class Recipes
    {
        public List<Recipe> meals { get; set; }
    }
}
