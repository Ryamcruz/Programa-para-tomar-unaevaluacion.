using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multicursos
{
  class Students
    {
        //declaracion de variable 
        private string student_id;
        private string firstName;
        private string lastName;


        //mensajes para el nombre 
        public void setFirstName(string name)
        {
           
                      if (name.Length == 0 || name == "")
            {
                throw new Exception("Error:Porfavor introdusca su nombre"); //////////////////////
                
            }
            else
            {
                    firstName = name;
                }
        }

        //introducir nombre 
        public string getFirstName()
        {
            return firstName;
        }

        //introducir apellido
        public void setLastName(string surname)
        {
            if (surname.Length == 0 || surname == "")
            {
                throw new Exception("Error: Porfavor Introdusca su Apellido");
            }
            else
            {

                lastName = surname;
            }
        }

        //introducir nombre completo
        public string getLastName()
        {
            return lastName;
        }
        //intuducir id del estudiante 
        public  void setStudenID(string id)
        {
            student_id = id;
        }
        //intuducir id del estudiante
        public string getStudentID()
        {
            return student_id;
        }
        //creating random student numberds. 
        public string StudentID()
        {
            Random userid = new Random();
            int id = userid.Next(111111, 999999);
            return "BIEN" + id.ToString();

        }

    }
}
*/ RYAM CRUZ 15- MISM-1-109 Alexis Reyes 14-SISM-1-103  Alonzo Brand 15-EIST-1-026 /*