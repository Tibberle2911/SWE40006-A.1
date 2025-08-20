using System;
using System.Windows.Forms;
using MathLib;
using LoggingLib;

namespace CalculatorApp
{
    public class SimpleCalculator : Form
    {
        TextBox txtA = new TextBox { Left = 16, Top = 16, Width = 120 };
        TextBox txtB = new TextBox { Left = 152, Top = 16, Width = 120 };
        ComboBox cmbOp = new ComboBox { Left = 16, Top = 56, Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
        Button btnCalc = new Button { Left = 152, Top = 56, Width = 120, Text = "Calculate" };
        Label lblResult = new Label { Left = 16, Top = 96, Width = 300, AutoSize = true };

        public SimpleCalculator()
        {
            Text = "CalculatorApp (.NET 4.6.2)";
            Controls.AddRange(new Control[] { txtA, txtB, cmbOp, btnCalc, lblResult });
            cmbOp.Items.AddRange(new object[] { "+", "-", "×", "÷" });
            cmbOp.SelectedIndex = 0;

            btnCalc.Click += (s, e) =>
            {
                try
                {
                    double a = double.Parse(txtA.Text);
                    double b = double.Parse(txtB.Text);
                    string op = cmbOp.SelectedItem.ToString();
                    double res = op == "+" ? Operations.Add(a, b)
                              : op == "-" ? Operations.Subtract(a, b)
                              : op == "×" ? Operations.Multiply(a, b)
                              : Operations.Divide(a, b);
                    lblResult.Text = "Result: " + res;
                    AppLogger.Info($"Calc {a} {op} {b} = {res}");
                }
                catch (Exception ex)
                {
                    lblResult.Text = "Error: " + ex.Message;
                    AppLogger.Error(ex.ToString());
                }
            };
        }
    }
}
