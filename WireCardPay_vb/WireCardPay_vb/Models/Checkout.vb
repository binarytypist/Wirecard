Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Collections.Concurrent

'' WILD CARD PAY INDLUDE
'' CUSTOMER DETAIL 
'' ORDER DETAIL include order_State and orderLine class method'
'' FINGRERPRINT PROCEDURE INCLUDE MD5 data conversion for all available information 
'' CHECK OUT DETAIL
''

Namespace WireCardPay_vb
    Public Class Checkout
        'for fingure print data
        Private ReadOnly _autoAppendFingerprintOrder As Boolean = True
        Private ReadOnly _formValues As New NameValueCollection()
        Private ReadOnly _listOrder As New List(Of String)()
        Private ReadOnly _seed As New StringBuilder()

        Public Sub New(secret As String)
            Me._seed.Append(secret)
            Me._listOrder.Add("secret")
        End Sub

        Public Sub AddValue(name As String, value As String, Optional addToSeed As Boolean = True, Optional addToFormValues As Boolean = True)
            If addToSeed Then

                'include the all the 
                Me._seed.Append(value)
                Me._listOrder.Add(name)
            End If

            If addToFormValues Then
                Me._formValues.Add(name, value)
            End If
        End Sub

        Public Function GetFormValues() As NameValueCollection
            Return New NameValueCollection(Me._formValues)
        End Function

        'Public Shared Function GetMD5(key As String) As String
        '    Dim md = MD5.Create()
        '    ' Use input string to calculate MD5 hash
        '    Dim hash = md.ComputeHash(Encoding.UTF8.GetBytes(key))
        '    Return hash.Aggregate("", Function(current, b) current + b.ToString("x02"))
        'End Function

        Public Shared Function ByteToString(ByVal buff As Byte()) As String
            Dim sbinary As String = ""
            For i As Integer = 0 To buff.Length - 1
                sbinary += buff(i).ToString("x02")
            Next

            Return (sbinary)
        End Function


        Public Shared Function GenerateSHA512String(ByVal inputString As String, ByVal message As String) As String

            'Hmac sha 512 implementaton goes here.

            Dim getmessage As String = message
            Dim encoding As New System.Text.ASCIIEncoding()
            Dim getkeyByte As Byte() = encoding.GetBytes(inputString)
            Dim gethmacmd5 As New HMACMD5(getkeyByte)
            Dim gethmacsha512 As New HMACSHA512(getkeyByte)
            Dim getmessageBytes As Byte() = encoding.GetBytes(getmessage)
            Dim hashmessage As Byte() = gethmacmd5.ComputeHash(getmessageBytes)
            hashmessage = gethmacsha512.ComputeHash(getmessageBytes)
            Return ByteToString(hashmessage)

        End Function

        Public Function GetFingerPrint() As String
            ' Add security as new parameter to get finger print.
            Return GenerateSHA512String("DP4TMTPQQWFJW34647RM798E9A5X7E8ATP462Z4VGZK53YEJ3JWXS98B9P4F", Me._seed.ToString + GetFingerprintOrder().ToString())
        End Function

        ''old one 
        'Public Function EarlierGetFingerprint() As String
        '    'here all the value from the Getfingerprintorder is concantenation with seed.
        '    'the seed include all necessary information that contain orderid,customerid and secret.
        '    Return getshahHashMac(Me._seed.ToString() + GetFingerprintOrder().ToString())
        'End Function
        '
        'this funtion used to get all the listorder and make the unique order payment procedure  by contacting all the necessary input 
        ' 
        Public Function GetFingerprintOrder()
            Return String.Join(",", (If(Me._autoAppendFingerprintOrder, Me._listOrder.Concat(New String() {"requestFingerprintOrder"}), Me._listOrder)))
        End Function

        Public Sub New()
            Me._autoAppendFingerprintOrder = False

        End Sub
        Private Shared Function GetUrl(path As String) As String
            Return String.Format("{0}{1}", "https://213.23.209.110/", path)

        End Function

        ''for writing data on HTML'S form Post method
        Public Function GetFormData() As NameValueCollection

            '' for test mode there are two option
            '' 3-D Secure based  ->  .AddValue("shopId", "3D")  required.
            '' Non 3-D Secure based - > not used

            Dim b = New Checkout("DP4TMTPQQWFJW34647RM798E9A5X7E8ATP462Z4VGZK53YEJ3JWXS98B9P4F") ' provider by merchant and are unique
            b.AddValue("orderId", Guid.NewGuid().ToString)
            b.AddValue("customerId", "D200411") 'dummy data
            b.AddValue("shopId", "3d")
            b.AddValue("amount", "5000") 'dummy data
            b.AddValue("currency", "EUR")
            b.AddValue("paymenttype", "CCARD") 'Select one 
            b.AddValue("language", "de")
            b.AddValue("orderDescription", "Order description.")
            b.AddValue("displayText", "Thank you for your order.")
            b.AddValue("successURL", GetUrl("Home/Sucess.aspx"))
            b.AddValue("cancelURL", GetUrl("Home/Cancel.aspx"))
            b.AddValue("failureURL", GetUrl("Home/Failure.aspx"))
            b.AddValue("serviceURL", GetUrl("Home/Service.aspx"))
            b.AddValue("confirmURL", GetUrl("Home/Confirm.aspx"))
            b.AddValue("imageURL", GetUrl("/sites/website/images/common/logo.png"))
            b.AddValue("duplicateRequestCheck", "yes")
            Dim form = b.GetFormValues()
            form.Add("requestFingerprintOrder", b.GetFingerprintOrder())
            form.Add("requestFingerprint", b.GetFingerprint())
            Return form
        End Function

        Public Shared Sub RedirectWithData(availableData As NameValueCollection, url As String)
            Dim response As HttpResponse = HttpContext.Current.Response

            Dim str As New StringBuilder()
            str.Append("<html>")
            str.AppendFormat("<body onload='document.forms[""payForm""].submit()'>")
            str.AppendFormat("<form name='payForm' action='{0}' method='post'>", url)
            For Each key As String In availableData
                str.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", key, availableData(key))
            Next
            str.Append("</form></body></html>")
            response.Write(str.ToString())
            response.[End]()
        End Sub


    End Class
End Namespace
