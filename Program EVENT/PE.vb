Option Strict Off
Module PE
    Public Function bulan(tgl As String)
        Dim bln, romawi As String

        bln = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(tgl, 5), 2)
        romawi = ""
        Select Case bln
            Case "01"
                romawi = "I"
            Case "02"
                romawi = "II"
            Case "03"
                romawi = "III"
            Case "04"
                romawi = "IV"
            Case "05"
                romawi = "V"
            Case "06"
                romawi = "VI"
            Case "07"
                romawi = "VII"
            Case "08"
                romawi = "VIII"
            Case "09"
                romawi = "IX"
            Case "10"
                romawi = "X"
            Case "11"
                romawi = "XI"
            Case "12"
                romawi = "XII"
        End Select
        Return romawi
    End Function

    Public Sub HitungSaldo(idbank As Integer, debit As Double, kredit As Double, id As Double)
        Dim c, s As String
        Dim tbl As New DataTable
        Dim saldoawal As Double
        Dim saldonow As Double
        Dim cmd As New Odbc.OdbcCommand

        If idbank = 1 Then
            'Kas Tunai
            s = ""
            s = s & " select saldo from kas_tunai where idkastunai = '" & id - 1 & "'"
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds.Clear()
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)
            saldoawal = tbl.Rows(0)("saldo")
            saldonow = saldoawal - debit + kredit

            c = ""
            c = c & " update kas_tunai set saldo = '" & saldonow & "'"
            c = c & " where idkastunai='" & id & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            c = ""
            c = c & " update bank set saldo = '" & saldonow & "'"
            c = c & " where idbank='" & idbank & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

        End If
    End Sub

    Public Function replaceNewLine(ByVal selContent As String, ByVal isReplacingNewLineWithChar As Boolean,
                                   Optional ByVal selNewLineStringToUse As String = ".:.myCooLvbNewLine.:.") As String
        If isReplacingNewLineWithChar Then : Return selContent.Replace(vbNewLine, selNewLineStringToUse)
        Else : Return selContent.Replace(selNewLineStringToUse, vbNewLine)
        End If
    End Function
	Public Function monthDifference(ByVal startDate As DateTime, ByVal endDate As DateTime) As Integer
		Dim systemStartDate As DateTime = New DateTime()
		Dim timeDifference As TimeSpan

		If endDate > startDate Then
			timeDifference = endDate.Subtract(startDate)
		Else
			timeDifference = startDate.Subtract(endDate)
		End If

		Dim generatedDate As DateTime = systemStartDate.Add(timeDifference)
		Dim noOfYears As Integer = generatedDate.Year - 1
		Dim noOfMonths As Integer = generatedDate.Month - 1
		noOfMonths = noOfMonths + (noOfYears * 12)
		Return noOfMonths
	End Function
End Module
