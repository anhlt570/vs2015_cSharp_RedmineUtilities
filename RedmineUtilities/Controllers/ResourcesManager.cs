using RedmineUtilities.Models.project_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineUtilities.Controllers
{
    class ResourcesManager
    {
        private static ResourcesManager instance=null;
        public static ResourcesManager getInstance()
        {
            if (instance == null) instance = new ResourcesManager();
            return instance;
        }

        public List<Project> currentProjects;
    }
}
