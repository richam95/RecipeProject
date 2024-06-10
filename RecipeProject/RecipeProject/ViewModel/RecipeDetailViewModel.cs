using Newtonsoft.Json;
using RecipeProject.Models;
using RecipeProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeProject.ViewModel
{
    public class RecipeDetailViewModel : BaseViewModel
    {
        private Meal meal;
        public Meal Meal
        {
            get => meal;
            set => SetProperty(ref meal, value);
        }

        IApiService apiservice = new ApiService();
        Recipe recipe;
        public RecipeDetailViewModel(Recipe recipe)
        {
            this.recipe = recipe;
            Title = recipe.strMeal;
            LoadMeal(recipe);
        }

        private async void LoadMeal(Recipe recipe)
        {
            StartIndicator();
            var res = await apiservice.GetApiResponse(string.Format(Constants.GET_RECIPE_DETAIL,recipe.idMeal));
            if (!string.IsNullOrEmpty(res) && !res.Contains(Constants.ERROR))
            {
                var categories = JsonConvert.DeserializeObject<Meals>(res);
                Meal = categories.meals.FirstOrDefault();
            }
            StopIndicator();
        }
    }
}
