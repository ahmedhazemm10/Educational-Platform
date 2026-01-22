using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Educational_Platform.Repository;

namespace Educational_Platform.Services
{
    public class GradeServices : IGradeServices
    {
        private readonly IGradeRepository gradeRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IExamRepository examRepository;
        private readonly IStudentRepository studentRepository;

        public GradeServices(IGradeRepository gradeRepository, IQuestionRepository questionRepository, IExamRepository examRepository, IStudentRepository studentRepository)
        {
            this.gradeRepository = gradeRepository;
            this.questionRepository = questionRepository;
            this.examRepository = examRepository;
            this.studentRepository = studentRepository;
        }

        public int? SubmitExam(List<SubmitExamDTO> submitExamDTOs, int examId, int studentId)
        {
            var exam = examRepository.Details(examId);
            if (exam is null)
            {
                return null;
            }
            var student = studentRepository.Details(studentId);
            if (student is null)
            {
                return null;
            }
            int score = 0;
            var questions = questionRepository.ExamQuestions(examId);
            foreach (var submitExamDTO in submitExamDTOs)
            {
                if (questions.FirstOrDefault(q => q.Id == submitExamDTO.QuestionId)?.CorrectAnswerOption == submitExamDTO.StudentAnswer)
                {
                    score++;
                }
            }
            var grade = new Grade()
            {
                ExamId = examId,
                StudentId = studentId,
                Score = score
            };
            gradeRepository.Add(grade);
            gradeRepository.Save();
            return score;
        }
    }
    public interface IGradeServices
    {
        public int? SubmitExam(List<SubmitExamDTO> submitExamDTOs, int examId, int studentId);
    }
}
