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
            Console.WriteLine($"costo total de receta: {GetTotalCost()}");
        }

        public double GetTotalCost()
        {
            double TotalProductionCost = 0;
            
            TotalProductionCost += GetEquipmentCost();
            TotalProductionCost += GetProductCost();

            return TotalProductionCost;
        }

        public double GetProductCost()
        {
            double ProductCosts = 0;
            foreach (Step step in this.steps)
            {
                ProductCosts += step.Input.UnitCost;
            }
            return ProductCosts;
        }

        public double GetEquipmentCost()
        {
            double EquipmentCosts = 0;
            foreach (Step step in this.steps)
            {
                EquipmentCosts += step.Time / step.Equipment.HourlyCost;
            }
            return EquipmentCosts;
        }

    }
}