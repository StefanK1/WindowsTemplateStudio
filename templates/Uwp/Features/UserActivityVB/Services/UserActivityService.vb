﻿Imports Windows.ApplicationModel.UserActivities
Imports Windows.UI.Shell

Namespace Services
    ' More details about this functionality can be found at https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/features/user-activity.md
    ' For more info about UserActivities in Timeline see https//docs.microsoft.com/windows/uwp/launch-resume/useractivities
    ' For more info about UserActivities with AdaptativeCards see https://docs.microsoft.com/adaptive-cards/get-started/windows
    ' Please note that user activities will only show on devices with Windows 10 Build 1803 Or higher
    Partial Public Module UserActivityService
        Private _currentUserActivitySession As UserActivitySession

        Async Function CreateUserActivityAsync(activityData As UserActivityData) As Task
            Dim activity = Await activityData.ToUserActivity()

            ' Cleanup any content assigned earlier
            activity.VisualElements.Content = Nothing
            Await SaveAsync(activity)
        End Function

        Async Function CreateUserActivityAsync(activityData As UserActivityData, adaptiveCard As IAdaptiveCard) As Task
            Dim activity = Await activityData.ToUserActivity()
            activity.VisualElements.Content = adaptiveCard
            Await SaveAsync(activity)
        End Function

        Private Async Function SaveAsync(activity As UserActivity) As Task
            Await activity.SaveAsync()

            ' Dispose of any current UserActivitySession, And create a New one.
            _currentUserActivitySession?.Dispose()
            _currentUserActivitySession = activity.CreateSession()
        End Function
    End Module
End Namespace

