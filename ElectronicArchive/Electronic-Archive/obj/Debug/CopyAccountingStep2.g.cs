﻿#pragma checksum "..\..\CopyAccountingStep2.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E84EB48FCC2A4B30098404D841A2E4570B04DFAD1AA30FD1303B566E9B3560B8"
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
    /// CopyAccountingStep2
    /// </summary>
    public partial class CopyAccountingStep2 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CopiesGrid;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Base;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox In;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Out;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Trash;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Abonent;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\CopyAccountingStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SearchLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/Electronic-Archive;component/copyaccountingstep2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CopyAccountingStep2.xaml"
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
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.CopiesGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\CopyAccountingStep2.xaml"
            this.CopiesGrid.Loaded += new System.Windows.RoutedEventHandler(this.CopiesGrid_Loaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\CopyAccountingStep2.xaml"
            this.CopiesGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CopiesGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\CopyAccountingStep2.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CellContextMenu_CopyValue);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Base = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.In = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Out = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\CopyAccountingStep2.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Trash = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\CopyAccountingStep2.xaml"
            this.Trash.Click += new System.Windows.RoutedEventHandler(this.Trash_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.Abonent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 127 "..\..\CopyAccountingStep2.xaml"
            this.Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.SearchLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
