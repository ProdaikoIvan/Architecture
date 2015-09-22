using System.IO;
using System.Web;

namespace Extensions.WebExtensions
{
    public class FileExtensions
    {
        public bool HasFile(HttpPostedFileBase file)
        {
            return file != null && file.ContentLength > 0;
        }

        public void SaveFileToFolder(HttpPostedFileBase file)
        {
            if (HasFile(file))
            {
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/"), file.FileName);
                file.SaveAs(path);
            }
        }
    }
}
