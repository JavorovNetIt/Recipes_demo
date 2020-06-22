using Recipes.Data.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Data.Models
{
    public class Author : BaseModel
    {
        public List<Recipe> Recipes { get; set; }
    }
}
