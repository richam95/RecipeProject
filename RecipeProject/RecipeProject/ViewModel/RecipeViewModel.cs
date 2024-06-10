using Newtonsoft.Json;
using RecipeProject.Models;
using RecipeProject.Service;
using RecipeProject.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RecipeProject.ViewModel
{
    public class RecipeViewModel : BaseViewModel
    {
        private List<Recipe> recipes;
        public List<Recipe> Recipes
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
        }

        public Command<Recipe> SelectRecipeCommand { get; }

        private readonly IApiService apiservice;

        Category category;
        public RecipeViewModel(Category category)
        {
            this.category = category;
            Title = "Recipes of " + category.strCategory;
            apiservice = new ApiService();
            SelectRecipeCommand = new Command<Recipe>(SelectRecipe);
            LoadRecipes();
        }

        private async void LoadRecipes()
        {
            StartIndicator();
            var res = await apiservice.GetApiResponse(string.Format(Constants.GET_RECIPES, category.strCategory));
            if (!string.IsNullOrEmpty(res) && !res.Contains(Constants.ERROR))
            {
                var categories = JsonConvert.DeserializeObject<Recipes>(res);
                Recipes = categories.meals;
            }
            StopIndicator();
        }
        private async void SelectRecipe(Recipe recipe)
        {

            if (IsLoading)
            {
                return;
            }
            StartIndicator();
            await Application.Current.MainPage.Navigation.PushAsync(new RecipeDetailPage(recipe));
            StopIndicator();
        }
    }
}
