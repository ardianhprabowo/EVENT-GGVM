Public Class CMD5
    Public Function computeHash(ByVal textToHash As String) As String
        Dim MD5 As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim Bytes() As Byte = MD5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(textToHash))
        Dim s As String = ""
        For Each by As Byte In Bytes
            ' s += by.ToString('x2')
            s = by.ToString("x2")
        Next
        Return s
    End Function

End Class
