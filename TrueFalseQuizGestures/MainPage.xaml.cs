using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TrueFalseQuizGestures
{
    public partial class MainPage : ContentPage
    {

        private List<Question> questions = new List<Question>();
        private int currentQuestion = 0;
        private int score = 0;
        private bool finished = false;

        public MainPage()
        {
            questions.Add(new Question { Text = "An ant can lift 1,000 times its body weight.", Answer = false, Img = "antLift.jpg" });
            questions.Add(new Question { Text = "Greenland is the largest island in the world.", Answer = true, Img = "greenland.jpg" });
            questions.Add(new Question { Text = "Vatican City is the smallest country in the world.", Answer = true, Img = "vaticanCity.jpg" });
            questions.Add(new Question { Text = "Cheesecake comes from Italy.", Answer = false, Img = "cheesecake.jpg" });
            questions.Add(new Question { Text = "An astronaut has played golf on the moon.", Answer = true, Img = "astronaughtGolfing.jpg" });

            InitializeComponent();

            DisplayQuestion(currentQuestion);
        }

        private void DisplayQuestion(int index)
        {
            if (index >= questions.Count)
            {
                RevealScore();
            }
            else
            {
                Question q = questions.ElementAt(index);
                QuestionImage.Source = q.Img;
                QuestionHeader.Text = $"Question #{currentQuestion + 1}";
                QuestionText.Text = q.Text;
            }
        }

        private void RevealScore()
        {
            finished = true;
            QuestionHeader.Text = "Results";
            QuestionText.Text = $"You scored a {score}/{questions.Count}!";
            QuestionImage.IsVisible = false;
            SwipeMarkers.IsVisible = false;
        }

        private void SwipedRight(object sender, SwipedEventArgs e)
        {
            if(!finished)
            {
                if (questions.ElementAt(currentQuestion).Answer) score++;
                DisplayQuestion(++currentQuestion);
            }
            
        }

        private void SwipedLeft(object sender, SwipedEventArgs e)
        {
            if(!finished)
            {
                if (!questions.ElementAt(currentQuestion).Answer) score++;
                DisplayQuestion(++currentQuestion);
            }
        }
    }
}
