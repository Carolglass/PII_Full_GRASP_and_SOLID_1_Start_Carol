//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }
        //Sería el tiempo de uso del equipo

        public Equipment Equipment { get; set; }


        public double StepCost()
        /*Va a calcular el total del costo por cada paso de la forma 
        Costo total = costo unitario + tiempo de uso x costo/hora del equipo*/

        {
            return (((this.Input.UnitCost)*this.Quantity) + (((this.Time)/3600)*this.Equipment.HourlyCost) );
            /* 1 hora = 3600 segs
            El cafe con leche demora 120 segundos --> 120/3600=0.033 horas
            El costo es por hora. Por eso debo pasar el tiempo que me da a horas*/

        }
    }
}