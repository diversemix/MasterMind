using System;
using System.Collections.Generic;

namespace MasterMindLibrary
{

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

            // Randomly select the colours...
            Array values = Enum.GetValues(typeof(ColourChoice));
            Random random = new Random();
            for (int i = 0; i < NUM_COLOURS; i++)
            {
                int index = random.Next(values.Length);
                colours[i] = (ColourChoice)values.GetValue(index);
            }
        }

        public ColourSet(params string[] coloursToUse)
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
                string colourName = coloursToUse[i].ToUpper();
                colours[i] = (ColourChoice) Enum.Parse(typeof(ColourChoice), colourName);
            }
        }

        // public ColourSet(params ColourChoice[] coloursToUse)
        // {
        //     if (coloursToUse.Length != NUM_COLOURS)
        //     {
        //         string errorMsg = String.Format("Expected {0} colours got {1}",
        //                                         NUM_COLOURS, coloursToUse.Length);
        //         throw new ArgumentOutOfRangeException(errorMsg);
        //     }
        //     colours = new ColourChoice[NUM_COLOURS];
        // 
        //     for (int i = 0; i < coloursToUse.Length; i++)
        //     {
        //         colours[i] = coloursToUse[i];
        //     }
        // }

        /// <summary>
        /// Get property for the set of colours.
        /// </summary>
        public ColourChoice[] Colours { get { return colours;  } }

        public static string ColoursToString(ColourChoice[] colours)
        {
            return String.Join(" | ", colours);
        }

        /// <summary>
        /// This generates the black/white pins to indicate what is correct and/or
        /// in the right place.
        /// 
        /// Black - correct colour and correct place.
        /// White - correct colour and wrong place.
        /// 
        /// Psuedo Code:
        /// 1) Check for black pins and create sets of anything left over
        /// 2) Check for white pins by looking in the leftover sets.
        /// </summary>
        /// <param name="other">The other set we are comparing against.</param>
        /// <returns>A list of pins</returns>
        public List<ComparePin> Compare(ColourSet other)
        {
            List<ComparePin> pins = new List<ComparePin>();
            SortedSet<ColourChoice> thisSet = new SortedSet<ColourChoice>();
            SortedSet<ColourChoice> otherSet = new SortedSet<ColourChoice>();

            // Check for black pins - create sets for checking for whites
            for (int i = 0; i < NUM_COLOURS; i++)
            {
                if (colours[i] == other.colours[i])
                {
                    pins.Add(ComparePin.BLACK);
                }
                else
                {
                    thisSet.Add(colours[i]);
                    otherSet.Add(other.colours[i]);
                }
            }

            // Check for white pins
            foreach (ColourChoice colour in thisSet)
            {
                if (otherSet.Contains(colour))
                {
                    pins.Add(ComparePin.WHITE);
                }
            }
            return pins;
        }

        // ########## OVERRIDES ###############################################

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
