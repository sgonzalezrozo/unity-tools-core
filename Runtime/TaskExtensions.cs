using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ToolsCore
{
    /// <summary>
    /// Starts a task from sync code and logs what it throws, so nothing is lost and no caller needs async void.
    /// Use it as <c>DoWorkAsync().Forget("Context")</c>; the context names the failure in the log.
    /// </summary>
    public static class TaskExtensions
    {
        public static async void Forget(this Task task, string context)
        {
            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                Debug.LogError($"[{context}] Background task failed: {exception}");
            }
        }
    }
}
