using System.IO;
using System.Net;

namespace youtubedown2.SystemFrame
{
    public static class WebRequestExtensions
    {
        /// <summary>
        /// リソースをローカル ファイルにダウンロードします。
        /// </summary>
        /// <param name="request">リソースへのリクエスト。</param>
        /// <param name="fileName">データを受信するローカル ファイルの名前。</param>
        public static void DownloadFileTo(this WebRequest request, string fileName)
        {
            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                int read;
                byte[] buffer = new byte[1024];
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    file.Write(buffer, 0, read);
                }
            }
        }
    }
}