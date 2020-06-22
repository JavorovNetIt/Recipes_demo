using Recipes.Data.Models;
using Recipes.Data.Services;
using Recipes.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipes_Demo
{
    public partial class Form1 : Form
    {
        private IBaseService<Recipe> recipeService;
        private IBaseService<Author> authorService;


        public Form1()
        {
            InitializeComponent();

            recipeService = new RecipeFileService();
            authorService = new AuthorFileService();
        }

        private void btnRecipes_Click(object sender, EventArgs e)
        {
            var recipes = recipeService.GetAllModels();

            foreach (var recipe in recipes)
            {
                recipe.Author = authorService.GetModelByID(recipe.AuthorID);
            }

            using (RecipesListForm recipesListForm = new RecipesListForm(recipes))
            {
                recipesListForm.ShowDialog();
            }
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            var authors = authorService.GetAllModels();


            using (AuthorsListForm authorsListForm = new AuthorsListForm(authors))
            {
                authorsListForm.ShowDialog();
            }
        }
    }
}
