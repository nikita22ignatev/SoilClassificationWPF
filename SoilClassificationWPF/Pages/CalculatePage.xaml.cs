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

        private void CalculateFirstEge(object sender, RoutedEventArgs e)
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
                        Calculation firstEge = new Calculation(Type1.SelectedIndex, h, 0, p, ps, w, wl, wp);

                        var firstEgeDict = new Dictionary<string, double>();
                        firstEgeDict = firstEge.CalculationVal();

                        Classification firstEgeClass = new Classification(Type1.SelectedIndex, firstEgeDict);

                        StringBuilder firstEgeOut = new StringBuilder();
                        firstEgeOut = firstEgeClass.ClassificationVal();
                        firstEgeOut.Append(".  ");
                        firstEgeOut.Append(GenerationOut(Type1.SelectedIndex, firstEgeDict));

                        Out1.Text = Convert.ToString(firstEgeOut);

                        UnlockInputSecondEge();
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

                        int.TryParse(Fract1_1.Text, out fract[0]) &&
                        int.TryParse(Fract1_2.Text, out fract[1]) &&
                        int.TryParse(Fract1_3.Text, out fract[2]) &&
                        int.TryParse(Fract1_4.Text, out fract[3]) &&
                        int.TryParse(Fract1_5.Text, out fract[4]) &&
                        int.TryParse(Fract1_6.Text, out fract[5]) &&
                        int.TryParse(Fract1_7.Text, out fract[6]))
                    {
                        Calculation firstEge = new Calculation(Type1.SelectedIndex, h, 0, p, ps, w, fract);

                        var firstEgeDict = new Dictionary<string, double>();
                        firstEgeDict = firstEge.CalculationVal();

                        Classification firstEgeClass = new Classification(Type1.SelectedIndex, firstEgeDict);

                        StringBuilder firstEgeOut = new StringBuilder();
                        firstEgeOut = firstEgeClass.ClassificationVal();
                        firstEgeOut.Append(".  ");
                        firstEgeOut.Append(GenerationOut(Type1.SelectedIndex, firstEgeDict));

                        Out1.Text = Convert.ToString(firstEgeOut);

                        UnlockInputSecondEge();
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

        private void CalculateSecondEge(object sender, RoutedEventArgs e)
        {
            if (Type2.SelectedIndex > -1)
            {
                double h = 0;
                double p = 0;
                double ps = 0;
                double w = 0;

                if (Type2.SelectedIndex != 2)
                {
                    double wl = 0;
                    double wp = 0;

                    if (Double.TryParse(H2.Text, out h) &&
                        Double.TryParse(P2.Text, out p) &&
                        Double.TryParse(Ps2.Text, out ps) &&
                        Double.TryParse(W2.Text, out w) &&
                        Double.TryParse(Wl2.Text, out wl) &&
                        Double.TryParse(Wp2.Text, out wp))
                    {
                        double hPrev = Convert.ToDouble(H1.Text) / 2;

                        Calculation secondEge = new Calculation(Type2.SelectedIndex, h, hPrev, p, ps, w, wl, wp);

                        var secondEgeDict = new Dictionary<string, double>();
                        secondEgeDict = secondEge.CalculationVal();

                        Classification secondEgeClass = new Classification(Type2.SelectedIndex, secondEgeDict);

                        StringBuilder secondEgeOut = new StringBuilder();
                        secondEgeOut = secondEgeClass.ClassificationVal();
                        secondEgeOut.Append(".  ");
                        secondEgeOut.Append(GenerationOut(Type2.SelectedIndex, secondEgeDict));

                        Out2.Text = Convert.ToString(secondEgeOut);

                        UnlockInputThirdEge();
                    }
                    else
                    {
                        OpenFailWindow(4);
                    }
                }
                else
                {
                    int[] fract = new int[7];

                    if (Double.TryParse(H2.Text, out h) &&
                        Double.TryParse(P2.Text, out p) &&
                        Double.TryParse(Ps2.Text, out ps) &&
                        Double.TryParse(W2.Text, out w) &&

                        int.TryParse(Fract2_1.Text, out fract[0]) &&
                        int.TryParse(Fract2_2.Text, out fract[1]) &&
                        int.TryParse(Fract2_3.Text, out fract[2]) &&
                        int.TryParse(Fract2_4.Text, out fract[3]) &&
                        int.TryParse(Fract2_5.Text, out fract[4]) &&
                        int.TryParse(Fract2_6.Text, out fract[5]) &&
                        int.TryParse(Fract2_7.Text, out fract[6]))
                    {
                        double hPrev = Convert.ToDouble(H1.Text) / 2;

                        Calculation secondEge = new Calculation(Type2.SelectedIndex, h, hPrev, p, ps, w, fract);

                        var secondEgeDict = new Dictionary<string, double>();
                        secondEgeDict = secondEge.CalculationVal();

                        Classification secondEgeClass = new Classification(Type2.SelectedIndex, secondEgeDict);

                        StringBuilder secondEgeOut = new StringBuilder();
                        secondEgeOut = secondEgeClass.ClassificationVal();
                        secondEgeOut.Append(".  ");
                        secondEgeOut.Append(GenerationOut(Type2.SelectedIndex, secondEgeDict));

                        Out2.Text = Convert.ToString(secondEgeOut);

                        UnlockInputThirdEge();
                    }
                    else
                    {
                        OpenFailWindow(4);
                    }
                }
            }
            else
            {
                OpenFailWindow(3);
            }
        }

        private void CalculateThirdEge(object sender, RoutedEventArgs e)
        {
            if (Type3.SelectedIndex > -1)
            {
                double h = 0;
                double p = 0;
                double ps = 0;
                double w = 0;

                if (Type3.SelectedIndex != 2)
                {
                    double wl = 0;
                    double wp = 0;

                    if (Double.TryParse(H3.Text, out h) &&
                        Double.TryParse(P3.Text, out p) &&
                        Double.TryParse(Ps3.Text, out ps) &&
                        Double.TryParse(W3.Text, out w) &&
                        Double.TryParse(Wl3.Text, out wl) &&
                        Double.TryParse(Wp3.Text, out wp))
                    {
                        double hPrev = Convert.ToDouble(H1.Text) / 2 + Convert.ToDouble(H2.Text) / 2;

                        Calculation thirdEge = new Calculation(Type3.SelectedIndex, h, hPrev, p, ps, w, wl, wp);

                        var thirdEgeDict = new Dictionary<string, double>();
                        thirdEgeDict = thirdEge.CalculationVal();

                        Classification thirdEgeClass = new Classification(Type3.SelectedIndex, thirdEgeDict);

                        StringBuilder thirdEgeOut = new StringBuilder();
                        thirdEgeOut = thirdEgeClass.ClassificationVal();
                        thirdEgeOut.Append(".  ");
                        thirdEgeOut.Append(GenerationOut(Type3.SelectedIndex, thirdEgeDict));

                        Out3.Text = Convert.ToString(thirdEgeOut);

                        UnlockInputFourthEge();
                    }
                    else
                    {
                        OpenFailWindow(6);
                    }
                }
                else
                {
                    int[] fract = new int[7];

                    if (Double.TryParse(H3.Text, out h) &&
                        Double.TryParse(P3.Text, out p) &&
                        Double.TryParse(Ps3.Text, out ps) &&
                        Double.TryParse(W3.Text, out w) &&

                        int.TryParse(Fract3_1.Text, out fract[0]) &&
                        int.TryParse(Fract3_2.Text, out fract[1]) &&
                        int.TryParse(Fract3_3.Text, out fract[2]) &&
                        int.TryParse(Fract3_4.Text, out fract[3]) &&
                        int.TryParse(Fract3_5.Text, out fract[4]) &&
                        int.TryParse(Fract3_6.Text, out fract[5]) &&
                        int.TryParse(Fract3_7.Text, out fract[6]))
                    {
                        double hPrev = Convert.ToDouble(H1.Text) / 2 + Convert.ToDouble(H2.Text) / 2;

                        Calculation thirdEge = new Calculation(Type3.SelectedIndex, h, hPrev, p, ps, w, fract);

                        var thirdEgeDict = new Dictionary<string, double>();
                        thirdEgeDict = thirdEge.CalculationVal();

                        Classification thirdEgeClass = new Classification(Type3.SelectedIndex, thirdEgeDict);

                        StringBuilder thirdEgeOut = new StringBuilder();
                        thirdEgeOut = thirdEgeClass.ClassificationVal();
                        thirdEgeOut.Append(".  ");
                        thirdEgeOut.Append(GenerationOut(Type3.SelectedIndex, thirdEgeDict));

                        Out3.Text = Convert.ToString(thirdEgeOut);

                        UnlockInputFourthEge();
                    }
                    else
                    {
                        OpenFailWindow(6);
                    }
                }
            }
            else
            {
                OpenFailWindow(5);
            }
        }

        private void CalculateFourthEge(object sender, RoutedEventArgs e)
        {
            if (Type4.SelectedIndex > -1)
            {
                double h = 0;
                double p = 0;
                double ps = 0;
                double w = 0;

                if (Type4.SelectedIndex != 2)
                {
                    double wl = 0;
                    double wp = 0;

                    if (Double.TryParse(H4.Text, out h) &&
                        Double.TryParse(P4.Text, out p) &&
                        Double.TryParse(Ps4.Text, out ps) &&
                        Double.TryParse(W4.Text, out w) &&
                        Double.TryParse(Wl4.Text, out wl) &&
                        Double.TryParse(Wp4.Text, out wp))
                    {
                        double hPrev = Convert.ToDouble(H1.Text) / 2 + Convert.ToDouble(H2.Text) / 2 + Convert.ToDouble(H3.Text) / 2;

                        Calculation fourthEge = new Calculation(Type4.SelectedIndex, h, hPrev, p, ps, w, wl, wp);

                        var fourthEgeDict = new Dictionary<string, double>();
                        fourthEgeDict = fourthEge.CalculationVal();

                        Classification fourthEgeClass = new Classification(Type4.SelectedIndex, fourthEgeDict);

                        StringBuilder fourthEgeOut = new StringBuilder();
                        fourthEgeOut = fourthEgeClass.ClassificationVal();
                        fourthEgeOut.Append(".  ");
                        fourthEgeOut.Append(GenerationOut(Type4.SelectedIndex, fourthEgeDict));

                        Out4.Text = Convert.ToString(fourthEgeOut);

                        UnlockInputFifthEge();
                    }
                    else
                    {
                        OpenFailWindow(8);
                    }
                }
                else
                {
                    int[] fract = new int[7];

                    if (Double.TryParse(H4.Text, out h) &&
                        Double.TryParse(P4.Text, out p) &&
                        Double.TryParse(Ps4.Text, out ps) &&
                        Double.TryParse(W4.Text, out w) &&

                        int.TryParse(Fract4_1.Text, out fract[0]) &&
                        int.TryParse(Fract4_2.Text, out fract[1]) &&
                        int.TryParse(Fract4_3.Text, out fract[2]) &&
                        int.TryParse(Fract4_4.Text, out fract[3]) &&
                        int.TryParse(Fract4_5.Text, out fract[4]) &&
                        int.TryParse(Fract4_6.Text, out fract[5]) &&
                        int.TryParse(Fract4_7.Text, out fract[6]))
                    {
                        double hPrev = Convert.ToDouble(H1.Text) / 2 + Convert.ToDouble(H2.Text) / 2 + Convert.ToDouble(H3.Text) / 2;

                        Calculation fourthEge = new Calculation(Type4.SelectedIndex, h, hPrev, p, ps, w, fract);

                        var fourthEgeDict = new Dictionary<string, double>();
                        fourthEgeDict = fourthEge.CalculationVal();

                        Classification fourthEgeClass = new Classification(Type4.SelectedIndex, fourthEgeDict);

                        StringBuilder fourthEgeOut = new StringBuilder();
                        fourthEgeOut = fourthEgeClass.ClassificationVal();
                        fourthEgeOut.Append(".  ");
                        fourthEgeOut.Append(GenerationOut(Type4.SelectedIndex, fourthEgeDict));

                        Out4.Text = Convert.ToString(fourthEgeOut);

                        UnlockInputFifthEge();
                    }
                    else
                    {
                        OpenFailWindow(8);
                    }
                }
            }
            else
            {
                OpenFailWindow(7);
            }
        }

        private void CalculateFifthEge(object sender, RoutedEventArgs e)
        {
            if (Type5.SelectedIndex > -1)
            {
                double h = 0;
                double p = 0;
                double ps = 0;
                double w = 0;

                if (Type5.SelectedIndex != 2)
                {
                    double wl = 0;
                    double wp = 0;

                    if (Double.TryParse(H5.Text, out h) &&
                        Double.TryParse(P5.Text, out p) &&
                        Double.TryParse(Ps5.Text, out ps) &&
                        Double.TryParse(W5.Text, out w) &&
                        Double.TryParse(Wl5.Text, out wl) &&
                        Double.TryParse(Wp5.Text, out wp))
                    {
                        double hPrev = Convert.ToDouble(H1.Text) / 2 + Convert.ToDouble(H2.Text) / 2 + Convert.ToDouble(H3.Text) / 2 + Convert.ToDouble(H4.Text) / 2;

                        Calculation fifthEge = new Calculation(Type5.SelectedIndex, h, hPrev, p, ps, w, wl, wp);

                        var fifthEgeDict = new Dictionary<string, double>();
                        fifthEgeDict = fifthEge.CalculationVal();

                        Classification fifthEgeClass = new Classification(Type5.SelectedIndex, fifthEgeDict);

                        StringBuilder fifthEgeOut = new StringBuilder();
                        fifthEgeOut = fifthEgeClass.ClassificationVal();
                        fifthEgeOut.Append(".  ");
                        fifthEgeOut.Append(GenerationOut(Type5.SelectedIndex, fifthEgeDict));

                        Out4.Text = Convert.ToString(fifthEgeOut);
                    }
                    else
                    {
                        OpenFailWindow(10);
                    }
                }
                else
                {
                    int[] fract = new int[7];

                    if (Double.TryParse(H5.Text, out h) &&
                        Double.TryParse(P5.Text, out p) &&
                        Double.TryParse(Ps5.Text, out ps) &&
                        Double.TryParse(W5.Text, out w) &&

                        int.TryParse(Fract5_1.Text, out fract[0]) &&
                        int.TryParse(Fract5_2.Text, out fract[1]) &&
                        int.TryParse(Fract5_3.Text, out fract[2]) &&
                        int.TryParse(Fract5_4.Text, out fract[3]) &&
                        int.TryParse(Fract5_5.Text, out fract[4]) &&
                        int.TryParse(Fract5_6.Text, out fract[5]) &&
                        int.TryParse(Fract5_7.Text, out fract[6]))
                    {
                        double hPrev = Convert.ToDouble(H1.Text) / 2 + Convert.ToDouble(H2.Text) / 2 + Convert.ToDouble(H3.Text) / 2 + Convert.ToDouble(H4.Text) / 2;

                        Calculation fifthEge = new Calculation(Type5.SelectedIndex, h, hPrev, p, ps, w, fract);

                        var fifthEgeDict = new Dictionary<string, double>();
                        fifthEgeDict = fifthEge.CalculationVal();

                        Classification fifthEgeClass = new Classification(Type5.SelectedIndex, fifthEgeDict);

                        StringBuilder fifthEgeOut = new StringBuilder();
                        fifthEgeOut = fifthEgeClass.ClassificationVal();
                        fifthEgeOut.Append(".  ");
                        fifthEgeOut.Append(GenerationOut(Type5.SelectedIndex, fifthEgeDict));

                        Out4.Text = Convert.ToString(fifthEgeOut);

                    }
                    else
                    {
                        OpenFailWindow(10);
                    }
                }
            }
            else
            {
                OpenFailWindow(9);
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
            else if (failNum == 3)
            {
                failTxt = "Антопологическое описание для ИГЭ-2 не указано!";
            }
            else if (failNum == 4)
            {
                failTxt = "Данные для ИГЭ-2 не указаны или указаны неверно!";
            }
            else if (failNum == 5)
            {
                failTxt = "Антопологическое описание для ИГЭ-3 не указано!";
            }
            else if (failNum == 6)
            {
                failTxt = "Данные для ИГЭ-3 не указаны или указаны неверно!";
            }
            else if (failNum == 7)
            {
                failTxt = "Антопологическое описание для ИГЭ-4 не указано!";
            }
            else if (failNum == 8)
            {
                failTxt = "Данные для ИГЭ-4 не указаны или указаны неверно!";
            }
            else if (failNum == 9)
            {
                failTxt = "Антопологическое описание для ИГЭ-5 не указано!";
            }
            else if (failNum == 10)
            {
                failTxt = "Данные для ИГЭ-5 не указаны или указаны неверно!";
            }

            MessageBox.Show(failTxt, "Упс, что-то пошло не так", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void UnlockInputSecondEge()
        {
            Type2.IsEnabled = true;
            H2.IsEnabled = true;
            P2.IsEnabled = true;
            Ps2.IsEnabled = true;
            W2.IsEnabled = true;
            Wl2.IsEnabled = true;
            Wp2.IsEnabled = true;
            Fract2_1.IsEnabled = true;
            Fract2_2.IsEnabled = true;
            Fract2_3.IsEnabled = true;
            Fract2_4.IsEnabled = true;
            Fract2_5.IsEnabled = true;
            Fract2_6.IsEnabled = true;
            Fract2_7.IsEnabled = true;
            CalculateBtn2.IsEnabled = true;
        }

        private void UnlockInputThirdEge()
        {
            Type3.IsEnabled = true;
            H3.IsEnabled = true;
            P3.IsEnabled = true;
            Ps3.IsEnabled = true;
            W3.IsEnabled = true;
            Wl3.IsEnabled = true;
            Wp3.IsEnabled = true;
            Fract3_1.IsEnabled = true;
            Fract3_2.IsEnabled = true;
            Fract3_3.IsEnabled = true;
            Fract3_4.IsEnabled = true;
            Fract3_5.IsEnabled = true;
            Fract3_6.IsEnabled = true;
            Fract3_7.IsEnabled = true;
            CalculateBtn3.IsEnabled = true;
        }

        private void UnlockInputFourthEge()
        {
            Type4.IsEnabled = true;
            H4.IsEnabled = true;
            P4.IsEnabled = true;
            Ps4.IsEnabled = true;
            W4.IsEnabled = true;
            Wl4.IsEnabled = true;
            Wp4.IsEnabled = true;
            Fract4_1.IsEnabled = true;
            Fract4_2.IsEnabled = true;
            Fract4_3.IsEnabled = true;
            Fract4_4.IsEnabled = true;
            Fract4_5.IsEnabled = true;
            Fract4_6.IsEnabled = true;
            Fract4_7.IsEnabled = true;
            CalculateBtn4.IsEnabled = true;
        }

        private void UnlockInputFifthEge()
        {
            Type5.IsEnabled = true;
            H5.IsEnabled = true;
            P5.IsEnabled = true;
            Ps5.IsEnabled = true;
            W5.IsEnabled = true;
            Wl5.IsEnabled = true;
            Wp5.IsEnabled = true;
            Fract5_1.IsEnabled = true;
            Fract5_2.IsEnabled = true;
            Fract5_3.IsEnabled = true;
            Fract5_4.IsEnabled = true;
            Fract5_5.IsEnabled = true;
            Fract5_6.IsEnabled = true;
            Fract5_7.IsEnabled = true;
            CalculateBtn5.IsEnabled = true;
        }
    }
}
