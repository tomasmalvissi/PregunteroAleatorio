using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preguntero
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //TODO: sortear preguntar
        public void RetornarPreguntas(int semana, DateTime fecha, string[] pregunta)
        {
            switch (fecha.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    txtPreguntas.Text = "Algo salió mal. Debe elegir un dia laboral";
                    break;
                case DayOfWeek.Saturday:
                    txtPreguntas.Text = "Algo salió mal. Debe elegir un dia laboral";
                    break;

                default:
                    if (fecha >= DateTime.Today)
                    {
                        Random rdn = new Random();  //creo el random afuera del for si no me repite el mismo resultado siempre
                        txtPreguntas.Text = "";
                        for (int i = 0; i < semana; i++)
                        {
                            int horas = rdn.Next(8, 18);    //le asigno al random la hora laboral
                            int minutos = rdn.Next(60);
                            TimeSpan ts = new TimeSpan(horas, minutos, 0);         //asigno la hora a la fecha que pickeo           
                            fecha = fecha.Date + ts;
                            txtPreguntas.Text += fecha.ToString("dddd, dd MMMM yyyy HH:mm:ss") + " - " + pregunta[i] + "\n";
                            fecha = fecha.AddDays(1);       //aumento la fecha
                            switch (fecha.DayOfWeek)        //valido que cuando aumente la fecha no toque finde
                            {
                                case DayOfWeek.Sunday:
                                    fecha = fecha.AddDays(1);
                                    break;
                                case DayOfWeek.Saturday:
                                    fecha = fecha.AddDays(2);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        txtPreguntas.Text = "Algo salió mal. Debe elegir una fecha actual o superior";
                    }
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtSemanas.Text == "")
            {
                MessageBox.Show("Ingrese un valor", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int semanas = int.Parse(txtSemanas.Text);
                DateTime fechaini = dtpFechaIni.Value;
                string[] preguntas = { "Pregunta1", "Pregunta2", "Pregunta3", "Pregunta4", "Pregunta5", "Pregunta6", "Pregunta7" };
                RetornarPreguntas(semanas, fechaini, preguntas);
            }
        }

        private void txtSemanas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
