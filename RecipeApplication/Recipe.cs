using RecipeApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RecipeApplication
{
    public class Recipe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private int totalCalories;
        private List<Ingredient> ingredients = new List<Ingredient>();

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public int TotalCalories
        {
            get { return totalCalories; }
            set
            {
                totalCalories = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalCalories)));
            }
        }

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                UpdateCalories();
            }
        }

        public void UpdateCalories()
        {
            int calories = 0;
            foreach (var ingredient in Ingredients)
            {
                calories += ingredient.Calories;
            }
            TotalCalories = calories;
        }
    }
}