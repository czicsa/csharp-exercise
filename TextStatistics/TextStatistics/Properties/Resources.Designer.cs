﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextStatistics.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TextStatistics.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///	&lt;head&gt;
        ///		&lt;link rel=&quot;stylesheet&quot; href=&quot;libs/bootstrap.min.css&quot;&gt;
        ///	&lt;/head&gt;
        ///	&lt;body&gt;
        ///		&lt;div class=&quot;row&quot;&gt;
        ///			&lt;div class=&quot;col-xs-2&quot;&gt;
        ///				&lt;table class=&quot;table&quot;&gt;
        ///				  &lt;thead&gt;
        ///					&lt;tr&gt;
        ///					  &lt;th&gt;Mondatban található szavak száma&lt;/th&gt;
        ///					  &lt;th&gt;Mondatok száma&lt;/th&gt;
        ///					&lt;/tr&gt;
        ///				  &lt;/thead&gt;
        ///				  &lt;tbody&gt;
        ///					{{tableContent}}
        ///				  &lt;/tbody&gt;
        ///				&lt;/table&gt;
        ///			&lt;/div&gt;
        ///		&lt;/div&gt;
        ///	&lt;/body&gt;
        ///&lt;/html&gt;.
        /// </summary>
        internal static string sample {
            get {
                return ResourceManager.GetString("sample", resourceCulture);
            }
        }
    }
}
