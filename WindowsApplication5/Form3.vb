Public Class Form3
    Dim torn As Boolean
    Dim cont As Integer
    Private Sub Form3_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Form2.Hide()
        actualitzar_estats()
        torn = False
    End Sub

    Private Sub AxWinsock1_ConnectionRequest(ByVal sender As Object, ByVal e As AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEvent) Handles AxWinsock1.ConnectionRequest
        If AxWinsock1.CtlState <> MSWinsockLib.StateConstants.sckConnected Then
            AxWinsock1.Close()
            AxWinsock1.Accept(e.requestID)
            actualitzar_estats()
        End If
    End Sub

    Private Sub AxWinsock1_DataArrival(ByVal sender As Object, ByVal e As AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent) Handles AxWinsock1.DataArrival
        Dim datos As Integer
        AxWinsock1.GetData(datos)
        If datos = 0 Then
            bloquejar()
            Label3.Text = "Comença el rival"
        ElseIf datos = 1 Then
            Button1.Text = "O"
            Button1.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 2 Then
            Button2.Text = "O"
            Button2.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 3 Then
            Button3.Text = "O"
            Button3.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 4 Then
            Button4.Text = "O"
            Button4.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 5 Then
            Button5.Text = "O"
            Button5.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 6 Then
            Button6.Text = "O"
            Button6.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 7 Then
            Button7.Text = "O"
            Button7.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 8 Then
            Button8.Text = "O"
            Button8.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 9 Then
            Button9.Text = "O"
            Button9.Enabled = False
            cont = cont + 1
            desbloquejar()
            turno_me()
            Label3.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 10 Then
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            turno_me()
            Label3.Text = "Comences tu!"
        End If
        actualitzar_estats()
    End Sub

    Private Sub Button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button10.Click
        If AxWinsock1.CtlState = MSWinsockLib.StateConstants.sckClosed Then
            AxWinsock1.RemoteHost = TextBox3.Text
            AxWinsock1.Connect()
            actualitzar_estats()
        End If
    End Sub

    Private Sub Caselles_tag(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        Dim enviar As Integer
        enviar = sender.Tag
        sender.Text = "X"
        sender.Enabled = False
        cont = cont + 1
        AxWinsock1.SendData(enviar)
        bloquejar()
        actualitzar_estats()
        Label3.Text = "Torn del rival"
        Me.BackColor = SystemColors.Control
        resultat()
    End Sub

    Sub estado1()
        Select Case AxWinsock1.CtlState
            Case MSWinsockLib.StateConstants.sckClosed
                Label4.Text = "Tancat"
            Case MSWinsockLib.StateConstants.sckOpen
                Label4.Text = "Open"
            Case MSWinsockLib.StateConstants.sckListening
                Label4.Text = "Listening"
            Case MSWinsockLib.StateConstants.sckConnectionPending
                Label4.Text = "Connection pending"
            Case MSWinsockLib.StateConstants.sckResolvingHost
                Label4.Text = "Resolving host"
            Case MSWinsockLib.StateConstants.sckHostResolved
                Label4.Text = "Host resolved"
            Case MSWinsockLib.StateConstants.sckConnecting
                Label4.Text = "Connecting"
            Case MSWinsockLib.StateConstants.sckConnected
                Label4.Text = "Connectat"
                Button10.Enabled = False
                TextBox3.Enabled = False
            Case MSWinsockLib.StateConstants.sckClosing
                Label4.Text = "Peer has closed the connection!"
            Case MSWinsockLib.StateConstants.sckError
                Label4.Text = "Error"
                AxWinsock1.Close()
        End Select
    End Sub

    Sub actualitzar_estats()
        estado1()
    End Sub

    Sub desbloquejar()
        For Each ctlControl In Me.Controls.OfType(Of Button)
            If ctlControl.Text = "" Then
                ctlControl.Enabled = True
            End If
        Next
    End Sub

    Sub bloquejar()
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
    End Sub

    Sub resultat()
        If Button1.Text = "X" AndAlso Button2.Text = "X" AndAlso Button3.Text = "X" Then
            Label3.Text = "HAS GUANYAT!"
            bloquejar()
        End If
        If Button4.Text = "X" AndAlso Button5.Text = "X" AndAlso Button6.Text = "X" Then
            Label3.Text = "HAS GUANYAT!"
            bloquejar()
        End If
        If Button7.Text = "X" AndAlso Button8.Text = "X" AndAlso Button9.Text = "X" Then
            Label3.Text = "HAS GUANYAT!"
            bloquejar()
        End If
        If Button1.Text = "X" AndAlso Button4.Text = "X" AndAlso Button7.Text = "X" Then
            Label3.Text = "HAS GUANYAT!"
            bloquejar()
        End If
        If Button2.Text = "X" AndAlso Button5.Text = "X" AndAlso Button8.Text = "X" Then
            Label3.Text = "HAS GUANYAT!"
            bloquejar()
        End If
        If Button3.Text = "X" AndAlso Button6.Text = "X" AndAlso Button9.Text = "X" Then
            Label3.Text = "HAS GUANYAT!"
            bloquejar()
        End If
        If Button1.Text = "X" AndAlso Button5.Text = "X" AndAlso Button9.Text = "X" Then
            Label3.Text = "HAS GUANYAT!"
            bloquejar()
        End If
        If Button3.Text = "X" AndAlso Button5.Text = "X" AndAlso Button7.Text = "X" Then
            Label3.Text = "HAS GUANYAT!"
            bloquejar()
        End If
        If Button1.Text = "O" AndAlso Button2.Text = "O" AndAlso Button3.Text = "O" Then
            Label3.Text = "Has perdut..."
            bloquejar()
        End If
        If Button4.Text = "O" AndAlso Button5.Text = "O" AndAlso Button6.Text = "O" Then
            Label3.Text = "Has perdut..."
            bloquejar()
        End If
        If Button7.Text = "O" AndAlso Button8.Text = "O" AndAlso Button9.Text = "O" Then
            Label3.Text = "Has perdut..."
            bloquejar()
        End If
        If Button1.Text = "O" AndAlso Button4.Text = "O" AndAlso Button7.Text = "O" Then
            Label3.Text = "Has perdut..."
            bloquejar()
        End If
        If Button2.Text = "O" AndAlso Button5.Text = "O" AndAlso Button8.Text = "O" Then
            Label3.Text = "Has perdut..."
            bloquejar()
        End If
        If Button3.Text = "O" AndAlso Button6.Text = "O" AndAlso Button9.Text = "O" Then
            Label3.Text = "Has perdut..."
            bloquejar()
        End If
        If Button1.Text = "O" AndAlso Button5.Text = "O" AndAlso Button9.Text = "O" Then
            Label3.Text = "Has perdut..."
            bloquejar()
        End If
        If Button3.Text = "O" AndAlso Button5.Text = "O" AndAlso Button7.Text = "O" Then
            Label3.Text = "Has perdut..."
            bloquejar()
        End If
        If cont = 9 And (Label3.Text = "Es el teu torn" Or Label3.Text = "Torn del rival") Then
            Label3.Text = "Empat"
            AxWinsock1.SendData(100)
            bloquejar()
        End If
    End Sub

    Sub turno_me()
        Me.BackColor = Color.LightGreen
    End Sub

End Class