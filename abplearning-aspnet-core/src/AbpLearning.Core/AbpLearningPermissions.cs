namespace AbpLearning.Core
{
    /// <summary>
    /// 权限
    /// </summary>
    public class AbpLearningPermissions
    {
        #region 节点

        #region Pages

        public const string Pages = "Pages";

        #region 云书单

        public const string Cloudbooklist = Pages + ".CloudBookList";

        public const string BookNode = Cloudbooklist + ".Book";

        public const string BooktagNode = Cloudbooklist + ".BookTag";

        public const string BooklistNode = Cloudbooklist + ".BookList";

        #endregion

        #endregion

        #region Administrator

        public const string Administrator = "Administrator";

        public const string Tenants = Administrator + ".Tenants";

        public const string Users = Administrator + ".Users";

        public const string Roles = Administrator + ".Roles";

        #endregion

        #endregion

        #region 功能

        public const string Query = ".Query";

        public const string Create = ".Create";

        public const string Edit = ".Edit";

        public const string Delete = ".Delete";

        /// <summary>
        /// 批量删除
        /// </summary>
		public const string BatchdDelete = ".BatchDelete";

        /// <summary>
        /// 导出
        /// </summary>
        public const string ExportExcel = ".ExportExcel";

        #endregion
    }
}
