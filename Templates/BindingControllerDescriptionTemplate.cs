using System;
using MonoDevelop.Ide.Templates;
using System.Collections.Generic;
using System.Linq;
using MonoDevelop.Ide;
using Mono.TextEditor;

namespace BindingControllerRegistrator.Templates
{
    public class BindingControllerDescriptionTemplate : TextFileDescriptionTemplate
    {
        public override string CreateContent (MonoDevelop.Projects.Project project, Dictionary<string, string> tags, string language)
        {
            var temp = base.CreateContent (project, tags, language);

            var projectFilesCollection = project.Files;
            var moduleList = projectFilesCollection.Where (file => file.Name.ToLowerInvariant().Contains ("module") ).ToList();

            if (moduleList.Count > 1)
            {

            }
            else
                RegisterControllerInModule (moduleList [0], tags["FullName"]);

            return temp;
        }

        private void RegisterControllerInModule (MonoDevelop.Projects.ProjectFile projectFile, string fullName)
        {
            var document = IdeApp.Workbench.OpenDocument(projectFile.FilePath, projectFile.Project, false);
            var textEditorData = document.GetContent<ITextEditorDataProvider> ().GetTextEditorData ();

            DocumentLine line = textEditorData.GetLine (textEditorData.Lines.Count () - 2);
            for (int i = 1; i < textEditorData.Lines.Count(); i++) {
                var lineText = textEditorData.GetLineText (i);

                if (lineText.ToLowerInvariant().Contains("registerservices"))
                {
                    int j = 1;
                    i++;
                    while (j != 0)
                    {
                        i++;
                        lineText = textEditorData.GetLineText (i);

                        if (lineText.Contains ("}"))
                            j--;
                        else if (lineText.Contains ("{"))
                            j++;
                    }
                    line = textEditorData.GetLine (i);
                    break;
                }
            }

            textEditorData.Insert (line.Offset, string.Format("\t\t\tbatch.RegisterController(() => new {0}());\n", fullName));

            document.Save ();
            document.Close ();
        }
    }
}

