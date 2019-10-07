using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StoryGameMaker
{
    public partial class StoryGameMaker : Form
    {
        private bool altPressed = false;

        public StoryGameMaker() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void submitText()
        {
            ConsoleOutput.Text += textBox1.Text + "\r\n";
            textBox1.Clear();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Alt && e.KeyCode.Equals(Keys.Enter))
            {
                submitText();
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }
    }
}
