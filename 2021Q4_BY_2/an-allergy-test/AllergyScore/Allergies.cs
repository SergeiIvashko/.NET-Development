using System;
using System.Collections.Generic;

namespace AllergyScore
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        private int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class with test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        public Allergies(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get => this.score;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score cannot be less than zero.");
                }

                this.score = value;
            }
        }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            // Implement this method.
            return (this.score & (int)allergens) == (int)allergens;
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            // Implement this method.
            List<Allergens> allergensList = new List<Allergens>();
            foreach (Allergens allergen in Enum.GetValues(typeof(Allergens)))
            {
                if ((this.score & (int)allergen) == (int)allergen)
                {
                    allergensList.Add(allergen);
                }
            }

            return allergensList.ToArray();
        }
    }
}
