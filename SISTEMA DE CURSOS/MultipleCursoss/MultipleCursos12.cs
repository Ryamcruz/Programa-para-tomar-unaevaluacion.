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
    public partial class MultipleCursos12 : Form
    {
        //Declarando variables y objetos.
        private Students student;
        //Craeting una matriz 2D
        private string[,] resultsAndMemo;
        private string[] question1;
        private string[] question2;
        private string[] question3;
        private string[] question4;
        private int number = 0;
        private int totalNumber = 0;
        private string studentMark = "";
        private int studentNo = 0;
        private int numberOpen = 0;
        private string line = "";
        private int num = 0;
        private int count = 0;
        private bool check =false;
        private string UsuarioNombre = "", Contraseña = "", Nombre = "", Apellido = "",fechade= "", email = "";
        private StreamWriter write;
        private StreamReader sr;
        private StreamReader read;

        public MultipleCursos12()
        {
            InitializeComponent();
            //Invocando mi método de identificación del estudiante.
            setUserID();
            //Inicio de mi temporizador.
            timerUpdateTime.Start();
            //Mostrando mi reloj.
            lblTime.Visible = true;


        }
        //Ocultar una nota cuando el usuario hace clic en iniciar sesión
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
        }
        //Ocultar un panel cuando el usuario hace clic en el botón
        private void btnStudentCenter_Click(object sender, EventArgs e)
        {
            panelStudentCenter.Visible = false;
            lblRegister.Visible = true;
            btnRegsiter.Visible = true;

        }
        //Ocultar el panel cuando el usuario hace clic en el botón
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
        }
        //Acción de ajuste para mi botón de inicio de sesión
        private void lblSignIn_Click(object sender, EventArgs e)
        {
            //Método de inicio de sesión
                                    signIn();
        }
        //Acción de ajuste para mi botón de inicio de sesión
        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
            //llamada de metodo.
            signIn();
        }

        //ocultar cuando los usuarios se apagan
        private void btnSignOut_Click_1(object sender, EventArgs e)
        {


            txtUserId.Clear();
            txtName.Clear();
            txtSurname.Clear();

            txtUserId.Text = student.StudentID().ToString();
            panelLogin.Visible = true;
            lblNameSign.Visible = false;
            btnSignOut.Visible = false;
            btnPastPaper.Visible = false;
            lblSignedIn.Visible = false;
            //ocultar el cuadro de texto del usuario
            txtUserAnswer1.Visible = false;
            txtUserAnswer2.Visible = false;
            txtUserAnswer3.Visible = false;
            txtUserAnswer4.Visible = false;
            //Borrar las preguntas y las posibles respuestas
            lblQuestion1.Text = "";
            lblQuestion2.Text = "";
            lblQuestion3.Text = "";
            lblQuestion4.Text = "";
            lblQuestion1Possible.Text = "";
            lblQuestion2Possible.Text = "";
            lblQuestion3Possible.Text = "";
            lblQuestion4Possible.Text = "";
            txtUserAnswer1.Clear();
            txtUserAnswer2.Clear();
            txtUserAnswer3.Clear();
            txtUserAnswer4.Clear();
            numberOpen = 0;
            panelLecture.Visible = true;


        }

        //Estableciendo mi ID de estudiante al azar
        public void setUserID()
        {

            student = new Students();
            txtUserId.Text = student.StudentID().ToString();
        }

        //Inicio de mi temporizador
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblTime.Text = time.ToLocalTime().ToString();

        }
        //Ocultar panel si se hace clic en el botón de conferencia
        private void btnHideLecture_Click(object sender, EventArgs e)
        {
            //Ocultando el botón de inicio de sesión y el botón.
            if (numberOpen == 1)
            {
                panelLecture.Visible = false;
                btnPastPaper.Visible = true;
            }
               
            else
            {
                MessageBox.Show("Por favor haga clic en ESTUDIANTES  y luego regrese aquí!!!!", "Es necesario iniciar sesión con los estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Creando acción para onlick
        private void btnSetTest_Click(object sender, EventArgs e)
        {
            //Llamando a mi posible método 
            possibleAnswersAndQuestion();

        }
        //llenando mis arreglos
        public void possibleAnswersAndQuestion()
        {
            question1 = new string[5]
               
                {
                txtQuestion1.Text,
                txtQuestion1Possible1.Text,
                txtQuestion1Possible2.Text,
                txtQuestion1Possible3.Text,
                txtQuestion1Possible4.Text
                };



            // agregar texto al array para la pregunta 1
            question1 = new string[5]
               
                {
                txtQuestion1.Text,
                txtQuestion1Possible1.Text,
                txtQuestion1Possible2.Text,
                txtQuestion1Possible3.Text,
                txtQuestion1Possible4.Text
                };


            // agregar texto al array para la pregunta 2
            question2 = new string[5]
                {
                txtQuestion2.Text,
                txtQuestion2Possible1.Text,
                txtQuestion2Possible2.Text,
                txtQuestion2Possible3.Text,
                txtQuestion2Possible4.Text
                };

            
            // agregar texto al array para la pregunta 3
            question3 = new string[5]
                {
                txtQuestion3.Text,
                txtQuestion3Possible1.Text,
                txtQuestion3Possible2.Text,
                txtQuestion3Possible3.Text,
                txtQuestion3Possible4.Text
                };
            
            // agregar texto al array para la pregunta 4
            question4 = new string[5]
                {
                txtQuestion4.Text,
                txtQuestion4Possible1.Text,
                txtQuestion4Possible2.Text,
                txtQuestion4Possible3.Text,
                txtQuestion4Possible4.Text
                };


            // Establecimiento de preguntas y posibles respuestas
            lblQuestion1.Text = question1[0];
            lblQuestion1Possible.Text = "";
           // llenado Array
            for (int x = 1; x < question1.Length; x++)
            {
                lblQuestion1Possible.Text += question1[x] + "\n";
            }

            // Establecimiento de preguntas y posibles respuestas
            lblQuestion2.Text = question2[0];
            lblQuestion2Possible.Text = "";
            // llenado Array
            for (int x = 1; x < question2.Length; x++)
            {
                lblQuestion2Possible.Text += question2[x] + "\n";
            }
            // Establecimiento de preguntas y posibles respuestas
            lblQuestion3.Text = question3[0];
            lblQuestion3Possible.Text = "";
            // llenado Array
            for (int x = 1; x < question3.Length; x++)
            {
                lblQuestion3Possible.Text += question3[x] + "\n";
            }

            // Establecimiento de preguntas y posibles respuestas
            lblQuestion4.Text = question4[0];
            lblQuestion4Possible.Text = "";
            // llenado Array
            for (int x = 1; x < question4.Length; x++)
            {
                lblQuestion4Possible.Text += question4[x] + "\n";
            }


            // llamando a mi método aquí.
            checkQuestions();
        }


        // habilitando los cuadros de texto de entrada del usuario.
        public void checkQuestions()
        {
            if (txtQuestion1.Text != "" & txtQuestion2.Text != "" & txtQuestion3.Text != "" & txtQuestion4.Text != "")
            {

                // Habilitación del cuadro de texto del usuario.
                txtUserAnswer1.Visible = true;
                txtUserAnswer2.Visible = true;
                txtUserAnswer3.Visible = true;
                txtUserAnswer4.Visible = true;
                check = true;

                try
                {
                    // guardar las respuestas de las conferencias y las preguntas en una cadena para poder guardarlas en un archivo más adelante.
                    string pastPaper = "";

                    pastPaper = "\tPast Paper" + "\n\n1. " + txtQuestion1.Text
                        + "\n  " + txtQuestion1Possible1.Text
                        + "\n  " + txtQuestion1Possible2.Text
                        + "\n  " + txtQuestion1Possible3.Text
                        + "\n  " + txtQuestion1Possible4.Text
                        + "\n\n  " + txtQuestion1Correct1.Text + " ✔"
                        + "\n\n2. " + txtQuestion2.Text
                        + "\n  " + txtQuestion2Possible1.Text
                        + "\n  " + txtQuestion2Possible2.Text
                        + "\n  " + txtQuestion2Possible3.Text
                        + "\n  " + txtQuestion2Possible4.Text
                        + "\n\n  " + txtQuestion2Correct2.Text + " ✔"
                        + "\n\n3. " + txtQuestion3.Text
                        + "\n  " + txtQuestion3Possible1.Text
                        + "\n  " + txtQuestion3Possible2.Text
                        + "\n  " + txtQuestion3Possible3.Text
                        + "\n  " + txtQuestion3Possible4.Text
                        + "\n\n  " + txtQuestion3Correct3.Text + " ✔"
                        + "\n\n4. " + txtQuestion4.Text
                        + "\n  " + txtQuestion4Possible1.Text
                        + "\n  " + txtQuestion4Possible2.Text
                        + "\n  " + txtQuestion4Possible3.Text
                        + "\n  " + txtQuestion4Possible4.Text
                        + "\n\n  " + txtQuestion4Correct4.Text + " ✔";

                    /*Crear el archivo.
                      Escribir en un archivo y cerrar el archivo
                     */

                    write = new StreamWriter("PEGAR.txt");
                    write.WriteLine(pastPaper);
                    write.Close();
                }
                // lanzando toda excepción que pudiera ocurrir
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("La prueba se ha configurado y guardado correctamente en el archivo.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelLecture.Visible = true;
                btnPastPaper.Visible = false;
            }
            else
            {
                MessageBox.Show("Por favor complete todas las preguntas y respuestas.", "SII..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Botón memo para ver nota
        private void btnMemo_Click(object sender, EventArgs e)
        {
            try
            {


                // leyendo el nombre del archivo
                read = new StreamReader("Test Results.txt");
                MessageBox.Show(read.ReadToEnd());
                read.Close();

            }
            // captura de todas las excepciones
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

        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {

            // Verificación de si la conferencia establece la prueba o no
            if (check == true)
            {
                try
                {

                    studentNo++;


                    // reiniciar los detalles capturados...
                    number = 0;
                    totalNumber = 0;


                    // inicializar y poblar la matriz 2D
                    resultsAndMemo = new string[2, 4]
            {
               
            {
             
              // las respuestas correctas de la conferencia
             txtQuestion1Correct1.Text, 
             txtQuestion2Correct2.Text,
             txtQuestion3Correct3.Text, 
             txtQuestion4Correct4.Text,
            
            },

            {
             // respuestas del usuario.
                txtUserAnswer1.Text,
                txtUserAnswer2.Text,
                txtUserAnswer3.Text,
                txtUserAnswer4.Text
            }
            };

                    /*
                      Cálculo de la calificación total del estudiante usando un bucle for
                     */

                    for (int x = 0; x < 1; x++)
                    {

                        for (int y = 0; y <= 3; y++)
                        {
                            number++;

                            if (resultsAndMemo[0, y].ToLower() == resultsAndMemo[1, y].ToLower())
                            {

                                studentMark += number.ToString() + ". ✔\n";
                                totalNumber++;
                            }
                            else
                            {
                                studentMark += number.ToString() + ". ✖\n";
                            }
                        }
                    }


                    if (studentMark != "")
                    {


                        // obtener los usuarios del usuario y el memo de las conferencias.
                        string outcomes = "";
                        outcomes = "Nombre: " + Nombre + " \nApellido: " + Apellido + "\n\nYour answers\t\tMemo\n"
                               + "1. " + txtUserAnswer1.Text.ToUpper() + "\t\t\t1. " + txtQuestion1Correct1.Text.ToUpper() + "\n"
                               + "2. " + txtUserAnswer2.Text.ToUpper() + "\t\t\t2. " + txtQuestion2Correct2.Text.ToUpper() + "\n"
                               + "3. " + txtUserAnswer3.Text.ToUpper() + "\t\t\t3. " + txtQuestion3Correct3.Text.ToUpper() + "\n"
                               + "4. " + txtUserAnswer4.Text.ToUpper() + "\t\t\t4. " + txtQuestion4Correct4.Text.ToUpper() + "\n\n"
                               + "Marking\n" + studentMark +
                               "\n\n" + "_____________________________________________________________________\n" +
                            "\n Total: " + totalNumber + "/4\n"
                            + "______________________________________________________________________";

                        string clasList = "ID: " + student.getStudentID() + "\nNombre: " + Nombre + "\nApellido: " + Apellido + "\nMarks: " + totalNumber + "/4\n_________________________________________________________________\n";
                        MessageBox.Show("La prueba fue completada y marcada exitosamente, por favor revise los resultados y la nota. La prueba y la nota se guardaron con éxito en el archivo.","Test completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // escribiendo para la lista de clases.
                        write = new StreamWriter("Class List.txt", true);
                        write.Write(clasList);
                        write.Close();

                        // creación del archivo
                        write = new StreamWriter("Test Results.txt");
                        write.Write(outcomes);
                        write.Close();
                        studentMark = null;

                    }
                    else
                    {

                        MessageBox.Show("por favor responde las preguntas primero!!!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // captura de todas las excepciones
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
            }
            else 
            {
                MessageBox.Show("Espere la conferencia para configurar el", "por favor espera.....",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentacion_Estudiamtes p = new Presentacion_Estudiamtes();
            p.Show();
        }

        private void lblNameSign_Click(object sender, EventArgs e)
        {

        }

        private void MultipleCursos12_Load(object sender, EventArgs e)
        {

        }

        private void btnViewClass_Click(object sender, EventArgs e)
        {
            try
            {
                read = new StreamReader("Class List.txt");
                MessageBox.Show("\t\t__Código Lista de clases de la escuela__\n\n" + read.ReadToEnd());
                read.Close();
            }
             // captura de todas las excepciones
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
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void btnRegsiter_Click(object sender, EventArgs e)
        {
            
            Register register = new Register();
            register.ShowDialog();
        }
        public void signIn()
        {
            StreamReader read;
            string details = "";



// Creando un try and catch, para atrapar a los estudiantes expulsados ​​excepción try
            {

                student = new Students();
                student.setStudenID(txtUserId.Text);
                student.setFirstName(txtName.Text.ToLower());
                student.setLastName(txtSurname.Text);



                // leer el nombre del archivo.
                read = new StreamReader("studentDetails.txt");

                while ((line = read.ReadLine()) != null)
                {
                    if (line.Contains(student.getFirstName()) && line.Contains(student.getLastName()))
                    {
                        num = 1;
                        details = line;

                    }
                }

                // crear una matriz para volcar los detalles del sistema y almacenarlos en variables
                string[] words = details.Split(',');
                foreach (string word in words)
                {
                    if (count == 0)
                    {
                        UsuarioNombre = word;
                    }
                    else if (count == 1)
                    {
                        Contraseña = word;
                    }
                    else if (count == 2)
                    {
                        Nombre = word;
                    }
                    else if (count == 3)
                    {
                        Apellido = word;
                    }
                    else if (count == 4)
                    {
                        fechade = word;
                    }
                    else if (count == 5)
                    {
                        email = word;
                        count = -1;
                        break;
                    }
                    count++;
                }

                // comprobar si el nombre de usuario y la contraseña coincidían con los del archivo.
                if (num == 1)
                {

                    count = 0;
                    num = 0;
                    if (UsuarioNombre == student.getFirstName() && Contraseña == student.getLastName())
                    {

                        // ocultar el panel y mostrar mi pantalla de inicio.
                        panelLogin.Visible = false;
                        lblNameSign.Visible = true;
                        lblNameSign.Text = email.ToLower();
                        lblSignedIn.Visible = true;
                        btnSignOut.Visible = true;

                        numberOpen = 1;
                    }
                    else
                    {
                        MessageBox.Show("nombre de usuario y contraseña inválidos", " error de inicio  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("nombre de usuario y contraseña inválidosSugerir un cambio", "error de inicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                read.Close();


            } 
            //Throwing exceptions.
            try
           
            {
                MessageBox.Show("Archivo no encontrado por favor regístrese antes de intentar iniciar sesión...", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnPastPaper_Click(object sender, EventArgs e)
        {
            try
            {
                //reading name from file
                read = new StreamReader("Past Paper.txt");
                MessageBox.Show(read.ReadToEnd());
                read.Close();

            } //catching all exceptions
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

    }
}
