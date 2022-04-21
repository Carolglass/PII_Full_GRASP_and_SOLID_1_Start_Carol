//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo total de la receta: ${this.GetProductionCost()}");
            //Se decide agregar la última consigna acá ya que es donde se imprime la receta final
        }

        /*El calculo de costo total es el siguiente:
        Costo insumos = Sumatoria de costo unitario de los insumos,
        Costo equipamiento = Sumatoria de tiempo de uso x costo/hora del equipo para todos los pasos de la receta,
        Costo total = costo insumos + costo equipamiento*/

        public double GetProductionCost()

        {
            double totalCost=0;
            foreach (Step step in this.steps)
            {
                totalCost+=step.StepCost();
            }
            return totalCost;
        }
                
        /*Agrego GetProductionCost() como método que suma todos los totales de cada paso de la receta.
        Dado que Recipe es la clase que tiene la información necesaria para la producción de la receta,
        se utiliza patron Expert, asignándole la responsabilidad a esta clase donde iterando en los pasoas de la receta, se puede
        calcular el costo total de producción.*/ 
    }
}