Imports System.ComponentModel

Public Class frmMainMenu

    'btnMainMenu_Click
    'Runs when the Main Menu button is clicked
    'asks user if they want to host a new game, and calls NextScreen
    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        'IsHosting()
        PlayMenu.Show()
        Me.Visible() = False
    End Sub


    'IsHosting
    'Runs when play button (btnMainMenu) is clicked
    'Prompts the user if they want to host or join a game, calls NextScreen based on response
    Sub IsHosting()
        If (MsgBox("Host new game?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            NextScreen(True)
        Else
            NextScreen(False)
        End If
    End Sub


    'NextScreen
    'Runs after the Mina Menu button is clicked
    'Hides the Main Menu form, and then gets what IP and port to use
    Sub NextScreen(HostOrClientBoolean As Boolean) 'Host is true, Client is false


        If HostOrClientBoolean Then
            serverPort = InputBox("Port:", "Port to use?", "1000")
            hostOrClient = HostOrClientBoolean
            joinIP = "127.0.0.1"
        Else
            joinIP = InputBox("Server Address:", "Server Address?", "127.0.0.1")
            serverPort = InputBox("Port:", "Port to use?", "1000")
        End If

    End Sub
End Class
