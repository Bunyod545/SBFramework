﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SB.Migrator.Postgres.ResxFiles {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SB.Migrator.Postgres.ResxFiles.Scripts", typeof(Scripts).Assembly);
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
        ///   Looks up a localized string similar to INSERT INTO public.&quot;MigrationsHistory&quot; (&quot;Name&quot; ,&quot;Version&quot;)
        ///VALUES (&apos;{0}&apos; ,&apos;{1}&apos;).
        /// </summary>
        internal static string InsertHistoryVersion {
            get {
                return ResourceManager.GetString("InsertHistoryVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO public.&quot;MigrationsHistory&quot; (&quot;Name&quot; ,&quot;Version2&quot;)
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
        ///WHERE table_schema != &apos;information_schema&apos; 
        ///AND table_schema != &apos;pg_catalog&apos;.
        /// </summary>
        internal static string SelectColumns {
            get {
                return ResourceManager.GetString("SelectColumns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///    tc.table_schema, 
        ///    tc.constraint_name, 
        ///    tc.table_name, 
        ///    kcu.column_name, 
        ///    ccu.table_schema AS foreign_table_schema,
        ///    ccu.table_name AS foreign_table_name,
        ///    ccu.column_name AS foreign_column_name 
        ///FROM 
        ///    information_schema.table_constraints AS tc 
        ///    JOIN information_schema.key_column_usage AS kcu
        ///      ON tc.constraint_name = kcu.constraint_name
        ///      AND tc.table_schema = kcu.table_schema
        ///    JOIN information_schema.constraint_column_usage AS ccu
        ///      ON c [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SelectForeignKeys {
            get {
                return ResourceManager.GetString("SelectForeignKeys", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM public.&quot;MigrationsHistory&quot;
        ///WHERE &quot;Name&quot; = &apos;{0}&apos;
        ///LIMIT 1.
        /// </summary>
        internal static string SelectHistory {
            get {
                return ResourceManager.GetString("SelectHistory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT &quot;Id&quot;
        ///      ,&quot;Name&quot;
        ///      ,&quot;Version&quot;
        ///      ,&quot;Version2&quot;
        ///  FROM public.&quot;MigrationsHistory&quot;.
        /// </summary>
        internal static string SelectMigrationsHistory {
            get {
                return ResourceManager.GetString("SelectMigrationsHistory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///FROM information_schema.table_constraints tc 
        ///JOIN information_schema.constraint_column_usage AS ccu USING (constraint_schema, constraint_name) 
        ///JOIN information_schema.columns AS c ON c.table_schema = tc.constraint_schema
        ///AND tc.table_name = c.table_name AND ccu.column_name = c.column_name
        ///WHERE constraint_type = &apos;PRIMARY KEY&apos;;.
        /// </summary>
        internal static string SelectPrimaryKeys {
            get {
                return ResourceManager.GetString("SelectPrimaryKeys", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///   *
        ///FROM
        ///   pg_catalog.pg_tables
        ///WHERE
        ///   schemaname != &apos;pg_catalog&apos;
        ///AND schemaname != &apos;information_schema&apos;;.
        /// </summary>
        internal static string SelectTables {
            get {
                return ResourceManager.GetString("SelectTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select 
        ///TC.Constraint_Name, 
        ///CC.Column_Name ,
        ///TC.TABLE_SCHEMA,
        ///TC.TABLE_NAME
        ///from information_schema.table_constraints TC
        ///inner join information_schema.constraint_column_usage CC on TC.Constraint_Name = CC.Constraint_Name
        ///where TC.constraint_type = &apos;UNIQUE&apos;
        ///order by TC.Constraint_Name.
        /// </summary>
        internal static string SelectUniqueKeys {
            get {
                return ResourceManager.GetString("SelectUniqueKeys", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE public.&quot;MigrationsHistory&quot;
        ///SET &quot;Version&quot; = &apos;{1}&apos;
        ///WHERE &quot;Name&quot; = &apos;{0}&apos;.
        /// </summary>
        internal static string UpdateHistoryVersion {
            get {
                return ResourceManager.GetString("UpdateHistoryVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE public.&quot;MigrationsHistory&quot;
        ///SET &quot;Version2&quot; = &apos;{1}&apos;
        ///WHERE &quot;Name&quot; = &apos;{0}&apos;.
        /// </summary>
        internal static string UpdateHistoryVersion2 {
            get {
                return ResourceManager.GetString("UpdateHistoryVersion2", resourceCulture);
            }
        }
    }
}
