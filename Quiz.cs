using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGameProject
{
    public partial class Quiz : Form
    {
        private Rectangle originalFormSize, backMapBtnRec, quizLvlRec, ticketIconRec, ticketAmountRec;
        private Rectangle questBoxRec, questLabelRec;
        private Rectangle choiceARec, choiceALabelRec, choiceBRec, choiceBLabelRec, choiceCRec, choiceCLabelRec, choiceDRec, choiceDLabelRec;

        // Preloaded arrays as a makeshift database
        private string[] quizQuest = SharedArray.quizQuest;
        private string[] quizChoiceA = SharedArray.quizChoiceA;
        private string[] quizChoiceB = SharedArray.quizChoiceB;
        private string[] quizChoiceC = SharedArray.quizChoiceC;
        private string[] quizChoiceD = SharedArray.quizChoiceD;

        private int[] correctAnswers = SharedArray.correctAnswers; // Array with correct answer indices
        private DBConnection Con = new DBConnection(); // Database connection instance
        private PictureBox lastWrongChoice = null; // Tracks the last clicked wrong choice
        private Timer resetTimer = new Timer();
        private Timer nextQuestionTimer = new Timer();
        private int currentQuizLevel = 0; // Keeps track of the current question index

        public Quiz()
        {
            InitializeComponent();
            SetupTimers();
            SetInitialChoiceBackgrounds();
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            AttachChoiceEvents();
            DisplayInitialQuizLevel();
            DisplayTicketAmount();

            InitializeRectangles();

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void InitializeRectangles()
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            //add any components here -jvp
            backMapBtnRec = new Rectangle(backMapBtn.Location.X, backMapBtn.Location.Y, backMapBtn.Width, backMapBtn.Height);
            quizLvlRec = new Rectangle(quizLvl.Location.X, quizLvl.Location.Y, quizLvl.Width, quizLvl.Height);
            ticketIconRec = new Rectangle(ticketIcon.Location.X, ticketIcon.Location.Y, ticketIcon.Width, ticketIcon.Height);
            ticketAmountRec = new Rectangle(ticketAmount.Location.X, ticketAmount.Location.Y, ticketAmount.Width, ticketAmount.Height);
            questBoxRec = new Rectangle(questBox.Location.X, questBox.Location.Y, questBox.Width, questBox.Height);
            questLabelRec = new Rectangle(questLabel.Location.X, questLabel.Location.Y, questLabel.Width, questLabel.Height);
            choiceARec = new Rectangle(choiceA.Location.X, choiceA.Location.Y, choiceA.Width, choiceA.Height);
            choiceALabelRec = new Rectangle(choiceALabel.Location.X, choiceALabel.Location.Y, choiceALabel.Width, choiceALabel.Height);
            choiceBRec = new Rectangle(choiceB.Location.X, choiceB.Location.Y, choiceB.Width, choiceB.Height);
            choiceBLabelRec = new Rectangle(choiceBLabel.Location.X, choiceBLabel.Location.Y, choiceBLabel.Width, choiceBLabel.Height);
            choiceCRec = new Rectangle(choiceC.Location.X, choiceC.Location.Y, choiceC.Width, choiceC.Height);
            choiceCLabelRec = new Rectangle(choiceCLabel.Location.X, choiceCLabel.Location.Y, choiceCLabel.Width, choiceCLabel.Height);
            choiceDRec = new Rectangle(choiceD.Location.X, choiceD.Location.Y, choiceD.Width, choiceD.Height);
            choiceDLabelRec = new Rectangle(choiceDLabel.Location.X, choiceDLabel.Location.Y, choiceDLabel.Width, choiceDLabel.Height);
        }


        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Quiz_Resize(object sender, EventArgs e)
        {
            resizeControl(backMapBtnRec, backMapBtn);
            resizeControl(quizLvlRec, quizLvl);
            resizeControl(ticketIconRec, ticketIcon);
            resizeControl(ticketAmountRec, ticketAmount);
            resizeControl(questBoxRec, questBox);
            resizeControl(questLabelRec, questLabel);
            resizeControl(choiceARec, choiceA);
            resizeControl(choiceALabelRec, choiceALabel);
            resizeControl(choiceBRec, choiceB);
            resizeControl(choiceBLabelRec, choiceBLabel);
            resizeControl(choiceCRec, choiceC);
            resizeControl(choiceCLabelRec, choiceCLabel);
            resizeControl(choiceDRec, choiceD);
            resizeControl(choiceDLabelRec, choiceDLabel);
        }
        private void backMapBtn_Click(object sender, EventArgs e)
        {
            Loading load = new Loading();
            load.Show();
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    load.Hide();
                    Map inv = new Map();
                    inv.Show();
                });
            });
        }

        private void SetupTimers()
        {
            resetTimer.Interval = 500;
            resetTimer.Tick += ResetTimer_Tick;

            nextQuestionTimer.Interval = 1000;
            nextQuestionTimer.Tick += NextQuestionTimer_Tick;
        }

        private void SetInitialChoiceBackgrounds()
        {
            choiceA.BackgroundImage = Properties.Resources.ChoiceQuiz;
            choiceB.BackgroundImage = Properties.Resources.ChoiceQuiz;
            choiceC.BackgroundImage = Properties.Resources.ChoiceQuiz;
            choiceD.BackgroundImage = Properties.Resources.ChoiceQuiz;
        }

        private void AttachChoiceEvents()
        {
            choiceA.Click += Choice_Click;
            choiceB.Click += Choice_Click;
            choiceC.Click += Choice_Click;
            choiceD.Click += Choice_Click;
        }

        private void DisplayInitialQuizLevel()
        {
            FetchAndDisplayQuizLevel(1); // Load the first quiz level
        }

        private void FetchAndDisplayQuizLevel(int quizID)
        {
            try
            {
                Con.Connection();
                Con.Con.Open();

                SqlCommand cmd = new SqlCommand("SELECT quizLevel FROM QuizTbl WHERE quizID = @quizID", Con.Con);
                cmd.Parameters.AddWithValue("@quizID", quizID);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    quizLvl.Text = "Level : " + result.ToString();
                    currentQuizLevel = Convert.ToInt32(result) - 1;
                    DisplayQuiz(currentQuizLevel);
                }
                else
                {
                    MessageBox.Show("Unable to fetch quiz data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching quiz level: " + ex.Message);
            }
            finally
            {
                Con.Con.Close();
            }
        }

        private void DisplayQuiz(int index)
        {
            try
            {
                if (index >= 0 && index < quizQuest.Length)
                {
                    SetInitialChoiceBackgrounds();
                    questLabel.Text = quizQuest[index];
                    choiceALabel.Text = quizChoiceA[index];
                    choiceBLabel.Text = quizChoiceB[index];
                    choiceCLabel.Text = quizChoiceC[index];
                    choiceDLabel.Text = quizChoiceD[index];
                }
                else
                {
                    MessageBox.Show("Invalid index for quiz questions.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying quiz data: " + ex.Message);
            }
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            PictureBox clickedChoice = sender as PictureBox;
            if (clickedChoice == null) return;

            int selectedIndex = DetermineSelectedIndex(clickedChoice);

            // Ensure index boundaries are respected
            if (currentQuizLevel >= 0 && currentQuizLevel < correctAnswers.Length)
            {
                if (selectedIndex == correctAnswers[currentQuizLevel]) // Check if the answer is correct
                {
                    HandleCorrectAnswer(clickedChoice);
                }
                else
                {
                    HandleWrongAnswer(clickedChoice);
                }
            }
            else
            {
                MessageBox.Show("Error: Current quiz index is out of bounds.");
            }
        }

        private int DetermineSelectedIndex(PictureBox clickedChoice)
        {
            if (clickedChoice == choiceA) return 0;
            if (clickedChoice == choiceB) return 1;
            if (clickedChoice == choiceC) return 2;
            if (clickedChoice == choiceD) return 3;
            return -1;
        }

        private void HandleCorrectAnswer(PictureBox choice)
        {
            choice.BackgroundImage = Properties.Resources.CorrectQuiz;
            UpdateDatabaseForCorrectAnswer();
            nextQuestionTimer.Start();
        }

        private void HandleWrongAnswer(PictureBox choice)
        {
            choice.BackgroundImage = Properties.Resources.WrongQuiz;
            lastWrongChoice = choice;
            resetTimer.Start();
        }

        private void UpdateDatabaseForCorrectAnswer()
        {
            try
            {
                Con.Connection();
                Con.Con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE CurrencyTbl SET gem = gem + 10", Con.Con);
                cmd.ExecuteNonQuery();

                DisplayTicketAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error handling correct answer: " + ex.Message);
            }
            finally
            {
                Con.Con.Close();
            }
        }

        private void ResetTimer_Tick(object sender, EventArgs e)
        {
            if (lastWrongChoice != null)
            {
                lastWrongChoice.BackgroundImage = Properties.Resources.ChoiceQuiz;
                resetTimer.Stop();
                lastWrongChoice = null;
            }
        }

        private void NextQuestionTimer_Tick(object sender, EventArgs e)
        {
            nextQuestionTimer.Stop();

            try
            {
                Con.Connection();
                Con.Con.Open();

                if (currentQuizLevel + 1 < quizQuest.Length) // Ensure no out-of-bound access
                {
                    SqlCommand cmd = new SqlCommand("UPDATE QuizTbl SET quizLevel = quizLevel + 1 WHERE quizID = @quizID", Con.Con);
                    cmd.Parameters.AddWithValue("@quizID", 1);
                    cmd.ExecuteNonQuery();

                    currentQuizLevel++;
                    DisplayQuiz(currentQuizLevel);
                }
                else
                {
                    MessageBox.Show("No more quiz questions.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error transitioning to the next question: " + ex.Message);
            }
            finally
            {
                Con.Con.Close();
            }
        }

        private void DisplayTicketAmount()
        {
            try
            {
                Con.Connection();
                Con.Con.Open();

                SqlCommand cmd = new SqlCommand("SELECT gem FROM CurrencyTbl", Con.Con);
                object result = cmd.ExecuteScalar();
                ticketAmount.Text = result?.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching ticket amount: " + ex.Message);
            }
            finally
            {
                Con.Con.Close();
            }
        }
    }
}
