namespace MB.ApplicationContract.Comment
{
    public interface ICommentApplication
    {
        void Add(CreateComment command);
    }
}
