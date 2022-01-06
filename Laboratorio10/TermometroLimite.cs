using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio10
{
    internal class TermometroLimite : Termometro
    {
        private double limiteSuperior;
        private bool disparadoEventoLimiteSuperior;
        public TermometroLimite(double ls)
        {
            limiteSuperior = ls;
            disparadoEventoLimiteSuperior = false;
        }
        public double LimiteSuperior
        {
            get { return limiteSuperior; }
            set { limiteSuperior = value; }
        }
        public delegate void MeuDelegate(string msg);

        public event MeuDelegate LimiteSuperiorEvent;

        private void OnLimiteSuperiorEvent()
        {
            // verifica se a temperatura ultrapassou o limite e
            // Verifica se o evento já foi disparado, para não disparar continuamente.
            // Verifica se a temperatura esta maior que o limite e se anteriormente a temperatura estava normal (disparadoEventoLimiteSuperior = false)
            if ((this.Temperatura > limiteSuperior) && (!disparadoEventoLimiteSuperior))//disparadoEventoLimiteSuperior for falso ele mostra a msg 
                // verifica se há tratador
                if (LimiteSuperiorEvent != null)
                {
                    LimiteSuperiorEvent("Atenção: temperatura acima do limite!!!");
                    disparadoEventoLimiteSuperior = true;
                }
        }

        public override void Aumentar()
        {
            base.Aumentar();
            OnLimiteSuperiorEvent();
        }
        public override void Aumentar(double quantia)
        {
            base.Aumentar(quantia);
            OnLimiteSuperiorEvent();
        }
        public override void Diminuir()
        {
            base.Diminuir();
            OnNormalizadoEvent();


        }
        public override void Diminuir(double quantia)
        {
            base.Diminuir(quantia);
            OnNormalizadoEvent();
            
        }

        //Exercício 3.1
        public event MeuDelegate NormalizadoEvent;
        private void OnNormalizadoEvent()
        {
            if ((this.Temperatura <= limiteSuperior) && (disparadoEventoLimiteSuperior))
                // verifica se há tratador
                if (NormalizadoEvent != null)
                {
                    disparadoEventoLimiteSuperior = false;
                    NormalizadoEvent("temperatura voltou ao normal!!!" + "Temperatura atual: " + Temperatura);
                    
                }

        }


    }
        
    
}
