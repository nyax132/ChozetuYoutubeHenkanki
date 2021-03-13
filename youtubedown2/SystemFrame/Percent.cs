using System;

namespace youtubedown2.SystemFrame
{
    class Percent
    {
        /// <summary>
        /// Youtube-dlログの中から%だけを抜き取る
        /// </summary>
        /// <param name="line">ログ一行を入力する</param>
        /// <returns></returns>
        public static String Parcent(String line)
        {
            string target1 = "]";
            string target2 = "%";

            string parce = "";

            int num1 = line.IndexOf(target1) + 1;
            int num2 = line.IndexOf(target2) + 1;

            if (num1 > 0)
            {
                //Console.WriteLine("{0}は{1}番目にあります", target1, num1);
            }
            else
            {
                //Console.WriteLine("{0}は見つかりませんでした", target1);
            }

            if (num2 > 0)
            {
                //Console.WriteLine("{0}は{1}番目にあります", target2, num2);
            }
            else
            {
                //Console.WriteLine("{0}は見つかりませんでした", target2);
            }

            if (!num1.Equals("") && !num2.Equals(""))
            {
                parce = line.Substring(num1, num2);

                if (parce.Length != 0)
                {
                    //Console.WriteLine(parce + ":parce");
                    return parce;
                }
            }
            return parce;
        }
    }
}
