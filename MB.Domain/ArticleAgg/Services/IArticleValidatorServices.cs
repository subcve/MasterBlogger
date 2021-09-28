namespace MB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorServices
    { 
        void CheckThatThisRecordAlreadyExist(string variable);
    }
}
