﻿#pragma checksum "..\..\ListExpanding.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C0291A70CACDC3F376275B8CE15C7A8CFF82A048029DB8878213ACA4363BEA66"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using codefox_wpf_vesion_2;


namespace codefox_wpf_vesion_2 {
    
    
    /// <summary>
    /// ListExpanding
    /// </summary>
    public partial class ListExpanding : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\ListExpanding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal codefox_wpf_vesion_2.ListExpanding ListExpandingWindow;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ListExpanding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button listExpendingBtn;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ListExpanding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newListBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/codefox wpf vesion 2;component/listexpanding.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListExpanding.xaml"
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
            this.ListExpandingWindow = ((codefox_wpf_vesion_2.ListExpanding)(target));
            return;
            case 2:
            this.listExpendingBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ListExpanding.xaml"
            this.listExpendingBtn.Click += new System.Windows.RoutedEventHandler(this.listExpendingBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.newListBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ListExpanding.xaml"
            this.newListBtn.Click += new System.Windows.RoutedEventHandler(this.newListBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

