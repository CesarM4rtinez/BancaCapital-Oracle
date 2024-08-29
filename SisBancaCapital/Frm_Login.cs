using Banco.Datos;
using Banco.Entidades;
using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisBanca
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_iniciar_Click(object sender, EventArgs e)
        {
            this.Login_us(txtUsuario.Text, txtContraseña.Text);
        }

        public void Login_us(string USUARIO, string CONTRASEÑA)
        {
            try
            {
                DataTable data_login = new DataTable();
                D_Usuarios Datos = new D_Usuarios();
                DataTable dataTable = Datos.Login_us(USUARIO, CONTRASEÑA);

                data_login = dataTable;
                if (data_login.Rows.Count > 0)
                {
                    string cNombres  = "";
                    string cCargo    = "";
                    bool   bAdmin    = false;
                    bool   bPrestamo = false;
                    bool   bCuentas  = false;
                    bool   bTarjetas = false;

                    cCargo    = Convert.ToString(data_login.Rows[0][12]);
                    cCargo    = Convert.ToString(data_login.Rows[0][22]);
                    cNombres  = Convert.ToString(data_login.Rows[0][14]);
                    bAdmin    = Convert.ToBoolean(data_login.Rows[0][16]);
                    bPrestamo = Convert.ToBoolean(data_login.Rows[0][17]);
                    bCuentas  = Convert.ToBoolean(data_login.Rows[0][18]);
                    bTarjetas = Convert.ToBoolean(data_login.Rows[0][19]);

                    Frm_Dashboard oDashBoard       = new Frm_Dashboard();
                    oDashBoard.Lbl_nombres_us.Text = "Usuario: " + cNombres;
                    oDashBoard.Lbl_cargo.Text      = "Cargo: "   + cCargo;
                    oDashBoard.Chk_admin.Checked   = bAdmin;

                    if (bAdmin == true) // Usuario Administrador
                    {
                        oDashBoard.btn_administracion.Enabled    = true;
                        oDashBoard.btn_detalleClientes.Enabled   = true;
                        oDashBoard.btn_detalleCuentas.Enabled    = true;
                        oDashBoard.btn_detalleTarjetas.Enabled   = true;
                        oDashBoard.btn_detallePrestamos.Enabled  = true;
                    }

                    else if (bPrestamo == true) // Usuario Víctor Martínez
                    {
                        oDashBoard.btn_movimientos.Enabled       = false;
                        oDashBoard.btn_detallePrestamos.Enabled  = true;

                        oDashBoard.btn_detalleCuentas.Enabled    = false;
                        oDashBoard.btn_detalleTarjetas.Enabled   = false;
                        oDashBoard.btn_administracion.Enabled    = false;
                        oDashBoard.btn_detalleClientes.Enabled   = false;

                        oDashBoard.btn_mvTarjetas.Enabled        = false;
                        oDashBoard.btn_mvCuentas.Enabled         = false;
                    }

                    else if (bCuentas == true) // Usuario Héctor Mérino
                    {
                        oDashBoard.btn_detalleCuentas.Enabled      = true;
                        oDashBoard.btn_movimientos.Enabled         = false;
                        oDashBoard.btn_mvTarjetas.Enabled          = false;

                        oDashBoard.btn_detalleTarjetas.Enabled     = false;
                        oDashBoard.btn_detallePrestamos.Enabled    = false;
                        oDashBoard.btn_administracion.Enabled      = false;
                        oDashBoard.btn_detalleClientes.Enabled     = false;

                        oDashBoard.btn_mvCuentas.Enabled           = false;
                    }

                    else if (bTarjetas == true) // Usuario Miguel Ayala
                    {
                        oDashBoard.btn_movimientos.Enabled         = false;
                        oDashBoard.btn_mvCuentas.Enabled           = false;
                        oDashBoard.btn_detalleTarjetas.Enabled     = true;

                        oDashBoard.btn_detalleCuentas.Enabled      = false;
                        oDashBoard.btn_mvTarjetas.Enabled          = false;
                        
                        oDashBoard.btn_detallePrestamos.Enabled    = false;
                        oDashBoard.btn_administracion.Enabled      = false;
                        oDashBoard.btn_detalleClientes.Enabled     = false;
                    }

                    else if (bAdmin == false) // Usuario Melvin Esteven
                    {
                        oDashBoard.btn_movimientos.Enabled         = false;
                        oDashBoard.btn_mvTarjetas.Enabled          = false;
                        oDashBoard.btn_mvCuentas.Enabled           = false;

                        oDashBoard.btn_detallePrestamos.Enabled    = false;
                        oDashBoard.btn_detalleCuentas.Enabled      = false;
                        oDashBoard.btn_detalleTarjetas.Enabled     = false;
                        oDashBoard.btn_administracion.Enabled      = false;
                        oDashBoard.btn_detalleClientes.Enabled     = true;
                    }
                    oDashBoard.Show();
                    oDashBoard.FormClosed += Logout;
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Acceso denegado", "Aviso del Sistema");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text    = "";
            txtContraseña.Text = "";
            this.Show();
            txtUsuario.Focus();
        }
    }
}