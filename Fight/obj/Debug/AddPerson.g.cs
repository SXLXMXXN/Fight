﻿#pragma checksum "..\..\AddPerson.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "341F8D9E5F6950E5DE9D2C1D3FB70B9E6720F7F362118113CF0B7AFDBE5956B8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Fight;
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


namespace Fight {
    
    
    /// <summary>
    /// AddPerson
    /// </summary>
    public partial class AddPerson : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Level;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Ammo;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Speed;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Amount;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Type;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Random;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Infantry;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Cavalry;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AddPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Archer;
        
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
            System.Uri resourceLocater = new System.Uri("/Fight;component/addperson.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddPerson.xaml"
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
            
            #line 8 "..\..\AddPerson.xaml"
            ((Fight.AddPerson)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\AddPerson.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Level = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Ammo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Speed = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Amount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Type = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Random = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.Infantry = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 10:
            this.Cavalry = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 11:
            this.Archer = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

