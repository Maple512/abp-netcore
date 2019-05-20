namespace AbpLearning.Core
{
    /// <summary>
    /// 权限
    /// </summary>
    public class AbpLearningPermissions
    {
        #region 节点

        public const string Pages = "Pages";

        public const string Admin = Pages + ".Admin";

        #region System

        public const string System = Admin + ".System";

        public const string Setting = System + ".Setting";

        public const string Language = System + ".Language";

        public const string AuditLog = System + ".AuditLog";

        #endregion

        #region Personnel

        public const string Personnel = Admin + ".Personnel";

        public const string Organization = Personnel + ".Organization";

        public const string Tenant = Personnel + ".Tenant";

        public const string User = Personnel + ".User";

        public const string Role = Personnel + ".Role";

        #endregion

        #endregion

        /// <summary>
        /// 功能
        /// </summary>
        public static class Action
        {
            public const string Query = ".Query";

            public const string Create = ".Create";

            public const string Update = ".Update";

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
