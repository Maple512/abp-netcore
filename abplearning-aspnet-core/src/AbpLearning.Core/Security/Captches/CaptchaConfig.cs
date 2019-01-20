namespace AbpLearning.Core.Security.Captches
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CaptchaConfig
    {
        public bool IsEnabled { get; set; }

        public int Type { get; set; }

        public int Length { get; set; }
    }
}
