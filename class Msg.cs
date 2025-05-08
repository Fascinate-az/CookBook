namespace CookBook;

    class MessageConsole
    {
        public void IntroMessage()
        {
            Console.WriteLine("Create a new cookie recipe!Available ingredients are:");
        }

        public void SceltaIngredienti()
        {
            Console.WriteLine("Add an ingredient by it's Id or type anything if finished");
        }

        public void TryParseFailed()
        {
            Console.WriteLine("scelta non valida,Seleziona un numero compreso tra 1 e 8");
        }

        public void RangeNonValido()
        {
            Console.WriteLine("Seleziona un numero compreso tra 1 e 8");
        }

        public void ConfermaIngredienteAggiunto()
        {
            Console.WriteLine($"Ingrediente aggiunto con successo");
        }

        public void ListaIngredientiVuota()
        {
            Console.WriteLine("Lista ingredienti vuota");
        }

        public void RecipeAdded()
        {
            Console.WriteLine("Recipe added:");
        }

        public void Exit()
        {
            Console.WriteLine("Press any key to close...");
        }

        public void SalvaFile()
        {
            Console.WriteLine("Salvataggio File in corso.....");
        }

        public void CaricaRecipe()
        {
            Console.WriteLine("Existing recipe are:");
        }

        public void Asterischi(int counter)
        {
            Console.WriteLine($"***** {counter} *****");
        }
    }
