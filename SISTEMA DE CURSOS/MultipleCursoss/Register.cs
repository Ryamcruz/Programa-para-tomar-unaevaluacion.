using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Multicursos
{
    public partial class Register : Form
    {
        //Declaracion de las variable 
        StreamWriter write;
        public Register()
        {
            InitializeComponent();
      
        }
       
        private void lblRegister_Click(object sender, EventArgs e)
        {
            //LLAMADA DE EL METODO
            registerButton(); 
        }


        private void txtDateOF_MouseEnter(object sender, EventArgs e)
        {
            if (txtDateOF.Text == "Dias / Mes / Año") 
            {
                txtDateOF.Text = "";
            }
        }

        private void txtDateOF_MouseLeave(object sender, EventArgs e)
        {
            if (txtDateOF.Text == "")
            {
                txtDateOF.Text = "Dias / Mes / Año";
            }
        }

        private void txtEmailAddress_MouseEnter(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "Ram.ip@gamil.com")
            {
                txtEmailAddress.Text = "";
            }
        }

        private void txtEmailAddress_MouseLeave(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Text = "Ram.ip@gamil.com";         
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //method call
            registerButton();
        }

        public void registerButton() 
        {
                
// intente capturar para abrir el archivo, escribirlo y cerrarlo.
            try
            {
                string students =
                    txtUsername.Text.ToLower() + "," +
                    txtPassword.Text + "," +
                    txtFirstName.Text + "," +
                    txtLastName.Text + "," +
                    txtDateOF.Text + "," +
                    txtEmailAddress.Text.ToLower() + "\n";
                //creating the file.
                write = new StreamWriter("studentDetails.txt", true);

                //if statements to filter the inputs. 
                if (txtUsername.Text != "" && txtPassword.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtDateOF.Text != "" && txtEmailAddress.Text != "")
                {
                    if (txtDateOF.Text != "Dias / Mes / Año" && txtEmailAddress.Text != "Ram.ip@gamil.com")
                    {
                        if (txtEmailAddress.Text.Contains("@") && txtEmailAddress.Text.Contains(".com"))
                        {
                            write.Write(students);
                            //displaying to the user that registration was successful.
                            MessageBox.Show("El registro fue exitoso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtFirstName.Clear();
                            txtLastName.Clear();
                            txtDateOF.Clear();
                            txtDateOF.Text = "Dias / Mes / Año";
                            txtEmailAddress.Clear();
                            txtEmailAddress.Text = "Ram.ip@gamil.com";
                        }
                        else
                        {
                            MessageBox.Show("Su formato de correo electrónico no es correcto, introduzca el correo electrónico correcto \n e.g isidro.p.171717.ip@gamil.com", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, rellene todos los campos obligatorios", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Porfavor llenar todo los campos", "Registro con Errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            //catching all exceptions
            catch (System.IO.PathTooLongException path)
            {
                MessageBox.Show(path.Message);

            }
            catch (IOException io)
            {
                MessageBox.Show(io.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closing my file.
                write.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
