using System.ComponentModel.DataAnnotations;

namespace MB.ApplicationContract.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "لطفا نام گروه مقالات را وارد کنید")]
        [MaxLength(80,ErrorMessage = "تعداد کاراکتر مجاز 80 حرف می باشد")]
        public string Title { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
    }
}
