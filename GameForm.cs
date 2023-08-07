using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class GameForm : Form
    {
        private int fieldSize = 4;
        private Label[,] labelsField;
        public static Random random = new Random();
        private int score = 0;
        private int bestScore;
        public GameForm(string currentName, List<RadioButton> radioButtons)
        {
            InitializeComponent();
            this.Name = currentName;
            this.radioButtons = radioButtons;
        }
        string Name;
        List<RadioButton> radioButtons;
        private void Form1_Load(object sender, EventArgs e)
        {
            CalculateFieldSize(radioButtons);


            InitField();
            GenerateNumber();
            ShowScore();
            CalculateBestScore();
        }

        private void CalculateFieldSize(List<RadioButton> radioButtons)
        {
            foreach (var item in radioButtons)
            {
                if (item.Checked)
                {
                    fieldSize = Convert.ToInt32(item.Text[0].ToString());
                    break;
                }
            }
        }

        private void CalculateBestScore()
        {
            var users = UserManager.GetAll();
            if (users.Count == 0)
            {
                return;
            }
            bestScore = users[0].Score;
            foreach (var user in users)
            {
                if (user.Score > bestScore)
                {
                    bestScore = user.Score;
                }
                ShowBestScore();
            }
        }
        private void ShowBestScore()
        {
            if (score > bestScore)
            {
                bestScore = score;
            }
            bestUserScore.Text = bestScore.ToString();
        }

        private void ShowScore()
        {
            scoreLabel.Text = score.ToString();
        }
        private void InitField()
        {
            this.ClientSize = new Size(10 + 76 * fieldSize, 70 + 76 * fieldSize);
            labelsField = new Label[fieldSize, fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsField[i, j] = newLabel;
                }
            }
        }

        private void GenerateNumber()
        {
            while (true)
            {
                var randomNumberLabel = random.Next(fieldSize * fieldSize);
                var indexRow = randomNumberLabel / fieldSize;
                var indexColumn = randomNumberLabel % fieldSize;
                if (labelsField[indexRow, indexColumn].Text == string.Empty)
                {
                    var numberForLabel = random.Next(1, 3) * 2;
                    labelsField[indexRow, indexColumn].Text = Convert.ToString(numberForLabel);
                    break;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.Info;
            label.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label.Size = new Size(70, 70);
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 10 + indexColumn * 76;
            int y = 70 + indexRow * 76;
            label.Location = new Point(x, y);

            label.TextChanged += Label_TextChanged;
            return label;
        }


        private void Label_TextChanged(object sender, EventArgs e)
        {
            var label = (Label)sender;
            switch (label.Text)
            {
                case "": label.BackColor = SystemColors.Info; break;
                case "2": label.BackColor = Color.FromArgb(175, 150, 190); break;
                case "4": label.BackColor = Color.FromArgb(200, 180, 220); break;
                case "8": label.BackColor = Color.FromArgb(220, 200, 240); break;
                case "16": label.BackColor = Color.FromArgb(240, 220, 255); break;
                case "32": label.BackColor = Color.FromArgb(140, 175, 205); break;
                case "64": label.BackColor = Color.FromArgb(180, 200, 230); break;
                case "128": label.BackColor = Color.FromArgb(240, 180, 225); break;
                case "256": label.BackColor = Color.FromArgb(230, 210, 200); break;
                case "512": label.BackColor = Color.FromArgb(185, 190, 205); break;
                case "1024": label.BackColor = Color.FromArgb(130, 220, 120); break;
                case "2048": label.BackColor = Color.FromArgb(110, 220, 150); break;        
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                return;
            }
            if (e.KeyCode == Keys.Right)
            {
                MoveRight();
            }

            if (e.KeyCode == Keys.Left)
            {
                MoveLeft();
            }

            if (e.KeyCode == Keys.Up)
            {
                MoveUp();
            }
            if (e.KeyCode == Keys.Down)
            {
                MoveDown();
            }
            GenerateNumber();
            ShowScore();
            ShowBestScore();
            if (Win())
            {
                UserManager.Add(new User(Name, score));
                MessageBox.Show("Поздравляю, " + Name + " вы победили!");
                return;
            }
            if (EndOfGame())
            {
                UserManager.Add(new User(Name, score));
                MessageBox.Show(Name + ", Игра окончена. Ходов не осталось.");
                return;
            }
        }

        private void MoveDown()
        {
            for (int j = 0; j < fieldSize; j++)
            {
                for (int i = fieldSize - 1; i >= 0; i--)
                {
                    if (labelsField[i, j].Text != string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (labelsField[k, j].Text != string.Empty)
                            {
                                if (labelsField[i, j].Text == labelsField[k, j].Text)
                                {
                                    var number = int.Parse(labelsField[i, j].Text);
                                    score += number * 2;
                                    labelsField[i, j].Text = (number * 2).ToString();
                                    labelsField[k, j].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < fieldSize; j++)
            {
                for (int i = fieldSize - 1; i >= 0; i--)
                {
                    if (labelsField[i, j].Text == string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (labelsField[k, j].Text != string.Empty)
                            {

                                labelsField[i, j].Text = labelsField[k, j].Text;
                                labelsField[k, j].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveUp()
        {
            for (int j = 0; j < fieldSize; j++)
            {
                for (int i = 0; i < fieldSize; i++)
                {
                    if (labelsField[i, j].Text != string.Empty)
                    {
                        for (int k = i + 1; k < fieldSize; k++)
                        {
                            if (labelsField[k, j].Text != string.Empty)
                            {
                                if (labelsField[i, j].Text == labelsField[k, j].Text)
                                {
                                    var number = int.Parse(labelsField[i, j].Text);
                                    score += number * 2;
                                    labelsField[i, j].Text = (number * 2).ToString();
                                    labelsField[k, j].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < fieldSize; j++)
            {
                for (int i = 0; i < fieldSize; i++)
                {
                    if (labelsField[i, j].Text == string.Empty)
                    {
                        for (int k = i + 1; k < fieldSize; k++)
                        {
                            if (labelsField[k, j].Text != string.Empty)
                            {

                                labelsField[i, j].Text = labelsField[k, j].Text;
                                labelsField[k, j].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveLeft()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (labelsField[i, j].Text != string.Empty)
                    {
                        for (int k = j + 1; k < fieldSize; k++)
                        {
                            if (labelsField[i, k].Text != string.Empty)
                            {
                                if (labelsField[i, j].Text == labelsField[i, k].Text)
                                {
                                    var number = int.Parse(labelsField[i, j].Text);
                                    score += number * 2;
                                    labelsField[i, j].Text = (number * 2).ToString();
                                    labelsField[i, k].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (labelsField[i, j].Text == string.Empty)
                    {
                        for (int k = j + 1; k < fieldSize; k++)
                        {
                            if (labelsField[i, k].Text != string.Empty)
                            {
                                labelsField[i, j].Text = labelsField[i, k].Text;
                                labelsField[i, k].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveRight()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = fieldSize - 1; j >= 0; j--)
                {
                    if (labelsField[i, j].Text != string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (labelsField[i, k].Text != string.Empty)
                            {
                                if (labelsField[i, j].Text == labelsField[i, k].Text)
                                {
                                    var number = int.Parse(labelsField[i, j].Text);
                                    score += number * 2;
                                    labelsField[i, j].Text = (number * 2).ToString();
                                    labelsField[i, k].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = fieldSize - 1; j >= 0; j--)
                {
                    if (labelsField[i, j].Text == string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (labelsField[i, k].Text != string.Empty)
                            {

                                labelsField[i, j].Text = labelsField[i, k].Text;
                                labelsField[i, k].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RulesForm rules = new RulesForm();
            rules.ShowDialog();
        }

        private void restartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }

        private bool EndOfGame()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (labelsField[i, j].Text == "")
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < fieldSize - 1; i++)
            {
                for (int j = 0; j < fieldSize - 1; j++)
                {
                    if (labelsField[i, j].Text == labelsField[i, j + 1].Text || labelsField[i, j].Text == labelsField[i + 1, j].Text)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool Win()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (labelsField[i, j].Text == "2048")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
