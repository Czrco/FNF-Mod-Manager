﻿#pragma checksum "..\..\..\..\Windows\ModShop.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C1A30098D6D2E4A95A9A8D954C5EB8465134E096"
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
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using Windows;


namespace Windows {
    
    
    /// <summary>
    /// ModShop
    /// </summary>
    public partial class ModShop : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Windows\ModShop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Download_Button;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Windows\ModShop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Mod_List;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Windows\ModShop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgBar;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Windows\ModShop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update_List;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Windows\ModShop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Warning;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Windows\ModShop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Privacy_Policy;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Windows\ModShop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FNF Mod Manager;component/windows/modshop.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\ModShop.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Windows\ModShop.xaml"
            ((Windows.ModShop)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Download_Button = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\Windows\ModShop.xaml"
            this.Download_Button.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Mod_List = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.ProgBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 5:
            this.Update_List = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Windows\ModShop.xaml"
            this.Update_List.Click += new System.Windows.RoutedEventHandler(this.Update_List_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Warning = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Privacy_Policy = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Windows\ModShop.xaml"
            this.Privacy_Policy.Click += new System.Windows.RoutedEventHandler(this.Privacy_Policy_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Windows\ModShop.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

