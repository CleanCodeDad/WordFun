using LetterFun.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EducationalSoftware
{
    public partial class Form1 : Form
    {
        int score = 0;  // Variable to store the current score
        int incorrectAnswers = 0;
        private bool isGameActive = true;

        public Form1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form1_Resize); // Subscribe to the resize event
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CenterLabel(); // Ensure label is centered when the form is first shown
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterLabel();
        }

        private void CenterLabel()
        {
            labelAlphabet.AutoSize = true; // Disable AutoSize
            labelAlphabet.Left = (this.ClientSize.Width - labelAlphabet.Width) / 2;
            labelAlphabet.Top = (this.ClientSize.Height - labelAlphabet.Height) / 3 - 30; // Position it higher
            labelAlphabet.TextAlign = ContentAlignment.MiddleCenter;
            labelAlphabet.BackColor = Color.Transparent;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.paper_1074131;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            btnGo.BackgroundImage = Resources.traffic_light_cropped;
            btnGo.BackgroundImageLayout = ImageLayout.Stretch;

            // On load, we want to hide the word, so we have the go signal
            labelAlphabet.Visible = false;

            // Correct / incorrect button
            button1.Visible = false;
            button2.Visible = false;
            
            // Timer and score
            labelTimer.Visible = false;
            labelScore.Visible = false;
            
            // Go button
            btnGo.Visible = true;

            CenterLabel();        // Then center the label
        }

        //string[] wordList = new string[] { "apple", "banana", "cherry", "date", "elderberry" };
        string[] wordList = new string[] {
    "a", "about", "all", "am", "an", "and", "are", "as", "at", "be", "been", "but", "by", "called", "can", "come",
    "could", "day", "did", "do", "down", "each", "find", "first", "for", "from", "get", "go", "had", "has", "have",
    "he", "her", "him", "his", "how", "I", "if", "in", "into", "is", "it", "its", "like", "long", "look", "made",
    "make", "many", "may", "more", "my", "no", "not", "now", "number", "of", "on", "one", "or", "other", "out",
    "part", "people", "said", "see", "she", "so", "some", "than", "that", "the", "their", "them", "then", "there",
    "these", "they", "this", "time", "to", "two", "up", "use", "was", "water", "way", "we", "were", "what", "when",
    "which", "who", "will", "with", "words", "would", "write", "you", "your"
};
        private string lastWord = string.Empty; // Initialize to an empty string

        private void GenerateRandomWord()
        {
            try
            {
                Random rnd = new Random();
                int index;

                do
                {
                    index = rnd.Next(wordList.Length); // Get a random index
                } while (wordList[index] == lastWord); // Ensure it's not the same as the last word

                lastWord = wordList[index]; // Update lastWord to the newly selected word
                labelAlphabet.Text = wordList[index]; // Set the label text to the word at the random index
                CenterLabel(); // Adjust the position of the label after setting the text
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            // Turn off go button
            btnGo.Visible = false;
            
            
            // Correct / incorrect button
            button1.Visible = true;
            button2.Visible = true;

            // Timer and score
            labelTimer.Visible = true;
            labelScore.Visible = true;
            

            GenerateRandomWord();
            labelAlphabet.Parent = this;
            labelAlphabet.Visible = true;
            labelAlphabet.Anchor = AnchorStyles.None;
            labelTimer.Text = "Time Left: 60s"; // Initialize to 60 seconds

            // Setup the timer
            timer1.Interval = 1000; // Set timer to tick every 1000 milliseconds (1 second)
            timer1.Enabled = true;  // Enable the timer
            timer1.Tick += new EventHandler(this.timer1_Tick);

            isGameActive = true;

            button1.BackgroundImage = Resources.checkmark;
            button1.BackgroundImageLayout = ImageLayout.Stretch;

            button2.BackgroundImage = Resources.xmark;
            button2.BackgroundImageLayout = ImageLayout.Stretch;

            labelTimer.BackColor = Color.Transparent;
            labelTimer.Parent = this;

            labelScore.BackColor = Color.Transparent;
            labelScore.Parent = this;

            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            this.Dock = DockStyle.Fill;

            button1.Anchor = AnchorStyles.None;
            button2.Anchor = AnchorStyles.None;

            labelTimer.Anchor = AnchorStyles.None;
            labelScore.Anchor = AnchorStyles.None;

            timer1.Start();         // Start the timer
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            if (isGameActive) 
            { 
                try
                {
                    score++;
                    labelScore.Text = $"Correct Answers: {score}";
                    GenerateRandomWord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void btnIncorrect_Click(object sender, EventArgs e)
        {
            if (isGameActive)
            {
                try
                {
                    incorrectAnswers++;
                    GenerateRandomWord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private int timeLeft = 60;  // Initialize to 60 seconds


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft -= 1;
                labelTimer.Text = $"Time Left: {timeLeft}s";  // Update labelTimer with additional
            }
            else
            {
                timer1.Stop();  // Stop the timer
                isGameActive = false;
                LogData("Finished");
                labelTimer.Text = "Time's Up!";  // Display end message
            }
            labelTimer.Refresh();
        }

        private void LogData(string status)
        {
            using (StreamWriter sw = new StreamWriter("log.csv", true))
            {
                string currentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                sw.WriteLine($"{currentTime},{score},{incorrectAnswers},{status}");
            }
        }

    }
}
