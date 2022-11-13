using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trpz_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region SettingsForm   
        private Point currentPosition = new Point(0, 0);

        // button close application
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // form move
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - currentPosition.X;
                Top += e.Y - currentPosition.Y;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            currentPosition = new Point(e.X, e.Y);
        }
        #endregion
        private bool isPoint = false;
        private bool isNum2 = false;

        private string num1 = null;
        private string num2 = null;

        private string currentOperation = "";

        private void SetNum(string txt)
        {
            if (isNum2)
            {
                num2 = txt;
                Textresult.Text = num2;
            }
            else
            {
                num1 = txt;
                Textresult.Text = num1;
            }
        }
        private void AddNum(string txt)
        {
            if (isNum2)
            {
                num2 += txt;
                Textresult.Text = num2;
            }
            else
            {
                num1 += txt;
                Textresult.Text = num1;
            }
        }
        private void buttonNumberClick(object obj, EventArgs e)
        {
            var txt = ((Button)obj).Text;
            {
                if (isPoint && txt == ",") { return; }
                if (txt == ",") { isPoint = true; }
            }
            if (txt == "+/-")
            {
                if (Textresult.Text.Length > 0)
                    if (Textresult.Text[0] == '-')
                    {
                        Textresult.Text = Textresult.Text.Substring(1, Textresult.Text.Length - 1);
                    }
                    else
                    {
                        Textresult.Text = "-" + Textresult.Text;
                    }
                SetNum(Textresult.Text);
                return;
            }
            AddNum(txt);
        }
        private void buttonOperationClick(object obj, EventArgs e)
        {
            if (num1 == null) { if (Textresult.Text.Length > 0) num1 = Textresult.Text; else return; }
            isNum2 = true;
            currentOperation = ((Button)obj).Text;
            SetResult(currentOperation);
        }
        private void SetResult(string operation)
        {
            string result = null;

            switch (operation)
            {
                case "+": { result = MathOperation.Add(num1, num2); break; }
                case "-": { result = MathOperation.Sub(num1, num2); break; }
                case "×": { result = MathOperation.Mul(num1, num2); break; }
                case "÷": { result = MathOperation.Dev(num1, num2); break; }
                case "%": { result = MathOperation.Perc(num1, num2); break; }
                case "√": { result = MathOperation.Sqrt(num1); isNum2 = false; break; }
                case "x²": { result = MathOperation.Pow(num1); isNum2 = false; break; }
                case "1/X": { result = MathOperation.OneDev(num1); isNum2 = false; break; }
                case "Sin": { result = MathOperation.Sin(num1); isNum2 = false; break; }
                case "Cos": { result = MathOperation.Cos(num1); isNum2 = false; break; }
                case "Tg": { result = MathOperation.Tg(num1); isNum2 = false; break; }
                case "Ctg": { result = MathOperation.Ctg(num1); isNum2 = false; break; }
                case "Round": { result = MathOperation.Round(num1); isNum2 = false; break; }
                case "Log10": { result = MathOperation.Log10(num1); isNum2 = false; break; }
                default: break;
            }
            OutputResult(result, operation);
            if(isNum2) { if (result != null) num1 = result; } else { num1 = null; }
            isPoint = false;
        }
        private void OutputResult(string result, string operation)
        { 
            switch (operation)
            {
                case "√": { if (num1 != null) Text.Text = "√" + num1 + " = ";break; }
                case "x²": { if (num1 != null) Text.Text = "²" + num1 + " = "; break; }
                case "1/X": { if (num1 != null) Text.Text = "1/" + num1 + " = "; break; }
                case "Sin": { if (num1 != null) Text.Text = "Sin(" + num1 + ") = "; break; }
                case "Cos": { if (num1 != null) Text.Text = "Cos(" + num1 + ") = "; break; }
                case "Tg": { if (num1 != null) Text.Text = "Tg(" + num1 + ") = "; break; }
                case "Ctg": { if (num1 != null) Text.Text = "Ctg(" + num1 + ") = "; break; }
                case "Round": { if (num1 != null) Text.Text = "(" + num1 + ") = "; break; }
                case "Log10": { if (num1 != null) Text.Text = "Log10(" + num1 + ") = "; break; }
                default:
                    {
                        if(num2 != null)
                        {
                            Text.Text = num1 + " " + operation + " " + num2 + " = ";
                            break;
                        }
                        else
                        {
                            if(num1 != null)
                            {
                                Text.Text = num1 + " " + operation + " " ;
                                break;
                            }
                        }
                    }
                    break;
            }
            num2 = null;
            if (result != null)
            {
                Textresult.Text = result;
            }
        }
        private void buttonClear(object obj, EventArgs e)
        {
            Textresult.Text = "";
            Text.Text = "";
            isNum2 = false;
            currentOperation = null;
            num1 = null;
            num2 = null;
            isPoint = false;
        }
        private void buttonResultClick(object obj, EventArgs e)
        {
            SetResult(currentOperation);
            isNum2 = false;
            num1 = null;
            num2 = null;
        }
        private void buttonResetNumber(object obj, EventArgs e)
        {
            if(Textresult.Text.Length<=0) { return; }
            Textresult.Text = Textresult.Text.Substring(0, Textresult.Text.Length - 1);
            SetNum(Textresult.Text);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
