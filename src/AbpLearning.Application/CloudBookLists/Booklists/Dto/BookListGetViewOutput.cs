namespace AbpLearning.Application.CloudBookLists.BookLists.Dto
{
    using Base;

    public class BookListGetViewOutput : INullIdEntityDto
    {
        /// <summary>
        /// 书单名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }
    }
}
