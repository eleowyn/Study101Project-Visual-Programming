using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study101Project
{
    public partial class Game : Form
    {
        private List<string> icons = new List<string>()
        {
            "🎮", "🎮", "🎨", "🎨", "🎭", "🎭", "🎪", "🎪",
            "🎯", "🎯", "🎲", "🎲", "🎸", "🎸", "🎺", "🎺"
        };

        private List<Button> buttons = new List<Button>();
        private Button firstClicked = null;
        private Button secondClicked = null;
        private Timer timer = new Timer();
        private int pairs = 0;

        public Game()
        {
            InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            // Form settings
            this.Text = "Memory Game";
            this.Size = new Size(600, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create title label
            Label titleLabel = new Label
            {
                Text = "Memory Card Game",
                Font = new Font("Arial", 20, FontStyle.Bold),
                AutoSize = true
            };
            titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width) / 2, 20);
            this.Controls.Add(titleLabel);

            // Shuffle icons
            Random rand = new Random();
            icons = icons.OrderBy(x => rand.Next()).ToList();

            // Create buttons (4x4 grid)
            int buttonSize = 80;
            int padding = 10;
            int startX = (this.ClientSize.Width - (4 * buttonSize + 3 * padding)) / 2;
            int startY = titleLabel.Bottom + 40;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Button button = new Button
                    {
                        Width = buttonSize,
                        Height = buttonSize,
                        Font = new Font("Arial", 24),
                        Location = new Point(
                            startX + col * (buttonSize + padding),
                            startY + row * (buttonSize + padding)
                        ),
                        Tag = icons[row * 4 + col],
                        Text = ""
                    };

                    button.Click += Button_Click;
                    buttons.Add(button);
                    this.Controls.Add(button);
                }
            }

            // Add New Game button
            Button newGameButton = new Button
            {
                Text = "New Game",
                Width = 120,
                Height = 40,
                Font = new Font("Arial", 12)
            };
            newGameButton.Location = new Point(
                (this.ClientSize.Width - newGameButton.Width) / 2,
                startY + 4 * (buttonSize + padding) + 20
            );
            newGameButton.Click += NewGameButton_Click;
            this.Controls.Add(newGameButton);

            // Setup timer
            timer.Interval = 750;
            timer.Tick += Timer_Tick;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == null || timer.Enabled || clickedButton.Text != "")
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedButton;
                firstClicked.Text = firstClicked.Tag.ToString();
                return;
            }

            secondClicked = clickedButton;
            secondClicked.Text = secondClicked.Tag.ToString();

            if (firstClicked.Tag.ToString() == secondClicked.Tag.ToString())
            {
                pairs++;
                firstClicked = null;
                secondClicked = null;

                if (pairs == 8)
                {
                    MessageBox.Show("Congratulations! You've won!", "Game Over");
                }
            }
            else
            {
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            firstClicked.Text = "";
            secondClicked.Text = "";
            firstClicked = null;
            secondClicked = null;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            // Reset game
            pairs = 0;
            firstClicked = null;
            secondClicked = null;

            // Shuffle icons
            Random rand = new Random();
            icons = icons.OrderBy(x => rand.Next()).ToList();

            // Reset buttons
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Text = "";
                buttons[i].Tag = icons[i];
                buttons[i].Enabled = true;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            // This can remain empty as we're handling everything in SetupGame
        }
    }
}