using Recipes.Data.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Data.Models
{
    public class Recipe : BaseModel
    {
        public string Content { get; set; }

        public Author Author { get; set; }

        public int AuthorID { get; set; }

        public string AuthorName { get => Author.Name; }
    }
}
