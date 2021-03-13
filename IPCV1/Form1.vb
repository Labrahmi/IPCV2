Public Class IPMC2
    Dim parts(4) As String
    Dim positions(3) As Integer
    Dim startP(4) As Integer
    Dim endP(4) As Integer
    Dim cls As String
    Dim msk As String
    Dim adrr As String
    Dim adrf As String
    Dim plg As String
    Private Sub Guna2HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles Guna2HScrollBar1.Scroll
        Guna2HtmlLabel1.Text = Guna2HScrollBar1.Value
    End Sub

    Private Sub info_Click(sender As Object, e As EventArgs) Handles info.Click
        Dim lentb As Integer = Len(Guna2TextBox1.Text)          '' lenght of gunatextBox
        Dim x(4) As Integer                                     ''x variable for while
        Dim ind As Integer = 0                                  '' indice
        If Guna2TextBox1.Text <> "" And lentb > 6 Then
            For i = 0 To lentb - 1
                If Guna2TextBox1.Text.Chars(i) = "." Then
                    positions(ind) = i
                    ind += 1
                End If
            Next
            If ind = 3 Then
                parts(0) = Guna2TextBox1.Text.Substring(0, positions(0))
                parts(1) = Guna2TextBox1.Text.Substring(positions(0) + 1, positions(1) - positions(0) - 1)
                parts(2) = Guna2TextBox1.Text.Substring(positions(1) + 1, positions(2) - positions(1) - 1)
                parts(3) = Guna2TextBox1.Text.Substring(positions(2) + 1, lentb - positions(2) - 1)
                If IsNumeric(parts(0)) And IsNumeric(parts(1)) And IsNumeric(parts(2)) And IsNumeric(parts(3)) Then
                    If Val(parts(0)) >= 0 And parts(0) < 256 Then
                        If Val(parts(1)) >= 0 And parts(1) < 256 Then
                            If Val(parts(2)) >= 0 And parts(2) < 256 Then
                                If Val(parts(3)) >= 0 And parts(3) < 256 Then
                                    If parts(0) >= 0 And parts(0) < 128 Then
                                        cls = "A"
                                        msk = "255.0.0.0"
                                        adrr = parts(0) & ".0.0.0"
                                        adrf = parts(0) & ".255.255.255"
                                        plg = parts(0) & ".0.0.1  To  " & parts(0) & ".255.255.254"
                                    End If
                                    If parts(0) >= 128 And parts(0) < 192 Then
                                        cls = "B"
                                        msk = "255.255.0.0"
                                        adrr = parts(0) & "." & parts(1) & ".0.0"
                                        adrf = parts(0) & "." & parts(1) & ".255.255"
                                        plg = parts(0) & "." & parts(1) & ".0.0  To  " & parts(0) & "." & parts(1) & ".255.254"
                                    End If
                                    If parts(0) >= 192 And parts(0) < 224 Then
                                        cls = "C"
                                        msk = "255.255.255.0"
                                        adrr = parts(0) & "." & parts(1) & "." & parts(2) & ".0"
                                        adrf = parts(0) & "." & parts(1) & "." & parts(2) & ".255"
                                        plg = parts(0) & "." & parts(1) & "." & parts(2) & ".1  To  " & parts(0) & "." & parts(1) & "." & parts(2) & ".254"
                                    End If
                                    If parts(0) >= 224 And parts(0) < 240 Then
                                        cls = "D"
                                    End If
                                    If parts(0) >= 240 Then
                                        cls = "E"
                                    End If
                                    If parts(0) <> 0 Then
                                        If cls <> "E" And cls <> "D" Then
                                            TextBox2.Text = "----------" & vbNewLine
                                            TextBox2.Text += "IP Addresses : " & Guna2TextBox1.Text & vbNewLine
                                            TextBox2.Text += "Class : " & cls & vbNewLine
                                            TextBox2.Text += "Default Mask : " & msk & vbNewLine
                                            TextBox2.Text += "Adresse reseau : " & adrr & vbNewLine
                                            TextBox2.Text += "Plage : " & plg & vbNewLine
                                            TextBox2.Text += "----------"
                                        Else
                                            TextBox2.Text = "----------" & vbNewLine
                                            TextBox2.Text += "IP Addresses : " & Guna2TextBox1.Text & vbNewLine
                                            TextBox2.Text += "Class : " & cls & vbNewLine
                                            TextBox2.Text += "----------"
                                        End If
                                    Else
                                        TextBox2.Text = "From Wikipedia, the free encyclopedia. In the Internet Protocol Version 4, the address 0.0.0.0 is a non-routable meta-address used to designate an invalid, unknown or non-applicable target. This address is assigned specific meanings in a number of contexts, such as on clients or on servers."
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub subnet_Click(sender As Object, e As EventArgs) Handles subnet.Click

        Dim subadss(128) As Integer
        Dim nmsub As Integer = Val(Guna2HtmlLabel1.Text)
        Dim fn As Integer = 1
        Dim ln As Integer
        Dim tmp1 As Integer
        Dim tmp2 As Integer
        Dim submask As Integer
        Dim pat As Integer
        Dim pas As Integer = 0

        tmp1 = nmsub
        tmp2 = nmsub

        While nmsub <> -1
            If (2 ^ fn) >= tmp1 Then
                ln = (2 ^ fn)
                nmsub = -1
            Else
                fn += 1
            End If
        End While

        Select Case fn
            Case 1
                submask = 128
            Case 2
                submask = 192
            Case 3
                submask = 224
            Case 4
                submask = 240
            Case 5
                submask = 248
            Case 6
                submask = 252
            Case 7
                submask = 254
        End Select

        Select Case ln
            Case 2
                pat = 128
            Case 4
                pat = 64
            Case 8
                pat = 32
            Case 16
                pat = 16
            Case 32
                pat = 8
            Case 64
                pat = 4
            Case 128
                pat = 2
        End Select




        Dim lentb As Integer = Len(Guna2TextBox1.Text)          '' lenght of gunatextBox
        Dim x(4) As Integer                                     ''x variable for while
        Dim ind As Integer = 0                                  '' indice
        If Guna2TextBox1.Text <> "" And lentb > 6 Then
            For i = 0 To lentb - 1
                If Guna2TextBox1.Text.Chars(i) = "." Then
                    positions(ind) = i
                    ind += 1
                End If
            Next
            If ind = 3 Then
                parts(0) = Guna2TextBox1.Text.Substring(0, positions(0))
                parts(1) = Guna2TextBox1.Text.Substring(positions(0) + 1, positions(1) - positions(0) - 1)
                parts(2) = Guna2TextBox1.Text.Substring(positions(1) + 1, positions(2) - positions(1) - 1)
                parts(3) = Guna2TextBox1.Text.Substring(positions(2) + 1, lentb - positions(2) - 1)
                If IsNumeric(parts(0)) And IsNumeric(parts(1)) And IsNumeric(parts(2)) And IsNumeric(parts(3)) Then
                    If Val(parts(0)) > 0 And parts(0) < 256 Then
                        If Val(parts(1)) >= 0 And parts(1) < 256 Then
                            If Val(parts(2)) >= 0 And parts(2) < 256 Then
                                If Val(parts(3)) >= 0 And parts(3) < 256 Then
                                    If parts(0) > 0 And parts(0) < 128 Then
                                        cls = "A"
                                        adrr = parts(0) & ".0.0.0"
                                    End If
                                    If parts(0) >= 128 And parts(0) < 192 Then
                                        cls = "B"
                                        adrr = parts(0) & "." & parts(1) & ".0.0"
                                    End If
                                    If parts(0) >= 192 And parts(0) < 224 Then
                                        cls = "C"
                                        adrr = parts(0) & "." & parts(1) & "." & parts(2) & ".0"
                                    End If
                                    If parts(0) >= 224 And parts(0) < 240 Then
                                        cls = "D"
                                    End If
                                    If parts(0) >= 240 Then
                                        cls = "E"
                                    End If
                                    If cls <> "E" And cls <> "D" Then
                                        Select Case cls
                                            Case "A"
                                                TextBox1.Text = "----------" & vbNewLine
                                                TextBox1.Text += "Adresse reseau : " & adrr & vbNewLine
                                                TextBox1.Text += "Subnet Mask : " & "255." & submask & ".0.0 / " & (8 + fn) & vbNewLine
                                                TextBox1.Text += "----------" & vbNewLine
                                                While tmp2 > 0
                                                    TextBox1.Text += parts(0) & "." & pas & ".0.0" & vbNewLine
                                                    pas += pat
                                                    tmp2 -= 1
                                                End While
                                                TextBox1.Text += "----------"
                                            Case "B"
                                                TextBox1.Text = "----------" & vbNewLine
                                                TextBox1.Text += "Adresse reseau : " & adrr & vbNewLine
                                                TextBox1.Text += "Subnet Mask : " & "255.255." & submask & ".0 / " & (16 + fn) & vbNewLine
                                                TextBox1.Text += "----------" & vbNewLine
                                                While tmp2 > 0
                                                    TextBox1.Text += parts(0) & "." & parts(1) & "." & pas & ".0" & vbNewLine
                                                    pas += pat
                                                    tmp2 -= 1
                                                End While
                                                TextBox1.Text += "----------"
                                            Case "C"
                                                TextBox1.Text = "----------" & vbNewLine
                                                TextBox1.Text += "Adresse reseau : " & adrr & vbNewLine
                                                TextBox1.Text += "Subnet Mask : " & "255.255.255." & submask & " / " & (24 + fn) & vbNewLine
                                                TextBox1.Text += "----------" & vbNewLine
                                                While tmp2 > 0
                                                    TextBox1.Text += parts(0) & "." & parts(1) & "." & parts(2) & "." & pas & vbNewLine
                                                    pas += pat
                                                    tmp2 -= 1
                                                End While
                                                TextBox1.Text += "----------"
                                        End Select
                                    Else
                                        MessageBox.Show("Seules les classes A, B, C peuvent être 'subnetted'")
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub IPMC2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class
