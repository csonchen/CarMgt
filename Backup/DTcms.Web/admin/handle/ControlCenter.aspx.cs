using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DTcms.Web.admin.handle
{
    public partial class ControlCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static bool saveFile(string savepath, ref List<string> filenames, HttpFileCollection files, string strCode)
        {
            //判断是否存在此路径upload文件夹 
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);//创建文件夹
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                if (file.FileName == string.Empty)
                { continue; }
                //判断是否存在文件夹 upload/enterFile/
                string fPath = string.Format(@"{0}\{1}", savepath, files.Keys[i]);
                if (!Directory.Exists(fPath))
                { Directory.CreateDirectory(fPath); }
                //例子: upload/enterFile/2013/
                string newPath = Path.Combine(fPath, DateTime.Now.Year.ToString());
                newPath = Path.Combine(newPath, DateTime.Now.Month.ToString());
                if (!Directory.Exists(newPath))
                { Directory.CreateDirectory(newPath); }
                //例子:upload/enterFile/2013/s001/
                newPath = Path.Combine(newPath, strCode);
                if (!Directory.Exists(newPath))
                { Directory.CreateDirectory(newPath); }
                else
                {
                    Directory.Delete(newPath, true);
                    Directory.CreateDirectory(newPath);
                }
                string extension = VirtualPathUtility.GetExtension(file.FileName);
                string strFile = string.Format("{0}{1}{2}", strCode, Directory.GetFiles(newPath).Length, extension);

                file.SaveAs(string.Format(@"{0}\{1}", newPath, strFile));
                newPath = string.Format(@"upload/-[##]-/{0}/{1}/{2}/{3}", DateTime.Now.Year, DateTime.Now.Month, strCode, strFile);
                newPath = newPath.Replace("-[##]-", files.Keys[i]);
                filenames.Add(newPath);
            }
            return true;
        }
    }
}