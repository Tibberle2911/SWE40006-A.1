using System;
using System.Drawing;
using System.Windows.Forms;

// Alias to avoid ambiguity with Label
using WinFormsLabel = System.Windows.Forms.Label;

namespace YourNamespace
{
    public class SimpleCalculator : Form
    {
        TextBox txtNum1;
        TextBox txtNum2;
        ComboBox cmbOperation;
        Button btnCalculate;
        WinFormsLabel lblResult;

        public SimpleCalculator()
        {
            Text = "Simple Calculator";
            Size = new Size(300, 250);
            StartPosition = FormStartPosition.CenterScreen;

            WinFormsLabel lbl1 = new WinFormsLabel() { Text = "Number 1:", Location = new Point(10, 20), AutoSize = true };
            txtNum1 = new TextBox() { Location = new Point(100, 20), Width = 150 };

            WinFormsLabel lbl2 = new WinFormsLabel() { Text = "Number 2:", Location = new Point(10, 60), AutoSize = true };
            txtNum2 = new TextBox() { Location = new Point(100, 60), Width = 150 };

            WinFormsLabel lblOp = new WinFormsLabel() { Text = "Operation:", Location = new Point(10, 100), AutoSize = true };
            cmbOperation = new ComboBox() { Location = new Point(100, 100), Width = 150 };
            cmbOperation.Items.AddRange(new string[] { "+", "-", "*", "/" });
            cmbOperation.SelectedIndex = 0;

            btnCalculate = new Button() { Text = "Calculate", Location = new Point(100, 140), Width = 150 };
            btnCalculate.Click += BtnCalculate_Click;

            lblResult = new WinFormsLabel() { Text = "Result will appear here", Location = new Point(10, 180), AutoSize = true, ForeColor = Color.Blue };

            Controls.AddRange(new Control[] { lbl1, txtNum1, lbl2, txtNum2, lblOp, cmbOperation, btnCalculate, lblResult });
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNum1.Text, out double num1) || !double.TryParse(txtNum2.Text, out double num2))
            {
                MessageBox.Show("Please enter valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string op = cmbOperation.SelectedItem.ToString();
            double result = 0;

            switch (op)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.", "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    result = num1 / num2;
                    break;
            }

            lblResult.Text = $"Result: {result}";
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleCalculator());
        }
    }
}
