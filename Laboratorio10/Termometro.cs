using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio10
{
    internal class Termometro
    {
        private double valor;
        public Termometro()
        {
            valor = 0.0;
        }
        public double Temperatura
        {
            get { return valor; }
            set { valor = value; }
        }
        virtual public void Aumentar()
        {
            valor += 0.1;
        }
        virtual public void Aumentar(double quantia)
        {
            valor += quantia;  //soma a quantia no valor atual
        }
        virtual public void Diminuir()
        {
            valor -= 0.1;
        }
        virtual public void Diminuir(double quantia)
        {
            valor -= quantia; //subtrai a quantia no valor atual
        }
        override public string ToString()
        {
            return valor.ToString();
        }


    }
}
