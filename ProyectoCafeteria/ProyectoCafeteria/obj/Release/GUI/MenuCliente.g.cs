﻿#pragma checksum "..\..\..\GUI\MenuCliente.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6778068F84B4F2F7DF80A6EC1F67FA2978EC82EA3CAD9395B873B9DE72DFA488"
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
    /// MenuCliente
    /// </summary>
    public partial class MenuCliente : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\GUI\MenuCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConsultarProductoButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\GUI\MenuCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button consultarFavoritos;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\GUI\MenuCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button evaluarServicio;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\GUI\MenuCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button consultarEstadisticas;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\GUI\MenuCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame contentFrame;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\GUI\MenuCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cerrarSesion;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\GUI\MenuCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button consultarPerfil;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\GUI\MenuCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox perfilLb;
        
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
            System.Uri resourceLocater = new System.Uri("/ProyectoCafeteria;component/gui/menucliente.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\MenuCliente.xaml"
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
            this.ConsultarProductoButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\GUI\MenuCliente.xaml"
            this.ConsultarProductoButton.Click += new System.Windows.RoutedEventHandler(this.ConsultarProductoButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.consultarFavoritos = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\GUI\MenuCliente.xaml"
            this.consultarFavoritos.Click += new System.Windows.RoutedEventHandler(this.FavProductoButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.evaluarServicio = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\GUI\MenuCliente.xaml"
            this.evaluarServicio.Click += new System.Windows.RoutedEventHandler(this.evaluarServicioButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.consultarEstadisticas = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\GUI\MenuCliente.xaml"
            this.consultarEstadisticas.Click += new System.Windows.RoutedEventHandler(this.ConsultarEstadisticasButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.contentFrame = ((System.Windows.Controls.Frame)(target));
            
            #line 36 "..\..\..\GUI\MenuCliente.xaml"
            this.contentFrame.Navigated += new System.Windows.Navigation.NavigatedEventHandler(this.contentFrame_Navigated);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cerrarSesion = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\GUI\MenuCliente.xaml"
            this.cerrarSesion.Click += new System.Windows.RoutedEventHandler(this.cerrarSesionButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.consultarPerfil = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\GUI\MenuCliente.xaml"
            this.consultarPerfil.Click += new System.Windows.RoutedEventHandler(this.ConsultarPerfilButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.perfilLb = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

