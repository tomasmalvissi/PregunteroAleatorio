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
        //TODO: ver xq manda la misma hora salvo cuando debuggeo
        //TODO: validar sabados y domingos de nuevo cuando lo asigno
        //TODO: escribir error en elseif
        public void RetornarPreguntas(int semana, DateTime fecha ,string[] pregunta) 
        {
            if (fecha.Day != 0 || fecha.Day != 6)
            {
                if (fecha >= DateTime.UtcNow)
                {
                    for (int i = 0; i < semana; i++)
                    {
                        Random rdn = new Random();
                        int horas = rdn.Next(8, 18);    //creo un randon de la hora laboral
                        int minutos = rdn.Next(60);
                        TimeSpan ts = new TimeSpan(horas, minutos, 0);         //asigno la hora a la fecha que pickeo           
                        fecha = fecha.Date + ts;
                        txtPreguntas.Text += fecha.ToString("dddd, dd MMMM yyyy HH:mm:ss")+ " - " + pregunta[i] + "\n";
                        fecha = fecha.AddDays(1);       //aumento la fecha
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int semanas = int.Parse(txtSemanas.Text);
            DateTime fechaini = dtpFechaIni.Value;
            string[] preguntas = { "Pregunta1", "Pregunta2", "Pregunta3", "Pregunta4", "Pregunta5", "Pregunta6", "Pregunta7" };
            RetornarPreguntas(semanas, fechaini, preguntas);
        }
    }
}
