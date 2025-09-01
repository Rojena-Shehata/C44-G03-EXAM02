using ExaminationSystem.Enums;
using ExaminationSystem.Exam;
using ExaminationSystem.QuestionFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public enum IsStartExam
    {
        Y,
        N
    }
    public class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public BaseExam? Exam { get; set; }

        public void CreateExam()
        {
            (int min, int max) ValidOptions = (1,2);
           int option= Helper.GetvalidInput($"Please, Enter type of Exam ({ValidOptions.min} for Practical | {ValidOptions.max} for Final)",ValidOptions,Helper.IsValidInput);
            Console.Clear();
            switch (option)
            {
                case 1:
                    Exam = new PracticalExam();
                    break;
                case 2:
                    Exam = new FinalExam();
                    break;
            }
            if (Exam is not null) 
            {
                Exam.EnterTime();
                Exam.EnterNumberOfQuestions();
                Console.Clear();

                Exam.ShowExam();
                Console.Clear();
               
                
            }




            //Console.WriteLine("Please Enter The Type Of Question (1 for MCQ | 2 for True | false)");


        }

        public void StartSubjectExam()
        {
            if (Exam is null)
            {
                Console.WriteLine("Exam is not available! ('_')");
                return;

            }
            IsStartExam isStartExam = Helper.ReadValidEnum<IsStartExam>("Do you want to Start Exam (Y|N)");
            Console.Clear();
            TimeSpan actualTimeOfExam;
            switch (isStartExam)
            {
                case IsStartExam.Y:
                    Exam.StartExam(out actualTimeOfExam);
                    Console.Clear();
                    Exam.ShowExamResult(actualTimeOfExam);
                    break;
                case IsStartExam.N:
                    Console.Clear();
                    Console.WriteLine("Bi Bi ('_')");
                    break;
            }
        }




    }
    }

