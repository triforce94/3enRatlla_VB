Public Class Form1
    Dim torn As Boolean
    Dim random As New Random
    Dim cont As Integer
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Form2.Hide()
        Label1.Text = Label1.Text & "   " & AxWinsock1.LocalIP
        AxWinsock1.Listen()
        actualitzar_estats()
        cont = 0
    End Sub

    Private Sub AxWinsock1_ConnectionRequest(ByVal sender As Object, ByVal e As AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEvent) Handles AxWinsock1.ConnectionRequest
        If AxWinsock1.CtlState <> MSWinsockLib.StateConstants.sckConnected Then
            AxWinsock1.Close()
            AxWinsock1.Accept(e.requestID)
            actualitzar_estats()
            Dim rand As Integer = random.Next(0, 2)
            If rand = 0 Then
                torn = True
                Button1.Enabled = True
                Button2.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Label2.Text = "Comences tu!"
                AxWinsock1.SendData(0)
            Else
                torn = False
                AxWinsock1.SendData(10)
                Label2.Text = "Comença el rival"
            End If

        End If
    End Sub

    Private Sub AxWinsock1_DataArrival(ByVal sender As Object, ByVal e As AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent) Handles AxWinsock1.DataArrival
        Dim datos As Integer
        AxWinsock1.GetData(datos)
        If datos = 1 Then
            Button1.Text = "X"
            Button1.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 2 Then
            Button2.Text = "X"
            Button2.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 3 Then
            Button3.Text = "X"
            Button3.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 4 Then
            Button4.Text = "X"
            Button4.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 5 Then
            Button5.Text = "X"
            Button5.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 6 Then
            Button6.Text = "X"
            Button6.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 7 Then
            Button7.Text = "X"
            Button7.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 8 Then
            Button8.Text = "X"
            Button8.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        ElseIf datos = 9 Then
            Button9.Text = "X"
            Button9.Enabled = False
            cont = cont + 1
            desbloquejar()
            Label2.Text = "Es el teu torn"
            resultat()
        End If
        actualitzar_estats()
    End Sub

    Private Sub Caselles_tag(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        Dim enviar As Integer
        enviar = sender.Tag
        sender.Text = "O"
        sender.Enabled = False
        AxWinsock1.SendData(enviar)
        cont = cont + 1
        bloquejar()
        Label2.Text = "Torn del rival"
        actualitzar_estats()
        resultat()
    End Sub

    Sub estado2()
        Select Case AxWinsock1.CtlState
            Case MSWinsockLib.StateConstants.sckClosed
                Label4.Text = "Cerrado"
            Case MSWinsockLib.StateConstants.sckOpen
                Label4.Text = "Open"
            Case MSWinsockLib.StateConstants.sckListening
                Label4.Text = "Escoltant"
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
            Case MSWinsockLib.StateConstants.sckClosing
                Label4.Text = "Peer has closed the connection!"
            Case MSWinsockLib.StateConstants.sckError
                Label4.Text = "Error"
                AxWinsock1.Close()
        End Select
    End Sub

    Sub actualitzar_estats()
        estado2()
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
            Label2.Text = "Has perdut..."
            AxWinsock1.SendData(98)
            bloquejar()
        End If
        If Button4.Text = "X" AndAlso Button5.Text = "X" AndAlso Button6.Text = "X" Then
            Label2.Text = "Has perdut..."
            AxWinsock1.SendData(98)
            bloquejar()
        End If
        If Button7.Text = "X" AndAlso Button8.Text = "X" AndAlso Button9.Text = "X" Then
            Label2.Text = "Has perdut..."
            AxWinsock1.SendData(98)
            bloquejar()
        End If
        If Button1.Text = "X" AndAlso Button4.Text = "X" AndAlso Button7.Text = "X" Then
            Label2.Text = "Has perdut..."
            AxWinsock1.SendData(98)
            bloquejar()
        End If
        If Button2.Text = "X" AndAlso Button5.Text = "X" AndAlso Button8.Text = "X" Then
            Label2.Text = "Has perdut..."
            AxWinsock1.SendData(98)
            bloquejar()
        End If
        If Button3.Text = "X" AndAlso Button6.Text = "X" AndAlso Button9.Text = "X" Then
            Label2.Text = "Has perdut..."
            AxWinsock1.SendData(98)
            bloquejar()
        End If
        If Button1.Text = "X" AndAlso Button5.Text = "X" AndAlso Button9.Text = "X" Then
            Label2.Text = "Has perdut..."
            AxWinsock1.SendData(98)
        End If
        If Button3.Text = "X" AndAlso Button5.Text = "X" AndAlso Button7.Text = "X" Then
            Label2.Text = "Has perdut..."
            AxWinsock1.SendData(98)
            bloquejar()
        End If
        If Button1.Text = "O" AndAlso Button2.Text = "O" AndAlso Button3.Text = "O" Then
            Label2.Text = "HAS GUANYAT!"
            AxWinsock1.SendData(99)
            bloquejar()
        End If
        If Button4.Text = "O" AndAlso Button5.Text = "O" AndAlso Button6.Text = "O" Then
            Label2.Text = "HAS GUANYAT!"
            AxWinsock1.SendData(99)
            bloquejar()
        End If
        If Button7.Text = "O" AndAlso Button8.Text = "O" AndAlso Button9.Text = "O" Then
            Label2.Text = "HAS GUANYAT!"
            AxWinsock1.SendData(99)
        End If
        If Button1.Text = "O" AndAlso Button4.Text = "O" AndAlso Button7.Text = "O" Then
            Label2.Text = "HAS GUANYAT!"
            AxWinsock1.SendData(99)
            bloquejar()
        End If
        If Button2.Text = "O" AndAlso Button5.Text = "O" AndAlso Button8.Text = "O" Then
            Label2.Text = "HAS GUANYAT!"
            AxWinsock1.SendData(99)
            bloquejar()
        End If
        If Button3.Text = "O" AndAlso Button6.Text = "O" AndAlso Button9.Text = "O" Then
            Label2.Text = "HAS GUANYAT!"
            AxWinsock1.SendData(99)
            bloquejar()
        End If
        If Button1.Text = "O" AndAlso Button5.Text = "O" AndAlso Button9.Text = "O" Then
            Label2.Text = "HAS GUANYAT!"
            AxWinsock1.SendData(99)
            bloquejar()
        End If
        If Button3.Text = "O" AndAlso Button5.Text = "O" AndAlso Button7.Text = "O" Then
            Label2.Text = "HAS GUANYAT!"
            AxWinsock1.SendData(99)
            bloquejar()
        End If
        If cont = 9 And (Label2.Text IsNot "HAS GUANYAT!" Or Label2.Text IsNot "Has perdut...") Then
            Label2.Text = "Empat"
            AxWinsock1.SendData(100)
            bloquejar()
        End If
    End Sub

End Class