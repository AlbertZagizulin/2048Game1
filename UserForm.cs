using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class UserForm : Form
    {
        public List<RadioButton> radioButtons;
        public UserForm()
        {
            InitializeComponent();
            radioButtons = new List<RadioButton>()
            {
                radioButton1,
                radioButton2,
                radioButton3,
                radioButton4
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentName = userName.Text;
            GameForm gameForm = new GameForm(currentName, radioButtons);
            gameForm.Show();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
