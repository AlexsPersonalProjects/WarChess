Imports System.ComponentModel

Public Class PlayMenu
    'PlayMenu_Closing
    'Closes the Main menu as it is only hidden earlier
    Private Sub PlayMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMainMenu.Close()

    End Sub

    Private Sub PlayMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitialLoading()
    End Sub

    Private Sub InitialLoading()
        For Each button In pnlGameBoard.Controls
            button.text = ""
            button.flatstyle = FlatStyle.Flat

        Next
        UpdateUnitCount()
        UpdateMoney()
    End Sub

    Private Sub UpdateUnitCount()
        lblPlayer1Inf.Text = "Player 1 Infantry:" & vbTab & p1Inf
        lblPlayer1Cav.Text = "Player 1 Cavalry:" & vbTab & p1Cav
        lblPlayer1Arc.Text = "Player 1 Archers:" & vbTab & p1Arc
        lblPlayer2Inf.Text = "Player 2 Infantry:" & vbTab & p2Inf
        lblPlayer2Cav.Text = "Player 2 Cavalry:" & vbTab & p2Cav
        lblPlayer2Arc.Text = "Player 2 Archers:" & vbTab & p2Arc
    End Sub
    Private Sub UpdateMoney()
        lblP1Money.Text = "Player 1 Money: " & vbTab & p1Money
        lblP2Money.Text = "Player 2 Money: " & vbTab & p2Money
    End Sub

    Private Function CheckMoney(sender As Object, player As String)
        Select Case sender.name
            Case "btnAddInf"

                Select Case player
                    Case player1
                        If p1Money < infCost Then
                            MsgBox("You're broke bitch")
                            Return False
                        End If
                        Return True
                    Case player2
                        If p2Money < infCost Then
                            MsgBox("You're broke bitch")
                            Return False
                        End If
                        Return True
                End Select

            Case "btnAddCav"

                Select Case player
                    Case player1
                        If p1Money < cavCost Then
                            MsgBox("You're broke bitch")
                            Return False
                        End If
                        Return True
                    Case player2
                        If p2Money < cavCost Then
                            MsgBox("You're broke bitch")
                            Return False
                        End If
                        Return True
                End Select

            Case "btnAddArc"

                Select Case player
                    Case player1
                        If p1Money < arcCost Then
                            MsgBox("You're broke bitch")
                            Return False
                        End If
                        Return True
                    Case player2
                        If p2Money < arcCost Then
                            MsgBox("You're broke bitch")
                            Return False
                        End If
                        Return True
                End Select

        End Select
        Return False
    End Function

    Private Sub UpdateWhomstPlayer()
        If playerTurn = player1 Then
            playerTurn = player2
        Else
            playerTurn = PLAYER1
        End If
        lblWhomstTurn.Text = playerTurn
        UpdateUnitCount()
        UpdateMoney()
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        UpdateWhomstPlayer()
    End Sub

    Private Sub btnAddInf_Click(sender As Object, e As EventArgs) Handles btnAddInf.Click


        If playerTurn = player1 Then
            If CheckMoney(sender, player1) Then
                p1Inf += 1
                p1Money -= infCost
            End If
        Else
            If CheckMoney(sender, player2) Then
                p2Inf += 1
                p2Money -= infCost
            End If
        End If
        UpdateWhomstPlayer()
    End Sub

    Private Sub btnAddCav_Click(sender As Object, e As EventArgs) Handles btnAddCav.Click
        If playerTurn = player1 Then
            If CheckMoney(sender, player1) Then
                p1Cav += 1
                p1Money -= cavCost
            End If
        Else
            If CheckMoney(sender, player2) Then
                p2Cav += 1
                p2Money -= cavCost
            End If
        End If
            UpdateWhomstPlayer()
    End Sub

    Private Sub btnAddArc_Click(sender As Object, e As EventArgs) Handles btnAddArc.Click
        If playerTurn = player1 Then
            If CheckMoney(sender, player1) Then
                p1Arc += 1
                p1Money -= arcCost
            End If
        Else
            If CheckMoney(sender, player2) Then
                p2Arc += 1
                p2Money -= arcCost
            End If
        End If
        UpdateWhomstPlayer()
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        pnlGameBoard.Visible = True
        btnDone.Visible = False
        btnAddArc.Enabled = False
        btnAddCav.Enabled = False
        btnAddInf.Enabled = False
    End Sub

    Private Sub bntPlaceUnit_Click(sender As Object, e As EventArgs) Handles btnPlaceInf.Click, btnPlaceCav.Click, btnPlaceArc.Click



        Select Case playerTurn
            Case player1
                Select Case sender.name
                    Case "btnPlaceInf"
                        If p1Inf > 0 Then
                            unitToPlace = "inf"
                            p1Inf -= 1
                        Else
                            MsgBox("You don't have enough of this unit!")
                            Exit Sub
                        End If
                    Case "btnPlaceCav"
                        If p1Cav > 0 Then
                            unitToPlace = "cav"
                            p1Cav -= 1
                        Else
                            MsgBox("You don't have enough of this unit!")
                            Exit Sub
                        End If
                    Case "btnPlaceArc"
                        If p1Arc > 0 Then
                            unitToPlace = "arc"
                            p1Arc -= 1
                        Else
                            MsgBox("You don't have enough of this unit!")
                            Exit Sub
                        End If
                End Select
                For Each button In pnlGameBoard.Controls
                    If button.tag = "playerSide" Then
                        button.flatappearance.borderColor = Color.Red
                        button.enabled = True
                    End If
                Next
            Case player2

                Select Case sender.name
                    Case "btnPlaceInf"
                        If p2Inf > 0 Then
                            unitToPlace = "inf"
                            p2Inf -= 1
                        Else
                            MsgBox("You don't have enough of this unit!")
                            Exit Sub
                        End If
                    Case "btnPlaceCav"
                        If p2Cav > 0 Then
                            unitToPlace = "cav"
                            p2Cav -= 1
                        Else
                            MsgBox("You don't have enough of this unit!")
                            Exit Sub
                        End If
                    Case "btnPlaceArc"
                        If p2Arc > 0 Then
                            unitToPlace = "arc"
                            p2Arc -= 1
                        Else
                            MsgBox("You don't have enough of this unit!")
                            Exit Sub
                        End If
                End Select

                For Each button In pnlGameBoard.Controls
                    If button.Tag = "otherSide" Then
                        button.flatappearance.borderColor = Color.Red
                        button.enabled = True
                    End If
                Next
        End Select
        If p1Inf = 0 And p1Cav = 0 And p1Arc = 0 And p2Inf = 0 And p2Cav = 0 And p2Arc = 0 Then
            btnPlay.Visible = True
        End If

    End Sub

    Private Sub btnPlayerSide_Click(sender As Object, e As EventArgs) Handles Button49.Click, Button50.Click, Button51.Click, Button52.Click, Button53.Click, Button54.Click, Button55.Click, Button56.Click, Button57.Click, Button58.Click, Button59.Click, Button60.Click, Button61.Click, Button62.Click, Button63.Click, Button64.Click, Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click
        If gamePhase = PREGAME Then
            sender.text = unitToPlace
            For Each button In pnlGameBoard.Controls
                button.enabled = False
                button.flatappearance.borderColor = Color.Black
            Next
            UpdateWhomstPlayer()
        End If

    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        StartGame()
    End Sub

    Private Sub StartGame()
        gamePhase = INGAME
        'Hides labels and buttons used in buying units
        lblP1Money.Visible = False
        lblP2Money.Visible = False
        lblPlayer1Inf.Visible = False
        lblPlayer2Inf.Visible = False
        lblPlayer1Cav.Visible = False
        lblPlayer2Cav.Visible = False
        lblPlayer1Arc.Visible = False
        lblPlayer2Arc.Visible = False
        btnAddInf.Visible = False
        btnAddCav.Visible = False
        btnAddArc.Visible = False
        For Each button In pnlGameBoard.Controls
            If button.text <> "" Then
                button.enabled = True
            End If
        Next
    End Sub

    Private Sub GameBoard_Click(sender As Object, e As EventArgs) Handles Button57.Click, Button9.Click, Button10.Click, Button58.Click, Button41.Click, Button42.Click, Button59.Click, Button11.Click, Button43.Click, Button60.Click, Button44.Click, Button12.Click, Button61.Click, Button45.Click, Button46.Click, Button62.Click, Button13.Click, Button47.Click, Button63.Click, Button48.Click, Button14.Click, Button64.Click, Button33.Click, Button34.Click, Button49.Click, Button15.Click, Button50.Click, Button35.Click, Button36.Click, Button51.Click, Button16.Click, Button37.Click, Button52.Click, Button38.Click, Button8.Click, Button53.Click, Button39.Click, Button40.Click, Button54.Click, Button7.Click, Button25.Click, Button55.Click, Button26.Click, Button6.Click, Button56.Click, Button27.Click, Button28.Click, Button5.Click, Button29.Click, Button30.Click, Button4.Click, Button31.Click, Button32.Click, Button3.Click, Button17.Click, Button18.Click, Button2.Click, Button19.Click, Button20.Click, Button1.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click
        'Handles is run through pnlGameBoard.collections, so it is terribly out of order and I hate it but I refuse to manually type them all and I have not learned an easier way
        Select Case sender.text
            Case "inf"
            Case "cav"
            Case "arc"
            Case Else

        End Select



    End Sub

    Private Sub btnHelp1_Click(sender As Object, e As EventArgs) Handles btnHelp1.Click
        Dim strFileReader As String
        strFileReader = My.Computer.FileSystem.ReadAllText("..\..\HELPunitselection.txt")
        Dim arrHelpMessage = strFileReader.Split(vbCrLf)
        Dim i = 0
        Dim strHelpMessage As String
        For Each item In arrHelpMessage
            If i > 0 Then
                strHelpMessage += item
            End If
            i += 1
        Next
        MsgBox(strHelpMessage)
    End Sub
End Class