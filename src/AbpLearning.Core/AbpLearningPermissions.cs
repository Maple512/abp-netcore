namespace AbpLearning.Core
{
    /// <summary>
    /// 权限
    /// </summary>
    public class AbpLearningPermissions
    {
        #region 节点

        public const string Pages = "Pages";

        #region Cloudbooklist

        public const string Cloudbooklist = Pages + ".CloudBookList";

        public const string Book = Cloudbooklist + ".Book";

        public const string Booklist = Cloudbooklist + ".BookList";

        #endregion

        #region Authentication

        public const string Authentication = Pages + ".Authentication";

        public const string Tenant = Authentication + ".Tenant";

        public const string User = Authentication + ".User";

        public const string Role = Authentication + ".Role";

        #endregion

        #region System

        public const string System = Pages + ".System";

        public const string AuditLog = System + ".AuditLog";

        #endregion

        #region File

        public const string File = Pages + ".File";

        public const string UploadFile = File + ".UpLoadFile";

        #endregion

        #endregion

        /// <summary>
        /// 功能
        /// </summary>
        public static class Action
        {
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

            /// <summary>
            /// 上传
            /// </summary>
            public const string Upload = ".Upload";

            /// <summary>
            /// 下载
            /// </summary>
            public const string Download = ".Download";
        }
    }
}
