using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineUtilities.Models.project_model
{
    class Project
    {
       public int id { get; set; }
       public string name { get; set; }
       public string identifier { get; set; }
       public string description { get; set; }
       public int status { get; set; }
       public string created_on { get; set; }
       public string updated_on { get; set; }
    }
}
