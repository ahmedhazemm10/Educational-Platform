using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Educational_Platform.Repository;

namespace Educational_Platform.Services
{
    public class QuestionServices : IQuestionServices
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IExamRepository examRepository;
        private readonly IOptionRepository optionRepository;

        public QuestionServices(IQuestionRepository questionRepository, IExamRepository examRepository, IOptionRepository optionRepository)
        {
            this.questionRepository = questionRepository;
            this.examRepository = examRepository;
            this.optionRepository = optionRepository;
        }

        public bool Add(QuestionCreateDTO entity)
        {
            var exam = examRepository.Details(entity.ExamId);
            if (exam is null)
            {
                return false;
            }
            var question = new Question()
            {
                ExamId = entity.ExamId,
                Text = entity.Text,
                CorrectAnswerOption = entity.CorrectAnswerOption
            };
            var options = entity.Options.Select(o => new Options()
            {
                Order = o.Order,
                Text = o.Text
            }).ToList();
            question.Options = options;
            questionRepository.Add(question);
            questionRepository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var question = questionRepository.Details(id);
            if (question is null)
            {
                return false;
            }
            questionRepository.Delete(question);
            questionRepository.Save();
            return true;
        }

        public List<QuestionReadDTO>? ExamQuestions(int examId)
        {
            var exam = examRepository.Details(examId);
            if (exam is null)
            {
                return null;
            }
            return questionRepository.ExamQuestions(examId).Select(q => new QuestionReadDTO()
            {
                Id = q.Id,
                Text = q.Text,
                Options = q.Options.Select(o => new OptionReadDTO()
                {
                    Id = o.Id,
                    Text = o.Text,
                    Order = o.Order
                }).ToList()
            }).ToList();
        }

        public QuestionReadDTO? GetById(int id)
        {
            var question = questionRepository.GetById(id);
            if (question is null)
            {
                return null;
            }
            var questionDTO = new QuestionReadDTO()
            {
                Id = question.Id,
                Text = question.Text,
                Options = question.Options.Select(o => new OptionReadDTO()
                {
                    Id = o.Id,
                    Text = o.Text,
                    Order = o.Order
                }).ToList()
            };
            return questionDTO;
        }

        public bool Update(QuestionCreateDTO entity, int id)
        {
            var exam = examRepository.Details(entity.ExamId);
            if (exam is null)
            {
                return false;
            }
            var question = questionRepository.Details(id);
            if (question is null)
            {
                return false;
            }
            question.Text = entity.Text;
            question.CorrectAnswerOption = entity.CorrectAnswerOption;
            question.ExamId = entity.ExamId;
            var options = optionRepository.GetByQId(id);
            optionRepository.RemoveList(options);
            var newOptions = entity.Options.Select(o => new Options()
            {
                Order = o.Order,
                Text = o.Text
            }).ToList();
            question.Options = newOptions;
            questionRepository.Update(question);
            questionRepository.Save();
            return true;
        }
    }
    public interface IQuestionServices
    {
        public bool Add(QuestionCreateDTO entity);
        public bool Update(QuestionCreateDTO entity, int id);
        public bool Delete(int id);
        public List<QuestionReadDTO>? ExamQuestions(int examId);
        public QuestionReadDTO? GetById(int id);
    }
}
