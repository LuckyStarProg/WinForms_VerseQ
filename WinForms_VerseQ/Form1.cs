using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_VerseQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
            //label1.Tag=Keys.Shift;
            label2.Tag = Keys.D1;
            label3.Tag = Keys.D2;
            label4.Tag = Keys.Q;
            label5.Tag = Keys.A;
            label6.Tag = Keys.Z;
            label7.Tag = Keys.D3;
            label8.Tag = Keys.D4;
            label9.Tag = Keys.W;
            label10.Tag = Keys.E;
            label11.Tag = Keys.S;
            label12.Tag = Keys.D;
            label13.Tag = Keys.X;
            label14.Tag = Keys.C;
            label15.Tag = Keys.D5;
            label16.Tag = Keys.D6;
            label17.Tag = Keys.R;
            label18.Tag = Keys.T;
            label19.Tag = Keys.F;
            label20.Tag = Keys.G;
            label21.Tag = Keys.V;
            label22.Tag = Keys.B;
            label23.Tag = Keys.D7;
            label24.Tag = Keys.D8;
            label25.Tag = Keys.Y;
            label26.Tag = Keys.U;
            label27.Tag = Keys.H;
            label28.Tag = Keys.J;
            label29.Tag = Keys.N;
            label30.Tag = Keys.M;
            label31.Tag = Keys.D9;
            label32.Tag = Keys.D0;
            label33.Tag = Keys.I;
            label34.Tag = Keys.K;
            label35.Tag = Keys.Oemcomma;
            label36.Tag = Keys.O;
            label37.Tag = Keys.P;
            label38.Tag = Keys.OemOpenBrackets;
            label39.Tag = Keys.OemCloseBrackets;
            label40.Tag = Keys.L;
            label41.Tag = Keys.OemSemicolon;
            label42.Tag = Keys.Oem3;
            label43.Tag = Keys.OemPeriod;
            Shift.Tag = Keys.Shift;
            label45.Tag = Keys.OemMinus;
            label46.Tag = Keys.Oemplus;
            label47.Tag = Keys.Space;
            textToType = new Label[maxCount];
            int count = 15;
            //Random rand = new Random();
            for (int i = 0; i < maxCount; ++i)
            {
                textToType[i] = new Label();
                // textToType[i].Text = charsToType[rand.Next(0, charsToType.Length)].ToString();
                textToType[i].Location = new Point(count, 15);
                textToType[i].Font = new System.Drawing.Font("Consolas", 13F);
                textToType[i].Visible = true;
                textToType[i].AutoSize = false;
                textToType[i].TextAlign = ContentAlignment.MiddleCenter;
                textToType[i].Size = new Size(12, 20);
                textToType[i].Tag = new Keys();
                count += 12;
                Controls.Add(textToType[i]);
            }
            textTyped = new Label[maxCount];
            count = 15;
            for (int i = 0; i < maxCount; ++i)
            {
                textTyped[i] = new Label();
                textTyped[i].Location = new Point(count, 35);
                textTyped[i].Font = new System.Drawing.Font("Consolas", 13F);
                textTyped[i].Visible = false;
                textTyped[i].AutoSize = false;
                textTyped[i].TextAlign = ContentAlignment.MiddleCenter;
                textTyped[i].Size = new Size(12, 20);
                textTyped[i].Tag = new Keys();
                count += 12;
                Controls.Add(textTyped[i]);
            }
            count = 0;
            LowBound = new string[46];
            Control.ControlCollection keyBord = Controls;
            foreach (Control temp in keyBord)
            {
                Label tempLabel = temp as Label;
                if (tempLabel != null && tempLabel.Name.Contains("label"))
                {
                    LowBound[count++] = tempLabel.Text;
                }
            }
            
        }
        private string[] LowBound;
        private Label[] textTyped;
        private Label[] textToType;
        //private readonly string fixedString = "";
        private int index = 0;
        private bool startFlag=true;
        private int errors=0;
        private double symbols = 0;
        private double symbolsPerSecond = 0;
        private double seconds = 0;
        private int maxCount = 47;
        private char[] charsToType;
        private string rusAlfabet = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
        private void KeyDownMethod(KeyEventArgs e)
        {
            Control.ControlCollection keyBord = Controls;
            //Label label;
            if (Keys.ShiftKey == e.KeyCode)
            {
                foreach (Control temp in keyBord)
                {
                    Label tempLabel = temp as Label;
                    if (tempLabel != null && tempLabel.Name.Contains("label"))
                    {
                        tempLabel.Text = tempLabel.Text.ToUpperInvariant();
                    }
                }
                label2.Text = "!";
                label3.Text = "\"";
                label7.Text = "№";
                label8.Text = "%";
                label15.Text = ":";
                label16.Text = ",";
                label23.Text = ".";
                label24.Text = ";";
                label31.Text = "(";
                label32.Text = ")";
                label45.Text = "_";
                label46.Text = "+";
                Shift.BackColor = Color.FromArgb(100, Shift.BackColor.R, Shift.BackColor.G, Shift.BackColor.B);
            }
            foreach (Control temp in keyBord)
            {
                Label tempLabel = temp as Label;
                if (tempLabel != null && tempLabel.Name.Contains("label") && ((Keys)tempLabel.Tag) == e.KeyCode)
                {
                    //label = tempLabel;
                    tempLabel.BackColor = Color.FromArgb(100, tempLabel.BackColor.R, tempLabel.BackColor.G, tempLabel.BackColor.B);
                    break;
                }
            }
        }
        private void KeyUpMethod(KeyEventArgs e)
        {
            Control.ControlCollection keyBord = Controls;
            //Label label;
            if (Keys.ShiftKey == e.KeyCode)
            {
                int count = 0;
                foreach (Control temp in keyBord)
                {
                    Label tempLabel = temp as Label;
                    if (tempLabel != null && tempLabel.Name.Contains("label"))
                    {
                        tempLabel.Text = LowBound[count++];
                    }
                }
                Shift.BackColor = Color.FromArgb(255, Shift.BackColor.R, Shift.BackColor.G, Shift.BackColor.B);
            }
            foreach (Control temp in keyBord)
            {
                Label tempLabel = temp as Label;

                if (tempLabel != null && tempLabel.Name.Contains("label") && ((Keys)tempLabel.Tag) == e.KeyCode)
                {
                    //label = tempLabel;
                    tempLabel.BackColor = Color.FromArgb(255, tempLabel.BackColor.R, tempLabel.BackColor.G, tempLabel.BackColor.B);
                    if (!startFlag)
                    {
                        textTyped[index].Visible = true;
                        if (tempLabel.Text == textToType[index].Text)
                        {
                            textTyped[index].Text = tempLabel.Text;
                            textTyped[index].BackColor = Color.Blue;
                            textToType[index].BackColor = Color.Blue;
                            ++symbols;
                            if (index + 1 < textToType.Length)
                            {
                                textToType[index + 1].BackColor = Color.FromArgb(100, Color.Blue.R, Color.Blue.G, Color.Blue.B);
                            }
                            if (index + 1 == textToType.Length)
                            {
                                timer1.Stop();
                                symbolsPerSecond = symbols / seconds;
                                startFlag = true;
                                StartButton.Enabled = false;
                                for (int i = 0; i < textTyped.Length; ++i)
                                {
                                    textTyped[i].Visible = false;
                                    textToType[i].BackColor = Color.FromArgb(255, 240, 240, 240);
                                }
                                CloseButton.Enabled = true;
                                MessageBox.Show($"Speed: {symbolsPerSecond:0.00} char/sec\nErrors: {errors}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                CreateTextToType();
                            }
                        }
                        else
                        {
                            textTyped[index].Text = tempLabel.Text;
                            textTyped[index].BackColor = Color.Red;
                            --index;
                            ++errors;
                        }
                        ++index;
                    }
                    break;
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownMethod(e);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUpMethod(e);
        }
        private void AddNums()
        {
            int temp = charsToType.Length;
            char nal = '0';
            Array.Resize(ref charsToType, charsToType.Length + 10);
            for (int i = temp; i < charsToType.Length; ++i)
            {
                charsToType[i] = nal++;
            }
        }
        private void AddPunctuation()
        {
            int temp = charsToType.Length;
            Array.Resize(ref charsToType, charsToType.Length + 14);
            charsToType[temp++] = '-';
            charsToType[temp++] = '=';
            charsToType[temp++] = '!';
            charsToType[temp++] = '"';
            charsToType[temp++] = '№';
            charsToType[temp++] = '%';
            charsToType[temp++] = ':';
            charsToType[temp++] = ',';
            charsToType[temp++] = '.';
            charsToType[temp++] = ';';
            charsToType[temp++] = '(';
            charsToType[temp++] = ')';
            charsToType[temp++] = '_';
            charsToType[temp++] = '+';
            // charsToType[i] = nal++;
        }
        private void AddSpase()
        {
            int temp = charsToType.Length;
            Array.Resize(ref charsToType, charsToType.Length + 1);
            charsToType[temp] = ' ';
        }
        private void CreateTextToType()
        {
            Random rand = new Random();
            int temp;
            for (int i = 0; i < textToType.Length; ++i)
            {
                temp = rand.Next(0, charsToType.Length);
                if (charsToType[temp] == ' ' && i>0 && textToType[i - 1].Text == ' '.ToString())
                {
                    --i;
                    continue;
                }
                textToType[i].Text = charsToType[temp].ToString();
                textToType[i].Visible = true;
            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            charsToType = new char[(int)numericAlfabet.Value];
            Random temp = new Random();
            for (int i = 0; i < charsToType.Length; ++i)
            {    
                int num = temp.Next(0, rusAlfabet.Length-1);
                if (charsToType.Contains(rusAlfabet[num]))
                {
                    continue;
                }
                charsToType[i] = rusAlfabet[num];
            }
            AddSpase();
            if (checkNumBox.CheckState == CheckState.Checked)
            {
                AddNums();
            }
            if (checkSymBox.CheckState == CheckState.Checked)
            {
                AddPunctuation();
            }
            CreateTextToType();
            CloseButton.Enabled = true;
            index = 0;
            startFlag = false;
            StartButton.Enabled = false;
            textToType[0].BackColor = Color.FromArgb(100, Color.Blue.R, Color.Blue.G, Color.Blue.B);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds+=0.1;  
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textToType.Length; ++i)
            {
                textToType[i].Visible = false;
            }
            StartButton.Enabled = true;
            CloseButton.Enabled = false;
        }
    }
}
