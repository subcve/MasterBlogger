using MB.Domain.Exceptions;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorServices : IArticleValidatorServices
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorServices(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckThatThisRecordAlreadyExist(string title)
        {
            if (_articleRepository.Exists(title))
            {
                throw new DuplicatedRecordException("This Record Already Exist In DataBase");
            }
        }
    }
}