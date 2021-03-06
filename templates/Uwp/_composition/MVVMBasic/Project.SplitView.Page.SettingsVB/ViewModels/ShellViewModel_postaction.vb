﻿'{**
'This code block adds the logic to handle SettingsItem in NavigationView control from ViewModel.
'**}
'{[{
Imports Param_ItemNamespace.Views
'}]}

Namespace ViewModels
    Public Class ShellViewModel
        Inherits Observable

        Private Sub OnItemInvoked(args As WinUI.NavigationViewItemInvokedEventArgs)
            '{[{
            If args.IsSettingsInvoked Then
                NavigationService.Navigate(GetType(wts.ItemNamePage))
                Return
            End If

            '}]}
        End Sub

        Private Sub Frame_Navigated(sender As Object, e As NavigationEventArgs)
            IsBackEnabled = NavigationService.CanGoBack
            '{[{
            If e.SourcePageType = GetType(wts.ItemNamePage) Then
                Selected = TryCast(_navigationView.SettingsItem, WinUI.NavigationViewItem)
                Return
            End If

            '}]}
        End Sub
    End Class
End Namespace
