using SoilClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoilClassificationWPF
{
    /// <summary>
    /// Interaction logic for CalculatePage.xaml
    /// </summary>
    public partial class CalculatePage : Page
    {
        public CalculatePage()
        {
            InitializeComponent();
        }


        private void Calculate1(object sender, RoutedEventArgs e)
        {

            if (Type1.SelectedIndex > -1)
            {
                double h = 0;
                double p = 0;
                double ps = 0;
                double w = 0;

                if (Type1.SelectedIndex != 2)
                {
                    double wl = 0;
                    double wp = 0;

                    if (Double.TryParse(H1.Text, out h) &&
                        Double.TryParse(P1.Text, out p) &&
                        Double.TryParse(Ps1.Text, out ps) &&
                        Double.TryParse(W1.Text, out w) &&
                        Double.TryParse(Wl1.Text, out wl) &&
                        Double.TryParse(Wp1.Text, out wp))
                    {
                        Calculation egeFirst;
                        egeFirst = new Calculation(Type1.SelectedIndex, h, 0, p, ps, w, wl, wp);

                        var egeFirstDict = new Dictionary<string, double>();
                        egeFirstDict = egeFirst.CalculationVal();

                        Classification egeFirstClass;
                        egeFirstClass = new Classification(Type1.SelectedIndex, egeFirstDict);

                        StringBuilder egeFirstOut = new StringBuilder();
                        egeFirstOut = egeFirstClass.ClassificationVal();
                        egeFirstOut.Append(".  ");
                        egeFirstOut.Append(GenerationOut(Type1.SelectedIndex, egeFirstDict));

                        Out1.Text = Convert.ToString(egeFirstOut);
                    }
                    else
                    {
                        OpenFailWindow(2);
                    }
                }
                else
                {
                    int[] fract = new int[7];

                    if (Double.TryParse(H1.Text, out h) &&
                        Double.TryParse(P1.Text, out p) &&
                        Double.TryParse(Ps1.Text, out ps) &&
                        Double.TryParse(W1.Text, out w) &&

                        int.TryParse(Fract1.Text, out fract[0]) &&
                        int.TryParse(Fract2.Text, out fract[1]) &&
                        int.TryParse(Fract3.Text, out fract[2]) &&
                        int.TryParse(Fract4.Text, out fract[3]) &&
                        int.TryParse(Fract5.Text, out fract[4]) &&
                        int.TryParse(Fract6.Text, out fract[5]) &&
                        int.TryParse(Fract7.Text, out fract[6]))
                    {
                        Calculation egeFirst;
                        egeFirst = new Calculation(Type1.SelectedIndex, h, 0, p, ps, w, fract);

                        var egeFirstDict = new Dictionary<string, double>();
                        egeFirstDict = egeFirst.CalculationVal();

                        Classification egeFirstClass;
                        egeFirstClass = new Classification(Type1.SelectedIndex, egeFirstDict);

                        StringBuilder egeFirstOut = new StringBuilder();
                        egeFirstOut = egeFirstClass.ClassificationVal();
                        egeFirstOut.Append(".  ");
                        egeFirstOut.Append(GenerationOut(Type1.SelectedIndex, egeFirstDict));

                        Out1.Text = Convert.ToString(egeFirstOut);
                    }
                    else
                    {
                        OpenFailWindow(2);
                    }
                }
            }
            else
            {
                OpenFailWindow(1);
            }
        }

        private StringBuilder GenerationOut(int typeIndex, Dictionary<string, double> valDict)
        {
            StringBuilder egeOut = new StringBuilder();

            if (typeIndex != 2)
            {
                egeOut.Append("H: ");
                egeOut.Append(valDict["h"]);
                egeOut.Append(" м");
                egeOut.Append(",  J(l): ");
                egeOut.Append(valDict["jl"]);
                egeOut.Append(",  J(p): ");
                egeOut.Append(valDict["jp"]);
                egeOut.Append(",  E: ");
                egeOut.Append(valDict["e"]);
                egeOut.Append(",  Sr: ");
                egeOut.Append(valDict["sr"]);
                egeOut.Append(",  R(0): ");
                egeOut.Append(valDict["r0"]);
                egeOut.Append(" кПа");
            }
            else
            {
                egeOut.Append("H: ");
                egeOut.Append(valDict["h"]);
                egeOut.Append(" м");
                egeOut.Append(",  E: ");
                egeOut.Append(valDict["e"]);
                egeOut.Append(",  Sr: ");
                egeOut.Append(valDict["sr"]);
                egeOut.Append(",  R(0): ");
                egeOut.Append(valDict["r0"]);
                egeOut.Append(" кПа");
            }

            return egeOut;
        }

        private void OpenFailWindow(int failNum)
        {
            string failTxt = "";

            if (failNum == 1)
            {
                failTxt = "Антопологическое описание для ИГЭ-1 не указано!";
            }
            else if (failNum == 2)
            {
                failTxt = "Данные для ИГЭ-1 не указаны или указаны неверно!";
            }

            FailWindow fail = new FailWindow(failTxt);
            fail.Show();
        }
    }
}
