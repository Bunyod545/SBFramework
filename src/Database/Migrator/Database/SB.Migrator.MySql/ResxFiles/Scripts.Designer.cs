﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SB.Migrator.MySql.ResxFiles {
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
    internal class Scripts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Scripts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SB.Migrator.MySql.ResxFiles.Scripts", typeof(Scripts).Assembly);
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
        ///   Looks up a localized string similar to INSERT INTO MigrationsHistory (Name ,Version)
        ///VALUES (&apos;{0}&apos; ,&apos;{1}&apos;).
        /// </summary>
        internal static string InsertHistoryVersion {
            get {
                return ResourceManager.GetString("InsertHistoryVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO MigrationsHistory (Name ,Version2)
        ///VALUES (&apos;{0}&apos; ,&apos;{1}&apos;).
        /// </summary>
        internal static string InsertHistoryVersion2 {
            get {
                return ResourceManager.GetString("InsertHistoryVersion2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM information_schema.columns
        ///WHERE TABLE_SCHEMA = &apos;{0}&apos;.
        /// </summary>
        internal static string SelectColumns {
            get {
                return ResourceManager.GetString("SelectColumns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT i.TABLE_SCHEMA, i.TABLE_NAME, i.CONSTRAINT_TYPE, i.CONSTRAINT_NAME, k.COLUMN_NAME, k.REFERENCED_TABLE_SCHEMA, k.REFERENCED_TABLE_NAME, k.REFERENCED_COLUMN_NAME 
        ///FROM information_schema.TABLE_CONSTRAINTS i 
        ///LEFT JOIN information_schema.KEY_COLUMN_USAGE k ON i.CONSTRAINT_NAME = k.CONSTRAINT_NAME 
        ///WHERE i.CONSTRAINT_TYPE = &apos;FOREIGN KEY&apos; AND i.TABLE_SCHEMA = &apos;{0}&apos;;.
        /// </summary>
        internal static string SelectForeignKeys {
            get {
                return ResourceManager.GetString("SelectForeignKeys", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM MigrationsHistory
        ///WHERE Name = &apos;{0}&apos;
        ///LIMIT 1.
        /// </summary>
        internal static string SelectHistory {
            get {
                return ResourceManager.GetString("SelectHistory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT Id
        ///      ,Name
        ///      ,Version
        ///      ,Version2
        ///  FROM {0}.MigrationsHistory.
        /// </summary>
        internal static string SelectMigrationsHistory {
            get {
                return ResourceManager.GetString("SelectMigrationsHistory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select tab.table_schema,
        ///    sta.index_name as CONSTRAINT_NAME,
        ///    sta.seq_in_index as COLUMN_ID,
        ///    sta.column_name,
        ///    tab.table_name
        ///from information_schema.tables as tab
        ///inner join information_schema.statistics as sta
        ///        on sta.table_schema = tab.table_schema
        ///        and sta.table_name = tab.table_name
        ///        and sta.index_name = &apos;primary&apos;
        ///where tab.table_schema = &apos;{0}&apos;
        ///    and tab.table_type = &apos;BASE TABLE&apos;
        ///order by tab.table_name,
        ///    column_id;.
        /// </summary>
        internal static string SelectPrimaryKeys {
            get {
                return ResourceManager.GetString("SelectPrimaryKeys", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM information_schema.tables where TABLE_SCHEMA = &apos;{0}&apos;;.
        /// </summary>
        internal static string SelectTables {
            get {
                return ResourceManager.GetString("SelectTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE MigrationsHistory
        ///SET &quot;Version&quot; = &apos;{1}&apos;
        ///WHERE &quot;Name&quot; = &apos;{0}&apos;.
        /// </summary>
        internal static string UpdateHistoryVersion {
            get {
                return ResourceManager.GetString("UpdateHistoryVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE MigrationsHistory
        ///SET Version2 = &apos;{1}&apos;
        ///WHERE Name = &apos;{0}&apos;.
        /// </summary>
        internal static string UpdateHistoryVersion2 {
            get {
                return ResourceManager.GetString("UpdateHistoryVersion2", resourceCulture);
            }
        }
    }
}
