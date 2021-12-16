Imports System.Data.Odbc
Module Conectionggvm
    Public conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public dt As DataTable
    Public dr As OdbcDataReader
    Public cmd As OdbcCommand
    Public str As String
    Public userid, Divisi As String
    Public tampilsurver, tampilSPGMaju, tampilALLMaju As String
    Public tampilIdPE, tampildetailpe, tampilIdMajuSPG, tampilIdMajuAll As String
    Public tampilLPJ, tampilIdMajuPRD, IdPOInterent As String
    Public tampilIDDetailDO, TampilIdCost As String
    Public ProsesCetak, CetakIdLPJ, CetakIdCost, CetakIdPE As String
    Public LevelUser, DivUser As Integer
    Public Usermenu, Fullname As String
    Public sql As String
    Public Sub GGVM_conn()
        'str = "Dsn=ggvmconn_lokal;server=localhost;uid=root;database=ggvm;port=3306"
        str = "DSN=ggvmconn;uid=root;password;toorGGVM;database=geogiven_vm;port=3306"
        conn = New OdbcConnection(str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Public Sub GGVM_conn_close()
        If conn.State = ConnectionState.Closed Then
            conn.Close()
            conn = Nothing
        End If
    End Sub

End Module
