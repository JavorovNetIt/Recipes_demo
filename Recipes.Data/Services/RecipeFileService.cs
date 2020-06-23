using Recipes.Data.Models;
using Recipes.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Recipes.Data.Services
{
    public class RecipeFileService : IBaseService<Recipe>
    {
        public List<Recipe> GetAllModels()
        {
            List<Recipe> recipes = new List<Recipe>();

            var txtFiles = Directory.EnumerateFiles(@"C:\Recipes.FileDB\Recipes", "*.txt");

            foreach (var path in txtFiles)
            {
                string[] recipeLines = File.ReadAllLines(path);

                Recipe recipe = new Recipe();

                recipe.ID = int.Parse(recipeLines[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                recipe.Name = recipeLines[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];

                recipe.Content = recipeLines[2].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];

                recipe.AuthorID = int.Parse(recipeLines[3].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                recipe.DateCreated = DateTime.Parse(recipeLines[4].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                recipes.Add(recipe);
            }



            return recipes;
        }

        public Recipe GetModelByID(int id)
        {
            throw new NotImplementedException();
        }

        public Recipe GetModelByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(Recipe model)
        {
            model.ID = GenreteID();
            model.DateCreated = DateTime.Now;

            using (StreamWriter writer = new StreamWriter($"C:\\Recipes.FileDB\\Recipes\\{model.Name}.txt"))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"ID = {model.ID}");
                sb.AppendLine($"Name = {model.Name}");
                sb.AppendLine($"Content = {model.Content}");
                sb.AppendLine($"AuthorID = {model.Author.ID}");
                sb.AppendLine($"DateCreated = {model.DateCreated}");

                writer.Write(sb.ToString());
            }

        }

        public bool CheckNameUniqness(string name)
        {
            var txtFiles = Directory.EnumerateFiles(@"C:\Recipes.FileDB\Recipes", "*.txt");

            foreach (var path in txtFiles)
            {
                string[] recipeLines = File.ReadAllLines(path);

                string tempName = recipeLines[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();

                if (tempName == name)
                {
                    return true;
                }
            }

            return false;
        }

        private int GenreteID()
        {
            var txtFiles = Directory.EnumerateFiles(@"C:\Recipes.FileDB\Recipes", "*.txt");

            int maxID = int.MinValue;

            foreach (var path in txtFiles)
            {
                string[] recipeLines = File.ReadAllLines(path);

                int tempID = int.Parse(recipeLines[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                if (maxID < tempID)
                {
                    maxID = tempID;
                }
            }

            return maxID + 1;

        }
    }
}
