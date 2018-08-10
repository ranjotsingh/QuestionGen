using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace questiongen
{
    public partial class questionGenWindow : Form
    {
        public bool multipleChoiceScreen = false;
        public int questionIndex = 0;
        public int numWrong = 0;
        public int numCorrect = 0;
        QuestionGeneration questionGeneration = new QuestionGeneration();
        Random rnd = new Random();

        public questionGenWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            goBackButton.Hide();
            generatedText.Hide();
            questionLabel.Hide();
            correctAnswerButton.Hide();
            answerButton1.Hide();
            answerButton2.Hide();
            answerButton3.Hide();
            quitQuizButton.Hide();
            statsLabel.Hide();
            blanksCheckBox.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            inputBox.Show();
            submitButton.Show();
            inputText.Show();
            checkBox1.Show();
            goBackButton.Hide();
            generatedText.Hide();
            blanksCheckBox.Show();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!multipleChoiceScreen)
            {
                questionGeneration.totalQuestions = 0;
                string gen = generatedText.Text;
                string old = inputBox.Text;
                questionGeneration.questions.Clear();
                questionGeneration.answers.Clear();
                questionGeneration.convertToQuestions(ref gen, ref old, blanksCheckBox.Checked);
                generatedText.Text = gen;
                if (checkBox1.Checked == true)
                {
                    inputBox.Hide();
                    submitButton.Hide();
                    inputText.Hide();
                    checkBox1.Hide();
                    blanksCheckBox.Hide();
                    statsLabel.Hide();
                    goBackButton.Show();
                    generatedText.Show();
                }
                else
                {
                    if (questionGeneration.totalQuestions >= 4)
                    {
                        multipleChoiceScreen = true;
                        displayQuestion();
                        inputBox.Hide();
                        inputText.Hide();
                        checkBox1.Hide();
                        blanksCheckBox.Hide();
                        questionLabel.Show();
                        correctAnswerButton.Show();
                        answerButton1.Show();
                        answerButton2.Show();
                        answerButton3.Show();
                        quitQuizButton.Show();
                        statsLabel.Show();
                    }
                    else
                    {
                        String failMsg = "Not enough questions for Multiple Choice could be generated. \nDisplaying Answer Sheet... \n\n";
                        failMsg = failMsg.Replace("\n", Environment.NewLine);
                        generatedText.Text = failMsg + gen;
                        inputBox.Hide();
                        submitButton.Hide();
                        inputText.Hide();
                        checkBox1.Hide();
                        blanksCheckBox.Hide();
                        goBackButton.Show();
                        generatedText.Show();
                    }
                }
            }
            else
            {
                if (!(correctAnswerButton.Checked == false && answerButton1.Checked == false && answerButton2.Checked == false && answerButton3.Checked == false))
                {
                    questionIndex++;
                    if (correctAnswerButton.Checked == true)
                        numCorrect++;
                    else
                        numWrong++;
                    displayQuestion();
                }
                else
                    statsLabel.Text = "ERROR: PLEASE SELECT AN OPTION!";
            }
            if (questionGeneration.totalQuestions <= (numCorrect+numWrong) && questionGeneration.totalQuestions >= 4)
            {
                int percentage = (int)(100.0*(numCorrect*1.0 / (numCorrect + numWrong)) + 0.5);
                statsLabel.Text = "Results: " + percentage + "% | Correct: " + numCorrect + " | Wrong: " + numWrong;
                questionIndex = 0;
                multipleChoiceScreen = false;
                inputBox.Show();
                inputText.Show();
                checkBox1.Show();
                blanksCheckBox.Show();
                goBackButton.Hide();
                questionLabel.Hide();
                correctAnswerButton.Hide();
                answerButton1.Hide();
                answerButton2.Hide();
                answerButton3.Hide();
                quitQuizButton.Hide();
                statsLabel.Show();
                numCorrect = 0;
                numWrong = 0;
            }
        }

        private void displayQuestion()
        {
            if (questionGeneration.questions.ElementAtOrDefault(questionIndex) != null)
                questionLabel.Text = questionIndex + 1 + ") " + questionGeneration.questions[questionIndex];
            else
                questionLabel.Text = "No Questions Generated.";
            if (questionGeneration.answers.ElementAtOrDefault(questionIndex) != null)
                correctAnswerButton.Text = questionGeneration.answers[questionIndex];
            else
                correctAnswerButton.Text = "answer";
            int ans1, ans2, ans3, corSelect;
            if(questionIndex < questionGeneration.answers.Count && questionIndex != -1)
            {
                do
                {
                    ans1 = rnd.Next(questionGeneration.answers.Count);
                    ans2 = rnd.Next(questionGeneration.answers.Count);
                    ans3 = rnd.Next(questionGeneration.answers.Count);
                } while (ans1.Equals(ans2) || ans1.Equals(ans3) || ans2.Equals(ans3) || questionIndex.Equals(ans1) || questionIndex.Equals(ans2) || questionIndex.Equals(ans3));
                answerButton1.Text = questionGeneration.answers[ans1];
                answerButton2.Text = questionGeneration.answers[ans2];
                answerButton3.Text = questionGeneration.answers[ans3];
            }
            if (questionGeneration.answers.Count >= 3)
            {
                corSelect = rnd.Next(4);
                if (corSelect == 0)
                {
                    correctAnswerButton.Location = new Point(26, 150);
                    answerButton1.Location = new Point(26, 230);
                    answerButton2.Location = new Point(26, 310);
                    answerButton3.Location = new Point(26, 390);
                }
                else if (corSelect == 1)
                {
                    answerButton1.Location = new Point(26, 150);
                    correctAnswerButton.Location = new Point(26, 230);
                    answerButton2.Location = new Point(26, 310);
                    answerButton3.Location = new Point(26, 390);
                }
                else if (corSelect == 2)
                {
                    answerButton1.Location = new Point(26, 150);
                    answerButton2.Location = new Point(26, 230);
                    correctAnswerButton.Location = new Point(26, 310);
                    answerButton3.Location = new Point(26, 390);
                }
                else if (corSelect == 3)
                {
                    answerButton1.Location = new Point(26, 150);
                    answerButton2.Location = new Point(26, 230);
                    answerButton3.Location = new Point(26, 310);
                    correctAnswerButton.Location = new Point(26, 390);
                }
            }
            correctAnswerButton.Checked = false;
            answerButton1.Checked = false;
            answerButton2.Checked = false;
            answerButton3.Checked = false;
            statsLabel.Text = "Total Questions: " + questionGeneration.totalQuestions + " | Correct: " + numCorrect + " | Wrong: " + numWrong;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void quitQuizButton_Click(object sender, EventArgs e)
        {
            questionIndex = 0;
            multipleChoiceScreen = false;
            inputBox.Show();
            inputText.Show();
            checkBox1.Show();
            blanksCheckBox.Show();
            goBackButton.Hide();
            questionLabel.Hide();
            correctAnswerButton.Hide();
            answerButton1.Hide();
            answerButton2.Hide();
            answerButton3.Hide();
            quitQuizButton.Hide();
            statsLabel.Hide();
            numCorrect = 0;
            numWrong = 0;
        }
    }
}
