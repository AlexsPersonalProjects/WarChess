Module Globals
    Public hostOrClient As Boolean  'Boolean to determine if user is hosting game or joining game
    Public serverPort As Integer    'Integer of what port to look for. Defaults to 1000
    Public joinIP As String         'String with IP to join. Defaults to 127.0.0.1 (localhost)
    Public Const player1 = "Player 1"
    Public Const player2 = "Player 2"
    Public playerTurn As String = player1
    Public p1Inf As Integer = 0
    Public p1Cav As Integer = 0
    Public p1Arc As Integer = 0
    Public p2Inf As Integer = 0
    Public p2Cav As Integer = 0
    Public p2Arc As Integer = 0
    Public p1Money As Integer = 100
    Public p2Money As Integer = 100
    Public infCost = 10
    Public cavCost = 25
    Public arcCost = 35
    Public unitToPlace As String = "inf"





End Module
