using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Service.CommonModels
{
    public static class ResponseMessage
    {
        public static string AddedSuccess = "Added successfully";
        public static string DeletedSuccess = "Deleted successfully";
        public static string Error = "Error while proccessing request";
        public static string NoRecordFound = "No record found";
        public static string RecordFound = "Data found successfully";
        public static string InvalidId = "Please provide valid Id";
        public static string UpdateSuccess = "Updaed successfully";
        public static string UpdateFailed = "Failed to update";
    }
}
