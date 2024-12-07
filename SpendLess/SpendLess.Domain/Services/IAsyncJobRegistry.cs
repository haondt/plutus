﻿
using Haondt.Core.Models;

namespace SpendLess.Domain.Services
{
    public interface IAsyncJobRegistry
    {
        void CancelJob(string jobId);
        void CompleteJob(string jobId, object result);
        void FailJob(string jobId, object? result = null, bool? requestCancellation = null);
        AsyncJobStatus GetJobStatus(string jobId);
        (AsyncJobStatus Status, double Progress, Optional<string> ProgressMessage) GetJobProgress(string jobId);
        void UpdateJobProgress(string jobId, double progress, Optional<Optional<string>> progressMessage = default);
        (string, CancellationToken) RegisterJob(Optional<string> progressMessage = default);
        Optional<object> GetJobResult(string jobId);
    }
}
