Imports System.IO


Friend Class ConversionHelper
    Function Base64File(ByVal file As Stream) As String
        Dim bytes As Byte()
        Using ms = New MemoryStream()
            Dim bytesRead As Integer
            Do
                Dim buf = New Byte(32767) {}
                bytesRead = file.Read(buf, 0, buf.Length)
                ms.Write(buf, 0, bytesRead)
            Loop While bytesRead > 0

            bytes = ms.ToArray()
        End Using

        Return Convert.ToBase64String(bytes)
    End Function
End Class
