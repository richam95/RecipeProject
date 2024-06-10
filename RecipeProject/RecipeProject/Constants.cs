using System;
namespace RecipeProject
{
	public class Constants
	{
        #region API Endpoints

        public const string GET_CATEGORIES = "categories.php";
        public const string GET_RECIPES = "filter.php?c={0}";
        public const string GET_RECIPE_DETAIL = "lookup.php?i={0}";


        #endregion

        public const string ERROR = "Error";
        public const string CATEGORIES = "Categories";
    }
}

