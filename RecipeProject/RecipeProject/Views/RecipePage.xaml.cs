﻿using RecipeProject.Models;
using RecipeProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        public RecipePage(Category category)
        {
            InitializeComponent();
            BindingContext = new RecipeViewModel(category);
        }
    }
}