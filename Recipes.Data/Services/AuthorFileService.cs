using Recipes.Data.Models;
using Recipes.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Recipes.Data.Services
{
    public class AuthorFileService : IBaseService<Author>
    {
        public List<Author> GetAllModels()
        {
            List<Author> authors = new List<Author>();

            var txtFiles = Directory.EnumerateFiles(@"C:\Recipes.FileDB\Authors", "*.txt");

            foreach (var path in txtFiles)
            {
                string[] authorsLines = File.ReadAllLines(path);

                Author author = new Author();

                author.ID = int.Parse(authorsLines[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                author.Name = authorsLines[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];

                author.DateCreated = DateTime.Parse(authorsLines[2].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                authors.Add(author);
            }



            return authors;
        }

        public Author GetModelByID(int id)
        {
            Author author = new Author();

            var txtFiles = Directory.EnumerateFiles(@"C:\Recipes.FileDB\Authors", "*.txt");

            foreach (var path in txtFiles)
            {
                string[] authorsLines = File.ReadAllLines(path);


                int tempID = int.Parse(authorsLines[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                if (tempID == id)
                {
                    author.ID = tempID;

                    author.Name = authorsLines[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    author.DateCreated = DateTime.Parse(authorsLines[2].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                }

            }



            return author;
        }

        public Author GetModelByName(string name)
        {
            Author author = null;

            var txtFiles = Directory.EnumerateFiles(@"C:\Recipes.FileDB\Authors", "*.txt");

            foreach (var path in txtFiles)
            {
                string[] authorsLines = File.ReadAllLines(path);


                string tempName = authorsLines[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();

                if (tempName == name)
                {
                    author = new Author();
                    author.ID = int.Parse(authorsLines[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                    author.Name = name;

                    author.DateCreated = DateTime.Parse(authorsLines[2].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                }

            }

            return author;
        }

        public void Save(Author model)
        {
            model.ID = GenreteID();
            model.DateCreated = DateTime.Now;

            using (StreamWriter writer = new StreamWriter($"C:\\Recipes.FileDB\\Authors\\{model.Name}.txt"))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"ID = {model.ID}");
                sb.AppendLine($"Name = {model.Name}");
                sb.AppendLine($"DateCreated = {model.DateCreated}");

                writer.Write(sb.ToString());
            }
        }

        private int GenreteID()
        {
            var txtFiles = Directory.EnumerateFiles(@"C:\Recipes.FileDB\Authors", "*.txt");

            int maxID = int.MinValue;

            foreach (var path in txtFiles)
            {
                string[] authorLines = File.ReadAllLines(path);

                int tempID = int.Parse(authorLines[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                if (maxID < tempID)
                {
                    maxID = tempID;
                }
            }

            return maxID + 1;

        }

        public bool CheckNameUniqness(string name)
        {
            var txtFiles = Directory.EnumerateFiles(@"C:\Recipes.FileDB\Authors", "*.txt");

            foreach (var path in txtFiles)
            {
                string[] authorLines = File.ReadAllLines(path);

                string tempName = authorLines[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();

                if (tempName == name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
