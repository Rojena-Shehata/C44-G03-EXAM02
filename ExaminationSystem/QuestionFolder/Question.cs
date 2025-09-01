using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.QuestionFolder
{
   public enum QuestionType
    {
        MCQ,
        TrueOrFalse

    }
    public abstract class Question
    {
        

        public string? HeaderOfQuestion {  get; set; }
        public string? BodyOfQuestion {  get; set; }
        public decimal Mark {  get; set; }
        public Answer[]Answers { get; set; }
        public int RightAnswerId { get; set; }
        public int UserAnswerId { get; set; }


        //Question()
        //{
        //    Answers=new Answer[];
        //}
        public abstract void AddQuestion(QuestionType questionType);
        public override string ToString()
        {
            return $"Header: {HeaderOfQuestion}\n Body:{BodyOfQuestion}, Mark:{Mark}, Right{RightAnswerId}";
        }

        public void AddQuestionsAttributes(QuestionType questionType)
        {
            HeaderOfQuestion = $"{questionType} Question";
            BodyOfQuestion = Helper.ReadValidString("Please enter Question Body");

        }

        public void AddQuestionMark()
        {
            Mark = Helper.ReadInt("Please enter Question Mark");

        }

        public int getRightAnswerId(string message,int numberOfChices)
        {
            (int min, int max) validRange = (1, numberOfChices);

            int idOfRightAnswer = Helper.GetvalidInput(message, validRange, Helper.IsValidInput);
            return idOfRightAnswer;
        }


    }
}
