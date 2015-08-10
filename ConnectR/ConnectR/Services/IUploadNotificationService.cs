using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectR.Services
{
    public interface IUploadNotificationService
    {
        void OnFileUploaded(string fileName);
    }
}
