using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SoilClassification;

namespace SoilClassification
{
    public class Calculation
    {
        private int typeIndex;

        private double h;
        private double hPrev;

        private double p;
        private double ps;

        private double w;
        private double wl;
        private double wp;

        private int[] fractContent;

        public Calculation(int typeIndex, double h, double hPrev, double p, double ps, double w, double wl, double wp)
        {
            this.typeIndex = typeIndex;
            this.h = h;
            this.hPrev = hPrev;
            this.p = p;
            this.ps = ps;
            this.w = w;
            this.wl = wl;
            this.wp = wp;
        }

        public Calculation(int typeIndex, double h, double hPrev, double p, double ps, double w, int[] fractContent)
        {
            this.typeIndex = typeIndex;
            this.h = h;
            this.hPrev = hPrev;
            this.p = p;
            this.ps = ps;
            this.w = w;
            this.fractContent = fractContent;
        }

        public Dictionary<string, double> CalculationVal()
        {
            var valDict = new Dictionary<string, double>();

            valDict.Add("h", CalculationH(h, hPrev));
            valDict.Add("e", CalculationE(p, ps, w));
            valDict.Add("sr", CalculationSr(w, ps, valDict["e"]));

            if (typeIndex != 2)
            {
                valDict.Add("jp", CalculationJp(wl, wp));
                valDict.Add("jl", CalculationJl(w,wp,wl));
                valDict.Add("r0", CalculationR0(typeIndex, valDict["e"], valDict["jl"]));
            }
            else
            {
                valDict.Add("fractCategory", CalculationFractCategory(fractContent));
                valDict.Add("r0", CalculationSandR0(valDict["fractCategory"], valDict["e"], valDict["sr"]));
            }

            return valDict;
        }

        static private double CalculationH(double h, double hPrev)
        {
            double hNew = hPrev + h / 2;
            hNew = Math.Round(hNew, 2, MidpointRounding.AwayFromZero);

            return hNew;
        }

        static private double CalculationE(double ps, double p, double w)
        {
            double e = ps / p * (1 + w / 100);
            e = Math.Round(e, 2, MidpointRounding.AwayFromZero);

            return e;
        }

        static private double CalculationSr(double w, double ps, double e)
        {
            double sr = (w / 100 * ps) / e;
            sr = Math.Round(sr, 2, MidpointRounding.AwayFromZero);

            return sr;
        }

        static private double CalculationJp(double wl, double wp)
        {
            double jp = (wl - wp);

            return jp;
        }

        static private double CalculationJl(double w, double wp, double wl)
        {
            double jl = (w - wp) / (wl - wp);
            jl = Math.Round(jl, 2, MidpointRounding.AwayFromZero);

            return jl;
        }

        static private double CalculationFractCategory(int[] fractContent)
        {
            double fractCategory = 0;
            double fractSum = 0;

            for (int i = 0; i < 8; i++)
            {
                if (fractSum > 50)
                {
                    fractCategory = i + 1;
                }
                else
                {
                    fractSum += fractContent[i];
                }
            }

            return fractCategory;
        }

        private static double CalculationR0(int typeIndex, double e, double jl)
        {
            double r0Max = 0;
            double r0Min = 0;

            double eMax = 0;
            double eMin = 0;

            if (typeIndex == 0)
            {
                eMax = 0.7;
                eMin = 0.5;

                if (jl <= 0)
                {
                    r0Max = 250;
                    r0Min = 300;
                }
                else
                {
                    r0Max = 200;
                    r0Min = 300;
                }
            }
            else if (typeIndex == 1)
            {
                eMax = 1;
                eMin = 0.5;

                if (jl <= 0)
                {
                    r0Max = 200;
                    r0Min = 300;
                }
                else
                {
                    r0Max = 100;
                    r0Min = 250;
                }
            }
            else if (typeIndex == 3)
            {
                eMax = 1.1;
                eMin = 0.5;

                if (jl <= 0)
                {
                    r0Max = 250;
                    r0Min = 600;
                }
                else
                {
                    r0Max = 100;
                    r0Min = 400;
                }
            }

            double r0 = r0Min + (r0Max - r0Min) / (eMax - eMin) * (e - eMin);

            r0 = Math.Round(r0, 2, MidpointRounding.AwayFromZero);
            return r0;
        }

        private static double CalculationSandR0(double fractCategory, double e, double sr)
        {
            double r0 = 0;

            if (fractCategory == 4)
            {
                if (e < 0.6)
                {
                    if ((sr > 0) && (sr <= 0.5))
                    {
                        r0 = 400;
                    }
                    else
                    {
                        r0 = 300;
                    }
                }
                else
                {
                    if ((sr > 0) && (sr <= 0.5))
                    {
                        r0 = 300;
                    }
                    else
                    {
                        r0 = 200;
                    }
                }
            }
            else if (fractCategory == 5)
            {
                if (e < 0.6)
                {
                    if ((sr > 0) && (sr <= 0.5))
                    {
                        r0 = 300;
                    }
                    else if ((sr > 0.5) && (sr <= 0.8))
                    {
                        r0 = 200;
                    }
                    else
                    {
                        r0 = 150;
                    }
                }
                else
                {
                    if ((sr > 0) && (sr <= 0.5))
                    {
                        r0 = 250;
                    }
                    else if ((sr > 0.5) && (sr <= 0.8))
                    {
                        r0 = 150;
                    }
                    else
                    {
                        r0 = 100;
                    }
                }
            }
            else if (fractCategory == 2)
            {
                if (e < 0.5)
                {
                    r0 = 600;
                }
                else
                {
                    r0 = 500;
                }
            }
            else
            {
                if (e < 0.5)
                {
                    r0 = 500;
                }
                else
                {
                    r0 = 400;
                }
            }

            return r0;
        }
    }
}
