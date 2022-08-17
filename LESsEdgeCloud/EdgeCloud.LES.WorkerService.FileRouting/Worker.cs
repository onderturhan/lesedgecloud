using AutoMapper;
using EdgeCloud.LES.ClassLibrary.Core.Constants;
using EdgeCloud.LES.ClassLibrary.Core.DTOs;
using EdgeCloud.LES.ClassLibrary.Core.DTOs.Base;
using EdgeCloud.LES.ClassLibrary.Core.Enums;
using EdgeCloud.LES.ClassLibrary.Core.Helpers;
using EdgeCloud.LES.ClassLibrary.Core.Services;
using EdgeCloud.LES.ClassLibrary.Service.Exceptions;

namespace EdgeCloud.LES.WorkerService.FileRouting
{
    public class Worker : BackgroundService
    {
        //private readonly ILogger<Worker> _logger;
        //private readonly IMapper _mapper;
        private readonly IApiRequestLogService _apiRequestLogService;
        private readonly IUserAuthenticationLogService _authenticationLogService;
        private readonly IInteractionLogService _interactionLogService;
        private readonly INavigationLogService _navigationLogService;
        private readonly INetworkLogService _networkLogService;
        private readonly IEventLogService _eventLogService;

        public Worker(/*ILogger<Worker> logger, IMapper mapper,*/ IApiRequestLogService apiRequestLogService, IUserAuthenticationLogService authenticationLogService, IInteractionLogService interactionLogService, INetworkLogService networkLogService, INavigationLogService navigationLogService, IEventLogService eventLogService)
        {
            //_logger = logger;
            //_mapper = mapper;
            _apiRequestLogService = apiRequestLogService;
            _authenticationLogService = authenticationLogService;
            _interactionLogService = interactionLogService;
            _networkLogService = networkLogService;
            _navigationLogService = navigationLogService;
            _eventLogService = eventLogService;
        }

        public static bool FileDirectoryExist => Directory.Exists(FilePath.FileDirectory);
        public static bool ArchiveDirectoryExist => Directory.Exists(FilePath.ArchiveFileDirectory);
        public static List<string> FileNames => Directory.GetFiles(FilePath.FileDirectory).ToList();
        public static bool CurrentFilePathExists
        {
            get
            {
                if (FileNames.Count < 1)
                    return false;

                string fileName = FileNames.First();
                return File.Exists(fileName);
            }
        }
        public static string CurrentFilePath
        {
            get
            {
                if (!CurrentFilePathExists)
                    return string.Empty;
                return FileNames.First();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Info: Worker started at: {DateTimeOffset.Now}" + Environment.NewLine);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    if (!ValidatePath()) continue;

                    File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Info: No Validation error in {CurrentFilePath} file" + Environment.NewLine);

                    var data = File.ReadAllText(CurrentFilePath);

                    File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Info: Data in {CurrentFilePath} file is read" + Environment.NewLine);

                    await ParseAndSaveDataAsync(data);

                    File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Info: Operation in {CurrentFilePath} file is succesfully parsed and written to database" + Environment.NewLine);

                    MoveFileToArchiveAfterSuccess();

                    File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Info: Operation in {CurrentFilePath} file is moved to archive" + Environment.NewLine);
                }
                catch (Exception)
                {
                    //throw;
                    return;
                }
                finally
                {
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }

        private static bool ValidatePath()
        {
            if (!ArchiveDirectoryExist)
            {
                File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Error: {ArchiveDirectoryExist} archive file directory doesn't exist" + Environment.NewLine);
                throw new DirectoryNotExistedException();
            }

            if (!FileDirectoryExist)
            {
                File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Error: {FileDirectoryExist} file directory doesn't exist" + Environment.NewLine);
                throw new DirectoryNotExistedException();
            }

            if (!CurrentFilePathExists)
            {
                File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Warning: {CurrentFilePathExists} File not found in this directory" + Environment.NewLine);
                return false;
            }
            return true;
        }

        private async Task ParseAndSaveDataAsync(string data)
        {
            try
            {
                //if (Enum.IsDefined(typeof(UserAPIServiceType), CurrentLogType))
                //{

                //var result = await _apiRequestLogService.AddAsync(JsonHelper<ApiRequestLogDto>.ParseString(data));
                //if (result != null && result.Id > 0)
                //    await _eventLogService.SendEventLogAsync(new EventLogDto { EventType = UserEventType.FileIsRead, ServiceType = UserAPIServiceType.ApiRequest }, currentFilePath);
                //else
                //    await _eventLogService.SendEventLogAsync(new EventLogDto { EventType = UserEventType.FileNotParsed, ServiceType = UserAPIServiceType.ApiRequest }, currentFilePath);


                //var eventLog = await _eventLogService.AddAsync(data);

                //if (eventLog != null)
                //    File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Info: Added event successfully for data of {currentFilePath} file" + Environment.NewLine);
                //else
                //    File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Error: Getting an error during adding event for data of {currentFilePath} file" + Environment.NewLine);

                foreach (var item in JsonHelper<List<object>>.ParseString(data))
                {
                    EventLogDto eventLogDto = null;
                    LogBaseDto result = null;

                    if (JsonHelper<ApiRequestLogDto>.Parsable(item.ToString()))
                    {
                        var parsedData = JsonHelper<ApiRequestLogDto>.ParseString(item.ToString());
                        parsedData.AccessToken = parsedData.MacAddress = "12345";
                        result = await _apiRequestLogService.AddAsync(parsedData);
                        eventLogDto = new EventLogDto { ServiceType = UserAPIServiceType.ApiRequest };
                    }
                    else if (JsonHelper<UserAuthenticationLogDto>.Parsable(item.ToString()))
                    {
                        var parsedData = JsonHelper<UserAuthenticationLogDto>.ParseString(item.ToString());
                        parsedData.AccessToken = parsedData.MacAddress = "12345";
                        result = await _authenticationLogService.AddAsync(parsedData);
                        eventLogDto = new EventLogDto { ServiceType = UserAPIServiceType.Authentication };
                    }
                    else if (JsonHelper<InteractionLogDto>.Parsable(item.ToString()))
                    {
                        var parsedData = JsonHelper<InteractionLogDto>.ParseString(item.ToString());
                        parsedData.AccessToken = parsedData.MacAddress = "12345";
                        result = await _interactionLogService.AddAsync(parsedData);
                        eventLogDto = new EventLogDto { ServiceType = UserAPIServiceType.Interaction };
                    }
                    else if (JsonHelper<NavigationLogDto>.Parsable(item.ToString()))
                    {
                        var parsedData = JsonHelper<NavigationLogDto>.ParseString(item.ToString());
                        parsedData.AccessToken = parsedData.MacAddress = "12345";
                        result = await _navigationLogService.AddAsync(parsedData);
                        eventLogDto = new EventLogDto { ServiceType = UserAPIServiceType.Navigation };
                    }
                    else if (JsonHelper<NetworkLogDto>.Parsable(item.ToString()))
                    {
                        var parsedData = JsonHelper<NetworkLogDto>.ParseString(item.ToString());
                        parsedData.AccessToken = parsedData.MacAddress = "12345";
                        result = await _networkLogService.AddAsync(parsedData);
                        eventLogDto = new EventLogDto { ServiceType = UserAPIServiceType.Network };
                    }
                    else
                    {
                        eventLogDto = new EventLogDto { EventType = UserEventType.UnknownServiceType };
                        MoveFileToArchiveAfterError();
                        throw new NotParsedException();
                    }


                    if (result != null)
                        eventLogDto.EventType = (result != null && result.Id > 0) ? UserEventType.FileIsRead : UserEventType.DataNotInserted;
                    if (eventLogDto != null)
                        File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath,
                            (await _eventLogService.AddAsync(eventLogDto) != null) ?
                            $"Info: Added event successfully for data of {CurrentFilePath} file" + Environment.NewLine :
                            $"Error: Getting an error during adding event for data of {CurrentFilePath} file" + Environment.NewLine);

                }
                //}
                //else
                //{
                //    var eventLog = await _eventLogService.AddAsync(new EventLogDto { EventType = UserEventType.UnknownServiceType });

                //    if (eventLog != null)
                //        File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Info: Added event successfully for data of {CurrentFilePath} file" + Environment.NewLine);
                //    else
                //        File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Error: Getting an error during adding event for data of {CurrentFilePath} file" + Environment.NewLine);
                //    MoveFileToArchiveAfterError();
                //    throw new NotParsedException();
                //}                
            }
            catch (Exception ex)
            {
                File.AppendAllText(FileConverterHelper.GetAbsoluteDailyLogFilePath, $"Error: Getting an error for {CurrentFilePath} file, detail: {ex}" + Environment.NewLine);
                //todo MoveFileToArchiveAfterError();
                throw;
            }
        }

        private static void MoveFileToArchiveAfterSuccess()
        {
            string currentFileName = Path.GetFileName(CurrentFilePath);
            string destinationFileName = currentFileName.Replace(".json", ".json.success");
            File.Move(CurrentFilePath, Path.Combine(FilePath.ArchiveFileDirectory, destinationFileName));
        }
        private static void MoveFileToArchiveAfterError()
        {
            string currentFileName = Path.GetFileName(CurrentFilePath);
            string destinationFileName = currentFileName.Replace(".json", ".json.error");
            File.Move(CurrentFilePath, Path.Combine(FilePath.ArchiveFileDirectory, destinationFileName));
        }
    }
}