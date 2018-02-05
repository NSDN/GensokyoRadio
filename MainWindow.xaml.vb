Imports MaterialDesignThemes.Wpf

Class MainWindow

    Private Sub MainPanel_MouseMove(sender As Object, e As MouseEventArgs) Handles MainPanel.MouseMove
        If e.LeftButton = MouseButtonState.Pressed Then
            Me.DragMove()
        End If
    End Sub

    Private Sub Head_MouseMove(sender As Object, e As MouseEventArgs) Handles Head.MouseMove
        If e.LeftButton = MouseButtonState.Pressed Then
            Me.DragMove()
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs) Handles BtnClose.Click
        Player.Close()
        Me.Close()
    End Sub

    Private Sub BtnPlay_Click(sender As Object, e As RoutedEventArgs) Handles BtnPlay.Click
        Player.Play()
        ButtonProgressAssist.SetIsIndicatorVisible(BtnPause, False)
    End Sub

    Private Sub BtnPause_Click(sender As Object, e As RoutedEventArgs) Handles BtnPause.Click
        Player.Pause()
        ButtonProgressAssist.SetIsIndicatorVisible(BtnPause, True)
    End Sub

    Private Sub Player_BufferingStarted(sender As Object, e As RoutedEventArgs) Handles Player.BufferingStarted
        ButtonProgressAssist.SetValue(BtnPause, -1)
        ButtonProgressAssist.SetIsIndeterminate(BtnPause, True)
    End Sub

    Private Sub Player_BufferingEnded(sender As Object, e As RoutedEventArgs) Handles Player.BufferingEnded
        ButtonProgressAssist.SetValue(BtnPause, 75)
        ButtonProgressAssist.SetIsIndeterminate(BtnPause, False)
    End Sub

End Class
