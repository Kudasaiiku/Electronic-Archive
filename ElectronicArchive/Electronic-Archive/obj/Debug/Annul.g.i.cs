﻿#pragma checksum "..\..\Annul.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "439E403A49C8468AEEAB0A87729E2B7534A9BC2B21A9DAF2EB6C0B8321AB275F"
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
    /// Annul
    /// </summary>
    public partial class Annul : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AnnulGrid;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DNV;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AnnulBtn;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Comment;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labeltext;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox YesBox;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SearchLabel;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\Annul.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateA;
        
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
            System.Uri resourceLocater = new System.Uri("/Electronic-Archive;component/annul.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Annul.xaml"
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
            this.AnnulGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\Annul.xaml"
            this.AnnulGrid.Loaded += new System.Windows.RoutedEventHandler(this.AnnulGrid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\Annul.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CellContextMenu_CopyValue);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DNV = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AnnulBtn = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\Annul.xaml"
            this.AnnulBtn.Click += new System.Windows.RoutedEventHandler(this.AnnulBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Comment = ((System.Windows.Controls.TextBox)(target));
            
            #line 114 "..\..\Annul.xaml"
            this.Comment.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Comment_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.labeltext = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.YesBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 127 "..\..\Annul.xaml"
            this.YesBox.Checked += new System.Windows.RoutedEventHandler(this.YesBox_Checked);
            
            #line default
            #line hidden
            
            #line 127 "..\..\Annul.xaml"
            this.YesBox.Unchecked += new System.Windows.RoutedEventHandler(this.YesBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 137 "..\..\Annul.xaml"
            this.Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SearchLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.DateA = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

