﻿#pragma checksum "..\..\..\GUI\GUI-CU03-IniciarSesion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "382642621CDE107984A3E936298167842FC82B3DE8D93FDDC698C2F98421D071"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ProyectoCafeteria.GUI;
using ProyectoCafeteria.Properties.Langs;
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


namespace ProyectoCafeteria.GUI {
    
    
    /// <summary>
    /// GUI_CU03_IniciarSesion
    /// </summary>
    public partial class GUI_CU03_IniciarSesion : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\GUI\GUI-CU03-IniciarSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ClaveTrabajadorTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\GUI\GUI-CU03-IniciarSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox ContrasenaPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\GUI\GUI-CU03-IniciarSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button IniciarSesionButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ProyectoCafeteria;component/gui/gui-cu03-iniciarsesion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\GUI-CU03-IniciarSesion.xaml"
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
            this.ClaveTrabajadorTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\GUI\GUI-CU03-IniciarSesion.xaml"
            this.ClaveTrabajadorTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ClaveTrabajadorTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ContrasenaPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.IniciarSesionButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\GUI\GUI-CU03-IniciarSesion.xaml"
            this.IniciarSesionButton.Click += new System.Windows.RoutedEventHandler(this.IniciarSesionButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 39 "..\..\..\GUI\GUI-CU03-IniciarSesion.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.RegistrarseTextBlockHyperlink_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

