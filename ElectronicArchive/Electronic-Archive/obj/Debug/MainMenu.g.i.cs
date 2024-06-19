﻿#pragma checksum "..\..\MainMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79A9A56D811DCAE52F263F7E37F0DD10C774175DF1F06B8D394DF6D060DA85DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Electronic_Archive;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Electronic_Archive {
    
    
    /// <summary>
    /// MainMenu
    /// </summary>
    public partial class MainMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CardsGrid;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FilesGrid;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Annul;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exploitation;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Changes;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Copies;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 262 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SearchLabel;
        
        #line default
        #line hidden
        
        
        #line 272 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Trash;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Electronic-Archive;component/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainMenu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CardsGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 65 "..\..\MainMenu.xaml"
            this.CardsGrid.Loaded += new System.Windows.RoutedEventHandler(this.CardsGrid_Loaded);
            
            #line default
            #line hidden
            
            #line 65 "..\..\MainMenu.xaml"
            this.CardsGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.CardsGrid_MouseDoubleClick_1);
            
            #line default
            #line hidden
            
            #line 65 "..\..\MainMenu.xaml"
            this.CardsGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CardsGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 68 "..\..\MainMenu.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CellContextMenu_CopyValue);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FilesGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 216 "..\..\MainMenu.xaml"
            this.FilesGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.FilesGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Annul = ((System.Windows.Controls.Button)(target));
            
            #line 224 "..\..\MainMenu.xaml"
            this.Annul.Click += new System.Windows.RoutedEventHandler(this.Annul_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Exploitation = ((System.Windows.Controls.Button)(target));
            
            #line 229 "..\..\MainMenu.xaml"
            this.Exploitation.Click += new System.Windows.RoutedEventHandler(this.Exploitation_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Changes = ((System.Windows.Controls.Button)(target));
            
            #line 234 "..\..\MainMenu.xaml"
            this.Changes.Click += new System.Windows.RoutedEventHandler(this.Changes_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Copies = ((System.Windows.Controls.Button)(target));
            
            #line 239 "..\..\MainMenu.xaml"
            this.Copies.Click += new System.Windows.RoutedEventHandler(this.Copies_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 244 "..\..\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Create_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Edit = ((System.Windows.Controls.Button)(target));
            
            #line 249 "..\..\MainMenu.xaml"
            this.Edit.Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 254 "..\..\MainMenu.xaml"
            this.Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SearchLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            
            #line 267 "..\..\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Admin_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Trash = ((System.Windows.Controls.Button)(target));
            
            #line 272 "..\..\MainMenu.xaml"
            this.Trash.Click += new System.Windows.RoutedEventHandler(this.Trash_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

