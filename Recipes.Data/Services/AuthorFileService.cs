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
            throw new NotImplementedException();
        }
    }
}
