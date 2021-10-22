using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_GUI_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            try
            {
                
                double x0 = Double.Parse(textBoxX_0.Text);
                double x1 = Double.Parse(textBoxX.Text);
                double y0 = Double.Parse(textBoxY_0.Text);
                int n = Int32.Parse(textBoxN.Text);
                int n_max = Int32.Parse(textBoxNmax.Text);

                double[] pointsOfDiscontinuty = new double[2];
                double pointOfDiscontinuty = CalculationsForExact.Get_Point_Of_Discontinuty(x0,y0);
                double esConst = CalculationsForExact.Get_Constant(x0, y0);
                if (0 < pointOfDiscontinuty)
                {
                    pointsOfDiscontinuty[0] = 0;
                    pointsOfDiscontinuty[1] = pointOfDiscontinuty;
                } else {
                    pointsOfDiscontinuty[0] = pointOfDiscontinuty;
                    pointsOfDiscontinuty[1] = 0;
                }


                Grid totalGrid = new Grid(x0,x1,n);
                int counter1 = 0;
                int counter2 = 0;
                int counter3 = 0;
                int i = 0;
                int size = totalGrid.x.Length;
                while (i < totalGrid.x.Length && totalGrid.x[i] <= pointsOfDiscontinuty[0] && totalGrid.x[i] <= totalGrid.x[size - 1])
                {
                    counter1++;
                    i++;
                }

                while (i < totalGrid.x.Length && totalGrid.x[i] <= pointsOfDiscontinuty[1] && totalGrid.x[i] <= totalGrid.x[size-1])
                {
                    counter2++;
                    i++;
                }

                while (i < totalGrid.x.Length && totalGrid.x[i] <= totalGrid.x[size - 1])
                {
                    counter3++;
                    i++;
                }

                if (counter1 > 1)
                {
                    //int range = counter1 - 1;
                    int range = n;
                    Exact_Solution exact1 = new Exact_Solution(x0,totalGrid.x[counter1-1], y0, range, esConst);
                    Euler_Method em1 = new Euler_Method(x0, totalGrid.x[counter1 - 1], y0, range);
                    Improved_Euler_Method iem1 = new Improved_Euler_Method(x0, totalGrid.x[counter1 - 1], y0, range);
                    Rung_Kutta_Method rkm1 = new Rung_Kutta_Method(x0, totalGrid.x[counter1 - 1], y0, range);

                    Numerical_Method_Error eme1 = new Numerical_Method_Error(x0, totalGrid.x[counter1 - 1], range, exact1, em1);
                    Numerical_Method_Error ieme1 = new Numerical_Method_Error(x0, totalGrid.x[counter1 - 1], range, exact1, iem1);
                    Numerical_Method_Error rkme1 = new Numerical_Method_Error(x0, totalGrid.x[counter1 - 1], range, exact1, rkm1);

                    chart1.Series[0].Points.DataBindXY(em1.x, em1.y);
                    chart1.Series[3].Points.DataBindXY(iem1.x, iem1.y);
                    chart1.Series[6].Points.DataBindXY(rkm1.x, rkm1.y);
                    chart1.Series[9].Points.DataBindXY(exact1.x, exact1.y);

                    chart2.Series[0].Points.DataBindXY(eme1.x, eme1.y);
                    chart2.Series[3].Points.DataBindXY(ieme1.x, ieme1.y);
                    chart2.Series[6].Points.DataBindXY(rkme1.x, rkme1.y);
                } else
                {
                    double[] emptyX = new double[0];
                    double[] emptyY = new double[0];
                    chart1.Series[0].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[3].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[6].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[9].Points.DataBindXY(emptyX, emptyY);

                    chart2.Series[0].Points.DataBindXY(emptyX, emptyY);
                    chart2.Series[3].Points.DataBindXY(emptyX, emptyY);
                    chart2.Series[6].Points.DataBindXY(emptyX, emptyY);
                }

                if (counter2 > 1)
                {
                    int beginIndex;
                    int endIndex;
                    int range;
                    if (counter1 > 0)
                    {
                        beginIndex = counter1 + 1;
                        endIndex = counter1 + counter2 - 1;
                        range = counter2 - 2;
                    } else
                    {
                        beginIndex = counter1;
                        endIndex = counter1 + counter2 - 1;
                        range = counter2 - 1;
                    }
                    //range = n;

                    double y1 = CalculationsForExact.Get_Value_At_Point(x0, y0, totalGrid.x[beginIndex]);
                    Exact_Solution exact2 = new Exact_Solution(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1 , range, esConst);
                    Euler_Method em2 = new Euler_Method(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range);
                    Improved_Euler_Method iem2 = new Improved_Euler_Method(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range);
                    Rung_Kutta_Method rkm2 = new Rung_Kutta_Method(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range);

                    Numerical_Method_Error eme2 = new Numerical_Method_Error(totalGrid.x[beginIndex], totalGrid.x[endIndex], range, exact2, em2);
                    Numerical_Method_Error ieme2 = new Numerical_Method_Error(totalGrid.x[beginIndex], totalGrid.x[endIndex], range, exact2, iem2);
                    Numerical_Method_Error rkme2 = new Numerical_Method_Error(totalGrid.x[beginIndex], totalGrid.x[endIndex], range, exact2, rkm2);

                    chart1.Series[1].Points.DataBindXY(em2.x, em2.y);
                    chart1.Series[4].Points.DataBindXY(iem2.x, iem2.y);
                    chart1.Series[7].Points.DataBindXY(rkm2.x, rkm2.y);
                    chart1.Series[10].Points.DataBindXY(exact2.x, exact2.y);

                    chart2.Series[1].Points.DataBindXY(eme2.x, eme2.y);
                    chart2.Series[4].Points.DataBindXY(ieme2.x, ieme2.y);
                    chart2.Series[7].Points.DataBindXY(rkme2.x, rkme2.y);
                } else
                {
                    double[] emptyX = new double[0];
                    double[] emptyY = new double[0];
                    chart1.Series[1].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[4].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[7].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[10].Points.DataBindXY(emptyX, emptyY);

                    chart2.Series[1].Points.DataBindXY(emptyX, emptyY);
                    chart2.Series[4].Points.DataBindXY(emptyX, emptyY);
                    chart2.Series[7].Points.DataBindXY(emptyX, emptyY);
                }

                if (counter3 > 1)
                {
                    int beginIndex;
                    int endIndex;
                    int range;
                    if (counter2 > 0)
                    {
                        beginIndex = counter1 + counter2 + 1;
                        endIndex = counter1 + counter2 + counter3 - 1;
                        range = counter3 - 2;
                    }
                    else
                    {
                        beginIndex = counter1 + counter2;
                        endIndex = counter1 + counter2 + counter3 - 1;
                        range = counter3 - 1;
                    }
                    //range = n;

                    double y1 = CalculationsForExact.Get_Value_At_Point(x0, y0, totalGrid.x[beginIndex]);
                    Exact_Solution exact3 = new Exact_Solution(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range, esConst);
                    Euler_Method em3 = new Euler_Method(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range);
                    Improved_Euler_Method iem3 = new Improved_Euler_Method(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range);
                    Rung_Kutta_Method rkm3 = new Rung_Kutta_Method(totalGrid.x[beginIndex], totalGrid.x[endIndex], y1, range);

                    Numerical_Method_Error eme3 = new Numerical_Method_Error(totalGrid.x[beginIndex], totalGrid.x[endIndex], range, exact3, em3);
                    Numerical_Method_Error ieme3 = new Numerical_Method_Error(totalGrid.x[beginIndex], totalGrid.x[endIndex], range, exact3, iem3);
                    Numerical_Method_Error rkme3 = new Numerical_Method_Error(totalGrid.x[beginIndex], totalGrid.x[endIndex], range, exact3, rkm3);

                    chart1.Series[2].Points.DataBindXY(em3.x, em3.y);
                    chart1.Series[5].Points.DataBindXY(iem3.x, iem3.y);
                    chart1.Series[8].Points.DataBindXY(rkm3.x, rkm3.y);
                    chart1.Series[11].Points.DataBindXY(exact3.x, exact3.y);

                    chart2.Series[2].Points.DataBindXY(eme3.x, eme3.y);
                    chart2.Series[5].Points.DataBindXY(ieme3.x, ieme3.y);
                    chart2.Series[8].Points.DataBindXY(rkme3.x, rkme3.y);
                } else
                {
                    double[] emptyX = new double[0];
                    double[] emptyY = new double[0];
                    chart1.Series[2].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[5].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[8].Points.DataBindXY(emptyX, emptyY);
                    chart1.Series[11].Points.DataBindXY(emptyX, emptyY);

                    chart2.Series[2].Points.DataBindXY(emptyX, emptyY);
                    chart2.Series[5].Points.DataBindXY(emptyX, emptyY);
                    chart2.Series[8].Points.DataBindXY(emptyX, emptyY);
                }

                Euler_Method_Max_Error emme = new Euler_Method_Max_Error(x0, x1, y0, n, n_max);
                Improved_Euler_Method_Max_Error iemme = new Improved_Euler_Method_Max_Error(x0, x1, y0, n, n_max);
                Rung_Kutta_Method_Max_Error rkmme = new Rung_Kutta_Method_Max_Error(x0, x1, y0, n, n_max);
                chart3.Series[0].Points.DataBindXY(emme.x, emme.y);
                chart3.Series[1].Points.DataBindXY(iemme.x, iemme.y);
                chart3.Series[2].Points.DataBindXY(rkmme.x, rkmme.y);

                chart1.ChartAreas[0].AxisX.Minimum = x0;
                chart1.ChartAreas[0].AxisX.Maximum = x1;
                chart2.ChartAreas[0].AxisX.Minimum = x0;
                chart2.ChartAreas[0].AxisX.Maximum = x1;
                chart3.ChartAreas[0].AxisX.Minimum = n;
                chart3.ChartAreas[0].AxisX.Maximum = n_max;
            }
            catch
            {
                MessageBox.Show("Wrong Data");
            }
            
        }

        private void checkBoxEM_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = checkBoxEM.Checked;
            chart2.Series[0].Enabled = checkBoxEM.Checked;
            chart3.Series[0].Enabled = checkBoxEM.Checked;

            chart1.Series[1].Enabled = checkBoxEM.Checked;
            chart2.Series[1].Enabled = checkBoxEM.Checked;

            chart1.Series[2].Enabled = checkBoxEM.Checked;
            chart2.Series[2].Enabled = checkBoxEM.Checked;
            buttonPlot_Click(sender, e);
        }

        private void checkBoxIEM_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[3].Enabled = checkBoxIEM.Checked;
            chart2.Series[3].Enabled = checkBoxIEM.Checked;
            chart3.Series[1].Enabled = checkBoxIEM.Checked;

            chart1.Series[4].Enabled = checkBoxIEM.Checked;
            chart2.Series[4].Enabled = checkBoxIEM.Checked;

            chart1.Series[5].Enabled = checkBoxIEM.Checked;
            chart2.Series[5].Enabled = checkBoxIEM.Checked;
            buttonPlot_Click(sender, e);
        }

        private void checkBoxRKM_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[6].Enabled = checkBoxRKM.Checked;
            chart2.Series[6].Enabled = checkBoxRKM.Checked;
            chart3.Series[2].Enabled = checkBoxRKM.Checked;

            chart1.Series[7].Enabled = checkBoxRKM.Checked;
            chart2.Series[7].Enabled = checkBoxRKM.Checked;

            chart1.Series[8].Enabled = checkBoxRKM.Checked;
            chart2.Series[8].Enabled = checkBoxRKM.Checked;
            buttonPlot_Click(sender, e);
        }

        private void checkBoxExact_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[9].Enabled = checkBoxExact.Checked;
            chart1.Series[10].Enabled = checkBoxExact.Checked;
            chart1.Series[11].Enabled = checkBoxExact.Checked;
            buttonPlot_Click(sender, e);
        }

        private void buttonNext1_2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            checkBoxExact.Visible = false;
            buttonPrev2_1.Visible = true;
            buttonNext2_3.Visible = true;
            buttonNext1_2.Visible = false;
        }

        private void buttonPrevious2_1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            checkBoxExact.Visible = true;
            buttonPrev2_1.Visible = false;
            buttonNext2_3.Visible = false;
            buttonNext1_2.Visible = true;
        }

        private void buttonNext2_3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            buttonPrev2_1.Visible = false;
            buttonNext2_3.Visible = false;
            buttonPrevious3_2.Visible = true;
            textBoxNmax.Visible = true;
            labelNmax.Visible = true;
        }

        private void buttonPrevious3_2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            buttonPrev2_1.Visible = true;
            buttonNext2_3.Visible = true;
            buttonPrevious3_2.Visible = false;
            textBoxNmax.Visible = false;
            labelNmax.Visible = false;
        }
    }
}
