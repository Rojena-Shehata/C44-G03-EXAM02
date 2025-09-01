using ExaminationSystem.QuestionFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Exam
{
    public class FinalExam : BaseExam
    {
        private decimal _grade;
        private decimal _totalGrade;
        public FinalExam()
        {
            Questions = new List<Question>();


            _grade = 0;
            _totalGrade = 0;

        }
        public override List<Question> Questions { get; set; }


        public override void ShowExam()
        {

            (int min, int max) ExamType = (1, 2);
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                int input = Helper.GetvalidInput("Please Enter The Type Of Question (1 for MCQ | 2 for True | false)", ExamType, Helper.IsValidInput);
                Question question;
                switch (input)
                {
                    case 1:
                        question = new MCQ();
                        question.AddQuestion(QuestionType.MCQ);
                        Questions.Add(question);
                        break;

                    case 2:
                        question = new TrueOrFalse();
                        question.AddQuestion(QuestionType.TrueOrFalse);
                        Questions.Add(question);

                        break;

                }

            }

        }

        public override void ShowExamResult(TimeSpan actualTimeOfExam)
        {
            if (actualTimeOfExam > TimeOfExam)
            {
                Console.WriteLine("Time Ended!!!!!!");
                Console.WriteLine($"You take {actualTimeOfExam}");
                Console.WriteLine($"But exam Time ={actualTimeOfExam}");


            }

            if (Questions is null) return;
            else if (Questions.Count == 0) return;


            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].Answers == null)
                    continue;
                else if (Questions[i].Answers.Length == 0)
                    continue;

                Console.WriteLine(Questions[i].HeaderOfQuestion);
                Console.WriteLine($"Question {i + 1}:{Questions[i].BodyOfQuestion}");
                if (Questions[i] != null)
                {
                    int userAnswerId = Questions[i].UserAnswerId - 1;
                    int rightAnswerId = Questions[i].RightAnswerId - 1;
                    if(userAnswerId == rightAnswerId)
                    {
                        _grade += Questions[i].Mark;
                    }
                    _totalGrade += Questions[i].Mark;
                    Console.WriteLine($"Your Answer => {Questions[i].Answers[userAnswerId]}");
                    Console.WriteLine($"Right Answer => {Questions[i].Answers[rightAnswerId]}");
                }

                Console.WriteLine("============================");

            }
            Console.WriteLine();
            
                Console.WriteLine($"Your Grade is {_grade} / {_totalGrade}");

            Console.WriteLine($"Time: {actualTimeOfExam.ToString()}");

            Console.WriteLine("\nThank you");
        }


    }
}
