namespace AbpLearning.Core
{
    /// <summary>
    /// 权限
    /// </summary>
    public class AbpLearningPermissions
    {
        #region 节点

        public const string Pages = "Pages";

        #region System

        public const string System = Pages + ".System";

        public const string Organization = System + ".Organization";

        public const string AuditLog = System + ".AuditLog";

        public const string Tenant = System + ".Tenant";

        public const string User = System + ".User";

        public const string Role = System + ".Role";

        public const string Setting = System + ".Setting";

        public const string Language = System + ".Language";

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
