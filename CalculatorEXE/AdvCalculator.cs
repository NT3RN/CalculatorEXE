namespace CalculatorEXE
{
     public partial class AdvCalculator : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public AdvCalculator()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if ((txtBox.Text == "0") || (isOperationPerformed))
                {
                    txtBox.Clear();
                }
                isOperationPerformed = false;

                if (btn.Text == "." && txtBox.Text.Contains("."))
                {
                    return;
                }

                txtBox.Text += btn.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while clicking button");
            }
        }

        private void operationBtnClick(object sender, EventArgs e)
        {
            try
            {
                Button aBtn = (Button)sender;
                if (result != 0 && !isOperationPerformed)
                {
                    equalBtnClick(this, EventArgs.Empty);
                }
                operation = aBtn.Text;
                result = double.Parse(txtBox.Text);
                isOperationPerformed = true;
                lblFn.Text = txtBox.Text;
                lblSn.Text = operation;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred with operation");
            }
        }

        private void clearBtnClick(object sender, EventArgs e)
        {
            try
            {
                txtBox.Text = "0";
                result = 0;
                operation = "";
                lblFn.Text = "";
                lblSn.Text = "";
                isOperationPerformed = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while clearing");
            }
        }

        private void equalBtnClick(object sender, EventArgs e)
        {
            try
            {
                switch (operation)
                {
                    case "+":
                        txtBox.Text = (result + double.Parse(txtBox.Text)).ToString();
                        break;
                    case "-":
                        txtBox.Text = (result - double.Parse(txtBox.Text)).ToString();
                        break;
                    case "*":
                        txtBox.Text = (result * double.Parse(txtBox.Text)).ToString();
                        break;
                    case "/":
                        txtBox.Text = (result / double.Parse(txtBox.Text)).ToString();
                        break;
                    default:
                        break;
                }
                result = double.Parse(txtBox.Text);
                operation = "";
                lblFn.Text = "";
                lblSn.Text = "";
                isOperationPerformed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred clicking equal");
            }
        }
    }
}
