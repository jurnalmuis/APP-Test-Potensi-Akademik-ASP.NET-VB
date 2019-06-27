Imports System.Data.SqlClient
Imports System.Data
Partial Class User_TestSoal2
    Inherits System.Web.UI.Page
    Dim iduser As String
    Dim jb As String
    Dim jwbA As String
    Dim cek As String
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString
   
    Public Class CountDownTimer
        Public TimeLeft As TimeSpan
        Private thread As System.Threading.Thread

        Public Sub New(ByVal original As TimeSpan)
            Me.TimeLeft = original
        End Sub

        Public Sub Start()
            thread = New System.Threading.Thread(Sub()

                                                     While True
                                                         System.Threading.Thread.Sleep(1000)
                                                         TimeLeft = TimeLeft.Subtract(TimeSpan.Parse("00:00:01"))
                                                     End While
                                                 End Sub)
            thread.Start()
        End Sub
    End Class
    Protected Sub Timer1_Tick(sender As Object, e As EventArgs)
        If Session("CountdownTimer") IsNot Nothing Then
            labeltime.Text = (CType(Session("CountdownTimer"), CountDownTimer)).TimeLeft.ToString()
        End If
    End Sub

    Sub carisesijawab()
        Dim idSoal As String
        Dim u As usr = Session("user-sesi")
        iduser = u.getid
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "SELECT id_user,id_soal,jawaban FROM TB_SimpanJawab WHERE id_soal='" & nomor.Text & "' AND id_user='" & iduser & "' "
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                idSoal = reader.GetString(1)
                jwbA = reader.GetString(2)
                If jwbA = "" Then
                    jwbA = "0"
                ElseIf jwbA = "A" Then
                    JawabA.Checked = True
                ElseIf jwbA = "B" Then
                    JawabB.Checked = True
                ElseIf jwbA = "C" Then
                    JawabC.Checked = True
                ElseIf jwbA = "D" Then
                    JawabD.Checked = True
                End If
            End If
            reader.Close()
        Catch ex As Exception
            statusupload.Text = "Error : " & ex.Message
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub
    Protected Sub uploadjawabab()
        Dim u As usr = Session("user-sesi")
        Dim benar As Int16
        Dim soal As Int16
        Dim scorenya As Int16
        Dim salah As Int16
        Dim keterangan As String
        iduser = u.getid
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sqlbenar As String = "Select COUNT('TB_Tes.id_soal, TB_Tes.kunci, TB_SimpanJawab.id_Soal, TB_SimpanJawab.id_User, TB_SimpanJawab.jawaban') From dbo.TB_Tes, dbo.TB_SimpanJawab WHERE TB_Tes.id_soal=TB_SimpanJawab.id_Soal AND TB_Tes.kunci=TB_SimpanJawab.jawaban AND TB_SimpanJawab.id_User='" & iduser & "'"
            Dim cmdbenar As SqlCommand = New SqlCommand(sqlbenar, cn)
            benar = cmdbenar.ExecuteScalar

            Dim sqlsoal As String = "Select count(status) FROM TB_Tes Where Status='AKTIF'"
            Dim cmdsoal As SqlCommand = New SqlCommand(sqlsoal, cn)
            soal = cmdsoal.ExecuteScalar

            Dim sqltimer As String = "Select nilailulus From TB_Ket"
            Dim cmdtimer As SqlCommand = New SqlCommand(sqltimer, cn)
            Dim nilailulus As String = cmdtimer.ExecuteScalar

            salah = (soal - benar)
            scorenya = (benar) * 10

            If scorenya >= nilailulus Then
                keterangan = "Lulus"
            Else
                keterangan = "Tidak Lulus"
            End If

            Dim sql As String = "Insert INTO TB_Nilai(id_user,benar,salah,score,keterangan) VALUES('" & iduser & "','" & benar & "','" & salah & "','" & scorenya & "','" & keterangan & "')"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            statusupload.Text = "Upload Berhasil Tunggu Beberapa Detik"
            If statusupload.Text = "Upload Berhasil Tunggu Beberapa Detik" Then
                Dim sqldel As String = "Delete from TB_SimpanJawab WHERE id_user='" & iduser & "' "
                Dim cmddel As SqlCommand = New SqlCommand(sqldel, cn)
                cmddel.ExecuteNonQuery()
            End If
        Catch ex As Exception
            statusupload.Text = "Data Error : " + ex.Message
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Session Countdown
        If Session("CountdownTimer") Is Nothing Then
            cn = New SqlConnection(cnsql)
            cn.Open()
            Dim sqltimer As String = "Select timedurasi From TB_Ket"
            Dim cmdtimer As SqlCommand = New SqlCommand(sqltimer, cn)
            Dim timernya As String = cmdtimer.ExecuteScalar

            Session("CountdownTimer") = New CountDownTimer(TimeSpan.Parse(timernya))
            CType(Session("CountdownTimer"), CountDownTimer).Start()

        End If
        'Untuk melakukan insert jawaban saat waktu habis
        If labeltime.Text = "00:00:00" Then
            uploadjawabab()
            Response.Redirect("LihatHasil.aspx")
        End If
        'mengecek session user
        If Session("user-sesi") Is Nothing Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If

        ''Mengambil Session user
        Dim u As usr = Session("user-sesi")
        welcm.InnerText = u.getusrid()
        ''cek user apakah sudah pernah mengerjakan

        If Not IsPostBack Then
            If Request.Params("id_Soal") <> "" Then
                nomor.Text = Request.Params("id_soal")
            Else
                'Response.Redirect("LihatSoal.aspx")
            End If
            cn = New SqlConnection(cnsql)
            Try
                cn.Open()
                'cek user apakah sudah mensubmit jawaban
                Dim sqlcek As String = "Select COUNT(*) From TB_Nilai WHERE id_User='" & u.getid & "'"
                Dim cmdcek As SqlCommand = New SqlCommand(sqlcek, cn)
                Dim benar As Int16
                benar = cmdcek.ExecuteScalar
                If benar = 1 Then
                    Response.Redirect("LihatHasil.aspx")
                Else
                    Dim sqlsoal As String = "SELECT id_soal,soal,a,b,c,d FROM TB_Tes WHERE id_soal='" & nomor.Text & "' "
                    Dim cmdsoal As SqlCommand = New SqlCommand(sqlsoal, cn)
                    Dim readersoal As SqlDataReader = cmdsoal.ExecuteReader
                    If readersoal.HasRows Then
                        readersoal.Read()
                        nomor.Text = readersoal.GetString(0)
                        SoalText.Text = readersoal.GetString(1)
                        JawabA.Text = readersoal.GetString(2)
                        JawabB.Text = readersoal.GetString(3)
                        JawabC.Text = readersoal.GetString(4)
                        JawabD.Text = readersoal.GetString(5)
                    Else
                        SoalText.Text = "Daa Tidak Ditemukan"
                    End If
                End If
            Catch ex As Exception
                'pesan.InnerHtml = "Error : " & ex.Message
            Finally
                cn.Close()
                cn = Nothing
            End Try
        End If
        carisesijawab()
    End Sub
    
    Protected Sub updatejawaban()
        Dim sql2 As String = "UPDATE TB_SimpanJawab SET jawaban='" & jb & "' WHERE id_user='" & iduser & "' AND id_soal='" & nomor.Text & "'"
        Dim cmd2 As SqlCommand = New SqlCommand(sql2, cn)
        cmd2.ExecuteNonQuery()
    End Sub
    Protected Sub inputjawaban()
        Dim sql1 As String = "Insert INTO TB_SimpanJawab(id_user,id_soal,jawaban) Values('" & iduser & "','" & nomor.Text & "','" & jb & "')"
        Dim cmd1 As SqlCommand = New SqlCommand(sql1, cn)
        cmd1.ExecuteNonQuery()
    End Sub
    Protected Sub JawabA_CheckedChanged(sender As Object, e As EventArgs) Handles JawabA.CheckedChanged
        Dim u As usr = Session("user-sesi")
        iduser = u.getid
        cn = New SqlConnection(cnsql)
        jb = "A"
        Try
            cn.Open()
            If JawabB.Checked = True Or JawabC.Checked = True Or JawabD.Checked = True Then
                updatejawaban()
            ElseIf JawabA.Checked = True Then
                inputjawaban()
            End If
        Catch ex As Exception

        Finally
            cn.Close()
            cn = Nothing
        End Try

    End Sub

    Protected Sub JawabB_CheckedChanged(sender As Object, e As EventArgs) Handles JawabB.CheckedChanged
        Dim u As usr = Session("user-sesi")
        iduser = u.getid
        cn = New SqlConnection(cnsql)
        jb = "B"
        Try
            cn.Open()
            If JawabA.Checked = True Or JawabC.Checked = True Or JawabD.Checked = True Then
                updatejawaban()
            ElseIf JawabB.Checked = True Then
                inputjawaban()
            End If

        Catch ex As Exception

        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Protected Sub JawabC_CheckedChanged(sender As Object, e As EventArgs) Handles JawabC.CheckedChanged
        Dim u As usr = Session("user-sesi")
        iduser = u.getid
        cn = New SqlConnection(cnsql)
        jb = "C"
        Try
            cn.Open()
            If JawabA.Checked = True Or JawabB.Checked = True Or JawabD.Checked = True Then
                updatejawaban()
            ElseIf JawabC.Checked = True Then
                inputjawaban()
            End If
        Catch ex As Exception

        Finally
            cn.Close()
            cn = Nothing
        End Try

    End Sub

    Protected Sub JawabD_CheckedChanged(sender As Object, e As EventArgs) Handles JawabD.CheckedChanged
        Dim u As usr = Session("user-sesi")
        iduser = u.getid
        cn = New SqlConnection(cnsql)
        jb = "D"
        Try
            cn.Open()
            If JawabA.Checked = True Or JawabC.Checked = True Or JawabB.Checked = True Then
                updatejawaban()
            ElseIf JawabD.Checked = True Then
                inputjawaban()
            End If
        Catch ex As Exception

        Finally
            cn.Close()
            cn = Nothing
        End Try

    End Sub

    Protected Sub btnSubJawaban_Click(sender As Object, e As EventArgs) Handles btnSubJawaban.Click
        uploadjawabab()
        Response.AddHeader("REFRESH", "1;URL=LihatHasil.aspx")
    End Sub
    Protected Sub no1_Click(sender As Object, e As EventArgs) Handles no1.Click
        Response.Redirect("TestSoal2.aspx?id_soal=1")
        'carisesijawab()
    End Sub

    Protected Sub no2_Click(sender As Object, e As EventArgs) Handles no2.Click
        Response.Redirect("TestSoal2.aspx?id_soal=2")
        'carisesijawab()
    End Sub

    Protected Sub no3_Click(sender As Object, e As EventArgs) Handles no3.Click
        Response.Redirect("TestSoal2.aspx?id_soal=3")
        'carisesijawab()
    End Sub
    Protected Sub no4_Click(sender As Object, e As EventArgs) Handles no4.Click
        Response.Redirect("TestSoal2.aspx?id_soal=4")
        'carisesijawab()
    End Sub
    
    Protected Sub no5_Click(sender As Object, e As EventArgs) Handles no5.Click
        Response.Redirect("TestSoal2.aspx?id_soal=5")
        'carisesijawab()
    End Sub

    Protected Sub no6_Click(sender As Object, e As EventArgs) Handles no6.Click
        Response.Redirect("TestSoal2.aspx?id_soal=6")
        'carisesijawab()
    End Sub

    Protected Sub no7_Click(sender As Object, e As EventArgs) Handles no7.Click
        Response.Redirect("TestSoal2.aspx?id_soal=7")
        'carisesijawab()
    End Sub

    Protected Sub no8_Click(sender As Object, e As EventArgs) Handles no8.Click
        Response.Redirect("TestSoal2.aspx?id_soal=8")
        'carisesijawab()
    End Sub

    Protected Sub no9_Click(sender As Object, e As EventArgs) Handles no9.Click
        Response.Redirect("TestSoal2.aspx?id_soal=9")
        'carisesijawab()
    End Sub

    Protected Sub no10_Click(sender As Object, e As EventArgs) Handles no10.Click
        Response.Redirect("TestSoal2.aspx?id_soal=10")
        'carisesijawab()
    End Sub

    'Protected Sub no11_Click(sender As Object, e As EventArgs) Handles no11.Click
    '    Response.Redirect("TestSoal2.aspx?id_soal=11")
    '    carisesijawab()
    'End Sub
    
End Class
