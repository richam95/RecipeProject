using Newtonsoft.Json;
using RecipeProject.Models;
using RecipeProject.Service;
using RecipeProject.Views;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RecipeProject.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }

        public Command<Category> SelectCategoryCommand { get; }

        public MainPageViewModel()
        {
            SelectCategoryCommand = new Command<Category>(SelectCategory);
            Title = Constants.CATEGORIES;
            LoadCategories();
        }

        private async void LoadCategories()
        {
            StartIndicator();
            var res = await apiservice.GetApiResponse(Constants.GET_CATEGORIES);
            if (!string.IsNullOrEmpty(res) && !res.Contains(Constants.ERROR))
            {
               var categories = JsonConvert.DeserializeObject<Categories>(res);
                Categories = categories.categories;
            }
            StopIndicator();
        }

        private async void SelectCategory(Category category)
        {
            if (IsLoading)
            {
                return;
            }
            StartIndicator();
            await Application.Current.MainPage.Navigation.PushAsync(new RecipePage(category));
            StopIndicator();
        }
    }
}
