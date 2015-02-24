using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly:Addin (
    "BindingControllerRegistrator", 
    Namespace = "BindingControllerRegistrator",
    Version = "1.0"
)]

[assembly:AddinName ("BindingControllerRegistrator")]
[assembly:AddinCategory ("BindingControllerRegistrator")]
[assembly:AddinDescription ("BindingControllerRegistrator")]
[assembly:AddinAuthor ("maksimevtuh")]

[assembly:AddinDependency ("::MonoDevelop.Core", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency ("::MonoDevelop.Ide", MonoDevelop.BuildInfo.Version)]
