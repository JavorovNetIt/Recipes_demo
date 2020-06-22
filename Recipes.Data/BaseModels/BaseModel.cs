using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Data.BaseModels
{
    public abstract class BaseModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
