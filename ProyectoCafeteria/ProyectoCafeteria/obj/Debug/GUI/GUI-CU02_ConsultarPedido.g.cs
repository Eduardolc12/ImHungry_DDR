﻿#pragma checksum "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D548F3B2C242C3B182A1AA9A88DB79F3EFCB14685D5681CFCD108C95C90DD48"
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
    /// GUI_CU02_ConsultarPedido
    /// </summary>
    public partial class GUI_CU02_ConsultarPedido : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BusquedaTextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConsultarButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PedidoDataGrid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ProductoImage;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ModificarButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CerrarButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ProyectoCafeteria;component/gui/gui-cu02_consultarpedido.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
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
            this.BusquedaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ConsultarButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
            this.ConsultarButton.Click += new System.Windows.RoutedEventHandler(this.ConsultarButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PedidoDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
            this.PedidoDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PedidoDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ProductoImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.ModificarButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\GUI\GUI-CU02_ConsultarPedido.xaml"
            this.ModificarButton.Click += new System.Windows.RoutedEventHandler(this.ModificarButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CerrarButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

