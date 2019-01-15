namespace AbpLearning.Common.VerificationCode
{
    using System;
    using System.IO;
    using System.Text;
    using Abp;
    using Extensions;
    using System.DrawingCore;
    using System.DrawingCore.Imaging;

    /// <summary>
    /// 验证码 工具
    /// 实现<see cref="IVerificationCodeHelper"/>
    /// </summary>
    public class VerificationCodeHelper : IVerificationCodeHelper
    {
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public MemoryStream Create(out string code, VerificationCodeType type = VerificationCodeType.Number, int length = 4)
        {
            switch (type)
            {
                case VerificationCodeType.Number:
                    code = GetRandomForNumber(length);
                    break;
                case VerificationCodeType.Letter:
                    code = GetRandomForLetter(length);
                    break;
                case VerificationCodeType.NumberAndLetter:
                    code = GetRandomForNumberAndLetter(length);
                    break;
                case VerificationCodeType.Hanzi:
                    code = GetRandomForHanzi(length);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            var random = new Random();
            // 验证码颜色集合  
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            // 验证码字体集合
            string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

            // 定义图像的大小，生成图像的实例  
            var img = new Bitmap(code.Length * 18, 32);

            var g = Graphics.FromImage(img);

            g.Clear(Color.White);// 背景设为白色  

            // 在随机位置画背景点  
            for (var i = 0; i < 100; i++)
            {
                var x = random.Next(img.Width);
                var y = random.Next(img.Height);
                g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }
            // 验证码绘制在g中  
            for (var i = 0; i < code.Length; i++)
            {
                var cindex = random.Next(7);// 随机颜色索引值  
                var findex = random.Next(5);// 随机字体索引值  
                var f = new Font(fonts[findex], 15, FontStyle.Bold);// 字体  
                Brush b = new SolidBrush(c[cindex]);// 颜色  
                var ii = 4;
                if ((i + 1) % 2 == 0)// 控制验证码不在同一高度  
                {
                    ii = 2;
                }
                g.DrawString(code.Substring(i, 1), f, b, 3 + (i * 12), ii);// 绘制一个验证字符  
            }
            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);// 将此图像以Png图像文件的格式保存到流中  

            //回收资源  
            g.Dispose();
            img.Dispose();

            return ms;
        }

        /// <summary>
        /// 数字 验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetRandomForNumber(int length = 4)
        {
            var ints = new int[length];

            for (int i = 0; i < length; i++)
            {
                ints[i] = RandomHelper.GetRandom(0, 9);
            }

            return ints.ExpandAndToString("");
        }

        /// <summary>
        /// 字母 验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetRandomForLetter(int length = 4)
        {
            var resultCode = string.Empty;

            // 验证码字符集合
            var baseCodes = @"a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,
                                A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');

            int temp = -1;// 记录上次的随机数，避免重复

            var rand = new Random();
            for (var i = 0; i < length; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));//初始化随机类  
                }
                int t = rand.Next(baseCodes.Length);//获取随机数  
                if (temp != -1 && temp == t)
                {
                    return GetRandomForLetter(length);// 如果获取的随机数重复，则递归调用
                }
                temp = t;// 把本次产生的随机数记录起来

                resultCode += baseCodes[t];// 随机数的位数加一
            }

            return resultCode;
        }

        /// <summary>
        /// 数字+字母 验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetRandomForNumberAndLetter(int length = 4)
        {
            var resultCode = string.Empty;

            // 所有的验证码字符
            var baseCodes = @"0,1,2,3,4,5,6,7,8,9,
                        a,b,c,d,e,f,g,h,i,j,k,m,l,n,o,p,q,r,s,t,u,v,w,s,y,z,
                        A,B,C,D,E,F,G,H,I,J,K,M,L,N,O,P,Q,R,S,T,U,V,W,S,Y,Z".Split(',');
            // 记录上次随机数，避免重复
            var temp = -1;

            var rand = new Random();

            // 采用简单算法，保证生成不同的随机数
            for (var i = 0; i < length; i++)
            {
                if (temp != -1)
                {
                    // 初始化随机数
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }

                var t = rand.Next(61);
                if (temp != -1 && temp == t)
                {
                    // 如果重复，则递归
                    return GetRandomForNumberAndLetter(length);
                }

                temp = t;
                resultCode += baseCodes[t];
            }

            return resultCode;
        }

        /// <summary>
        /// 汉字 验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GetRandomForHanzi(int length = 4)
        {
            var resultCode = string.Empty;

            // 汉字编码的组成元素，十六进制数
            var baseStrs = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f".Split(',');
            var encoding = Encoding.GetEncoding("GB2312");

            // 每循环一次，产生一个含两个元素的十六进制字节数组，并放入bytes数组中
            // 汉字有四个区位码组成，1，2位作为字节数组的第一个元素，3，4位作为第二个元素
            for (var i = 0; i < length; i++)
            {
                var index1 = RandomHelper.GetRandom(11, 14);
                var str1 = baseStrs[index1];

                var index2 = index1 == 13 ? RandomHelper.GetRandom(0, 7) : RandomHelper.GetRandom(0, 16);
                var str2 = baseStrs[index2];

                var index3 = RandomHelper.GetRandom(10, 16);
                var str3 = baseStrs[index3];

                var index4 = index3 == 10 ? RandomHelper.GetRandom(1, 16) : (index3 == 15 ? RandomHelper.GetRandom(0, 15) : RandomHelper.GetRandom(0, 16));
                var str4 = baseStrs[index4];

                // 定义两个字节变量存储产生的随机汉字区位码
                var b1 = Convert.ToByte(str1 + str2, 16);
                var b2 = Convert.ToByte(str3 + str4, 16);
                byte[] bs = { b1, b2 };

                resultCode += encoding.GetString(bs);
            }

            return resultCode;
        }
    }
}
