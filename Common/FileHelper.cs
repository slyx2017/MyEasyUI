using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FileHelper
    {
        public FileHelper() { }

        #region 1.0 删除磁盘中文件 bool DeleteDiskImage(string ImageURL)
        /// <summary>
        /// 根据物理路径删除磁盘中文件
        /// </summary>
        /// <param name="ImageURL">物理图片路径</param>
        /// <returns></returns>
        public static bool DeleteDiskImage(string ImageURL)
        {
            try
            {
                if (File.Exists(ImageURL))
                {
                    File.Delete(ImageURL);//执行IO文件删除,需引入命名空间System.IO;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
