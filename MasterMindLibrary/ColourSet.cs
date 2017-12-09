using System;
using System.Collections.Generic;

namespace MasterMindLibrary
{
    /// <summary>
    /// Valid colour choices for a ColourSet.
    /// </summary>
    public enum ColourChoice {
        RED = 'R',
        GREEN = 'G',
        BLUE = 'B',
        YELLOW = 'Y'
    }
    
    /// <summary>
    /// The represention of a set of colours in the game.
    /// </summary>
    public class ColourSet
    {
        const int NUM_COLOURS = 4;
        private ColourChoice[] colours = null;

        public ColourSet()
        {
            colours = new ColourChoice[NUM_COLOURS];
            Array values = Enum.GetValues(typeof(ColourChoice));

            // Randomly select the colours...
            Random random = new Random();
            for (int i = 0; i < NUM_COLOURS; i++)
            {
                int index = random.Next(values.Length);
                colours[i] = (ColourChoice)values.GetValue(index);
            }
        }

        public ColourSet(params ColourChoice[] coloursToUse)
        {
            if (coloursToUse.Length != NUM_COLOURS)
            {
                string errorMsg = String.Format("Expected {0} colours got {1}",
                                                NUM_COLOURS, coloursToUse.Length);
                throw new ArgumentOutOfRangeException(errorMsg);
            }
            colours = new ColourChoice[NUM_COLOURS];

            for (int i = 0; i < coloursToUse.Length; i++)
            {
                colours[i] = coloursToUse[i];
            }
        }

        /// <summary>
        /// Get property for the set of colours.
        /// </summary>
        public ColourChoice[] Colours { get { return colours;  } }

        public static string ColoursToString(ColourChoice[] colours)
        {
            return String.Join(" | ", colours);
        }
        /// <summary>
        /// Useful function for debugging.
        /// </summary>
        /// <returns>Representation of the four colours.</returns>
        override public string ToString()
        {
            return String.Format("<{0}: [{1}]>", GetType().Name, ColoursToString(colours));
        }
       
        public override int GetHashCode()
        {
            // This is needed to supress CS0659
            return 75448090 + EqualityComparer<ColourChoice[]>.Default.GetHashCode(colours);
        }

        public override bool Equals(object obj)
        {
            var set = obj as ColourSet;
            return set != null &&
                   ColoursToString(colours) == ColoursToString(set.colours);
        }
    }
}
