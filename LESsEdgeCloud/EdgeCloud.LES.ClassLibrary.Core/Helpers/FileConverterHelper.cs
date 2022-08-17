using EdgeCloud.LES.ClassLibrary.Core.Constants;
using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;
using EdgeCloud.LES.ClassLibrary.Core.DTOs.Request;
using EdgeCloud.LES.ClassLibrary.Core.Enums;
using System.Text;

namespace EdgeCloud.LES.ClassLibrary.Core.Helpers
{
    public class FileConverterHelper
    {
        public static ResultMessage WriteFile(List<FileTransferDto> requestDataList)
        {
            var userid = "1";

            //foreach (var serviceType in Enum.GetNames(typeof(UserAPIServiceType)))
            //{
            //    var groupedDatalist = requestDataList.Where(x => x.ServiceType == serviceType);

            //    try
            //    {
            //        if (groupedDatalist.Count() > 0)
            //            WriteDataFile(groupedDatalist.ToList(), userid);
            //    }
            //    catch (Exception ex)
            //    {
            //        WriteLogFile(groupedDatalist.ToList(), userid, ex.ToString());
            //        return new ResultMessage
            //        {
            //            IsSuccess = false,
            //            Exception = ex
            //        };
            //    }
            //}

            try
            {
                if (requestDataList.Count > 0)
                    WriteDataFile(requestDataList, userid);
            }
            catch (Exception ex)
            {
                WriteLogFile(requestDataList.ToList(), userid, ex.ToString());
                return new ResultMessage
                {
                    IsSuccess = false,
                    Exception = ex
                };
            }
            
            return new ResultMessage
            {
                IsSuccess = true
            };
        }

        private static void WriteDataFile(List<FileTransferDto> requestData, string userid)
        {
            string datenowString = DateTimeOffset.Now.DateOffsetToString();
            requestData.ForEach(x => x.RequestDataObject = JsonHelper<object>.ParseString(x.RequestData.ToBase64Decode()));
            File.AppendAllText(
                GetAbsoluteFilePath(string.Empty, userid, datenowString, FilePath.FileDirectory),
                JsonHelper<List<object>>.ToJSONString(
                    requestData.Select(x => x.RequestDataObject).ToList()));
        }

        private static void WriteLogFile(List<FileTransferDto> requestData, string userid, string failMessage)
        {
            string datenowString = DateTimeOffset.Now.DateOffsetToString();
            File.AppendAllText(GetAbsoluteFilePath(requestData[0].ServiceType, userid, datenowString, FilePath.LogFileDirectory), $" date: {datenowString} detail: {failMessage}");
        }

        private static string GetAbsoluteFilePath(string serviceType, string userid, string datenowString, string directory)
        {
            CreateDirectoryIfNotExists(directory);
            return Path.Combine(directory, $"{serviceType}_{datenowString}_{userid}.json");
        }

        public static string GetAbsoluteDailyLogFilePath
        {
            get
            {
                string directory = FilePath.LogFileDirectory;
                string datenowString = DateTimeOffset.Now.ToString("ddMMyyyy");
                CreateDirectoryIfNotExists(directory);
                return Path.Combine(directory, $"{datenowString}.txt");
            }
        }
        private static void CreateDirectoryIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }
    }
}
