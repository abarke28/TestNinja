using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly string _setupLocationPath;
        private readonly IFileDownloader _fileDownloader;

        public InstallerHelper(string path = null, IFileDownloader fileDownloader = null)
        {
            _setupLocationPath = path ?? @"C:/Users/Owner/desktop/setup.txt";
            _fileDownloader = fileDownloader ?? new FileDownloader();
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloader.DownloadFile(String.Format("http://www.example.com/{0}/{1}", customerName, installerName), _setupLocationPath);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
