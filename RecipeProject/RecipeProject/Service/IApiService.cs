using RecipeProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Service
{
    public interface IApiService
    {
        Task<string> GetApiResponse(string url);
    }
}
