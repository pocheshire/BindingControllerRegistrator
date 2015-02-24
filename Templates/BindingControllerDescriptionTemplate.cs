using System;
using MonoDevelop.Ide.Templates;
using System.Collections.Generic;
using System.Linq;
using MonoDevelop.Ide;

namespace BindingControllerRegistrator.Templates
{
    public class BindingControllerDescriptionTemplate : TextFileDescriptionTemplate
    {
        public override string CreateContent (MonoDevelop.Projects.Project project, Dictionary<string, string> tags, string language)
        {
            var temp = base.CreateContent (project, tags, language);

            var projectFilesCollection = project.Files;
            var moduleList = projectFilesCollection.Where (file => file.Name.ToLowerInvariant().Contains ("module")).ToList();

            if (moduleList.Count > 1)
            {

            }
            else
                RegisterControllerInModule (moduleList [0], tags["FullName"]);

            return temp;
        }

        private void RegisterControllerInModule (MonoDevelop.Projects.ProjectFile projectFile, string fullName)
        {
            var moduleDocument = IdeApp.Workbench.GetDocument (projectFile.Name);

        }
    }
}

