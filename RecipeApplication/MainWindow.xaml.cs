using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RecipeApplication
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
            RecipeList.ItemsSource = recipes;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient();
            IngredientList.ItemsSource = new List<Ingredient> { ingredient };
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.Name = RecipeName.Text;

            List<Ingredient> ingredients = (IngredientList.ItemsSource as IEnumerable<Ingredient>)?.ToList();
            if (ingredients != null)
            {
                recipe.Ingredients = ingredients;
            }

            recipe.UpdateCalories();
            if (recipe.TotalCalories > 300)
            {
                MessageBox.Show("Warning: Total calories exceed 300.");
            }
            recipes.Add(recipe);
        }
    }
}