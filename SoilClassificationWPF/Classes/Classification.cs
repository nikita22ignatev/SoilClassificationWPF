using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilClassification
{
    public class Classification
    {
        private int typeIndex;

        private Dictionary<string, double> valDict;

        public Classification(int typeIndex, Dictionary<string, double> valDict)
        {
            this.typeIndex = typeIndex;
            this.valDict = valDict;
        }

        public StringBuilder ClassificationVal()
        {
            StringBuilder outClassification = new StringBuilder();
            outClassification = ClassificationType(typeIndex);

            if (typeIndex != 2)
            {
                outClassification.Append(" ");
                outClassification.Append(ClassificationVariety(typeIndex, valDict["jl"]));
            }
            else
            {
                outClassification.Append(" ");
                outClassification.Append(ClassificationSandType(valDict["fractCategory"]));
                outClassification.Append(" ");
                outClassification.Append(ClassificationSandDensity(valDict["e"], valDict["fractCategory"]));
            }

            outClassification.Append(" ");
            outClassification.Append(ClassificationHumidity(valDict["sr"]));

            return outClassification;
        }

        private static StringBuilder ClassificationType(int typeIndex)
        {
            StringBuilder valType = new StringBuilder();

            if (typeIndex == 0)
            {
                valType = new StringBuilder("Суглинки");
            }
            else if (typeIndex == 1)
            {
                valType = new StringBuilder("Супеси");
            }
            else if (typeIndex == 2)
            {
                valType = new StringBuilder("Пески");
            }
            else
            {
                valType = new StringBuilder("Глины");
            }

            return valType;
        }

        private static StringBuilder ClassificationVariety(int typeIndex, double jl)
        {
            StringBuilder valVariety = new StringBuilder();

            if (typeIndex == 0 || typeIndex == 3)
            {
                if (jl <= 0)
                {
                    valVariety = new StringBuilder("твёрдые");
                }
                else if ((jl >= 0) && (jl <= 0.25))
                {
                    valVariety = new StringBuilder("полутвёрдые");
                }
                else if ((jl > 0.25) && (jl <= 0.5))
                {
                    valVariety = new StringBuilder("тугопластичные");
                }
                else if ((jl > 0.5) && (jl <= 0.75))
                {
                    valVariety = new StringBuilder("мягкопластичные");
                }
                else if ((jl > 0.75) && (jl <= 1))
                {
                    valVariety = new StringBuilder("текучепластичные");
                }
                else
                {
                    valVariety = new StringBuilder("текучие");
                }
            }
            else
            {
                if (jl <= 0)
                {
                    valVariety = new StringBuilder("твёрдые");
                }
                else if ((jl > 0) && (jl <= 1))
                {
                    valVariety = new StringBuilder("пластичные");
                }
                else
                {
                    valVariety = new StringBuilder("текучие");
                }
            }

            return valVariety;
        }

        private static StringBuilder ClassificationHumidity(double sr)
        {
            StringBuilder valHumidity = new StringBuilder();

            if ((sr > 0) && (sr <= 0.5))
            {
                valHumidity = new StringBuilder("маловлажные");
            }
            else if ((sr > 0.5) && (sr <= 0.8))
            {
                valHumidity = new StringBuilder("влажные");
            }
            else
            {
                valHumidity = new StringBuilder("насыщенные водой");
            }

            return valHumidity;
        }

        private static StringBuilder ClassificationSandType(double fractCategory)
        {
            StringBuilder valSandType = new StringBuilder();

            if (fractCategory == 1)
            {
                valSandType = new StringBuilder("гравелистые");
            }
            else if (fractCategory == 2)
            {
                valSandType = new StringBuilder("крупные");
            }
            else if (fractCategory == 3)
            {
                valSandType = new StringBuilder("средней крупности");
            }
            else if (fractCategory == 4)
            {
                valSandType = new StringBuilder("мелкие");
            }
            else if (fractCategory == 5)
            {
                valSandType = new StringBuilder("пылеватые");
            }

            return valSandType;
        }

        private static StringBuilder ClassificationSandDensity(double e, double fractCategory)
        {
            StringBuilder valSandDensity = new StringBuilder();

            if (fractCategory == 4)
            {
                if (e < 0.6)
                {
                    valSandDensity = new StringBuilder("плотные");
                }
                else if ((e >= 0.6) && (e <= 0.75))
                {
                    valSandDensity = new StringBuilder("средней плотности");
                }
                else
                {
                    valSandDensity = new StringBuilder("рыхлые");
                }
            }
            else if (fractCategory == 5)
            {
                if (e < 0.6)
                {
                    valSandDensity = new StringBuilder("плотные");
                }
                else if ((e >= 0.6) && (e <= 0.8))
                {
                    valSandDensity = new StringBuilder("средней плотности");
                }
                else
                {
                    valSandDensity = new StringBuilder("рыхлые");
                }
            }
            else
            {
                if (e < 0.5)
                {
                    valSandDensity = new StringBuilder("плотные");
                }
                else if ((e >= 0.5) && (e <= 0.7))
                {
                    valSandDensity = new StringBuilder("средней плотности");
                }
                else
                {
                    valSandDensity = new StringBuilder("рыхлые");
                }
            }

            return valSandDensity;
        }
    }
}
