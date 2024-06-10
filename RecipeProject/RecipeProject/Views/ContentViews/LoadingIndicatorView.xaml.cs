using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeProject.Views.ContentViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingIndicatorView : ContentView
	{
		public LoadingIndicatorView ()
		{
			InitializeComponent ();
		}
	}
}