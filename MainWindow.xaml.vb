Imports System.Threading

Class MainWindow
    Private Checker As Timer

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Checker = New Timer((
        Sub(obj)
            ProBar.Dispatcher.Invoke(
                Sub()
                    ProBar.Value = Player.BufferingProgress
                End Sub
            )
        End Sub
         ), Nothing, Timeout.Infinite, 10)

    End Sub

    Private Sub MainPanel_MouseMove(sender As Object, e As MouseEventArgs) Handles MainPanel.MouseMove
        If e.LeftButton = MouseButtonState.Pressed Then
            Me.DragMove()
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs) Handles BtnClose.Click
        Checker.Change(Timeout.Infinite, 10)
        Player.Close()
        Me.Close()
    End Sub

    Private Sub BtnPlay_Click(sender As Object, e As RoutedEventArgs) Handles BtnPlay.Click
        Player.Play()
    End Sub

    Private Sub BtnPause_Click(sender As Object, e As RoutedEventArgs) Handles BtnPause.Click
        Player.Pause()
    End Sub

    Private Sub Player_BufferingStarted(sender As Object, e As RoutedEventArgs) Handles Player.BufferingStarted
        ProBar.Value = 0
        ProBar.Visibility = Visibility.Visible
        Checker.Change(0, 10)
    End Sub

    Private Sub Player_BufferingEnded(sender As Object, e As RoutedEventArgs) Handles Player.BufferingEnded
        Checker.Change(Timeout.Infinite, 10)
        ProBar.Visibility = Visibility.Hidden
    End Sub
End Class
