namespace AbpLearning.Core
{
    /// <summary>
    /// 权限
    /// </summary>
    public class AbpLearningPermissions
    {
        #region 节点

        #region Pages

        public const string PAGES = "Pages";

        #region 云书单

        public const string CLOUDBOOKLIST = PAGES + ".CloudBookList";

        public const string BOOK_NODE = CLOUDBOOKLIST + ".Book";

        public const string BOOKTAG_NODE = CLOUDBOOKLIST + ".BookTag";

        public const string BOOKLIST_NODE = CLOUDBOOKLIST + ".BookList";

        #endregion

        #endregion

        #region Administrator

        public const string ADMINISTRATOR = "Administrator";

        public const string TENANTS = ADMINISTRATOR + ".Tenants";

        public const string USERS = ADMINISTRATOR + ".Users";

        public const string ROLES = ADMINISTRATOR + ".Roles";

        #endregion

        #endregion

        #region 功能

        public const string QUERY = ".Query";

        public const string CREATE = ".Create";

        public const string EDIT = ".Edit";

        public const string DELETE = ".Delete";

        /// <summary>
        /// 批量删除
        /// </summary>
		public const string BATCHD_DELETE = ".BatchDelete";

        /// <summary>
        /// 导出
        /// </summary>
        public const string EXPORT_EXCEL = ".ExportExcel";

        #endregion
    }
}
